using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    public class EnergyLogRepo : Repo, IRepo<EnergyLog, int, EnergyLog>,IEnergyLogControl
    {
        public EnergyLog Create(EnergyLog obj)
        {
            db.EnergyLogs.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public EnergyLog Update(EnergyLog obj)
        {
            var existing = db.EnergyLogs.Find(obj.Id);
            if (existing == null) return null;

            db.Entry(existing).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return existing;
        }

        public EnergyLog Delete(int id)
        {
            var data = db.EnergyLogs.Find(id);
            if (data != null)
            {
                db.EnergyLogs.Remove(data);
                db.SaveChanges();
            }
            return data;
        }

        public EnergyLog Get(int id)
        {
            return db.EnergyLogs.Find(id);
        }

        public List<EnergyLog> GetAll()
        {
            return db.EnergyLogs.ToList();
        }

        public List<EnergyLog> GetByDevice(int deviceId)
        {
            var data = (from log in db.EnergyLogs
                        where log.DeviceId == deviceId
                        select log).ToList();
            return data;
        }

        public List<EnergyLog> GetByRoom(int roomId)
        {
            var data = (from log in db.EnergyLogs
                        join dev in db.Devices on log.DeviceId equals dev.Id
                        where dev.RoomId == roomId
                        select log).ToList();
            return data;
        }
    }
}
