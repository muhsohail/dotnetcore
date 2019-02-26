using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ERP.Services.Interface
{
    public interface IProductRateService
    {
        ProductRate GetProductRate(Guid fabricId);
        Task<int> AddProductRate(ProductRate productRate);
        Task<int> UpdateProductRate(ProductRate productRate);
        List<ProductRate> GetAllProductRates(bool includeInActive);
    }
}
