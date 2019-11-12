using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoUoW.UI.Startup))]
namespace DemoUoW.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
