using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class TRANSACTION_ATTACHMENT
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string ATT_ATTACHMENT_NAME_AR { get; set; }

        [StringLength(150)]
        public string ATT_ATTACHMENT_NAME_EN { get; set; }

        public bool? ATT_ATTAHCMENT_MANDATORY { get; set; }

        public DateTime? TA_Creation_Date { get; set; }

        public string ATT_REF { get; set; }

        public bool ATT_UPLOADED { get; set; }

        public double? ATT_SIZE { get; set; }

        public int? ATT_VER_NO { get; set; }

        [ForeignKey("ATTACHMENT")]
        public int ATTACHMENT_ID { get; set; }
        public ATTACHMENT ATTACHMENT { get; set; }

        [ForeignKey("TRANSACTION")]
        public int TRANSACTION_ID { get; set; }
        public TRANSACTION TRANSACTION { get; set; }

    }
}
