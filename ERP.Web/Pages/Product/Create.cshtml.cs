using System;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using NToastNotify;


namespace ERP.Areas.Application.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IFabricService _fabricService;

        public CreateModel(ApplicationDbContext context, IToastNotification toastNotification, IFabricService fabricService)
        {
            _context = context;
            _toastNotification = toastNotification;
            _fabricService = fabricService;
        }

        public IActionResult OnGet()
        {
        ViewData["FabricTypeId"] = new SelectList(_context.FabricTypes, "Id", "Type");
        ViewData["FabricCodeId"] = new SelectList(_context.FabricCodes, "Id", "Code");

            return Page();
        }


        public JsonResult OnGetFabricDescription(string faricId)
        {
             string fabricDescription = _context.FabricCodes.FirstOrDefault(x => x.Id == Guid.Parse(faricId)).Description.ToUpper();


            _toastNotification.AddSuccessToastMessage("Fabric description has been reterieved", new NotyOptions()
            {
                Timeout = 20
            });
           
            return new JsonResult(fabricDescription);
        }

        [BindProperty]
        public Fabric Fabric { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string type = _context.FabricTypes.Where(x => x.Id == Fabric.FabricTypeId).FirstOrDefault().Type;
            string fabricCode = _context.FabricCodes.Where(x => x.Id == Fabric.FabricCodeId).FirstOrDefault().Code;
            Fabric.Code = string.Format("{0}/{1}", fabricCode, type);

            if (!_fabricService.IsFabricAlreadyCreated(Fabric.Code))
            {
                Fabric.IsActive = true;
                _context.Fabrics.Add(Fabric);
                await _context.SaveChangesAsync();

            }
            else 
                _toastNotification.AddInfoToastMessage("Fabric has been already added.");

            return RedirectToPage("./Index");
        }
    }
}