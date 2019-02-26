using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class City
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Code { get; set; }
        public bool IsActive { get; set; }

        [DisplayName("Region")]
        [ForeignKey("RegionId")]
        public Guid? RegionId { get; set; }
        public Region Region { get; set; }
    }
}
