using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace SoundCloudAndroid.Resources.Model
{
    public class JsonConverter
    {
        public async Task<string> GetStringbyJson(string link)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(link);
            return await message.Content.ReadAsStringAsync();

        }
    }
}