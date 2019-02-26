using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ERP.Controllers
{
    public class ERPHomeController : BaseController    
    {

        //public ActionResult AttachmentsParentView(string serviceCode, int transactionId = 0, bool canUpload = false, bool canDelete = false, bool canDownload = false)
        //{
        //    //AttachmentsModel model = BuildAttachmentsModel(serviceCode, transactionId);
        //    AttachmentsModel model = new AttachmentsModel();
        //    model.CanUpload = canUpload;
        //    model.CanDelete = canDelete;
        //    model.CanDownload = canDownload;

        //    return PartialView("~/Views/Shared/EditorTemplates/AttachmentsParentView.cshtml", model);
        //}

        [Route("/ERPHome/AttachmentsParentView", Name = "AttachmentsParentView")]
        public ActionResult AttachmentsParentView()
        {
            AttachmentsModel model = BuildAttachmentsModel(AttachmentModuleCodes.Order, 2);
            //AttachmentsModel model = new AttachmentsModel();
            model.CanUpload = true;
            model.CanDelete = true;
            model.CanDownload = true;

            return PartialView("~/Views/Shared/EditorTemplates/AttachmentsParentView.cshtml", model);
        }

        public AttachmentsModel BuildAttachmentsModel(AttachmentModuleCodes serviceCode, int transactionId)
        {
            // TODO - move this to AppService
            var transactionTypeId = 2;// GetTransactionTypeID(serviceCode);  //int transactionTypeId = 2;

            AttachmentsModel model = RequestForAttachments(transactionId, transactionTypeId);

            return model;
        }


        public AttachmentsModel RequestForAttachments(int transactionId, int transactionTypeId)
        {
            //string ApplicationSessionId = GetApplicationSession();

            //KeyValuePair<string, string>[] keyValues = new KeyValuePair<string, string>[3];
            //keyValues[0] = new KeyValuePair<string, string>("transactionType", transactionTypeId.ToString());
            //keyValues[1] = new KeyValuePair<string, string>("sessionId", ApplicationSessionId);
            //keyValues[2] = new KeyValuePair<string, string>("transactionId", transactionId.ToString());

            //var uploadedModel = _httpCallingAppService.GetAppServiceData<TempTransactionAttachmentsAppService,
            //    List<TempTransactionAttachmentDto>,
            //    APIResponseObject<List<TempTransactionAttachmentDto>>>("LoadTransactionTypeAttachments", new Dictionary<string, string>(), keyValues);

            //AttachmentsModel model = new AttachmentsModel();
            //model.AttachmentsRecords = new List<TempTransactionAttachmentDto>();
            //model.AttachmentsRecords = uploadedModel.Result;
            ////model.CanUpload = true;
            //return model;

            return null;
        }

        public ActionResult LoadAttachmentsView(AttachmentModuleCodes serviceCode, int transactionId = 0, bool canUpload = false, bool canDelete = false, bool canDownload = false)
        {
            //AttachmentsModel model = BuildAttachmentsModel(serviceCode, transactionId);

            AttachmentsModel model = new AttachmentsModel();
            model.CanUpload = canUpload;
            model.CanDelete = canDelete;
            model.CanDownload = canDownload;

            return PartialView("~/Views/Shared/EditorTemplates/AttachmentsView.cshtml", model);
        }

        public string PrepareAttachmentPath(string path, out FileType fileType)
        {
            fileType = FileType.NoPreview;
            if (string.IsNullOrEmpty(path))
            {
                return "";
            }
            #region Prepare Attachment path
            Regex r = new Regex(".jpg|.JPG|.jpeg|.JPEG|.TIFF|.tiff|.BMP|.bmp|.PNG|.png");
            fileType = r.IsMatch(path) ? FileType.Image :
              FileType.NoPreview;
            string extension = Path.GetExtension(path);
            string output = path;

            if (path.Contains("\\Images\\General"))
                output = path.Substring(path.IndexOf("\\Images\\General\\") + 16);

            output = output.Replace(@"\", @"/");
            path = @output;

            switch (extension.ToLower())
            {
                case ".pdf":
                    fileType = FileType.PDF;
                    break;
                case ".xls":
                case ".xlsx":
                    fileType = FileType.Excel;
                    break;
                case ".doc":
                case ".docx":
                    fileType = FileType.DOC;
                    break;
                case ".jpeg":
                case ".jpg":
                case ".tiff":
                case ".bmp":
                case ".png":
                    fileType = FileType.Image;
                    break;
                default:
                    fileType = FileType.NoPreview;
                    return path;
            }

            #endregion
            return path;
        }
        
    }
}