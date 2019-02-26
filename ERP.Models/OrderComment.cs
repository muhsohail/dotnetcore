using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class OrderComment
    {
        public Guid Id { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDate { get; set; }
        public string CreatedBy { get; set; }

        [DisplayName("Status")]
        [ForeignKey("Status")]
        public Guid? StatusId { get; set; }
        public Status Status { get; set; }

        [DisplayName("ConsignmentOrder")]
        [ForeignKey("ConsignmentOrder")]
        public Guid? ConsignmentOrderId { get; set; }
        public ConsignmentOrder ConsignmentOrder { get; set; }
    }
}
