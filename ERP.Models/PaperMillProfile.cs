using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PaperMillProfile
    {
        public Guid Id { get; set; }

        [DataType(DataType.Currency)]
        public double? TotalAmount { get; set; }

        public double? TotalPCSCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double? TotalConsAmtPerYear { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Mill")]
        [ForeignKey("Mill")]
        public Guid? MillId { get; set; }
        public Mill Mill { get; set; }

        [DisplayName("Region")]
        [ForeignKey("Region")]
        public Guid? RegionId { get; set; }
        public Region Region { get; set; }
    }
}
