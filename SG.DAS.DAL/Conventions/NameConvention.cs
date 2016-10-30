using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL.Conventions
{
    class NameConvention : Convention
    {
        public NameConvention()
        {
            this.Properties()
                .Where(p => p.Name.Contains("Name"))
                .Configure(p => p.IsRequired());
                
        }
    }
}
