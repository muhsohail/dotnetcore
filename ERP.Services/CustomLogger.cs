using ERP.EntityFramework;
using ERP.Services.Interface;
using Models.Logging;

namespace ERP.Services
{

    public class CustomLogger : ICustomLogger
    {
        private readonly ApplicationDbContext _context;
        public CustomLogger(ApplicationDbContext context)
        {
            _context = context;

        }
        public void InfoLog(Log log)
        {
            _context.ApplicationLog.Add(log);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void InfoLog(string message)
        {
            //throw new NotImplementedException();
        }
    }
}
