using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System.Collections.Generic;

namespace BLL.Services
{
    public class DeviceServices
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static List<DeviceDTO> GetAllDevices()
        {
            var data = DataAccessFactory.DeviceData().GetAll();
            return GetMapper().Map<List<DeviceDTO>>(data);
        }

        public static DeviceDTO GetDevice(int id)
        {
            var data = DataAccessFactory.DeviceData().Get(id);
            return GetMapper().Map<DeviceDTO>(data);
        }

        public static DeviceDTO Create(DeviceDTO dto)
        {
            var entity = GetMapper().Map<Device>(dto);
            var created = DataAccessFactory.DeviceData().Create(entity);
            return GetMapper().Map<DeviceDTO>(created);
        }

        public static DeviceDTO Update(DeviceDTO dto)
        {
            var entity = GetMapper().Map<Device>(dto);
            var updated = DataAccessFactory.DeviceData().Update(entity);
            return GetMapper().Map<DeviceDTO>(updated);
        }

        public static DeviceDTO Delete(int id)
        {
            var deleted = DataAccessFactory.DeviceData().Delete(id);
            return GetMapper().Map<DeviceDTO>(deleted);
        }


        public static DeviceDTO TurnOn(int id)
        {
            var device = DataAccessFactory.DeviceControlData().TurnOn(id);

            if (device == null)
                return null;

            device.Status = DeviceStatus.On;
            var updated = DataAccessFactory.DeviceData().Update(device);

            return GetMapper().Map<DeviceDTO>(updated);
        }

        public static DeviceDTO TurnOff(int id)
        {
            var device = DataAccessFactory.DeviceControlData().TurnOff(id);

            if (device == null)
                return null;

            device.Status = DeviceStatus.Off;
            var updated = DataAccessFactory.DeviceData().Update(device);

            return GetMapper().Map<DeviceDTO>(updated);
        }

        public static DeviceDTO Toggle(int id)
        {
            var device = DataAccessFactory.DeviceControlData().Toggle(id);
            if (device == null)
                return null;

            device.Status = (device.Status == DeviceStatus.On) ? DeviceStatus.Off : DeviceStatus.On;
            var updated = DataAccessFactory.DeviceData().Update(device);


            return GetMapper().Map<DeviceDTO>(device);
        }
    }
}
