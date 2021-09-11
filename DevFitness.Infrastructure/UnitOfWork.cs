using System.Threading.Tasks;
using DevFitness.Core.Interfaces.Repositories;
using DevFitness.Core.Interfaces.UnitOfWork;
using DevFitness.Infrastructure.Context;
using DevFitness.Infrastructure.Repositories;

namespace DevFitness.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DevFitnessDbContext _context;

        public UnitOfWork(DevFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return (await _context.SaveChangesAsync() >= 1);
        }

        public Task RollBack()
        {
            return Task.CompletedTask;
        }
    }
}