using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL.Conventions
{
    class DecimalConvention : Convention
    {
        public DecimalConvention()
        {
            this.Properties<Decimal>().
                Configure(p => p.HasPrecision(5, 4));


        }
    }
}
