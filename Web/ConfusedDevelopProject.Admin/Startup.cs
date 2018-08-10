using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConfusedDevelopProject.Admin.Startup))]
namespace ConfusedDevelopProject.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
