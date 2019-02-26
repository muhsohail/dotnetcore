using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ERP.Services.Interface
{
    public interface IMillService
    {
        string BuildMillCode(int regionNo, string cityCode, string millName);
        Task<int> AddMillAsync(Mill mill);
        Mill GetMillDetails(string millCode);
        List<Mill> GetAllMills();

        Mill GetMillByCode(string Code);
    }
}
