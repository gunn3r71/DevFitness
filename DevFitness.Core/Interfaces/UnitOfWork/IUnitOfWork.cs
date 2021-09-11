using System.Threading.Tasks;
using DevFitness.Core.Interfaces.Repositories;

namespace DevFitness.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        Task<bool> Commit();
    }
}