using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ERP.Services.Interface
{
    public interface IActionButtonsService
    {
        List<ActionButtons> GetActionButtons(Guid statusId);
    }
}
