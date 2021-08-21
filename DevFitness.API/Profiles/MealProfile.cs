using AutoMapper;
using DevFitness.API.Models.InputModels;
using DevFitness.API.Models.ViewModels;
using DevFitness.Core.Entities;

namespace DevFitness.API.Profiles
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealViewModel>();
            CreateMap<CreateMealInputModel, Meal>();
        }
    }
}
