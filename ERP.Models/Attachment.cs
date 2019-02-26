using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ATTACHMENT
    {
        public int Id { get; set; }        

        [Required]
        [StringLength(500)]
        public string ATT_ATTACHMENT_NAME_AR { get; set; }

        [Required]
        [StringLength(500)]
        public string ATT_ATTACHMENT_NAME_EN { get; set; }

        public bool ATT_ATTAHCMENT_MANDATORY { get; set; }

        public bool? ATT_IS_DISABLED { get; set; }

        public int? ATT_TYPE { get; set; }

        [ForeignKey("TRANSACTION_TYPE")]
        public int TRANSACTION_TYPE_ID { get; set; }
        public TRANSACTION_TYPE TRANSACTION_TYPE { get; set; }


        [ForeignKey("TRANSACTION_ATTACHMENT")]
        public int TRANSACTION_ATTACHMENT_ID { get; set; }
        public TRANSACTION_ATTACHMENT TRANSACTION_ATTACHMENT { get; set; }
    }
}
