using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Room, int, Room> RoomData()
        {
            return new RoomRepo();
        }
        public static IRoomControl RoomControlData()
        {
            return new RoomRepo();
        }

        public static IRepo<Device, int, Device> DeviceData()
        {
            return new DeviceRepo();
        }
        public static IDeviceControl DeviceControlData()
        {
            return new DeviceRepo();
        }

        public static IRepo<AutomationRule, int, AutomationRule> AutomationRuleData()
        {
            return new AutomationRuleRepo();
        }
        public static IRuleControl AutomationRuleControlData()
        {
            return new AutomationRuleRepo();
        }

        public static IRepo<EnergyLog, int, EnergyLog> EnergyLogData()
        {
            return new EnergyLogRepo();
        }
        public static IEnergyLogControl EnergyLogControlControlData()
        {
            return new EnergyLogRepo();
        }
    }
}
