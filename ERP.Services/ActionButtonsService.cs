using System;
using System.Collections.Generic;
using System.Linq;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Models;

namespace ERP.Services
{
    public class ActionButtonsService : IActionButtonsService
    {
        private readonly ApplicationDbContext _context;

        public ActionButtonsService(ApplicationDbContext context)
        {
            _context = context;

        }
        public List<ActionButtons> GetActionButtons(Guid statusId)
        {
            return _context.ActionButtons
                .Where(x => x.StatusId == statusId)
                .ToList();
        }
    }
}
