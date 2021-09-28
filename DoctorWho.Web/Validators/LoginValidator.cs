using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(dto => dto.Username).NotNull().NotEmpty().WithMessage("Please enter a username");
            RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Please enter a password");
        }
    }
}