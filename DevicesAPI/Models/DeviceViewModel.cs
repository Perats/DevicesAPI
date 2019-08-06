using DevicesAPI.Validators;
using FluentValidation.Attributes;

namespace DevicesAPI.Models
{
    [Validator(typeof(DeviceValidator))]
    public class DeviceViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
        public int DeviceId { get; set; }
    }
}