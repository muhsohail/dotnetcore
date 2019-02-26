using System.Collections.Generic;
using Models;

namespace ERP.Dto
{
    public class PaperMillProfileViewModel
    {
        public string MillJson { get; set; }
        public string PaperMillProfileJson { get; set; }
        public string buttonText { get; set; }
        public string RegionJson { get; set; }

        public Mill Mill { get; set; }

        public PaperMillProfile PaperMillProfile { get; set; }
        public List<PaperMillProfile> PaperMillProfiles { get; set; }

        public PaperMillProfileDetail PaperMillProfileDetail { get; set; }
        public List<PaperMillProfileDetail> PaperMillProfileDetails { get; set; }
        public List<CommandButtons> CommandButtons { get; set; }
    }
}
