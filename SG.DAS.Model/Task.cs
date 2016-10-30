using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.Model
{
    public class Task : Base
    {
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public TaskType TaskType { get; set; }

        public User User { get; set; }

        public User Supervisor { get; set; }

        public DateTime Deadline { get; set; }

        public TaskStatus Status { get; set; }

        public string Note { get; set; }

        public AppSystem System { get; set; }

        public DateTime CreateDate { get; set; }

        public byte[] Timestamp { get; set; }
    }
}
