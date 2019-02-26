using System;

namespace ERP.Services.Interface
{
    public interface IStatusService
    {
        Guid GetStatusId(string btnText);
    }
}
