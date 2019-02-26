using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Services
{
    public class DailyStockService : IDailyStockService
    {
        private readonly ApplicationDbContext _context;

        public DailyStockService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<int> AddDailyStock(DailyStock dailyStock)
        {
            _context.DailyStocks.Add(dailyStock);
            return await _context.SaveChangesAsync();
        }

        public List<DailyStock> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DailyStock> GetDailyStockById(Guid dailyStockId)
        {
            return await _context.DailyStocks
                .Include(d => d.Fabric)
                .Include(d => d.Mill)
                .FirstOrDefaultAsync(m => m.Id == dailyStockId);
        }

        public async Task<int> UpdateDailyStock(DailyStock dailyStock)
        {
            int result = 0;
            _context.Attach(dailyStock).State = EntityState.Modified;

            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyStockExists(dailyStock.Id))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        private bool DailyStockExists(Guid id)
        {
            return _context.DailyStocks.Any(e => e.Id == id);
        }
    }
}
