using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UMSContext:DbContext
    {
        public UMSContext() : base("name=UMSContext")
        {
            Configuration.LazyLoadingEnabled = false;

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<EnergyLog> EnergyLogs { get; set; }
        public DbSet<AutomationRule> AutomationRules { get; set; }

    }
}
