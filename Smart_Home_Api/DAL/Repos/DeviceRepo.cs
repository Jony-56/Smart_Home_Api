using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    public class DeviceRepo : Repo, IRepo<Device, int, Device>, IDeviceControl
    {
        public Device Create(Device obj)
        {
            db.Devices.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public Device Update(Device obj)
        {
            var existing = db.Devices.Find(obj.Id);
            if (existing == null) return null;

            db.Entry(existing).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return existing;
        }

        public Device Delete(int id)
        {
            var data = db.Devices.Find(id);
            if (data != null)
            {
                db.Devices.Remove(data);
                db.SaveChanges();
            }
            return data;
        }

        public Device Get(int id)
        {
            return db.Devices.Find(id);
        }

        public List<Device> GetAll()
        {
            return db.Devices.ToList();
        }

        
        public Device TurnOn(int id)
        {
            var data = db.Devices.Find(id);
           
            return data;
        }

        public Device TurnOff(int id)
        {
            var data = db.Devices.Find(id);
            
            return data;
        }

        public Device Toggle(int id)
        {
            var data = db.Devices.Find(id);
           
            return data;
        }
    }
}
