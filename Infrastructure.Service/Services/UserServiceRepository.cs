using Infrastructure.Interface.Interface;
using Infrastructure.Interface.Models;
using Infrastructure.Service.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Service.Services
{
    public class UserServiceRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserServiceRepository(MyContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
           return _context.Users.ToList();
        }
        public List<Device> GetDevices(int userId)
        {
            var devices = _context.Device.ToList();
            var res = devices.FindAll(_ => _.UserId == userId);
            return res;
        }
        public void AddNewDevice(Device device, int userId)
        {
            var user = _context.Users.FirstOrDefault(_ => _.Id == userId);
            if (user != null)
            {
                user.Device = new Device
                {
                    Type = device.Type,
                    Name = device.Name,
                    Number = device.Number,
                    UserId = user.Id
                };
            }
        }
        public void DeleteDevice(int userId, int deviceId)
        {
            //more deviceds for 1 user
            //var itemToDelete = _context.Device.Where(x => x.UserId == userId).Select(x => x).First();
            //devices.Remove(itemToDelete);
        }

        public User GetUser(int userId)
        {
            return _context.Users.FirstOrDefault(_ => _.Id == userId);
        }
    }
}
