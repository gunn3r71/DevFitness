using System.Collections.Generic;
using System.Threading.Tasks;
using DevFitness.Core.Entities.Base;

namespace DevFitness.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task Add(T entity);
        Task Update(T entity);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
    }
}