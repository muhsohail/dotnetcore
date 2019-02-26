using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ERP.Services.Interface
{
    public interface IConsignmentOrderService
    {
        List<ConsignmentOrderItem> GetConsignmentOrderItems();
        List<ConsignmentOrderItem> GetApprovedConsignmentOrderItems();
        List<ConsignmentOrder> GetConsignmentOrders();
        List<ConsignmentOrder> GetActiveConsignmentOrders();
        List<ConsignmentOrderItem> GetFormingWireConsignmentOrderItems();
        List<ConsignmentOrderItem> GetConsignmentOrderItemsByFabric(string fabric);
        int CreateConsignmentOrder(ConsignmentOrder consignmentOrder, string userName);
        int CreateConsignmentOrderItems(List<ConsignmentOrderItem> consignmentOrderItems);
        int DeleteConsignment(Guid ConsignmentId);
    }
}
