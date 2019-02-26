using System;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.WebApi.TypedClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using NToastNotify;

namespace ERP.Pages.ConsignmentView
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ConsginmentERPClient _consginmentERPClient;
        private readonly IToastNotification _toastNotification;

        public DeleteModel(
            ApplicationDbContext context,
            ConsginmentERPClient consginmentERPClient,
            IToastNotification toastNotification)
        {
            _context = context;
            _consginmentERPClient = consginmentERPClient;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public ConsignmentOrder ConsignmentOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ConsignmentOrder = await _context.ConsignmentOrders
                .Include(c => c.ConsignmentOrderItems)
                .Include(c => c.Mill)
                .Include(c => c.Region).FirstOrDefaultAsync(m => m.Id == id);

            if (ConsignmentOrder == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            bool result = false;

            if (id == null)
                return NotFound();

            result = await _consginmentERPClient.DeleteConsignment(id.Value);

            if (result)
                _toastNotification.AddSuccessToastMessage("Consignment has been deleted successfully.");
            else
                _toastNotification.AddErrorToastMessage("Error in deleting consignment");

            return RedirectToPage("./Index");
        }
    }
}
