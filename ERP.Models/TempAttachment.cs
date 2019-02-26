using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TempAttachment
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string SessionId { get; set; }

        public int? ApplicationTypeId { get; set; }

        public int? AttachmentTypeId { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string Path { get; set; }

        public DateTime? CreationDate { get; set; }

        public int? TransactionId { get; set; }

        public FileType? FileType { get; set; }

        public Guid? StreamId { get; set; }
    }
}
