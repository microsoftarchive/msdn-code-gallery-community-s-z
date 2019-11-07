using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalWPFHost.Startup))]

namespace SignalWPFHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            // 允许CORS跨域
            //app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
