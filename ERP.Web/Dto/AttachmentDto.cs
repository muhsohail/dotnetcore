using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Dto
{
    public class AttachmentDto
    {
        public int TRANSACTION_TYPE_ID { get; set; }

        public string ATT_ATTACHMENT_NAME_AR { get; set; }

        public string ATT_ATTACHMENT_NAME_EN { get; set; }

        public bool ATT_ATTAHCMENT_MANDATORY { get; set; }

        public bool? ATT_IS_DISABLED { get; set; }

        public int? ATT_TYPE { get; set; }

        public int? ATTACH_TYPE_ID { get; set; }
    }
}
