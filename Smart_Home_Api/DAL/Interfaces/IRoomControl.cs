using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRoomControl
    {
        List<Device> GetAllDevices(int roomId);
        List<Device> TurnOnAll(int roomId);
        List<Device> TurnOffAll(int roomId);

        Device TurnOnDevice(int roomId, int DeviceId);
        Device TurnOffDevice(int roomId, int DeviceId);

    }
}
