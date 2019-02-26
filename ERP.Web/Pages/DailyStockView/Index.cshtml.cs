using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ERP.EntityFramework;
using Models;

namespace ERP.Pages.DailyStockView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DailyStock> DailyStock { get;set; }

        public async Task OnGetAsync()
        {
            DailyStock = await _context.DailyStocks
                .Include(d => d.Fabric)
                .Include(d => d.Mill).ToListAsync();
        }
    }
}
