using System.Threading.Tasks;
using DevFitness.Core.Interfaces.Repositories;
using DevFitness.Core.Interfaces.UnitOfWork;
using DevFitness.Infrastructure.Context;
using DevFitness.Infrastructure.Repositories;

namespace DevFitness.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUserRepository _userRepository;
        public DevFitnessDbContext Context;

        public UnitOfWork(DevFitnessDbContext context)
        {
            Context = context;
        }

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(Context);

        public async Task<bool> Commit()
        {
            return (await Context.SaveChangesAsync() >= 1);
        }
    }
}