using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
    public interface IUserInterface
    {
        List<UserDomain> GetUsers();
        List<DeviceDomain> GetDevices(int userId);
        void AddNewDevice(DeviceDomain deviceDomain, int userId);
        void DeleteDevice(int userId, int deveceId);
    }
}
