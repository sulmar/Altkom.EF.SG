namespace SG.DAS.DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public User()
        {
            Tasks = new HashSet<Task>();
            Tasks1 = new HashSet<Task>();
            Systems = new HashSet<System>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string Address_Street { get; set; }

        public string Address_City { get; set; }

        public string Address_Country { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Birthday { get; set; }

        public string Note { get; set; }

        public string Position { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public virtual ICollection<Task> Tasks1 { get; set; }

        public virtual ICollection<System> Systems { get; set; }
    }
}
