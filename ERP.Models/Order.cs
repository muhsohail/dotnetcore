using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Order
    {
        public Guid Id { get; set; }

        [DisplayName("Width (m)")]
        public decimal Width { get; set; }

        [DisplayName("Length (m)")]
        public decimal Length { get; set; }

        [DisplayName("Msh./ GSM")]
        public string GSM { get; set; }

        [DisplayName("Rtae/KGM/SM")]
        public double SM { get; set; }

        [DisplayName("Amount Each Piece")]
        public double AmountEachPiece { get; set; }
            
        [DisplayName("Cons.Pcs/ year")]
        public int ConsPcsYear { get; set; }


        [DisplayName("Cons.Amt/ year")]
        public int ConsAmtYear { get; set; }

        [DisplayName("Next Order.")]
        public int NextOrder { get; set; }
        
        [DisplayName("Next Order Amt.")]
        public int NextOrderCount { get; set; }

        public bool IsActive { get; set; }

        [DisplayName("Fabric")]
        [ForeignKey("Fabric")]
        public Guid? FabricId { get; set; }
        public Fabric Fabric { get; set; }


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
