using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevFitness.Core.Entities.Base;

namespace DevFitness.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T> : IDisposable
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);

        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);

        Task<int> SaveChangesAsync();
        Task RollBack();
    }
}