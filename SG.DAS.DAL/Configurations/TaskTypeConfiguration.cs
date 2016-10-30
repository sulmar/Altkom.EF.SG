using SG.DAS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.DAL.Configurations
{
    class TaskTypeConfiguration : EntityTypeConfiguration<TaskType>
    {
        public TaskTypeConfiguration()
        {
            this.Property(p => p.TaskTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
