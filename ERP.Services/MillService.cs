using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Services
{
    public class MillService : IMillService
    {
        private readonly ApplicationDbContext _context;

        public MillService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<int> AddMillAsync(Mill mill)
        {
            mill.IsActive = true;
            _context.Mills.Add(mill);
            return await _context.SaveChangesAsync();

            //return null;

        }

        public string BuildMillCode(int regionNo, string cityCode, string millName)
        {
            return string.Format("{0}-{1}-{2}", regionNo, cityCode.ToLower(), millName.Substring(0, 3).ToLower());
        }

        public List<Mill> GetAllMills()
        {
            return _context.Mills.ToList();
        }

        public Mill GetMillByCode(string Code)
        {
            return _context.Mills
                .Include(x => x.City)
                .Include(x => x.CPMPerson)
                .Include(x => x.MangerPerson)
                .Include(x => x.MechanicalPerson)
                .Where(x => x.Code == Code && x.IsActive)
                .FirstOrDefault();
        }

        public Mill GetMillDetails(string millCode)
        {
            return _context.Mills
                        .Include(x => x.City)
                        .Include(x => x.CPMPerson)
                        .Include(x => x.MangerPerson)
                        .Include(x => x.MechanicalPerson)
                        .Where(x => x.Code == millCode).FirstOrDefault();
        }
    }
}
