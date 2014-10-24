using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fletnix.Web.Startup))]
namespace Fletnix.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
