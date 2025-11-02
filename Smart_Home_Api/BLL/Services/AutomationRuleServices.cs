using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class AutomationRuleServices
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AutomationRule, AutomationRuleDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        
        public static List<AutomationRuleDTO> GetAllRules()
        {
            var data = DataAccessFactory.AutomationRuleData().GetAll();
            return GetMapper().Map<List<AutomationRuleDTO>>(data);
        }

        public static AutomationRuleDTO GetRule(int id)
        {
            var data = DataAccessFactory.AutomationRuleData().Get(id);
            return GetMapper().Map<AutomationRuleDTO>(data);
        }

        public static AutomationRuleDTO Create(AutomationRuleDTO dto)
        {
            var entity = GetMapper().Map<AutomationRule>(dto);
            var created = DataAccessFactory.AutomationRuleData().Create(entity);
            return GetMapper().Map<AutomationRuleDTO>(created);
        }

        public static AutomationRuleDTO Update(AutomationRuleDTO dto)
        {
            var entity = GetMapper().Map<AutomationRule>(dto);
            var updated = DataAccessFactory.AutomationRuleData().Update(entity);
            return GetMapper().Map<AutomationRuleDTO>(updated);
        }
        public static AutomationRuleDTO Delete(int id)
        {
            var deleted = DataAccessFactory.AutomationRuleData().Delete(id);
            return GetMapper().Map<AutomationRuleDTO>(deleted);
        }

        public static AutomationRuleDTO EnableRule(int id)
        {
            var rule = DataAccessFactory.AutomationRuleControlData().EnableRule(id);
            return GetMapper().Map<AutomationRuleDTO>(rule);
        }

        public static AutomationRuleDTO DisableRule(int id)
        {
            var rule = DataAccessFactory.AutomationRuleControlData().DisableRule(id);
            return GetMapper().Map<AutomationRuleDTO>(rule);
        }

        

        // Temperature
        public static string EvaluateTempRule(double currentTemp, int deviceId)
        {
            var device = DataAccessFactory.DeviceData().Get(deviceId);
            if (device == null)
                return $" Device not found (Id: {deviceId})";

            if (device.Type != DeviceType.AC)
                return $" Device {deviceId} is not an AC (Type = {device.Type})";

            if (currentTemp > 30)
            {
                DeviceServices.TurnOn(deviceId);
                return $" AC (Device {deviceId}) turned ON because Temp = {currentTemp}°C";
            }

            if (currentTemp < 25)
            {
                DeviceServices.TurnOff(deviceId);
                return $" AC (Device {deviceId}) turned OFF because Temp = {currentTemp}°C";
            }

            return $" Condition not met (Temp = {currentTemp}°C)";
        }

        //  Humidity 
        public static string EvaluateHumidityRule(double currentHumidity, int deviceId)
        {
            var device = DataAccessFactory.DeviceData().Get(deviceId);
            if (device == null)
                return $" Device not found (Id: {deviceId})";

            if (device.Type != DeviceType.Plug)
                return $" Device {deviceId} is not a Humidifier (Type = {device.Type})";

            if (currentHumidity < 40)
            {
                DeviceServices.TurnOn(deviceId);
                return $" Humidifier (Device {deviceId}) turned ON because Humidity = {currentHumidity}%";
            }

            if (currentHumidity > 60)
            {
                DeviceServices.TurnOff(deviceId);
                return $" Humidifier (Device {deviceId}) turned OFF because Humidity = {currentHumidity}%";
            }

            return $" Condition not met (Humidity = {currentHumidity}%)";
        }

        
        public static string EvaluateTimeRule(DateTime currentTime, string type, int deviceId)
        {
            var device = DataAccessFactory.DeviceData().Get(deviceId);
            if (device == null)
                return $"❌ Device not found (Id: {deviceId})";

            if (device.Type != DeviceType.Light)
                return $"❌ Device {deviceId} is not a Light (Type = {device.Type})";

            string time = currentTime.ToString("HH:mm");

            
            TimeSpan now = currentTime.TimeOfDay;
            TimeSpan offTime = new TimeSpan(0, 0, 0);   
            TimeSpan onTime = new TimeSpan(6, 0, 0);   

            
            if (now >= offTime && now < onTime)
            {
                DeviceServices.TurnOff(deviceId);
                return $"Light (Device {deviceId}) turned OFF (Night time: {time})";
            }

            if (now >= onTime && now < new TimeSpan(23, 59, 59))
            {
                DeviceServices.TurnOn(deviceId);
                return $" Light (Device {deviceId}) turned ON (Day time: {time})";
            }

            return $"Condition not met (Time = {time})";
        }

    }
}
