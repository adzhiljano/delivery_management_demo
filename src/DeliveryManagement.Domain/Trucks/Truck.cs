using DeliveryManagement.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeliveryManagement.Domain.Trucks
{
    public partial class Shipment
    {
        public Shipment() { }

        public Shipment(
            TruckType truckType,
            string ownerName,
            string ownerPhone,
            string ownerEmail) : this()
        {
            this.CreateDate = this.ModifyDate = DateTime.Now;
            this.TruckType = truckType;
            this.OwnerName = ownerName;
            this.OwnerPhone = ownerPhone;
            this.OwnerEmail = ownerEmail;
        }

        public int TruckId { get; private set; }
        public TruckType TruckType { get; private set; }
        public string OwnerName { get; private set; }
        public string OwnerPhone { get; private set; }
        public string OwnerEmail { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime ModifyDate { get; private set; }
        public byte[] Version { get; private set; }
    }

    public class UserMap : IModelConfiguration
    {
        public void AddEntityTypeModel(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Shipment>();

            // Primary Key
            entity.HasKey(t => t.TruckId);

            // Properties
            entity.Property(t => t.TruckId)
                .ValueGeneratedOnAdd();

            entity.Property(t => t.TruckId)
                .IsRequired();

            entity.Property(t => t.TruckType)
                .IsRequired();

            entity.Property(t => t.OwnerName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(t => t.OwnerPhone)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(t => t.OwnerEmail)
                .HasMaxLength(200);

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
            entity.ToTable("Trucks");
            entity.Property(t => t.TruckId).HasColumnName("TruckId");
            entity.Property(t => t.TruckType).HasColumnName("TruckType");
            entity.Property(t => t.OwnerName).HasColumnName("OwnerName");
            entity.Property(t => t.OwnerPhone).HasColumnName("OwnerPhone");
            entity.Property(t => t.OwnerEmail).HasColumnName("OwnerEmail");
            entity.Property(t => t.CreateDate).HasColumnName("CreateDate");
            entity.Property(t => t.ModifyDate).HasColumnName("ModifyDate");
            entity.Property(t => t.Version).HasColumnName("Version");

            // Relationships
        }
    }
}