using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FabricCode
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
