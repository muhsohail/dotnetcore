using System;
using System.Collections.Generic;
using Models;

namespace ERP.Dto
{
    public class ConsignmentViewModel
    {
        public ConsignmentViewModel()
        {
            ConsignmentOrders = new List<ConsignmentOrder>();
            ConsignmentOrderItems = new List<ConsignmentOrderItem>();
            CommandButtons = new List<CommandButtons>();
        }
        public string ConsignmentOrderId { get; set; }
        public string MillJson { get; set; }
        public string ConsignmentOrderJson { get; set; }
        public string buttonText { get; set; }
        public string RegionJson { get; set; }
        public string OrderComments { get; set; }
        public Mill Mill { get; set; }
        public ConsignmentOrder ConsignmentOrder { get; set; }
        public List<ConsignmentOrder> ConsignmentOrders { get; set; }
        public ConsignmentOrderItem ConsignmentOrderItem { get; set; }
        public List<ConsignmentOrderItem> ConsignmentOrderItems { get; set; }
        public List<CommandButtons> CommandButtons { get; set; }
    }
}
