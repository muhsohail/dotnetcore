using System;
using System.Collections.Generic;

namespace Models
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int RegionNo { get; set; }

        public bool IsActive { get; set; }

        public List<City> Cities { get; set; }

    }
}
