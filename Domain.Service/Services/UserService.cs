using Domain.Interface;
using Domain.Models;
using Infrastructure.Interface.Interface;
using Infrastructure.Interface.Models;
using System.Collections.Generic;

namespace Domain.Service.Services
{
    public class UserService : IUserInterface
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository dataRepository)
        {
            _userRepository = dataRepository;
        }
        public List<UserDomain> GetUsers()
        {
            var users = _userRepository.GetUsers();
            var result = new List<UserDomain>();
            foreach (var item in users)
            {
                result.Add(new UserDomain
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Device = new DeviceDomain { }
                });
            }
            return result;
        }
        public List<DeviceDomain> GetDevices(int userId)
        {
            var devices = _userRepository.GetDevices(userId);
            var result = new List<DeviceDomain>();
            foreach (var item in devices)
            {
                result.Add(new DeviceDomain
                {
                    Name = item.Name,
                    Number = item.Number,
                    Type = item.Type,
                    UserId = item.UserId
                });
            }
            return result;
        }
        public void AddNewDevice(DeviceDomain deviceDomain, int userId)
        {
            var device = new Device
            {
                Name = deviceDomain.Name,
                Number = deviceDomain.Number,
                Type = deviceDomain.Type,
                UserId = deviceDomain.UserId
            };
            _userRepository.AddNewDevice(device, userId);
        }
        public void DeleteDevice(int userId, int deviceId)
        {
            _userRepository.DeleteDevice(userId, deviceId);
        }
    }
}
