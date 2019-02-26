using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Entity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set;}
        public string CreatedBy { get; set; }
    }
}
