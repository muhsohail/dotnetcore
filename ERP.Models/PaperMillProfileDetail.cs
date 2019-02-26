using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PaperMillProfileDetail
    {
        public Guid Id { get; set; }

        [DisplayName("Width (m)")]
        public decimal Width { get; set; }

        [DisplayName("Width (LN)")]
        public decimal Witln{ get; set; }

        [DisplayName("Length (m)")]
        public int Length { get; set; }

        [DisplayName("Msh./ GSM")]
        public string GSM { get; set; }

        [DisplayName("Rtae/KGM/SM")]
        public double SM { get; set; }

        [DisplayName("Amount Each Piece")]
        public double AmountEachPiece { get; set; }

        [DisplayName("Cons.Pcs/ year")]
        public int ConsPcsYear { get; set; }


        [DisplayName("Cons.Amt/ year")]
        public double ConsAmtYear { get; set; }

        [DisplayName("Next Order.")]
        public int NextOrder { get; set; }

        [DisplayName("Next Order Amt.")]
        public double? NextOrderCount { get; set; }

        public bool IsActive { get; set; }

        [DisplayName("Fabric")]
        [ForeignKey("Fabric")]
        public Guid? FabricId { get; set; }
        public Fabric Fabric { get; set; }

        [DisplayName("PaperMillProfile")]
        [ForeignKey("PaperMillProfile")]
        public Guid? PaperMillProfileId { get; set; }
        public PaperMillProfile PaperMillProfile { get; set; }
    }
}
