using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEnergyLogControl
    {
        List<EnergyLog> GetByDevice(int deviceId);
        List<EnergyLog> GetByRoom(int roomId);
    }
}
