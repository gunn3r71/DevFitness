using System.Threading.Tasks;
using DevFitness.Core.Entities;
using DevFitness.Core.Interfaces.Services.Base;

namespace DevFitness.Core.Interfaces.Services
{
    public interface IMealService : IService<Meal>
    {
        Task Delete(int id);
    }
}