using SG.DAS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace SG.DAS.DAL.Configurations
{
    class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            this.Property(p => p.Deadline)
                .HasColumnType("date");


            this.Property(p => p.Timestamp)
                .IsRowVersion();

            this.MapToStoredProcedures();
        }
    }
}
