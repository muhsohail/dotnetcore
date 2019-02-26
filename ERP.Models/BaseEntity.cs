using System.ComponentModel;

namespace Models
{
    public class BaseEntity: Entity
    {
        [DisplayName("Width (Meter)")]
        public decimal Width { get; set; }

        [DisplayName("Width (Inches)")]
        public decimal WidthInches { get; set; }

        [DisplayName("Length (Meter)")]
        public decimal Length { get; set; }

        [DisplayName("Msh./ GSM")]
        public string GSM { get; set; }

    }
}
