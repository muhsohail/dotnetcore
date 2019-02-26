using System;
using System.Collections.Generic;
using ERP.Web.ViewModels.Reports;

namespace ERP.ViewModels.Reports
{
    public class ReportsViewModel
    {
        public ReportsViewModel()
        {
            FormingWireReportViewModels = new List<FormingWireReportViewModel>();
            PieChartModels = new List<PieChartModel>();
            PieChartByMillCode = new List<PieChartModel>();
            PieChartByRegion = new List<PieChartModel>();

        }
        public Guid SelectedReportId { get; set; }
        public string ReportsTitle { get; set; }

        public List<FormingWireReportViewModel> FormingWireReportViewModels { get; set; }

        public List<PieChartModel> PieChartModels { get; set; }

        public List<PieChartModel> PieChartByMillCode { get; set; }

        public List<PieChartModel> PieChartByRegion { get; set; }
    }
}
