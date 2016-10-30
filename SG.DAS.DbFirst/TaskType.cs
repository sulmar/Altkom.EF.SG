namespace SG.DAS.DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaskType
    {
        public TaskType()
        {
            Tasks = new HashSet<Task>();
        }

        public int TaskTypeId { get; set; }

        [Required]
        [StringLength(2000)]
        public string TaskTypeName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
