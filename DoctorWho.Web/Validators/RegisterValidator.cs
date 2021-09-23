using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(dto => dto.Username).NotNull().NotEmpty().WithMessage("Please enter a valid username");
            RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Please enter a password");
        }
    }
}