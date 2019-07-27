using DevicesAPI.Models;
using Domain.Models;
using Infrastructure.Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevicesAPI.App_Start
{
    public class MappintConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config => {
                config.CreateMap<UserDomain, UserViewModel>();
                config.CreateMap<User, UserDomain>();
                config.CreateMap<Device, DeviceDomain>();
                config.CreateMap<DeviceDomain, DeviceViewModel>();
            });
        }
    }
}