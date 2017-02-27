using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppLabs.Startup))]
namespace AppLabs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
