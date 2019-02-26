using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using ERP.Web.ViewModels.Reports;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.ConsignmentView
{
    [Authorize(Roles = "Admin, Editor, Viewer")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConsignmentOrderService _consignmentOrderService;
        private readonly ConsginmentERPClient _consginmentERPClient;
        public IndexModel(ApplicationDbContext context, IConsignmentOrderService consignmentOrderService, ConsginmentERPClient consginmentERPClient)
        {
            _context = context;
            _consignmentOrderService = consignmentOrderService;
            _consginmentERPClient = consginmentERPClient;
        }

        public IList<ConsignmentOrder> ConsignmentOrder { get;set; }
        public IList<ConsignmentOrderItem> ConsignmentOrderItemsFormingWire { get; set; }
        public IList<ConsignmentOrderItem> ConsignmentOrderItemsFelt { get; set; }
        public IList<ConsignmentOrderItem> ConsignmentOrderItemsDryScreen { get; set; }
        public IList<ConsignmentOrderItem> ConsignmentApprovedOrderItems { get; set; }
        public IList<PieChartModel> OrdersByStatus { get; set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
                ConsignmentOrder = await _consginmentERPClient.GetConsignmentOrder();
            else 
                ConsignmentOrder = await _consginmentERPClient.GetActiveConsignmentOrder();

            ConsignmentOrderItemsFormingWire = await _consginmentERPClient.GetConsignmentOrderItemsByFabric("FORMING WIRE");
            ConsignmentOrderItemsFelt = await _consginmentERPClient.GetConsignmentOrderItemsByFabric("FELT");
            ConsignmentOrderItemsDryScreen = await _consginmentERPClient.GetConsignmentOrderItemsByFabric("DRY SCREEN");
            ConsignmentApprovedOrderItems = await _consginmentERPClient.GetApprovedConsignmentOrderItems();

            OrdersByStatus = BuildPieChartModel();
        }

        private List<PieChartModel> BuildPieChartModel()
        {
            List<PieChartModel> formingWirePieChartModel = new List<PieChartModel>();
            formingWirePieChartModel = _context.ConsignmentOrders
                .Include(x => x.Status)
                .GroupBy(x => x.Status.Name)
                .Select(x => new PieChartModel
                {
                    FabricCode = x.Key,
                    Count = x.Count()
                }).ToList();

            return formingWirePieChartModel;
        }
    }
}
