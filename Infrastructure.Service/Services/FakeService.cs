using Infrastructure.Interface.Interface;
using Infrastructure.Interface.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Service.Services
{
    public class FakeService : IUserRepository
    {
        List<User> users = new List<User>()
        {
            new User { Id = 1, FirstName= "first1", LastName = "Last1", Device = new Device() },
            new User { Id = 2, FirstName= "first2", LastName = "Last2", Device = new Device() },
            new User { Id = 3, FirstName= "first3", LastName = "Last3", Device = new Device() },
            new User { Id = 4, FirstName= "first4", LastName = "Last4", Device = new Device() }
        };
        List<Device> devices = new List<Device>()
        {
            new Device { Name = "dev1", Number = 1, Type ="type1", UserId = 1 },
            new Device { Name = "dev2", Number = 2, Type ="type2", UserId = 2 },
            new Device { Name = "dev3", Number = 3, Type ="type3", UserId = 3 },
            new Device { Name = "dev4", Number = 4, Type ="type4", UserId = 4 }
        };

        public List<User> GetUsers()
        {
            return users;
        }
        public List<Device> GetDevices(int userId)
        {
            var res = devices.FindAll(_ => _.UserId == userId);
            return res;
        }
        public void AddNewDevice(Device device, int userId)
        {
            var user = users.FirstOrDefault(_ => _.Id == userId);
            if (user != null) user.Device = new Device
            {
                Type = device.Type,
                Name = device.Name,
                Number = device.Number,
                UserId = user.Id
            };
        }
        public void DeleteDevice(int userId, int deviceId)
        {
           //more deviceds for 1 user
            var itemToDelete = devices.Where(x => x.UserId == userId).Select(x => x).First();
            devices.Remove(itemToDelete);
        }

    }
}
