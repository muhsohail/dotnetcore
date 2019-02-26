using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.PaperMillProfileView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PaperMillProfile> PaperMillProfile { get;set; }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Editor"))
            {
                PaperMillProfile = await _context.PaperMillProfile
                .Include(p => p.Mill)
                .Include(p => p.Region)
                .ToListAsync();

                List<PaperMillProfileDetail> paperMillProfileDetail = await _context.PaperMillProfileDetail.ToListAsync();

                foreach (PaperMillProfile item in PaperMillProfile)
                {
                    item.TotalAmount = paperMillProfileDetail.Where(x => x.PaperMillProfileId == item.Id).Sum(x => x.AmountEachPiece);
                    item.TotalPCSCount = paperMillProfileDetail.Where(x => x.PaperMillProfileId == item.Id).Sum(x => x.ConsPcsYear);
                    item.TotalConsAmtPerYear = paperMillProfileDetail.Where(x => x.PaperMillProfileId == item.Id).Sum(x => x.ConsAmtYear);
                }

            }
            else {

                PaperMillProfile = await _context.PaperMillProfile
                .Include(p => p.Mill)
                .Include(p => p.Region)
                .Where(x => x.IsActive)
                .ToListAsync();

                List<PaperMillProfileDetail> paperMillProfileDetail = await _context.PaperMillProfileDetail.Where(x => x.IsActive).ToListAsync();

                foreach (PaperMillProfile item in PaperMillProfile)
                {
                    item.TotalAmount = paperMillProfileDetail.Where(x => x.PaperMillProfileId == item.Id).Sum(x => x.AmountEachPiece);
                    item.TotalPCSCount = paperMillProfileDetail.Where(x => x.PaperMillProfileId == item.Id).Sum(x => x.ConsPcsYear);
                    item.TotalConsAmtPerYear = paperMillProfileDetail.Where(x => x.PaperMillProfileId == item.Id).Sum(x => x.ConsAmtYear);
                }
            }
        }
    }
}
