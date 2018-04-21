using DeliveryManagement.Domain.Core;
using DeliveryManagement.Domain.Shipments;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryManagement.Web.Host.Controllers
{
    [Route("api/shipments")]
    public class ShipmentsController : Controller
    {
        private IShipmentsService shipmentsService { get; set; }

        public ShipmentsController(IShipmentsService shipmentsService)
        {
            this.shipmentsService = shipmentsService;
        }

        [HttpGet]
        public PagingDO<ShipmentDO> GetShipments(ShipmentStatus? status = null, int? offset = 0, int? limit = 5)
        {
            return this.shipmentsService.GetShipments(1, status, offset, limit);
        }

        [HttpPost]
        [Route("{shipmentId:int}/changeStatusToDelivered")]
        public ShipmentDO ChangeStatusToDelivered(int shipmentId, [FromBody] ShipmentDO shipment)
        {
            return this.shipmentsService.ChangeStatus(shipmentId, ShipmentStatus.Delivered, shipment.HasDamagedPackages, shipment.ReceiverFound, shipment.Notes);
        }

        [HttpPost]
        [Route("{shipmentId:int}/changeStatusToHeldInTruck")]
        public ShipmentDO ChangeStatusToHeldInTruck(int shipmentId, [FromBody] ShipmentDO shipment)
        {
            return this.shipmentsService.ChangeStatus(shipmentId, ShipmentStatus.HeldInTruck, shipment.HasDamagedPackages, shipment.ReceiverFound, shipment.Notes);
        }

        [HttpPost]
        [Route("{shipmentId:int}/resetShipment")]
        public ShipmentDO ResetShipment(int shipmentId)
        {
            return this.shipmentsService.ResetShipment(shipmentId);
        }
    }
}
