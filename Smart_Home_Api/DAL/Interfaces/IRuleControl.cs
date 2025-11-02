using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRuleControl
    {
        AutomationRule EnableRule(int id);
        AutomationRule DisableRule(int id);
    }
}
