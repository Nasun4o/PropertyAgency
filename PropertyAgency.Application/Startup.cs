using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PropertyAgency.Application.Startup))]
namespace PropertyAgency.Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
