namespace SG.DAS.DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class System
    {
        public System()
        {
            Tasks = new HashSet<Task>();
            Users = new HashSet<User>();
        }

        public int SystemId { get; set; }

        [Required]
        [StringLength(2000)]
        public string SystemName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
