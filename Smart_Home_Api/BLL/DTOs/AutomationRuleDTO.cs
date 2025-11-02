using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AutomationRuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Trigger { get; set; }
        public string Action { get; set; }
        public bool IsEnabled { get; set; }
    }
}
