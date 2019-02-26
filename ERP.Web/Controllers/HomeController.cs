using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ERP.EntityFramework;
using ERP.Web.ViewModels.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Controllers
{
    [Authorize(Roles = "Admin, Editor, Viewer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            List<DashboardStackChartViewModel> dashboardStackChartViewModel = new List<DashboardStackChartViewModel>();
            dashboardStackChartViewModel = _dbContext.PaperMillProfileDetail
                        .Include(x => x.PaperMillProfile)
                        .GroupBy(x => x.PaperMillProfile.Region.Name)
                        .Select(x => new DashboardStackChartViewModel
                        {
                            RegionName = x.Key,
                            DashboardViewModel = x.Select(y => new DashboardViewModel
                            {

                                //RegionNo = x.Key,
                                MillsCount = x.Count(),
                                TotalAmountEachPiece = x.Sum(z => z.AmountEachPiece),
                                TotalConsAmountYear = x.Sum(z => z.ConsAmtYear),
                                TotalConsPcsPerYear = x.Sum(z => z.AmountEachPiece),
                                TotalNextOrder = x.Sum(z => z.NextOrder),
                                TotalNextOrderAmount = x.Sum(z => z.AmountEachPiece)
                            }).FirstOrDefault()

                        }).ToList();

            foreach (DashboardStackChartViewModel item in dashboardStackChartViewModel)
                item.CommaSepratedValues = string.Format("{0}, {1}, {2}, {3}, {4}, {5}", item.DashboardViewModel.MillsCount, item.DashboardViewModel.TotalAmountEachPiece, item.DashboardViewModel.TotalConsAmountYear, item.DashboardViewModel.TotalConsPcsPerYear, item.DashboardViewModel.TotalNextOrder, item.DashboardViewModel.TotalNextOrderAmount);

            return View(dashboardStackChartViewModel);
        }

        [Authorize(Roles = "Admin, Editor, Viewer")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please find below our contact details.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
