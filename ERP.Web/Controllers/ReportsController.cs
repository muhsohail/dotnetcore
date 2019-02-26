using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.EntityFramework;
using ERP.ViewModels.Reports;
using ERP.Web.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Controllers
{
    public class ReportsController : Controller
    {
        ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {

            //List<Report> reports = _context.Reports.Where(x =>x.IsActive).ToList();
            List<ReportsViewModel> viewModels = new List<ReportsViewModel>();
            ViewData["ReportsId"] = new SelectList(_context.Reports.Where(x => x.IsActive), "Id", "Title");
            return View("GenerateReportByFormingWire");
        }

        public ActionResult GenerateReportByFormingWire()
        {
            ViewData["ReportsId"] = new SelectList(_context.Reports.Where(x => x.IsActive), "Id", "Title");
            //List<FormingWireReportViewModel> viewModel = BuildFormingWireReportViewModel();
            ReportsViewModel model = new ReportsViewModel();
            return View(model);
        }

        public ActionResult GenerateReportByFormingWire1(Guid selectedReportId)
        {
            List<FormingWireReportViewModel> viewModel = new List<FormingWireReportViewModel>();
            ViewData["ReportsId"] = new SelectList(_context.Reports.Where(x => x.IsActive), "Id", "Title");

            Report report = _context.Reports.Where(x => x.Id == selectedReportId).FirstOrDefault();

            if (report.Title == "Fabrics Report By Forming Wire")
                viewModel = BuildFormingWireReportViewModel();
            else if (report.Title == "Fabrics Report By Felts")
                viewModel = BuildFeltReportViewModel();
            else if (report.Title == "Fabrics Report By Dryer Screen")
                viewModel = BuildDryerScreenReportViewModel();



            ReportsViewModel model = new ReportsViewModel();
            model.FormingWireReportViewModels = viewModel;

            model.PieChartModels = BuildPieChartModel(viewModel);
            model.PieChartByMillCode = BuildPieChartByMillCode(viewModel);
            model.PieChartByRegion = BuildPieChartByRegion(viewModel);

            return View("GenerateReportByFormingWire", model);
        }

        private List<PieChartModel> BuildPieChartByRegion(List<FormingWireReportViewModel> viewModel)
        {
            List<PieChartModel> formingWirePieChartModel = new List<PieChartModel>();
            formingWirePieChartModel = viewModel.GroupBy(x => x.Region)
                .Select(x => new PieChartModel
                {
                    FabricCode = x.Key,
                    Count = x.Count()
                }).ToList();

            return formingWirePieChartModel;
        }

        private List<PieChartModel> BuildPieChartByMillCode(List<FormingWireReportViewModel> viewModel)
        {
            List<PieChartModel> formingWirePieChartModel = new List<PieChartModel>();
            formingWirePieChartModel = viewModel.GroupBy(x => x.MillCode)
                .Select(x => new PieChartModel
                {
                    FabricCode = x.Key,
                    Count = x.Count()
                }).ToList();

            return formingWirePieChartModel;
        }

        private List<PieChartModel> BuildPieChartModel(List<FormingWireReportViewModel> viewModel)
        {
            List<PieChartModel> formingWirePieChartModel = new List<PieChartModel>();
            formingWirePieChartModel = viewModel.GroupBy(x => x.FabricType)
                .Select(x => new PieChartModel
                {
                    FabricCode = x.Key,
                    Count = x.Count()
                }).ToList();

            return formingWirePieChartModel;
        }

        private List<FormingWireReportViewModel> BuildFormingWireReportViewModel()
        {
            List<FormingWireReportViewModel> viewModel = new List<FormingWireReportViewModel>();
            Guid fabricCodeId = _context.FabricCodes.Where(x => x.Description.ToUpper() == "FORMING WIRE").FirstOrDefault().Id;

            List<Guid> fabricIds = _context.Fabrics.Where(x => x.FabricCodeId == fabricCodeId).Select(x => x.Id).ToList();

            List<PaperMillProfileDetail> PaperMillProfileDetails = _context.PaperMillProfileDetail
                .Include(x => x.Fabric)
                .Include(x => x.PaperMillProfile)
                .Include(x => x.PaperMillProfile.Mill)
                .Include(x => x.PaperMillProfile.Region)
                .Where(x => fabricIds.Contains(x.FabricId.Value))
                .ToList();

            foreach (PaperMillProfileDetail detail in PaperMillProfileDetails)
            {
                viewModel.Add(new FormingWireReportViewModel
                {

                    FabricType = detail.Fabric.Code,
                    GSM = detail.GSM,
                    Length = detail.Length,
                    MillCode = detail.PaperMillProfile.Mill.Code,
                    Width = detail.Width,
                    Region = detail.PaperMillProfile.Region.Name

                });

            }

            return viewModel;
        }

        private List<FormingWireReportViewModel> BuildFeltReportViewModel()
        {
            List<string> FeltReportCriteria = new List<string> { "PRESS FELT", "PICKUP-FELT", "MG FELT" };

            List<FormingWireReportViewModel> viewModel = new List<FormingWireReportViewModel>();
            List<Guid> formingWireIds = _context.Fabrics.Where(x => FeltReportCriteria.Contains(x.Description.ToUpper())).Select(x => x.Id).ToList();

            List<PaperMillProfileDetail> PaperMillProfileDetails = _context.PaperMillProfileDetail
                .Include(x => x.Fabric)
                .Include(x => x.PaperMillProfile)
                .Include(x => x.PaperMillProfile.Mill)
                .Include(x => x.PaperMillProfile.Region)
                .Where(x => formingWireIds.Contains(x.FabricId.Value)).ToList();

            foreach (PaperMillProfileDetail detail in PaperMillProfileDetails)
            {
                viewModel.Add(new FormingWireReportViewModel
                {

                    FabricType = detail.Fabric.Code,
                    GSM = detail.GSM,
                    Length = detail.Length,
                    MillCode = detail.PaperMillProfile.Mill.Code,
                    Width = detail.Width,
                    Region = detail.PaperMillProfile.Region.Name

                });

            }

            return viewModel;
        }

        private List<FormingWireReportViewModel> BuildDryerScreenReportViewModel()
        {
            List<FormingWireReportViewModel> viewModel = new List<FormingWireReportViewModel>();
            Guid formingWireId = _context.Fabrics.Where(x => x.Description.ToUpper() == "DRYER SCREEN").FirstOrDefault().Id;

            List<PaperMillProfileDetail> PaperMillProfileDetails = _context.PaperMillProfileDetail
                .Include(x => x.Fabric)
                .Include(x => x.PaperMillProfile)
                .Include(x => x.PaperMillProfile.Mill)
                .Include(x => x.PaperMillProfile.Region)
                .Where(x => x.FabricId == formingWireId).ToList();

            foreach (PaperMillProfileDetail detail in PaperMillProfileDetails)
            {
                viewModel.Add(new FormingWireReportViewModel
                {

                    FabricType = detail.Fabric.Code,
                    GSM = detail.GSM,
                    Length = detail.Length,
                    MillCode = detail.PaperMillProfile.Mill.Code,
                    Width = detail.Width,
                    Region = detail.PaperMillProfile.Region.Name

                });

            }

            return viewModel;
        }

        public ActionResult GenerateReportByFelts()
        {

            List<FormingWireReportViewModel> viewModel = BuildFeltReportViewModel();
            return View(viewModel);

        }

        public ActionResult ExportToExcel(Guid selectedReportId)
        {

            StringBuilder stringBuilder = new StringBuilder();
            List<FormingWireReportViewModel> model = new List<FormingWireReportViewModel>();

            ViewData["ReportsId"] = new SelectList(_context.Reports.Where(x => x.IsActive), "Id", "Title");

            Report report = _context.Reports.Where(x => x.Id == selectedReportId).FirstOrDefault();
            if (report.Title == "Fabrics Report By Forming Wire")
                model = BuildFormingWireReportViewModel();
            else if (report.Title == "Fabrics Report By Felts")
                model = BuildFeltReportViewModel();
            else if (report.Title == "Fabrics Report By Dryer Screen")
                model = BuildDryerScreenReportViewModel();

            stringBuilder.AppendLine("Report :  List of Fabrics ( FW,FLT and DS) by width \r\n");
            stringBuilder.AppendLine("Beneficiary  Department :\r\n");
            stringBuilder.AppendLine("Forming Wires\r\n");


            string[] headers = new string[] {

                "FabricType",
               " GSM",
                "Length",
                "MillCode",
                "Region",
                "Width",
                "",
                "",
                "",

               "FabricType",
               "GSM",
                "Length",
                "MillCode",
                "Region",
                "Width",
            };


            foreach (FormingWireReportViewModel viewModel in model)
            {
                List<string> reportData = new List<string>();
                reportData.Add(viewModel.FabricType);
                reportData.Add(viewModel.GSM);
                reportData.Add(viewModel.Length.ToString());
                reportData.Add(viewModel.MillCode);
                reportData.Add(viewModel.Region);
                reportData.Add(viewModel.Width.ToString());

                reportData.Add(string.Empty);
                reportData.Add(string.Empty);
                reportData.Add(string.Empty);

                //List<string> reportData = new List<string>();
                reportData.Add(viewModel.FabricType);
                reportData.Add(viewModel.GSM);
                reportData.Add(viewModel.Length.ToString());
                reportData.Add(viewModel.MillCode);
                reportData.Add(viewModel.Region);
                reportData.Add(viewModel.Width.ToString());


                stringBuilder.AppendLine(string.Join(",", reportData));
            }

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", headers)}\r\n{stringBuilder.ToString()}");
            return File(buffer, "text/csv", string.Format("${0}.csv",report.Title));
        }
    }
}