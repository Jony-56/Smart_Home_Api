using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class EnergyLogServices
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EnergyLog, EnergyLogDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        // Get all logs
        public static List<EnergyLogDTO> GetAllLogs()
        {
            var data = DataAccessFactory.EnergyLogData().GetAll();
            return GetMapper().Map<List<EnergyLogDTO>>(data);
        }

        // Get log by ID
        public static EnergyLogDTO GetLog(int id)
        {
            var data = DataAccessFactory.EnergyLogData().Get(id);
            return GetMapper().Map<EnergyLogDTO>(data);
        }

        // Create new log
        public static EnergyLogDTO Create(EnergyLogDTO dto)
        {
            var entity = GetMapper().Map<EnergyLog>(dto);
            var created = DataAccessFactory.EnergyLogData().Create(entity);
            return GetMapper().Map<EnergyLogDTO>(created);
        }

        // Update log
        public static EnergyLogDTO Update(EnergyLogDTO dto)
        {
            var entity = GetMapper().Map<EnergyLog>(dto);
            var updated = DataAccessFactory.EnergyLogData().Update(entity);
            return GetMapper().Map<EnergyLogDTO>(updated);
        }

        // Delete log
        public static EnergyLogDTO Delete(int id)
        {
            var deleted = DataAccessFactory.EnergyLogData().Delete(id);
            return GetMapper().Map<EnergyLogDTO>(deleted);
        }

        
        public static double GetTotalByDevice(int deviceId, DateTime start, DateTime end)
        {
            var logs = DataAccessFactory.EnergyLogControlControlData().GetByDevice(deviceId);
            var total = (from l in logs
                         where l.Timestamp >= start && l.Timestamp <= end
                         select (double)l.UsageKWh).Sum();  
            return total;
        }

        public static double GetTotalByRoom(int roomId, DateTime start, DateTime end)
        {
            var logs = DataAccessFactory.EnergyLogControlControlData().GetByRoom(roomId);
            var total = (from l in logs
                         where l.Timestamp >= start && l.Timestamp <= end
                         select (double)l.UsageKWh).Sum();  
            return total;
        }

       

    }
}
