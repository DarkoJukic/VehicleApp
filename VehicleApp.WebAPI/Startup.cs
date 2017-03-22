using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularVehicleApp.Startup))]
namespace AngularVehicleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
