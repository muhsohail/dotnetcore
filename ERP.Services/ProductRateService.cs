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
    public class ProductRateService : IProductRateService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaperMillService _paperMillService;

        public ProductRateService(ApplicationDbContext context, IPaperMillService paperMillService)
        {
            _context = context;
            _paperMillService = paperMillService;

        }

        public async Task<int> UpdateProductRate(ProductRate productRate)
        {
            int result = 0;
            productRate.IsActive = true;
            _context.Attach(productRate).State = EntityState.Modified;

            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductRateExists(productRate.Id))
                {
                    throw;// return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Update the rate in the linked PaperMillProfile enteries
            if (result > 0)
            {
                if (productRate.FabricId.HasValue)
                {
                    result = _paperMillService.UpdateAmountEachPiece(productRate.FabricId.Value, productRate.AskingRate);
                }
            }

            return result;
        }

        public ProductRate GetProductRate(Guid fabricId)
        {
            return _context.ProductRate
                .Where(x => x.FabricId == fabricId)
                .FirstOrDefault();
        }

        public async Task<int> AddProductRate(ProductRate productRate)
        {
            productRate.IsActive = true;
            _context.ProductRate.Add(productRate);
            return await _context.SaveChangesAsync();
        }

        private bool ProductRateExists(Guid id)
        {
            return _context.ProductRate.Any(e => e.Id == id);
        }

        public List<ProductRate> GetAllProductRates(bool includeInactive)
        {
            List<ProductRate> productRates = new List<ProductRate>();
            if (includeInactive)
                productRates = _context.ProductRate.Include(p => p.Fabric).ToList();
            else
                productRates = _context.ProductRate.Include(p => p.Fabric).Where(x => x.IsActive).ToList();

            return productRates;
        }
    }
}
