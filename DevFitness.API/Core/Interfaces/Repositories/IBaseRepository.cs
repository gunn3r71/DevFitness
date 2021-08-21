using System;
using System.Threading.Tasks;

namespace DevFitness.API.Core.Interfaces.Repositories
{
    public interface IBaseRepository : IDisposable
    {
        Task<int> SaveChangesAsync();
        Task Rollback();
    }
}