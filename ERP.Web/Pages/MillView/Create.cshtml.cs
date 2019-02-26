using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using NToastNotify;

namespace ERP.Pages.MillView
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        private readonly IMillService _millService;
        private readonly ICityService _cityService;

        public CreateModel(ApplicationDbContext context, IToastNotification toastNotification, IMillService millService, ICityService cityService)
        {
            _context = context;
            _toastNotification = toastNotification;
            _millService = millService;
            _cityService = cityService;
        }

        public IActionResult OnGet()
        {
            IEnumerable<Person> persons = _context.Person.Where(x => x.IsActive);
            if (persons.ToList().Count > 0)
            {
                ViewData["MangerId"] = new SelectList(_context.Person.Where(x => x.IsActive), "Id", "Name");
                ViewData["MechanicalId"] = new SelectList(_context.Person.Where(x => x.IsActive), "Id", "Name");
                ViewData["MDId"] = new SelectList(_context.Person.Where(x => x.IsActive), "Id", "Name");
                ViewData["CPMId"] = new SelectList(_context.Person.Where(x => x.IsActive), "Id", "Name");
            }
            else
                _toastNotification.AddAlertToastMessage("Please add persons first in the system.");

            IEnumerable<City> cities = _context.City.Where(x => x.IsActive);
            if (cities.ToList().Count > 0)
                ViewData["CityId"] = new SelectList(_context.City.Where(x => x.IsActive).Include(x => x.Region), "Id", "Name");
            else
                _toastNotification.AddAlertToastMessage("Please add city first in the system.");


            return Page();
        }

        [BindProperty]
        public Mill Mill { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            int regionNo = _cityService.GetRegionNo(Mill.CityId.Value);
            string cityCode = _cityService.GetCityCode(Mill.CityId.Value);

            Mill.Code = _millService.BuildMillCode(regionNo, cityCode, Mill.Name);

            int result = await _millService.AddMillAsync(Mill);
            if(result > 0)
                _toastNotification.AddSuccessToastMessage("Mill has been successfully created.");
            else
                _toastNotification.AddErrorToastMessage("Something went wrong.");

            return RedirectToPage("./Index");
        }
    }
}