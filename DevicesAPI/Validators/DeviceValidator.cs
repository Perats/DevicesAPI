using DevicesAPI.Models;
using FluentValidation;

namespace DevicesAPI.Validators
{
    public class DeviceValidator : AbstractValidator<DeviceViewModel>
    {
        public DeviceValidator()
        {
            RuleFor(_ => _.Name).NotNull().MinimumLength(3).MaximumLength(20);
            RuleFor(_ => _.Type).NotNull().MinimumLength(1).MaximumLength(20);
            RuleFor(_ => _.DeviceId).NotNull();
            RuleFor(_ => _.UserId).NotNull();
            RuleFor(_ => _.Number).NotNull();
        }
    }
}