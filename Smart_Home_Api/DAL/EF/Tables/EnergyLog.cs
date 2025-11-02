using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class EnergyLog
    {
        public int Id { get; set; }

       
        public int DeviceId { get; set; }
       

        public decimal UsageKWh { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual Device Device { get; set; }
    }
}
