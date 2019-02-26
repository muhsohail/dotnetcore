using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Pages.ReceivableView
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, List<AccountReceivableDto>> Receivables { get;set; }

        public async Task OnGetAsync()
        {
            List<Receivable> Receivable = new List<Receivable>();
            
            Receivable = await _context.Receivables
                .Include(r => r.CPMPerson)
                .Include(r => r.Mill)
                .Include(x =>x.Region)
                .ToListAsync();

            foreach (Receivable receivable in Receivable)
            {
                if (receivable.CreatedDate.HasValue)
                {
                    if ((DateTime.Now - receivable.CreatedDate.Value).TotalDays < 30)
                        receivable.CurrentLessThen30Days = receivable.ReceiveableUpToDate;
                    else if ((DateTime.Now - receivable.CreatedDate.Value).TotalDays > 30 && (DateTime.Now - receivable.CreatedDate.Value).TotalDays < 60)
                        receivable.Rec31To60 = receivable.ReceiveableUpToDate;
                    else if ((DateTime.Now - receivable.CreatedDate.Value).TotalDays > 60 && (DateTime.Now - receivable.CreatedDate.Value).TotalDays < 90)
                        receivable.Rec61To90 = receivable.ReceiveableUpToDate;
                    else if ((DateTime.Now - receivable.CreatedDate.Value).TotalDays > 90)
                        receivable.Rec90Plus = receivable.ReceiveableUpToDate;
                }
            }

            Receivables = Receivable
                .GroupBy(x => x.Region.Name)
                .ToDictionary(x => x.Key, y => y.Select(z => new AccountReceivableDto
                {
                    Id = z.Id,
                    AlmostDead = z.AlmostDead,
                    AmounntReceiveable = z.AmounntReceiveable,
                    CurrentLessThen30Days = z.CurrentLessThen30Days,
                    DirectNumber = z.DirectNumber,
                    Drawing = z.Drawing,
                    MechanicalData = z.MechanicalData,
                    NextAction = z.NextAction,
                    PersonReceivable = z.PersonReceivable,
                    PotentialAnnual = z.PotentialAnnual,
                    Rec31To60 = z.Rec31To60,
                    Rec61To90 = z.Rec61To90,
                    Rec90Plus = z.Rec90Plus,
                    ReceiveableUpToDate = z.ReceiveableUpToDate,
                    Sale2k16 = z.Sale2k16,
                    Sale2k17 = z.Sale2k17,
                    Sale2K18 = z.Sale2K18,
                    Width = z.Width,
                    MillName = z.Mill.Code,
                    CPMName = z.CPMPerson.Name
                }).ToList());

            Console.Write("a");
        }
    }
}
