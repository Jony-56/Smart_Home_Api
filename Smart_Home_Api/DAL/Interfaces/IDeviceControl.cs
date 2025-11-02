using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDeviceControl
    {
        Device TurnOn(int id);
        Device TurnOff(int id);
        Device Toggle(int id);
    }
}
