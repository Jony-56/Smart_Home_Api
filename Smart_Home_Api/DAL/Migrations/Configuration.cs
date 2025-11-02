namespace DAL.Migrations
{
    using DAL.EF.Tables;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.UMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.UMSContext context)
        {
            // ---------- Rooms ----------
            context.Rooms.AddOrUpdate(
                r => r.ID,  
                new Room { Name = "Living Room" },
                new Room { Name = "Bedroom" },
                new Room { Name = "Kitchen" },
                new Room { Name = "Office" }
            );
            context.SaveChanges();

            var livingRoomId = context.Rooms.First(r => r.Name == "Living Room").ID;
            var bedroomId = context.Rooms.First(r => r.Name == "Bedroom").ID;
            var kitchenId = context.Rooms.First(r => r.Name == "Kitchen").ID;
            var officeId = context.Rooms.First(r => r.Name == "Office").ID;

            // ---------- Devices ----------
            context.Devices.AddOrUpdate(
                d => d.Id,  
                new Device { Name = "Light 1", Type = DeviceType.Light, Status = DeviceStatus.Off, RoomId = livingRoomId },
                new Device { Name = "Light 2", Type = DeviceType.Light, Status = DeviceStatus.Off, RoomId = bedroomId },
                new Device { Name = "Fan", Type = DeviceType.Plug, Status = DeviceStatus.On, RoomId = bedroomId },
                new Device { Name = "AC", Type = DeviceType.AC, Status = DeviceStatus.Off, RoomId = bedroomId },
                new Device { Name = "Fridge", Type = DeviceType.Plug, Status = DeviceStatus.On, RoomId = kitchenId },
                new Device { Name = "PC", Type = DeviceType.Plug, Status = DeviceStatus.Off, RoomId = officeId }
            );
            context.SaveChanges();

            var light1Id = context.Devices.First(d => d.Name == "Light 1").Id;
            var light2Id = context.Devices.First(d => d.Name == "Light 2").Id;
            var fanId = context.Devices.First(d => d.Name == "Fan").Id;
            var acId = context.Devices.First(d => d.Name == "AC").Id;
            var fridgeId = context.Devices.First(d => d.Name == "Fridge").Id;
            var pcId = context.Devices.First(d => d.Name == "PC").Id;

            // ---------- Automation Rules ----------
            context.AutomationRules.AddOrUpdate(
                a => a.Id,  
                new AutomationRule
                {
                    Name = "Midnight Lights Off",
                    Trigger = "time:00:00",
                    Action = "turnoff type:Light",
                    IsEnabled = true
                },
                new AutomationRule
                {
                    Name = "AC Auto On",
                    Trigger = "temp>30",
                    Action = $"turnon device:{acId}",
                    IsEnabled = true
                },
                new AutomationRule
                {
                    Name = "Humidifier Auto On",
                    Trigger = "humidity<40",
                    Action = "turnon type:Humidifier",
                    IsEnabled = true
                },
                new AutomationRule
                {
                    Name = "PC Auto Shutdown",
                    Trigger = "time:23:00",
                    Action = $"turnoff device:{pcId}",
                    IsEnabled = true
                }
            );
            context.SaveChanges();

            // ---------- Energy Logs ----------
            context.EnergyLogs.AddOrUpdate(
                e => e.Id,  
                new EnergyLog { DeviceId = light1Id, UsageKWh = 0.5m, Timestamp = DateTime.Now.AddHours(-1) },
                new EnergyLog { DeviceId = light2Id, UsageKWh = 0.7m, Timestamp = DateTime.Now.AddHours(-2) },
                new EnergyLog { DeviceId = fanId, UsageKWh = 1.2m, Timestamp = DateTime.Now.AddHours(-3) },
                new EnergyLog { DeviceId = acId, UsageKWh = 3.5m, Timestamp = DateTime.Now.AddHours(-5) },
                new EnergyLog { DeviceId = fridgeId, UsageKWh = 2.1m, Timestamp = DateTime.Now.AddHours(-6) },
                new EnergyLog { DeviceId = pcId, UsageKWh = 1.8m, Timestamp = DateTime.Now.AddHours(-7) }
            );
            context.SaveChanges();
        }
    }
}
