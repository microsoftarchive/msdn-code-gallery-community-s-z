using System.ServiceProcess;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalRWindowsService.Startup))]
namespace SignalRWindowsService
{
    public partial class SignalRChat : ServiceBase
    {
        
        public SignalRChat()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            if (!System.Diagnostics.EventLog.SourceExists("SignalRChat"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "SignalRChat", "Application");
            }
            eventLog1.Source = "SignalRChat";
            eventLog1.Log = "Application";

            eventLog1.WriteEntry("In OnStart");
            string url = "http://localhost:8080";
            WebApp.Start(url);
            
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
