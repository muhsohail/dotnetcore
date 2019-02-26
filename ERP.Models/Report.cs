using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Report
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
