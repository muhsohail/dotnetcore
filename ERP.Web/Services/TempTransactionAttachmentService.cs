using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Dto;
using Models;

namespace ERP.Services
{
    public class TempTransactionAttachmentService
    {
        ApplicationDbContext _context;
        public TempTransactionAttachmentService(ApplicationDbContext context)
        {
            _context = context;

        }

        public bool GetAttachmentsByTransactionId(int transactionId, string ApplicationSessionId)
        {
            bool res = false;
            return res;
        }

        public List<TempAttachment> LoadTransactionTypeAttachments(int transactionType, string sessionId = "", int transactionId = 0)
        {
            if (transactionId != 0)
            {
                List<TempAttachment> entityList = _context.TempAttachment.Where(x => x.TransactionId == transactionId).ToList();
                if (entityList != null)
                {
                    foreach (var item in entityList)
                    {
                        item.SessionId = sessionId;
                        
                        // Why we are updating
                        //Repository.Update(item);
                    }
                }
            }

            List<ATTACHMENT> attachmentList = new List<ATTACHMENT>();
            attachmentList = _context.ATTACHMENT.Where(x => x.TRANSACTION_TYPE_ID == transactionType).ToList();


            ///
            return null;

            //List<AttachmentDto> attachmentList = new List<AttachmentDto>();
            ////attachmentList = _attachmentService.GetAllAttachmentByTransactionType(transactionType);
            ////attachmentList = _context.Atatc

            //List<TempTransactionAttachmentDto> attachmentsViewModelList = new List<TempTransactionAttachmentDto>();
            //sessionId = sessionId.Replace("-", "");

            //List<TempTransactionAttachmentDto> tempAttachmentList = new List<TempTransactionAttachmentDto>();
            //tempAttachmentList = GetAllBySessionIdAndTransactionTypeId(sessionId, transactionType);


            //if (tempAttachmentList != null && tempAttachmentList.Count > 0)
            //{
            //    foreach (var item in tempAttachmentList)
            //    {
            //        FileType fileType;
            //        item.Path = PrepareAttachmentPath(item.Path, out fileType);
            //        attachmentsViewModelList.Add(new TempTransactionAttachmentDto
            //        {
            //            Id = item.AttachmentTypeId == null ? 0 : item.AttachmentTypeId.Value,
            //            AttachmentTypeId = item.AttachmentTypeId,
            //            AttachmentName = "",
            //            Path = item.Path,
            //            FileName = item.FileName,
            //            FileType = GetFileType(Path.Combine(item.Path, item.FileName)),
            //            ApplicationTypeId = transactionType

            //        });
            //    }
            //}
            ////Add all attchments for this application type
            //foreach (var attachment in attachmentList)
            //{
            //    if (!attachmentsViewModelList.Exists(x => x.Id == attachment.Id))
            //    {
            //        attachmentsViewModelList.Add(new TempTransactionAttachmentDto
            //        {
            //            Id = attachment.Id,
            //            AttachmentName = attachment.ATT_ATTACHMENT_NAME_EN,
            //            Path = "",
            //            FileName = "",
            //            FileType = FileType.Image,
            //            IsRequired = attachment.ATT_ATTAHCMENT_MANDATORY,
            //            ApplicationTypeId = attachment.TRANSACTION_TYPE_ID,
            //            AttachmentTypeId = attachment.ATTACH_TYPE_ID
            //        });
            //    }
            //    else
            //    {
            //        int index = attachmentsViewModelList.FindIndex(x => x.Id == attachment.Id);
            //        attachmentsViewModelList[index].AttachmentName = attachment.ATT_ATTACHMENT_NAME_EN;
            //        attachmentsViewModelList[index].IsRequired = attachment.ATT_ATTAHCMENT_MANDATORY;
            //    }
            //}
            //return attachmentsViewModelList.OrderBy(x => x.AttachmentName).ToList();

        }

        //public string PrepareAttachmentPath(string path, out FileType fileType)
        //{
        //    fileType = FileType.NoPreview;
        //    if (string.IsNullOrEmpty(path))
        //    {
        //        return "";
        //    }
        //    #region Prepare Attachment path
        //    Regex r = new Regex(".jpg|.JPG|.jpeg|.JPEG|.TIFF|.tiff|.BMP|.bmp|.PNG|.png");
        //    fileType = r.IsMatch(path) ? FileType.Image :
        //      FileType.NoPreview;
        //    string extension = Path.GetExtension(path);
        //    string output = path;

        //    if (path.Contains("\\Images\\General"))
        //        output = path.Substring(path.IndexOf("\\Images\\General\\") + 16);

        //    output = output.Replace(@"\", @"/");
        //    path = @output;

        //    switch (extension.ToLower())
        //    {
        //        case ".pdf":
        //            fileType = FileType.PDF;
        //            break;
        //        case ".xls":
        //        case ".xlsx":
        //            fileType = FileType.Excel;
        //            break;
        //        case ".doc":
        //        case ".docx":
        //            fileType = FileType.DOC;
        //            break;
        //        case ".jpeg":
        //        case ".jpg":
        //        case ".tiff":
        //        case ".bmp":
        //        case ".png":
        //            fileType = FileType.Image;
        //            break;


        //        default:
        //            fileType = FileType.NoPreview;
        //            return path;
        //    }
        //    #endregion
        //    return path;
        //}

        //public bool IsBlockedExtension(string path)
        //{
        //    bool blocked = true;
        //    if (string.IsNullOrEmpty(path))
        //    {
        //        return blocked = false;
        //    }

        //    string extension = Path.GetExtension(path);
        //    string blockedExtension = ".adp .app .asp .bas .ade .adp .app .asp .bas .bat .cer .chm .cmd .com ." +
        //                              "cpl .csh .dwg .exe .fxp .hlp .hta .inf .ins .isp .its .js .jse .ksh .mda " +
        //                              "mdb .mde .mdw .mdz .midst .msc .msi .msp .mst .ops";
        //    if (blockedExtension.Contains(extension.ToLower()))
        //    {
        //        blocked = true;
        //    }
        //    else
        //    {
        //        blocked = false;
        //    }


        //    return blocked;
        //}

        //public FileType GetFileType(string path)
        //{
        //    if (string.IsNullOrEmpty(path))
        //    {
        //        return FileType.NoPreview;
        //    }
        //    Regex r = new Regex(".jpg|.JPG|.jpeg|.JPEG|.TIFF|.tiff|.BMP|.bmp|.PNG|.png");
        //    FileType fileType = r.IsMatch(path) ? FileType.Image :
        //    FileType.NoPreview;
        //    string extension = Path.GetExtension(path);
        //    string output = path;

        //    if (path.Contains("\\Images\\General"))
        //        output = path.Substring(path.IndexOf("\\Images\\General\\") + 16);

        //    output = output.Replace(@"\", @"/");
        //    path = @output;

        //    switch (extension.ToLower())
        //    {
        //        case ".pdf":
        //            fileType = FileType.PDF;
        //            break;
        //        case ".xls":
        //        case ".xlsx":
        //            fileType = FileType.Excel;
        //            break;
        //        case ".doc":
        //        case ".docx":
        //            fileType = FileType.DOC;
        //            break;
        //        case ".jpeg":
        //        case ".jpg":
        //        case ".tiff":
        //        case ".bmp":
        //        case ".png":
        //            fileType = FileType.Image;
        //            break;
        //    }
        //    return fileType;
        //}
    }
}
