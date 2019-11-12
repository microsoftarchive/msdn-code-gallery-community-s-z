//---------------------------------------------------------------------------------
// Copyright (c) 2014, Microsoft Corporation
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//---------------------------------------------------------------------------------

namespace Microsoft.ServiceBus.Samples.EventHubHttpClient
{
    using System;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    class HttpClientHelper
    {
        const string ApiVersion = "&api-version=2014-05";

        HttpClient httpClient;
        string address;

        public HttpClientHelper(string address, string token)
        {
            this.httpClient = new HttpClient();
            this.address = address;
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            httpClient.DefaultRequestHeaders.Add("ContentType", "application/atom+xml;type=entry;charset=utf-8");
        }

        public async Task<byte[]> GetEntity()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.GetAsync(this.address + "?timeout=60" + ApiVersion);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("GetEntity failed: " + ex.Message);
            }
            byte[] entityDescription = await response.Content.ReadAsByteArrayAsync();
            return entityDescription;
        }

        // Create event hub. Returns 0 on success, 1 if event hub exists, -1 if event hub could not be created.
        public async Task<int> CreateEntity(byte[] entityDescription)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PutAsync(this.address + "?timeout=60" + ApiVersion, new ByteArrayContent(entityDescription));
                response.EnsureSuccessStatusCode();
                return 0;
            }
            catch (HttpRequestException ex)
            {
                if (response != null)
                {
                    Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    if ((int)response.StatusCode == 409)
                    {
                        Console.WriteLine("Entity " + this.address + " already exists.");
                        return 1;
                    }
                }
                Console.WriteLine("CreateEntity failed: " + ex.Message);
                return -1;
            }
        }

        public async Task UpdateEntity(byte[] entityDescription)
        {
            httpClient.DefaultRequestHeaders.Add("If-Match", "*");
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PutAsync(this.address + "?timeout=60" + ApiVersion, new ByteArrayContent(entityDescription));
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                if (response != null)
                {
                    Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                    if ((int)response.StatusCode == 409)
                    {
                        Console.WriteLine("Entity " + this.address + " already exists.");
                        return;
                    }
                }
                Console.WriteLine("UpdateEntity failed: " + ex.Message);
            }
        }

        public async Task DeleteEntity()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.DeleteAsync(this.address + "?timeout=60" + ApiVersion);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("DeleteEntity failed: " + ex.Message);
            }
        }

        public async Task SendMessage(string messageBody, NameValueCollection customProperties = null)
        {
            HttpContent postContent = new ByteArrayContent(Encoding.UTF8.GetBytes(messageBody));

            // Add custom properties.
            if (customProperties != null)
            {
                foreach (string key in customProperties)
                {
                    postContent.Headers.Add(key, customProperties.GetValues(key));
                }
            }
            
            // Send message.
            HttpResponseMessage response = null;
            try
            {
                response = await this.httpClient.PostAsync(this.address + "/messages" + "?timeout=60" + ApiVersion, postContent);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("SendMessage failed: " + ex.Message);
            }
        }
    }
}
