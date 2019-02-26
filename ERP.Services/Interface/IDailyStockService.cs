using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ERP.Services.Interface
{
    public interface IDailyStockService
    {
        Task<int> AddDailyStock(DailyStock dailyStock);
        Task<int> UpdateDailyStock(DailyStock dailyStock);
        Task<DailyStock> GetDailyStockById(Guid dailyStockId);
        List<DailyStock> GetAll();

    }
}
