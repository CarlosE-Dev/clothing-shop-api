using Autofac;
using Infra.Repositories;
using System.Linq;

namespace Shared.IoC
{
    public class RepositoryContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces();
        }
    }
}
