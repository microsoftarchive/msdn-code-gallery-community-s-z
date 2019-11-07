using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IgniteUI.Startup))]
namespace IgniteUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
