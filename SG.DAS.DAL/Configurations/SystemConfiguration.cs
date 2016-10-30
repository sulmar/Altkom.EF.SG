using SG.DAS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL.Configurations
{
    class SystemConfiguration : EntityTypeConfiguration<AppSystem>
    {
        public SystemConfiguration()
        {            

            this.Property(p => p.SystemName)
                .IsRequired();

        }
    }
}
