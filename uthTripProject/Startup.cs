using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uthTripProject.Startup))]
namespace uthTripProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
