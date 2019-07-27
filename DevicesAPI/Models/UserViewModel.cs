﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevicesAPI.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DeviceViewModel Device { get; set; }
    }
}