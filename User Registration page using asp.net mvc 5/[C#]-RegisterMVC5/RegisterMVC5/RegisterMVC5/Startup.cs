using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegisterMVC5.Startup))]
namespace RegisterMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
