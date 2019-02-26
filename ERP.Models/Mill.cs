using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Mill
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Editable(false)]
        public string Code { get; set; }

        public bool IsActive { get; set; }

        [DisplayName("MD")]
        [ForeignKey("Person")]
        [Required]
        public Guid? MDId { get; set; }
        public Person Person { get; set; }


        [Display(Name = "Manger")]
        [ForeignKey("MangerPerson")]
        [Required]
        public Guid? MangerId { get; set; }
        public Person MangerPerson { get; set; }


        [DisplayName("CPM")]
        [ForeignKey("CPMPerson")]
        [Required]
        public Guid? CPMId { get; set; }
        public Person CPMPerson { get; set; }


        [DisplayName("Mechanical")]
        [ForeignKey("MechanicalPerson")]
        [Required]
        public Guid? MechanicalId { get; set; }
        public Person MechanicalPerson { get; set; }

        [DisplayName("City")]
        [Required]

        [ForeignKey("City")]
        public Guid? CityId { get; set; }
        public City City { get; set; }
    }
}
