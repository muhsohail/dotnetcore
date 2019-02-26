namespace ERP.Web.ViewModels.Home
{
    public class DashboardViewModel
    {
        public int RegionNo { get; set; }
        public int MillsCount { get; set; }
        public double? TotalAmountEachPiece { get; set; }
        public double? TotalConsPcsPerYear { get; set; }
        public double? TotalConsAmountYear { get; set; }
        public int TotalNextOrder { get; set; }
        public double? TotalNextOrderAmount { get; set; }
    }
}
