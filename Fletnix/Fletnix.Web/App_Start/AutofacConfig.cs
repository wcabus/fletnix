using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Fletnix.Domain.Caching;
using Fletnix.EF;
using Fletnix.EF.Repositories;
using Fletnix.EF.Services;
using Fletnix.Web.Areas.Administration.Controllers;
using Fletnix.Web.Caching;

namespace Fletnix.Web
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            //DB Context
            builder.RegisterType<FletnixDbContext>().AsSelf().InstancePerRequest();

            //Repositories
            builder.RegisterGeneric(typeof(BaseRepository<>)).AsImplementedInterfaces().InstancePerRequest();

            //Services
            builder.RegisterAssemblyTypes(typeof(VideoService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<CacheProvider>().
                As<ICacheProvider>().SingleInstance();

            builder.RegisterType<Cache>().AsSelf().SingleInstance();

            builder.RegisterModelBinderProvider();
            builder.RegisterModelBinders();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        } 
    }
}