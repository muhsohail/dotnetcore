using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ConsignmentOrder
    {
        public Guid Id { get; set; }

        public DateTime? OrderDate { get; set; }
        public string CreatedBy { get; set; }
        public string OrderComments { get; set; }
        public bool IsActive { get; set; }
        public string BarCode { get; set; }

        [DisplayName("Mill")]
        [ForeignKey("Mill")]
        public Guid? MillId { get; set; }
        public Mill Mill { get; set; }

        [DisplayName("Region")]
        [ForeignKey("Region")]
        public Guid? RegionId { get; set; }
        public Region Region { get; set; }

        [DisplayName("Status")]
        [ForeignKey("Status")]
        public Guid? StatusId { get; set; }
        public Status Status { get; set; }

        public List<ConsignmentOrderItem> ConsignmentOrderItems { get; set; }
    }
}
