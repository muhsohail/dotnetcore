using System;

namespace Models
{
    public class FabricType
    {
        public Guid Id { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
