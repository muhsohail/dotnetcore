using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class DailyStock : BaseEntity
    {
        public Guid Id { get; set; }

        [DisplayName("Date Received")]
        [DataType(DataType.Date)]
        public DateTime DateReceived { get; set; }

        [Required]
        [DisplayName("WT One Piece")]        
        public double WTOnePiece { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double Code { get; set; }

        [Required]
        [DisplayName("TTL WT")]        
        public double TTLWT { get; set; }

        [Required]
        [DisplayName("Asking Rate")]        
        public double AskingRate { get; set; }

        [Required]
        [DisplayName("Variance In Width")]        
        public string VarianceInWidth { get; set; }

        [Required]
        [DisplayName("Variance In Length")]        
        public string VarianceInLength { get; set; }

        [Required]
        [DisplayName("Variance In GSM")]        
        public string VarianceInGSM { get; set; }

        [Required]
        [DisplayName("Fabric")]
        [ForeignKey("Fabric")]
        public Guid? FabricId { get; set; }
        public Fabric Fabric { get; set; }

        [Required]
        [DisplayName("Mill")]
        [ForeignKey("Mill")]
        public Guid? MillId { get; set; }
        public Mill Mill { get; set; }


    }
}
