using System;

namespace DeliveryManagement.Domain.Shipments
{
    public partial class ShipmentDO
    {
        public ShipmentDO() { }

        public ShipmentDO(Shipment shipment)
        {
            this.ShipmentId = shipment.ShipmentId;
            this.TrackingNumber = shipment.TrackingNumber;
            this.SenderName = shipment.SenderName;
            this.SenderAddress = shipment.SenderAddress;
            this.ReceiverName = shipment.ReceiverName;
            this.ReceiverAddress = shipment.ReceiverAddress;
            this.PackagesCount = shipment.PackagesCount;
            this.Status = shipment.Status;
            this.HasDamagedPackages = shipment.HasDamagedPackages;
            this.ReceiverFound = shipment.ReceiverFound;
            this.Notes = shipment.Notes;
            this.TruckId = shipment.TruckId;
            this.CreateDate = shipment.CreateDate;
            this.ModifyDate = shipment.ModifyDate;
            this.Version = shipment.Version;
        }

        public int ShipmentId { get; set; }
        public Guid TrackingNumber { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public int PackagesCount { get; set; }
        public ShipmentStatus Status { get; set; }
        public bool? HasDamagedPackages { get; set; }
        public bool? ReceiverFound { get; set; }
        public string Notes { get; set; }
        public int? TruckId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public byte[] Version { get; set; }
    }
}