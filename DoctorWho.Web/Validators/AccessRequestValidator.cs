using DoctorWho.Db.Access;
using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class AccessRequestValidator : AbstractValidator<AccessForCreationRequestDto>
    {
        public AccessRequestValidator()
        {
            RuleFor(ar => ar.UserId).NotNull().NotEmpty();
            RuleFor(ar => ar.StartTime).NotNull();
            RuleFor(ar => ar.EndTime).NotNull();
            RuleFor(ar => ar.AccessLevel).NotNull().NotEqual(AccessLevel.Unknown);
            RuleFor(ar => ar.StartTime).LessThan(ar => ar.EndTime);
            
        }
    }
}