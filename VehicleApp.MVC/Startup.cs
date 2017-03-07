using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleApp.MVC.Startup))]
namespace VehicleApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
