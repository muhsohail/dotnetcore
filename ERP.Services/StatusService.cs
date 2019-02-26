using System;
using System.Linq;
using ERP.EntityFramework;
using ERP.Services.Interface;

namespace ERP.Services
{
    public class StatusService : IStatusService
    {
        private readonly ApplicationDbContext _context;
        public StatusService(ApplicationDbContext context)
        {
            _context = context;

        }

        public Guid GetStatusId(string buttonText)
        {
            Guid statusId = Guid.Empty;
            if (string.Equals(buttonText, "CREATE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Created").Id;
            else if (string.Equals(buttonText, "APPROVE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Approved").Id;
            else if (string.Equals(buttonText, "REJECT"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Rejected").Id;
            else if (string.Equals(buttonText, "on-hold"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Completed").Id;
            else if (string.Equals(buttonText, "SHIP"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Completed").Id;
            else if (string.Equals(buttonText, "UPDATE"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Rejected").Id;
            else if (string.Equals(buttonText, "Meeting"))
                statusId = _context.Status.FirstOrDefault(x => x.Name == "Rejected").Id;

            return statusId;
        }
    }
}
