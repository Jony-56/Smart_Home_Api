using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EnergyLogDTO
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public decimal UsageKWh { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
