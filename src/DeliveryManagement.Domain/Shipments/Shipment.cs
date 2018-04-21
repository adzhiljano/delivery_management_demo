using DeliveryManagement.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeliveryManagement.Domain.Shipments
{
    public partial class Shipment
    {
        public Shipment() { }

        public Shipment(
            int shipmentId,
            int truckId,
            string senderName,
            string senderAddress,
            string receiverName,
            string receiverAddress,
            int packagesCount) : this()
        {
            this.CreateDate = this.ModifyDate = DateTime.Now;
            this.TrackingNumber = Guid.NewGuid();
            this.Status = ShipmentStatus.OutForDelivery;
            this.ShipmentId = shipmentId;
            this.TruckId = truckId;
            this.SenderName = senderName;
            this.SenderAddress = senderAddress;
            this.ReceiverName = receiverName;
            this.ReceiverAddress = receiverAddress;
            this.PackagesCount = packagesCount;
        }

        public int ShipmentId { get; private set; }
        public Guid TrackingNumber { get; private set; }
        public string SenderName { get; private set; }
        public string SenderAddress { get; private set; }
        public string ReceiverName { get; private set; }
        public string ReceiverAddress { get; private set; }
        public int PackagesCount { get; private set; }
        public ShipmentStatus Status { get; private set; }
        public bool? HasDamagedPackages { get; private set; }
        public bool? ReceiverFound { get; private set; }
        public string Notes { get; private set; }
        public int? TruckId { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime ModifyDate { get; private set; }
        public byte[] Version { get; private set; }

        public void ChangeStatus(ShipmentStatus status, bool? hasDamagedPackages = null, bool? receiverFound = null, string notes = null)
        {
            if((status == ShipmentStatus.Delivered && !hasDamagedPackages.HasValue && !receiverFound.HasValue) ||
               (status == ShipmentStatus.HeldInTruck && String.IsNullOrEmpty(notes)))
            {
                throw new Exception("Validation error");
            }
            this.SetStatus(status);
            this.SetAttributes(hasDamagedPackages, receiverFound, notes);
        }

        private void SetAttributes(bool? hasDamagedPackages, bool? receiverFound, string notes)
        {
            this.HasDamagedPackages = hasDamagedPackages;
            this.ReceiverFound = receiverFound;
            this.Notes = notes;
            this.ModifyDate = DateTime.Now;
        }

        private void SetStatus(ShipmentStatus status)
        {
            if((this.Status == ShipmentStatus.OutForDelivery && status == ShipmentStatus.OutForDelivery) ||
               (this.Status != ShipmentStatus.OutForDelivery && status != ShipmentStatus.OutForDelivery))
            {
                throw new Exception("Validation error");
            }
            this.Status = status;
            this.ModifyDate = DateTime.Now;
        }
    }

    public class UserMap : IModelConfiguration
    {
        public void AddEntityTypeModel(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Shipment>();

            // Primary Key
            entity.HasKey(t => t.ShipmentId);

            // Properties
            entity.Property(t => t.ShipmentId)
                .ValueGeneratedOnAdd();

            entity.Property(t => t.ShipmentId)
                .IsRequired();

            entity.Property(t => t.TrackingNumber)
                .IsRequired();

            entity.Property(t => t.SenderName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(t => t.SenderAddress)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(t => t.ReceiverName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(t => t.ReceiverAddress)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(t => t.PackagesCount)
                .IsRequired();

            entity.Property(t => t.Status)
                .IsRequired();

            entity.Property(t => t.Notes)
                .HasMaxLength(500);

            entity.Property(t => t.CreateDate)
                .IsRequired();

            entity.Property(t => t.ModifyDate)
                .IsRequired();

            entity.Property(t => t.Version)
                .IsRequired()
                .HasMaxLength(8)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            // Table & Column Mappings
            entity.ToTable("Shipments");
            entity.Property(t => t.ShipmentId).HasColumnName("ShipmentId");
            entity.Property(t => t.TrackingNumber).HasColumnName("TrackingNumber");
            entity.Property(t => t.SenderName).HasColumnName("SenderName");
            entity.Property(t => t.SenderAddress).HasColumnName("SenderAddress");
            entity.Property(t => t.ReceiverAddress).HasColumnName("ReceiverAddress");
            entity.Property(t => t.PackagesCount).HasColumnName("PackagesCount");
            entity.Property(t => t.Status).HasColumnName("Status");
            entity.Property(t => t.HasDamagedPackages).HasColumnName("HasDamagedPackages");
            entity.Property(t => t.ReceiverFound).HasColumnName("ReceiverFound");
            entity.Property(t => t.Notes).HasColumnName("Notes");
            entity.Property(t => t.TruckId).HasColumnName("TruckId");
            entity.Property(t => t.CreateDate).HasColumnName("CreateDate");
            entity.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            entity.Property(t => t.Version).HasColumnName("Version");

            // Relationships
        }
    }
}