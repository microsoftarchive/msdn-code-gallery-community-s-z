using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.SelfHost;
using JsonNetSample.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JsonNetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpSelfHostServer server = null;
            try
            {
                // Set up server configuration
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost:8080");
                config.Routes.MapHttpRoute("Default", "{controller}", new { controller = "Home" });

                // Create Json.Net formatter serializing DateTime using the ISO 8601 format
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                serializerSettings.Converters.Add(new IsoDateTimeConverter());
                config.Formatters[0] = new JsonNetFormatter(serializerSettings);

                // Create server
                server = new HttpSelfHostServer(config);

                // Start listening
                server.OpenAsync().Wait();

                // Create HttpClient, do an HTTP GET on the controller, and show the output
                HttpClient client = new HttpClient();
                client.GetAsync("http://localhost:8080").ContinueWith(
                    (requestTask) =>
                    {
                        // Get HTTP response from completed task.
                        HttpResponseMessage response = requestTask.Result;

                        // Check that response was successful or throw exception
                        response.EnsureSuccessStatusCode();

                        // Read response asynchronously as string and write out
                        response.Content.ReadAsStringAsync().ContinueWith(
                            (readTask) =>
                            {
                                Console.WriteLine(readTask.Result);
                            });
                    });

                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();

            }
            finally
            {
                if (server != null)
                {
                    // Stop listening
                    server.CloseAsync().Wait();
                }
            }
        }
    }
}
