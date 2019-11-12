using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

// ReSharper disable once CheckNamespace
namespace MsdrRu.SimpleWebSocketApp.NET461
{
    public class WebSocketRequestHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public WebSocketRequestHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                await WebSocketRequestHandler.Handle(context, webSocket);
            }

            // Call the next delegate/middleware in the pipeline
            await this.next(context);
        }
    }

    public static class WebSocketRequestHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseWebSocketRequestHandlerMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketRequestHandlerMiddleware>();
        }
    }
}
