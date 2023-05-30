using Autofac;
using Infrastructure.DbContexts;
using Infrastructure.Respositories;
using Infrastructure.Services;
using Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
              .WithParameter("connectionString", _connectionString)
              .WithParameter("migrationAssemblyName", _migrationAssemblyName)
              .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();

            //Repository
            builder.RegisterType<OrderRepository>().As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ItemRepository>().As<IItemRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>()
                .InstancePerLifetimeScope();

            //Services
            builder.RegisterType<OrderService>().As<IOrderService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ItemService>().As<IItemService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderItemService>().As<IOrderItemService>()
                .InstancePerLifetimeScope();

            //Unit of Works
            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
