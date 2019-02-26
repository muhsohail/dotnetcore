using System;
using System.Collections.Generic;
using System.Linq;
using ERP.EntityFramework;
using ERP.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ERP.Services
{
    public class ConsignmentOrderService : IConsignmentOrderService
    {
        private readonly ApplicationDbContext _context;

        public ConsignmentOrderService(ApplicationDbContext context)
        {
            _context = context;

        }

        public List<ConsignmentOrderItem> GetApprovedConsignmentOrderItems()
        {
            Guid ApprovedStatusId = _context.Status.Where(x => x.Name == "Approved").FirstOrDefault().Id;
            return _context.ConsignmentOrderItem.Where(x => x.ConsignmentOrder.StatusId == ApprovedStatusId).ToList();
        }

        public List<ConsignmentOrderItem> GetConsignmentOrderItems()
        {
            List<Guid> Ids = _context.Status.Where(x => x.Name == "Completed" || x.Name == "Closed").Select(x => x.Id).ToList();
            return _context.ConsignmentOrderItem
                    .Include(x => x.ConsignmentOrder)
                    .Where(x => Ids.Contains(x.ConsignmentOrder.StatusId.Value))
                    .ToList();
        }

        public List<ConsignmentOrder> GetConsignmentOrders()
        {
            return _context.ConsignmentOrders
                .Include(c => c.Mill)
                .Include(c => c.Region)
                .Include(c => c.Status)
                .OrderByDescending(x => x.OrderDate.Value)
                .ToList();
        }

        public List<ConsignmentOrder> GetActiveConsignmentOrders()
        {
            return _context.ConsignmentOrders
                .Include(c => c.Mill)
                .Include(c => c.Region)
                .Include(c => c.Status)
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.OrderDate.Value)
                .ToList();
        }

        public List<ConsignmentOrderItem> GetFormingWireConsignmentOrderItems()
        {
            List<Guid> Ids = _context.Status.Where(x => x.Name == "Completed" || x.Name == "Closed").Select(x => x.Id).ToList();
            return _context.ConsignmentOrderItem
                    .Include(x => x.ConsignmentOrder)
                    .Where(x => Ids.Contains(x.ConsignmentOrder.StatusId.Value) && x.FabricTitle.Contains("FORMING WIRE"))
                    .ToList();
        }

        public List<ConsignmentOrderItem> GetConsignmentOrderItemsByFabric(string fabric)
        {
            List<Guid> Ids = _context.Status.Where(x => x.Name == "Completed" || x.Name == "Closed").Select(x => x.Id).ToList();
            return _context.ConsignmentOrderItem
                    .Include(x => x.ConsignmentOrder)
                    .Where(x => Ids.Contains(x.ConsignmentOrder.StatusId.Value) && x.FabricTitle.Contains(fabric))
                    .ToList();
        }

        public int CreateConsignmentOrder(ConsignmentOrder consignmentOrder, string userName)
        {
            int result = 0;
            _context.ConsignmentOrders.Add(consignmentOrder);

            foreach (ConsignmentOrderItem orderItem in consignmentOrder.ConsignmentOrderItems)
            {
                orderItem.ConsignmentOrderId = consignmentOrder.Id;
                orderItem.BarCode = consignmentOrder.BarCode;
                orderItem.IsActive = true;
            }

            _context.ConsignmentOrderItem.AddRange(consignmentOrder.ConsignmentOrderItems);

            OrderComment orderComment = new OrderComment
            {
                StatusId = consignmentOrder.StatusId,
                ConsignmentOrderId = consignmentOrder.Id,
                Comments = consignmentOrder.OrderComments,
                CommentDate = DateTime.Now,
                CreatedBy = userName

            };

            _context.OrderComments.Add(orderComment);

            result = _context.SaveChanges();
            return result;
        }

        public int CreateConsignmentOrderItems(List<ConsignmentOrderItem> consignmentOrderItems)
        {
            throw new NotImplementedException();
        }

        public int DeleteConsignment(Guid ConsignmentId)
        {
            ConsignmentOrder consignmentOrder = _context.ConsignmentOrders.Find(ConsignmentId);

            if (consignmentOrder != null)
                consignmentOrder.IsActive = false;


            List<ConsignmentOrderItem> consignmentOrderItems = _context.ConsignmentOrderItem.Where(x => x.ConsignmentOrderId == consignmentOrder.Id).ToList();
            foreach (ConsignmentOrderItem item in consignmentOrderItems)
                item.IsActive = false;

            return _context.SaveChanges();
        }
    }
}
