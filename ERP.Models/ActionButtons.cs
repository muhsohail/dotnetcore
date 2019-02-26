using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class ActionButtons
    {
        public Guid Id { get; set; }
        public string ButtonText { get; set; }

        [DisplayName("Status")]
        [ForeignKey("Status")]
        public Guid? StatusId { get; set; }
        public Status Status { get; set; }
    }
}
