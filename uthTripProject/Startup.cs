using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UthTripProject.Startup))]
namespace UthTripProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
