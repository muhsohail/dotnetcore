using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Web.ViewModels.Home;

namespace ERP.Web.ViewModels.Home
{
    public class DashboardStackChartViewModel
    {
        public DashboardStackChartViewModel()
        {
            DashboardViewModel = new DashboardViewModel();
        }

        public string RegionName { get; set; }
        public string CommaSepratedValues { get; set; }
        public DashboardViewModel DashboardViewModel { get; set; }
    }
}
