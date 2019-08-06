using DevicesAPI.Models;
using FluentValidation;

namespace DevicesAPI.Validators
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(_ => _.FirstName).MinimumLength(3).MaximumLength(20);
            RuleFor(_ => _.LastName).MinimumLength(3).MaximumLength(20);
            RuleFor(_ => _.Device).NotNull();
        }
    }
}