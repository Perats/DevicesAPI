using DevicesAPI.Validators;
using FluentValidation.Attributes;

namespace DevicesAPI.Models
{
    [Validator(typeof(UserValidator))]
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DeviceViewModel Device { get; set; }
    }
}