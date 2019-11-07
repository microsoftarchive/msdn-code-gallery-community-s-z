using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TDD.Web.Startup))]
namespace TDD.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
