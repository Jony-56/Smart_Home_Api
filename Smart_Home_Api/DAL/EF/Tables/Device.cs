using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public enum DeviceType
    {
        Light,
        Thermostat,
        Plug,
        AC,
        SensorMotion
    }

    public enum DeviceStatus
    {
        Off = 0,
        On = 1
    }

    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DeviceType Type { get; set; }
        public DeviceStatus Status { get; set; }

        
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        
        public virtual ICollection<EnergyLog> EnergyLogs { get; set; }
    

     }
}
