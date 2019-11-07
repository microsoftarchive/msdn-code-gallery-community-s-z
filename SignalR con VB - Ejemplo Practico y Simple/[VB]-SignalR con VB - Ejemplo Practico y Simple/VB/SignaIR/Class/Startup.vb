Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web
Imports System.Web.Routing
Imports Microsoft.AspNet.SignalR
Imports Microsoft.Owin.Security
Imports Owin
Imports Microsoft.Owin

<Assembly: OwinStartup(GetType(NotificacionesSignalr.Startup))> 
Namespace NotificacionesSignalr
    Public Class Startup
        Public Sub Configuration(app As IAppBuilder)
            ' Any connection or hub wire up and configuration should go here
            app.MapSignalR()
        End Sub
    End Class
End Namespace

