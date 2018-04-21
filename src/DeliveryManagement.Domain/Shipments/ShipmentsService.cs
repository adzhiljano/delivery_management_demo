using DeliveryManagement.Domain.Core;
using System.Linq;

namespace DeliveryManagement.Domain.Shipments
{
    public interface IShipmentsService
    {
        PagingDO<ShipmentDO> GetShipments(int truckId, ShipmentStatus? status = null, int? offset = 0, int? limit = 10);
        ShipmentDO ChangeStatus(int shipmentId, ShipmentStatus status, bool? hasDamagedPackages = null, bool? receiverFound = null, string notes = null);
        ShipmentDO ResetShipment(int shipmentId);
    }

    public class ShipmentsService : IShipmentsService
    {
        private UnitOfWork unitOfWork;
        public ShipmentsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        public PagingDO<ShipmentDO> GetShipments(int truckId, ShipmentStatus? status = null, int? offset = 0, int? limit = 10)
        {
            var query = this.unitOfWork.Set<Shipment>()
                .Where(t => t.TruckId == truckId);

            if(status.HasValue)
            {
                query = query.Where(t => t.Status == status);
            }

            return new PagingDO<ShipmentDO>()
            {
                Count = query.Count(),
                Results = query
                    .OrderBy(t => t.ShipmentId)
                    .WithOffsetAndLimit(offset, limit)
                    .Select(t => new ShipmentDO(t))
                    .ToList()
            };
        }

        public ShipmentDO ChangeStatus(int shipmentId, ShipmentStatus status, bool? hasDamagedPackages = null, bool? receiverFound = null, string notes = null)
        {
            var shipment = this.GetShipment(shipmentId);
            shipment.ChangeStatus(status, hasDamagedPackages, receiverFound, notes);
            this.unitOfWork.Save();
            return new ShipmentDO(shipment);
        }

        public ShipmentDO ResetShipment(int shipmentId)
        {
            var shipment = this.GetShipment(shipmentId);
            shipment.ChangeStatus(ShipmentStatus.OutForDelivery, null, null, null);
            this.unitOfWork.Save();
            return new ShipmentDO(shipment); ;
        }

        private Shipment GetShipment(int shipmentId)
        {
            return this.unitOfWork.Set<Shipment>().Where(t => t.ShipmentId == shipmentId).Single();
        }
    }
}
