using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GridExampleMVC.Startup))]
namespace GridExampleMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
