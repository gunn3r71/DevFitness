using AutoMapper;
using DevFitness.API.Models.users.InputModels;
using DevFitness.API.Models.users.ViewModels;
using DevFitness.Core.Entities;

namespace DevFitness.API.Profiles
{
    /// <summary>
    /// Mapper configuration
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// User mapping
        /// </summary>
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<AddUserInputModel, User>();
        }
    }
}
