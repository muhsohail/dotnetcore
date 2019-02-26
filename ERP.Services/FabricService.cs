using System;
using System.Linq;
using ERP.EntityFramework;
using ERP.Services.Interface;

namespace ERP.Services
{

    public class FabricService : IFabricService
    {
        private readonly ApplicationDbContext _context;

        public FabricService(ApplicationDbContext context)
        {
            _context = context;

        }

        public string GetFabricDescription(Guid fabricId)
        {
            Guid? fabricCodeId = _context.Fabrics.FirstOrDefault(x => x.Id == fabricId).FabricCodeId;
            return _context.FabricCodes.FirstOrDefault(x => x.Id == fabricCodeId).Description.ToUpper();

        }

        public bool IsFabricAlreadyCreated(string fabricCode)
        {
            return _context.Fabrics.Any(x => x.Code == fabricCode);
        }
    }
}
