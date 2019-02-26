using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ConsignmentOrderItem
    {
        public Guid Id { get; set; }

        [DisplayName("Fabric Title")]
        public string FabricTitle { get; set; }

        [DisplayName("Width (m)")]
        public decimal Width { get; set; }

        [DisplayName("Length (m)")]
        public decimal Length { get; set; }

        [DisplayName("Msh./ GSM")]
        public string GSM { get; set; }

        [DisplayName("Qty J")]
        public int QtyJ { get; set; }

        [DisplayName("Qty IJ")]
        public int QtyIJ { get; set; }

        [DisplayName("Qty WMA")]
        public int QtyWMA { get; set; }

        [DisplayName("WT")]
        public int WT { get; set; }

        [DisplayName("Format Reference")]
        public string FormatReference { get; set; }

        [DisplayName("Single OR Double")]
        public string LayerType { get; set; }

        [DisplayName("Paper Type")]
        public string PaperType { get; set; }

        [DisplayName("Bar Code")]
        public string BarCode { get; set; }

        [DisplayName("Size")]
        public string Size { get; set; }

        [DisplayName("Fabric Tyoe")]
        public string FabricType { get; set; }

        [DisplayName("Remark (paper Type)")]
        public string Remarks { get; set; }

        public bool IsActive { get; set; }

        [DisplayName("Fabric")]
        [ForeignKey("Fabric")]
        public Guid? FabricId { get; set; }
        public Fabric Fabric { get; set; }

        [DisplayName("ConsignmentOrder")]
        [ForeignKey("ConsignmentOrder")]
        public Guid? ConsignmentOrderId { get; set; }
        public ConsignmentOrder ConsignmentOrder { get; set; }
    }
}
