using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;

namespace ERP.Services
{
    public class PaperMillService : IPaperMillService
    {
        private readonly ApplicationDbContext _context;

        public PaperMillService(ApplicationDbContext context)
        {
            _context = context;

        }
        public Guid AddMillProfile(Guid statusId, string millJson, string regionJson, string userName)
        {
            PaperMillProfile PaperMillProfile = new PaperMillProfile
            {
                MillId = Guid.Parse(millJson),
                RegionId = Guid.Parse(regionJson),
                CreatedDate = DateTime.Now,
                CreatedBy = userName,
                IsActive = true

            };

            _context.PaperMillProfile.Add(PaperMillProfile);
            _context.SaveChanges();

            return PaperMillProfile.Id;
        }

        public int AddMillProfileDetails(Guid PaperMillProfileId, string PaperMillProfileJson)
        {
            List<PaperMillProfileDetail> profileDetails = new List<PaperMillProfileDetail>();
            profileDetails = JsonConvert.DeserializeObject<List<PaperMillProfileDetail>>(PaperMillProfileJson);


            foreach (PaperMillProfileDetail item in profileDetails)
            {
                item.PaperMillProfileId = PaperMillProfileId;
                item.IsActive = true;
            }

            _context.PaperMillProfileDetail.AddRange(profileDetails);
           return _context.SaveChanges();            
        }

        public async Task<int> DeletePaperMillProfile(Guid id)
        {

            PaperMillProfile PaperMillProfile = await _context.PaperMillProfile.FindAsync(id);

            if (PaperMillProfile != null)
                PaperMillProfile.IsActive = false;

            List<PaperMillProfileDetail> paperMillProfileDetail = await _context.PaperMillProfileDetail.ToListAsync();
            foreach (PaperMillProfileDetail item in paperMillProfileDetail)
                item.IsActive = false;

            return await _context.SaveChangesAsync();
        }

        public async Task<PaperMillProfile> GetPaperMillProfile(Guid id)
        {
            return await _context.PaperMillProfile
                .Include(p => p.Mill)
                .Include(p => p.Region)
                .Include(p => p.Mill.CPMPerson)
                .Include(p => p.Mill.MangerPerson)
                .Include(p => p.Mill.MechanicalPerson)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public List<PaperMillProfileDetail> GetPaperMillProfileDetails(Guid paperMillProfileId )
        {
            return _context.PaperMillProfileDetail
                .Include(x => x.Fabric)
                .Where(m => m.PaperMillProfileId == paperMillProfileId)
                .ToList();

        }

        public int UpdateAmountEachPiece(Guid fabricId, double productAskingRate)
        {
            List<PaperMillProfileDetail> paperMillProfileDetails = _context.PaperMillProfileDetail.Where(x => x.FabricId == fabricId).ToList();
            paperMillProfileDetails.ForEach(item => item.AmountEachPiece = Convert.ToDouble(item.Width) * Convert.ToDouble(item.Length) * productAskingRate);

            return _context.SaveChanges();
        }

        public int UpdatePapaerProfile(Guid paperMillProfileId, string millJson, string regionJson, string userName)
        {
            int result = 0;
            PaperMillProfile millProfile = _context.PaperMillProfile.FirstOrDefault(x => x.Id == paperMillProfileId);

            if (millProfile != null)
            {
                millProfile.MillId = Guid.Parse(millJson);
                millProfile.RegionId = Guid.Parse(regionJson);
                millProfile.CreatedDate = DateTime.Now;
                millProfile.CreatedBy = userName;
                millProfile.IsActive = true;

                _context.PaperMillProfile.Update(millProfile);
                result = _context.SaveChanges();
            }

            return result;
        }

        public Guid UpdatePaperProfileDetails(string paperMillProfileJson)
        {
            List<PaperMillProfileDetail> PaperMillProfileDetails = new List<PaperMillProfileDetail>();

            PaperMillProfileDetails = JsonConvert.DeserializeObject<List<PaperMillProfileDetail>>(paperMillProfileJson);


            List<Guid> PaperMillProfileDetailsIds = PaperMillProfileDetails.Select(x => x.Id).ToList();
            List<PaperMillProfileDetail> ExistingPaperMillProfileDetails = _context.PaperMillProfileDetail.Where(x => x.PaperMillProfileId == PaperMillProfileDetails[0].PaperMillProfileId).ToList();
            List<PaperMillProfileDetail> PaperMillProfileDetailsToBeDeleted = ExistingPaperMillProfileDetails.Where(x => !PaperMillProfileDetailsIds.Contains(x.Id)).ToList();


            _context.PaperMillProfileDetail.RemoveRange(PaperMillProfileDetailsToBeDeleted);

            foreach (PaperMillProfileDetail deletedItem in PaperMillProfileDetailsToBeDeleted)
                deletedItem.IsActive = false;

            _context.SaveChanges();

            List<PaperMillProfileDetail> PaperMillProfileDetailsToBeAdded = PaperMillProfileDetails
                                                    .Where(x => x.Id == Guid.Empty || x.Id == null)
                                                    .ToList();

            if (PaperMillProfileDetailsToBeAdded.Count > 0)
            {
                foreach (PaperMillProfileDetail addedItem in PaperMillProfileDetailsToBeAdded)
                    addedItem.IsActive = true;

                _context.PaperMillProfileDetail.AddRange(PaperMillProfileDetailsToBeAdded);
                _context.SaveChanges();
            }

            return PaperMillProfileDetails[0].PaperMillProfile.Id;
        }
    }
}
