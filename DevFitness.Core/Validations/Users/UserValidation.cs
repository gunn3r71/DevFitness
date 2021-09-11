using System;
using System.Data;
using DevFitness.Core.Entities;
using FluentValidation;

namespace DevFitness.Core.Validations.Users
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .Length(3, 100)
                .WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .LessThan(DateTime.UtcNow.Date)
                .WithMessage("The anniversary date must be less than the current date.")
                .GreaterThan(new DateTime(year: 1920, month: 01, day: 01))
                .WithMessage("The anniversary date must be greater than the current date.");
            RuleFor(x => x.Height)
                .NotEmpty()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .GreaterThan(0.00)
                .WithMessage("The {PropertyName} field must be greater than 0.");
            RuleFor(x => x.Weight)
                .NotEmpty()
                .WithMessage("The {PropertyName} field needs to be provided.")
                .GreaterThan(0.00)
                .WithMessage("The {PropertyName} field must be greater than 0.");
        }
    }
}