using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NikahMetromoniApp.Startup))]
namespace NikahMetromoniApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
