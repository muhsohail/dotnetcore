using System;

namespace ERP.Services.Interface
{
    public interface IFabricService
    {
        bool IsFabricAlreadyCreated(string fabricCode);
        string GetFabricDescription(Guid fabricId);
    }
}
