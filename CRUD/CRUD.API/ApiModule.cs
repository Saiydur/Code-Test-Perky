using Autofac;
using CRUD.API.Models;

namespace CRUD.API
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ItemModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderItemModel>().AsSelf()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
