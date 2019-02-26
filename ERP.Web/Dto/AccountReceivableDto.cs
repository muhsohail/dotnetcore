using System;
using System.ComponentModel;

namespace ERP.Dto
{
    public class AccountReceivableDto
    {
        public Guid Id { get; set; }

        [DisplayName("Receiveable Up To Date")]
        public double ReceiveableUpToDate { get; set; }

        [DisplayName("Amount Received")]
        public double? AmounntReceiveable { get; set; }

        [DisplayName("Person Receivable")]
        public string PersonReceivable { get; set; }

        [DisplayName("Direct Number")]
        public string DirectNumber { get; set; }

        [DisplayName("Current < 30 Days")]
        public double CurrentLessThen30Days { get; set; }

        [DisplayName("Rec 31 To 60")]
        public double Rec31To60 { get; set; }

        [DisplayName("Rec 61 To 90")]
        public double Rec61To90 { get; set; }

        [DisplayName("Rec 90 Plus")]
        public double Rec90Plus { get; set; }

        [DisplayName("Almost Dead")]
        public double AlmostDead { get; set; }

        // Sales
        [DisplayName("Potential Annual")]
        public double PotentialAnnual { get; set; }

        [DisplayName("Sales 2016")]
        public double Sale2k16 { get; set; }

        [DisplayName("Sales 2017")]
        public double Sale2k17 { get; set; }

        [DisplayName("Sales 2018")]
        public double Sale2K18 { get; set; }

        public int Width { get; set; }

        [DisplayName("Mechanical Data")]
        public string MechanicalData { get; set; }

        public string Drawing { get; set; }

        [DisplayName("Next Action")]
        public string NextAction { get; set; }

        public string MillName { get; set; }

        public string CPMName { get; set; }


    }
}
