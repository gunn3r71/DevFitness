using System.Threading.Tasks;
using DevFitness.Core.Entities;
using DevFitness.Core.Interfaces.Services.Base;

namespace DevFitness.Core.Interfaces.Services
{
    public interface IUserService : IService<User>
    {
        Task DisableUser(int id);
        Task EnableUser(int id);
    }
}