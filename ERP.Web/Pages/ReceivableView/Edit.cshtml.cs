using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Dto;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using NToastNotify;

namespace ERP.Pages.ReceivableView
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;

        public EditModel(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public ReceivableViewModel ReceivableViewModel { get; set; }
        public List<ActionButtons> ActionButtons { get; set; }
        public Receivable Receivable { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Receivable = await _context.Receivables
                .Include(r => r.CPMPerson)
                .Include(r => r.Mill).FirstOrDefaultAsync(m => m.Id == id);

            if (Receivable == null)
            {
                return NotFound();
            }
            ViewData["CPMId"] = new SelectList(_context.Person, "Id", "Name");
            ViewData["MillId"] = new SelectList(_context.Mills, "Id", "Code");
            ViewData["RegionId"] = new SelectList(_context.Region, "Id", "Name");

            ActionButtons = _context.ActionButtons.Where(x => x.StatusId == Guid.Parse("5A585CA4-941F-4892-2B81-08D64CCCFC63")).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Receivable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceivableExists(Receivable.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReceivableExists(Guid id)
        {
            return _context.Receivables.Any(e => e.Id == id);
        }
    }
}
