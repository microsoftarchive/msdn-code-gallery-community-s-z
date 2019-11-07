using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrmMobileSample
{
    public static class OrganizationServiceProxy
    {
        private static HttpClient httpClient;

        public static async Task Authenticate()
        {
            var auth = DependencyService.Get<IService>();
            var authResult = await auth.Authenticate(Constants.Authority, Constants.Resource, Constants.ClientId, Constants.RedirectUri);

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            httpClient.BaseAddress = new Uri(Constants.Resource + "/api/data/v8.1/");
            httpClient.Timeout = new TimeSpan(0, 2, 0);
            httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
            httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<IEnumerable<CrmTask>> GetTasks()
        {
            var queryOptions = "tasks?$select=subject&$orderby=subject";
            HttpResponseMessage response = await httpClient.GetAsync(queryOptions);
            var stringResult = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<CrmResult>(stringResult);
            return tasks.value;
        }

        public static async Task CreateTask(CrmTask task)
        {
            var strTask = JsonConvert.SerializeObject(task);
            HttpRequestMessage createRequest = new HttpRequestMessage(HttpMethod.Post, "tasks");
            createRequest.Content = new StringContent(strTask, Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(createRequest);
            var strRes = await response.Content.ReadAsStringAsync();
        }
    }

    public class CrmResult
    {
        public IEnumerable<CrmTask> value { get; set; }
    }

    public class CrmTask
    {
        public Guid activityid { get; set; }
        public string description { get; set; }
        public string subject { get; set; }
    }
}
