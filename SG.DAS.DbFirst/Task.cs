namespace SG.DAS.DbFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public int TaskId { get; set; }

        [Required]
        [StringLength(2000)]
        public string TaskName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Deadline { get; set; }

        public int Status { get; set; }

        public string Note { get; set; }

        public int? Supervisor_UserId { get; set; }

        public int? System_SystemId { get; set; }

        public int? TaskType_TaskTypeId { get; set; }

        public int? User_UserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        public virtual System System { get; set; }

        public virtual TaskType TaskType { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
