using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Fletnix.EF;
using Fletnix.EF.Repositories;

namespace Fletnix.Web
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FletnixDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(BaseRepository<>)).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterModelBinderProvider();
            builder.RegisterModelBinders();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        } 
    }
}