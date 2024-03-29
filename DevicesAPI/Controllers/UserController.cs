﻿using DevicesAPI.Filters;
using DevicesAPI.Models;
using Domain.Interface;
using Domain.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace DevicesAPI.Controllers
{
    [Route("users")]
    public class UserController : ApiController
    {
        public readonly IUserInterface _userService;

        public UserController(IUserInterface userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("")]
        public List<UserViewModel> GetUsers()
        {
            var users = _userService.GetUsers();
            var res = new List<UserViewModel>();
            foreach (var item in users)
            {
                res.Add(new UserViewModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Device = new DeviceViewModel
                    {
                        Name = item.Device.Name,
                        Number = item.Device.Number,
                        Type = item.Device.Type,
                    }
                });
            }
            return res;
        }

        [HttpGet, Route("devices/{id:int}")]
        public List<DeviceViewModel> GetDevices(int deviceid)
        {
            var device = _userService.GetDevices(deviceid);
            if (device.Count == 0)
            {
                throw new HttpException(404, "Not found");
            }
            var result = new List<DeviceViewModel>();
            foreach (var item in device)
            {
                result.Add(AutoMapper.Mapper.Map<DeviceDomain, DeviceViewModel>(item));
                //result.Add(new DeviceViewModel
                //{
                //    Name = item.Name,
                //    Number = item.Number,
                //    UserId = item.UserId,
                //    Type= item.Type
                //});
            }
            return result;
        }

        [HttpPost, Route("devices/")]
        [ResponseType(typeof(DeviceViewModel))]
        public IHttpActionResult AddDevice(DeviceViewModel data, int userId)
        {
            if (data != null)
            {
                _userService.AddNewDevice(new DeviceDomain { Name = data.Name, Number = data.Number, Type = data.Type, UserId = userId }, userId);
                return Ok();
            }
            throw new HttpException(404, "Not found");
        }

        [HttpDelete, Route("devices/")]
        [ResponseType(typeof(DeviceViewModel))]
        [ActionName("Device")]
        public void Device_1(int deviceid, int userId)
        {
            _userService.DeleteDevice(deviceid, userId);
        }
    }
}
