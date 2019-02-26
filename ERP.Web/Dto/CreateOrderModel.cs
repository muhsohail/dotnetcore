using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace ERP.Dto
{
    public class CreateOrderModel
    {
        public CreateOrderModel()
        {
            Orders = new List<Order>();
        }

        public string MillJson { get; set; }
        public Mill Mill { get; set; }


        public string OrderJson { get; set; }

        public Order Order { get; set; }
        public List<Order> Orders { get; set; }


    }
}
