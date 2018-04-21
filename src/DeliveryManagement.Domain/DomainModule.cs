using Autofac;
using DeliveryManagement.Domain.Core;
using DeliveryManagement.Domain.Shipments;
using System.Linq;

namespace DeliveryManagement.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder moduleBuilder)
        {
            // Mapping
            moduleBuilder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .Where(t => typeof(IModelConfiguration).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .SingleInstance();

            moduleBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            moduleBuilder.RegisterType<ShipmentsService>().As<IShipmentsService>().InstancePerLifetimeScope();
        }
    }
}
