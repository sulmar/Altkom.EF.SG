using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.Model
{
    public class User : Base
    {        
        public User()
        {
            this.Address = new Address();
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public Address Address { get; set; }

        public DateTime Birthday { get; set; }

        public string Note { get; set; }

        public string Position { get; set; }

        public string FullName 
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public bool IsLogged { get; set; }

        public byte[] Photo { get; set; }

       


        public virtual ICollection<AppSystem> AppSystems { get; set; }
    }
}
