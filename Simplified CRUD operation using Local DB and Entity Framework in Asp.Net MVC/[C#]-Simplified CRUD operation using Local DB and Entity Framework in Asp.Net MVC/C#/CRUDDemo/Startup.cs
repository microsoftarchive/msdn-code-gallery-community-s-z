using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDDemo.Startup))]
namespace CRUDDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
