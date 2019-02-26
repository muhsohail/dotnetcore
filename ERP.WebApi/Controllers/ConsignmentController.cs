using System;
using System.Collections.Generic;
using ERP.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsignmentController : ControllerBase
    {
        private readonly IConsignmentOrderService _consignmentOrderService;

        public ConsignmentController(IConsignmentOrderService consignmentOrderService)
        {
            _consignmentOrderService = consignmentOrderService;

        }

        // GET api/consignmentorders
        [HttpGet]
        public ActionResult<List<ConsignmentOrder>> GetConsignmentOrders()
        {
            return _consignmentOrderService.GetConsignmentOrders();
        }

        [HttpGet("GetActiveConsignmentOrders")]
        public ActionResult<List<ConsignmentOrder>> GetActiveConsignmentOrders()
        {
            return _consignmentOrderService.GetConsignmentOrders();
        }

        [HttpGet("GetFormingWireConsignmentOrderItems")]
        public ActionResult<List<ConsignmentOrderItem>> GetFormingWireConsignmentOrderItems()
        {
            return _consignmentOrderService.GetConsignmentOrderItems();
        }

        [HttpGet("GetConsignmentOrderItems")]
        public ActionResult<List<ConsignmentOrderItem>> GetConsignmentOrderItems()
        {
            return _consignmentOrderService.GetConsignmentOrderItems();
        }

        [HttpGet("GetApprovedConsignmentOrderItems")]
        public ActionResult<List<ConsignmentOrderItem>> GetApprovedConsignmentOrderItems()
        {
            return _consignmentOrderService.GetApprovedConsignmentOrderItems();
        }

        [HttpGet("GetConsignmentOrderItemsByFabric/{0}")]
        public ActionResult<List<ConsignmentOrderItem>> GetConsignmentOrderItemsByFabric(string fabric)
        {
            return _consignmentOrderService.GetConsignmentOrderItemsByFabric(fabric);
        }

        [HttpPost]
        public ActionResult<int> CreateConsignmentOrder(ConsignmentOrder consignmentOrder)
        {
            return _consignmentOrderService.CreateConsignmentOrder(consignmentOrder, User.Identity.Name);
        }


        [HttpDelete("{Id}")]
        public ActionResult<int> DeleteConsignment(Guid Id)
        {
            return _consignmentOrderService.DeleteConsignment(Id);
        }
    }
}