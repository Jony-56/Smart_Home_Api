using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class AutomationRuleRepo : Repo, IRepo<AutomationRule, int, AutomationRule>, IRuleControl
    {
        public AutomationRule Create(AutomationRule obj)
        {
            db.AutomationRules.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public AutomationRule Update(AutomationRule obj)
        {
            var existing = db.AutomationRules.Find(obj.Id);
            if (existing == null) return null;

            db.Entry(existing).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return existing;
        }

        public AutomationRule Delete(int id)
        {
            var data = db.AutomationRules.Find(id);
            if (data != null)
            {
                db.AutomationRules.Remove(data);
                db.SaveChanges();
            }
            return data;
        }

        public AutomationRule Get(int id)
        {
            return db.AutomationRules.Find(id);
        }

        public List<AutomationRule> GetAll()
        {
            return db.AutomationRules.ToList();
        }

        public AutomationRule EnableRule(int id)
        {
            var rule = db.AutomationRules.Find(id);
            if (rule != null)
            {
                rule.IsEnabled = true;
                db.SaveChanges();
            }
            return rule;
        }

        public AutomationRule DisableRule(int id)
        {
            var rule = db.AutomationRules.Find(id);
            if (rule != null)
            {
                rule.IsEnabled = false;
                db.SaveChanges();
            }
            return rule;
        }
    }
}
