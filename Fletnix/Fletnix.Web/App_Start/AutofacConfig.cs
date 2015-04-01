using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
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

            // MVC
            builder.RegisterModelBinderProvider();
            builder.RegisterModelBinders();

            var currentAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(currentAssembly);

            // Web Api
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(currentAssembly);

            var container = builder.Build();
            // MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // Web Api
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        } 
    }
}