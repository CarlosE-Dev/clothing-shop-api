using Autofac;
using Domain.Services;
using System.Linq;

namespace Shared.IoC
{
    public class ServiceContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseService<>).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces();
        }
    }
}
