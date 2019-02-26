using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ERP.Services.Interface
{
    public interface IPaperMillService
    {

        Guid AddMillProfile(Guid statusId, string millJson, string regionJson, string userName);
        int AddMillProfileDetails(Guid PaperMillProfileId, string PaperMillProfileJson);
        Task<PaperMillProfile>  GetPaperMillProfile(Guid id);
        List<PaperMillProfileDetail> GetPaperMillProfileDetails(Guid paperMillProfileId);
        Task<int> DeletePaperMillProfile(Guid id);
        Guid UpdatePaperProfileDetails(string paperMillProfileJson);
        int UpdatePapaerProfile(Guid paperMillProfileId, string millJson, string regionJson, string userName);
        int UpdateAmountEachPiece(Guid fabricId, double productAskingRate);
    }
}
