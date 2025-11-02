using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Room
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
