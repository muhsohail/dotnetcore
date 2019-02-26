using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Fabric
    {

        public Guid Id { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
        
        public bool IsActive { get; set; }

        [DisplayName("Fabric Type")]
        [ForeignKey("FabricType")]
        public Guid? FabricTypeId { get; set; }
        public FabricType FabricType { get; set; }

        [DisplayName("FabricCode")]
        [ForeignKey("FabricCode")]
        public Guid? FabricCodeId { get; set; }
        public FabricCode FabricCode { get; set; }
    }
}
