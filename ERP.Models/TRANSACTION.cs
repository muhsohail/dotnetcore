using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class TRANSACTION
    {
        public int Id { get; set; }

        public int TRANSACTION_STATUS_ID { get; set; }

        

        public int USER_ID { get; set; }

        public int? WORKFLOW_LEVEL_ID { get; set; }

        [Required]
        [StringLength(15)]
        public string TRA_TRANSACTION_BARCODE { get; set; }

        public DateTime TRA_TRANSACTION_CREATE_DATE { get; set; }

        public int? TRANSACTION_PARENT_ID { get; set; }

        public DateTime? TRA_TRANSACTION_SHIFT_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string TRA_REFERENCE_NUMBER { get; set; }

        [Required]
        [StringLength(300)]
        public string TRA_TRANSACTION_SUBJECT { get; set; }

        [StringLength(300)]
        public string TRA_TRANSACTION_CONTENT { get; set; }

        [StringLength(50)]
        public string TRA_TRANSACTION_INCOMING_NUMBER { get; set; }

        [StringLength(50)]
        public string TRA_TRANSACTION_OUTGOING_NUMBER { get; set; }

        [StringLength(50)]
        public string TRA_TRANSACTION_CONTRACT_NUMBER { get; set; }

        [StringLength(50)]
        public string TRA_TRANSACTION_PROJECT_NUMBER { get; set; }

        [StringLength(300)]
        public string TRA_TRANSACTION_PROJECT_NAME { get; set; }

        public int TRA_CONSIGNEE_ID { get; set; }

        public int? TRA_CONSIGNEE_GOV_COMP_ID { get; set; }

        [StringLength(50)]
        public string TRA_CONSIGNEE_NAME { get; set; }

        public bool? TRA_IS_COMPLETED { get; set; }

        public bool? TRA_IS_LAST_LEVEL { get; set; }

        public int? TRA_EXTENDED_VALUE_ID { get; set; }

        public bool? TRA_IS_PUBLISHED { get; set; }

        [StringLength(500)]
        public string TRA_Archivie_Path { get; set; }

        public int? TRA_IMPORTANCY_ID { get; set; }


        public int? REG_USER_ID { get; set; }

        public decimal? TRA_COST { get; set; }

        public int? TRA_PAYMENT_CHANNEL_ID { get; set; }

        public string DTS_CLIENT_USER_NAME { get; set; }

        public int? DTS_CLIENT_USER_ID { get; set; }

        public int? DTS_SPONSER_ID { get; set; }

        [StringLength(150)]
        public string WF_DOCUMENT_ID { get; set; }

        [StringLength(50)]
        public string DTS_REPRESENTATIVE_MOBILE { get; set; }

        [StringLength(100)]
        public string DTS_REPRESENTATIVE_EMAIL { get; set; }

        [StringLength(200)]
        public string DTS_REPRESENTATIVE_NAME { get; set; }

        [StringLength(150)]
        public string DTS_CLIENT_USER_Reference { get; set; }

        [StringLength(150)]
        public string DTS_CLIENT_Company_Reference { get; set; }

        [StringLength(200)]
        public string ASSIGNMENT_ID { get; set; }

        public bool? IsRead { get; set; }

        public int? DPW_LOGICAL_STATUS_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TRA_Expiry_Date { get; set; }

        [ForeignKey("TRANSACTION_ATTACHMENT")]
        public int TRANSACTION_ATTACHMENT_ID { get; set; }
        public TRANSACTION_ATTACHMENT TRANSACTION_ATTACHMENT { get; set; }

        [ForeignKey("TRANSACTION_TYPE")]
        public int TRANSACTION_TYPE_ID { get; set; }
        public TRANSACTION_TYPE TRANSACTION_TYPE { get; set; }
    }
}
