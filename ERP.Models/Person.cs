using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Primary Phone")]
        [Required]
        public string PrimaryPhone { get; set; }

        [DisplayName("Secondary Phone")]
        [Required]
        public string SecondaryPhone { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }
    }
}
