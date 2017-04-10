using Microsoft.Owin;
using PropertyAgency.Application;

[assembly: OwinStartup(typeof(Startup))]
namespace PropertyAgency.Application
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
