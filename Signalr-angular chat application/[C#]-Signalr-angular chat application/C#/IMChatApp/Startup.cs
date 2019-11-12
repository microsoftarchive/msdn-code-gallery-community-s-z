using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IMChatApp.Startup))]

namespace IMChatApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
            app.MapSignalR();
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
