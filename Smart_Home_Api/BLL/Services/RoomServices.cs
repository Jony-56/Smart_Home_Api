using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class RoomServices
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomDTO>().ReverseMap();
                cfg.CreateMap<Device, DeviceDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

      

        // Get all rooms
        public static List<RoomDTO> GetAllRooms()
        {
            var data = DataAccessFactory.RoomData().GetAll();
            return GetMapper().Map<List<RoomDTO>>(data);
        }

        // Get room by ID
        public static RoomDTO GetRoom(int id)
        {
            var data = DataAccessFactory.RoomData().Get(id);
            return GetMapper().Map<RoomDTO>(data);
        }

        // Create new room
        public static RoomDTO Create(RoomDTO room)
        {
            var entity = GetMapper().Map<Room>(room);
            var created = DataAccessFactory.RoomData().Create(entity);
            return GetMapper().Map<RoomDTO>(created);
        }

        // Update existing room
        public static RoomDTO Update(RoomDTO room)
        {
            var entity = GetMapper().Map<Room>(room);
            var updated = DataAccessFactory.RoomData().Update(entity);
            return GetMapper().Map<RoomDTO>(updated);
        }

        // Delete room by ID
        public static RoomDTO Delete(int id)
        {
            var deleted = DataAccessFactory.RoomData().Delete(id);
            return GetMapper().Map<RoomDTO>(deleted);
        }

        // -------------------- Device Controls --------------------

        // Get all devices in a room
        public static List<DeviceDTO> GetDevices(int roomId)
        {
            var data = DataAccessFactory.RoomControlData().GetAllDevices(roomId);
            return GetMapper().Map<List<DeviceDTO>>(data);
        }

        // Turn ON all devices in a room
        public static List<DeviceDTO> TurnOnAll(int roomId)
        {
            var devices = DataAccessFactory.RoomControlData().TurnOnAll(roomId);

            foreach (var device in devices)
            {
                device.Status = DeviceStatus.On; 
                DataAccessFactory.DeviceData().Update(device); 
            }

            return GetMapper().Map<List<DeviceDTO>>(devices);
        }

        // Turn OFF all devices in a room
        public static List<DeviceDTO> TurnOffAll(int roomId)
        {
            var devices = DataAccessFactory.RoomControlData().TurnOffAll(roomId);

            foreach (var device in devices)
            {
                device.Status = DeviceStatus.Off;
                DataAccessFactory.DeviceData().Update(device);
            }

            return GetMapper().Map<List<DeviceDTO>>(devices);
        }

        // Turn ON a specific device in a room
        public static DeviceDTO TurnOnDevice(int roomId, int deviceId)
        {
            var devices = DataAccessFactory.RoomControlData().TurnOnDevice(roomId,deviceId);
           

            if (devices != null)
            {
                devices.Status = DeviceStatus.On;
                DataAccessFactory.DeviceData().Update(devices);
            }

            return GetMapper().Map<DeviceDTO>(devices);
        }

        // Turn OFF a specific device in a room
        public static DeviceDTO TurnOffDevice(int roomId, int deviceId)
        {
            var devices = DataAccessFactory.RoomControlData().TurnOffDevice(roomId, deviceId);


            if (devices != null)
            {
                devices.Status = DeviceStatus.Off;
                DataAccessFactory.DeviceData().Update(devices);
            }

            return GetMapper().Map<DeviceDTO>(devices);
        }
    }
}
