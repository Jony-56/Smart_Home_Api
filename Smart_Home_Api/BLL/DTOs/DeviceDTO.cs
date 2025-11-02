using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceType Type { get; set; }     
        public DeviceStatus Status { get; set; }
        public int RoomId { get; set; }
    }
}
