using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.Model
{
    public class Audit
    {
        public int AuditId { get; set; }

        public string EntityName { get; set; }

        public string PropertyName { get; set; }

        public object OldValue { get; set; }

        public object NewValue { get; set; }

        public DateTime AuditDate { get; set; }
    }
}
