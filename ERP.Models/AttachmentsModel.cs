using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AttachmentsModel
    {
        public List<TempTransactionAttachmentDto> AttachmentsRecords { get; set; }
        public int TransactionId { get; set; }
        public bool CanUpload { get; set; }
        public bool CanDelete { get; set; }
        public bool CanDownload { get; set; }
    }

    public class TempTransactionAttachmentDto
    {
        public int Id { get; set; }
        public string SessionId { get; set; }

        public int? ApplicationTypeId { get; set; }

        public int? AttachmentTypeId { get; set; }

        public string FileName { get; set; }

        public string Path { get; set; }

        public DateTime? CreationDate { get; set; }

        public string AttachmentName { get; set; }

        public bool IsRequired { get; set; }

        public FileType? FileType { get; set; }

        public int? TransactionId { get; set; }

    }
}
