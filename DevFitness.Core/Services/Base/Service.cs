using DevFitness.Core.Entities.Base;
using FluentValidation;

namespace DevFitness.Core.Services.Base
{
    public abstract class Service
    {
        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            return false;
        }
    }
}