using Infrastructure.Interface.Models;
using System.Collections.Generic;

namespace Infrastructure.Interface.Interface
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        List<Device> GetDevices(int userId);
        void AddNewDevice(Device device, int userId);
        void DeleteDevice(int userId, int deviceId);
    }
}
