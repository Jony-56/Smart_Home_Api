using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repos
{
    public class RoomRepo : Repo, IRepo<Room, int, Room>, IRoomControl
    {

        public Room Create(Room obj)
        {
            db.Rooms.Add(obj);
            db.SaveChanges();   
            return obj;
        }

        public Room Delete(int id)
        {
            var data = db.Rooms.Find(id);
            if (data != null)
            {
                db.Rooms.Remove(data);
                db.SaveChanges();  
            }
            return data;
        }

        public Room Get(int id)
        {
            return db.Rooms.Find(id);
        }

        public List<Room> GetAll()
        {
            return db.Rooms.ToList();
        }

        public List<Device> GetAllDevices(int roomId)
        {
           var data = from d in db.Devices where d.RoomId == roomId select d;
            return data.ToList();
        }

        public List<Device> TurnOffAll(int roomId)
        {
            var data = from d in db.Devices where d.RoomId == roomId select d;
            return data.ToList();
        }

        public Device TurnOffDevice(int roomId, int DeviceId)
        {
            var device = (from d in db.Devices
                          where d.RoomId == roomId && d.Id == DeviceId
                          select d).FirstOrDefault();
            return device;
        }

        public List<Device> TurnOnAll(int roomId)
        {
            var data = from d in db.Devices where d.RoomId == roomId select d;
            return data.ToList();
        }

        public Device TurnOnDevice(int roomId, int DeviceId)
        {
            var device = (from d in db.Devices
                          where d.RoomId == roomId && d.Id == DeviceId
                          select d).FirstOrDefault();
            return device;
        }

        public Room Update(Room obj)
        {
            var existing = db.Rooms.Find(obj.ID);
            if (existing == null) return null;

            db.Entry(existing).CurrentValues.SetValues(obj); 
            db.SaveChanges(); 

            return existing;
        }

       
    }
}
