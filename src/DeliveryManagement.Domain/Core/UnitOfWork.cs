using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace DeliveryManagement.Domain.Core
{
    internal class UnitOfWork : DbContext, IUnitOfWork
    {
        private DomainAppSettings appSettings { get; set; }
        private IEnumerable<IModelConfiguration> modelConfigurations { get; set; }

        public UnitOfWork(IOptions<DomainAppSettings> appSettings, IEnumerable<IModelConfiguration> modelConfigurations)
        {
            this.appSettings = appSettings.Value;
            this.modelConfigurations = modelConfigurations;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.appSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var modelConfiguration in modelConfigurations)
            {
                modelConfiguration.AddEntityTypeModel(modelBuilder);
            }
        }

        public void Save()
        {
            try
            {
                this.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Entity already modified");
            }
        }
    }
}
