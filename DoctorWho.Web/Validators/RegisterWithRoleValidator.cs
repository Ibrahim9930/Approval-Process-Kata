using System;
using System.Linq;
using DoctorWho.Db.Authentication;
using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class RegisterWithRoleValidator : AbstractValidator<RegisterWithRoleDto>
    {
        public RegisterWithRoleValidator()
        {
            RuleFor(dto => dto.Username).NotNull().NotEmpty().WithMessage("Please enter a valid username");
            RuleFor(dto => dto.Password).NotNull().NotEmpty().WithMessage("Please enter a password");
            RuleFor(dto => dto.Role).Must(role => Enum.GetNames<UserRoles>().Contains(role));
        }
    }
}