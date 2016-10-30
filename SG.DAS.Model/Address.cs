using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG.DAS.Model
{
    public class Address : Base
    {

        public string Street { get; set; }
        
        public string City { get; set; }

        public string Country { get; set; }
    }
}
