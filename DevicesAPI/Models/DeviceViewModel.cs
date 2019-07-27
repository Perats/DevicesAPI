using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevicesAPI.Models
{
    public class DeviceViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
        public int DeviceId { get; set; }
    }
}