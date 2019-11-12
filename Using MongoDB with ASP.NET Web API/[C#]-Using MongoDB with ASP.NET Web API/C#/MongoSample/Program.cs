using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.SelfHost;
using System.Net.Http;
using MongoSample.Models;

namespace MongoSample
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

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                // Create server
                server = new HttpSelfHostServer(config);

                // Start listening
                server.OpenAsync().Wait();

                // Run HttpClient issuing requests
                RunClient();

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

        /// <summary>
        /// Runs an HttpClient issuing a GET and a POST request against the controller.
        /// The controller also supports PUT and DELETE.
        /// </summary>
        static void RunClient()
        {
            HttpClient client = new HttpClient();

            // Get the first two entries using the ODate query '$top=2'
            client.GetAsync("http://localhost:8080/api/contacts?$top=2").ContinueWith(
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
                            Console.WriteLine("\nGot first two entries: {0}\n", readTask.Result);
                        });
                });

            // Post a new entry and show result
            Contact contact = new Contact
            {
                Email = "new@example.com",
                Name = "new",
                Phone = "000 000 0000",
            };

            client.PostAsync("http://localhost:8080/api/contacts", contact, "application/json").ContinueWith(
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
                            Console.WriteLine("\nAdded entry: {0}\n", readTask.Result);
                        });
                });
        }
    }
}
