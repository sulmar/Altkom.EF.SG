using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.Model
{
    public class AppSystem : Base
    {
        public int AppSystemId { get; set; }

        public string SystemName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
