using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class TRANSACTION_TYPE
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TTP_TYPE_NAME_AR { get; set; }

        [Required]
        [StringLength(100)]
        public string TTP_TYPE_NAME_EN { get; set; }

        public int? TTP_DEFAULT_DURATION { get; set; }

        public bool? TTP_IS_DELETED { get; set; }

        public int? TTP_TRANSACTION_TYPE_FORM { get; set; }

        public string TTP_DELETE_COMMENT { get; set; }

        public bool? TTP_IS_PUBLISHED { get; set; }

        public bool? TTP_ALLOW_OTHER_ATTACHMENTS { get; set; }

        public bool? TTP_FORM_BUILDER_ACTIVE { get; set; }

        [StringLength(1000)]
        public string TTP_FORM_BUILDER_DLL_PATH { get; set; }

        [StringLength(500)]
        public string TTP_FORM_BUILDER_TABLE_NAME { get; set; }

        public decimal? TTP_PRICE { get; set; }

        [StringLength(150)]
        public string Schema_Code { get; set; }

        [StringLength(4000)]
        public string TTP_TYPE_DESC_EN { get; set; }

        [StringLength(4000)]
        public string TTP_TYPE_DESC_AR { get; set; }

        public int? TTP_TEMPLATE_ID { get; set; }

        public bool? TTP_NEED_CLIENT { get; set; }

        public int? TTP_CATEGORY_ID { get; set; }

        [StringLength(50)]
        public string TTP_SERVICE_CODE { get; set; }

        [StringLength(50)]
        public string TTP_SERVICE_TABLE_NAME { get; set; }

        [StringLength(150)]
        public string TTP_SERVICE_NAME { get; set; }

        public int? TTP_SERVICE_ID { get; set; }

        [ForeignKey("ATTACHMENT")]
        public int ATTACHMENT_ID { get; set; }
        public ATTACHMENT ATTACHMENT { get; set; }
    }
}
