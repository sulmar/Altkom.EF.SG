using SG.DAS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL
{
    public partial class DASContext
    {

        public override int SaveChanges()
        {

            this.Audits.AddRange(GetAudits());

            return base.SaveChanges();
        }

        public IList<Audit> GetAudits()
        {
            IList<Audit> audits = new List<Audit>();

            var entities = ChangeTracker
              .Entries()
              .Where(x => x.Entity is User || x.Entity is SG.DAS.Model.Task)
              .Where
              (x => x.State == EntityState.Modified);

            foreach (var entity in entities)
            {
                var entityName = entity.Entity.GetType().Name;

                var properties = entity.CurrentValues.PropertyNames;

                foreach (var property in properties)
                {
                    var originalValue = entity.OriginalValues[property];
                    var currentValue = entity.CurrentValues[property];

                    if (
                        (originalValue != null && currentValue != null && !originalValue.Equals(currentValue))
                        || (originalValue == null && currentValue != null)
                        || (originalValue != null && currentValue == null)
                        )
                    {

                        audits.Add(new Audit
                        {
                            EntityName = entityName,
                            PropertyName = property,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            AuditDate = DateTime.Now,
                        });

                    }
                }

            }

            return audits;

        }
    }
}
