// -----------------------------------------------------------------------------------------
// <copyright file="AzureCommon.cs" company="Microsoft">
//    Copyright 2014 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure;

namespace CorsBlogSample
{
    /// <summary>
    /// This class contains the Windows Azure Storage initialization and common functions.
    /// </summary>
    public class AzureCommon
    {
        private static CloudStorageAccount StorageAccount = CloudStorageAccount.DevelopmentStorageAccount;

        public static CloudBlobClient BlobClient
        {
            get;
            private set;
        }

        public static CloudTableClient TableClient
        {
            get;
            private set;
        }

        public static CloudBlobContainer ImagesContainer
        {
            get;
            private set;
        }

        public const string ImageContainerName = "someimagescontainer";

        /// <summary>
        /// Initialize Windows Azure Storage accounts and CORS settings.
        /// </summary>
        public static void InitializeAccountPropeties()
        {
            BlobClient = StorageAccount.CreateCloudBlobClient();
            TableClient = StorageAccount.CreateCloudTableClient();

            InitializeCors(BlobClient, TableClient);

            ImagesContainer = BlobClient.GetContainerReference(AzureCommon.ImageContainerName);
            ImagesContainer.CreateIfNotExists(BlobContainerPublicAccessType.Container);
        }

        /// <summary>
        /// Initialize Windows Azure Storage CORS settings.
        /// </summary>
        /// <param name="blobClient">Windows Azure storage blob client</param>
        /// <param name="tableClient">Windows Azure storage table client</param>
        private static void InitializeCors(CloudBlobClient blobClient, CloudTableClient tableClient)
        {
            // CORS should be enabled once at service startup
            ServiceProperties blobServiceProperties = new ServiceProperties();
            ServiceProperties tableServiceProperties = new ServiceProperties();

            // Nullifying un-needed properties so that we don't
            // override the existing ones
            blobServiceProperties.HourMetrics = null;
            tableServiceProperties.HourMetrics = null;
            blobServiceProperties.MinuteMetrics = null;
            tableServiceProperties.MinuteMetrics = null;
            blobServiceProperties.Logging = null;
            tableServiceProperties.Logging = null;

            // Enable and Configure CORS
            ConfigureCors(blobServiceProperties);
            ConfigureCors(tableServiceProperties);
            
            // Commit the CORS changes into the Service Properties
            blobClient.SetServiceProperties(blobServiceProperties);
            tableClient.SetServiceProperties(tableServiceProperties);
        }

        /// <summary>
        /// Adds CORS rule to the service properties.
        /// </summary>
        /// <param name="serviceProperties">ServiceProperties</param>
        private static void ConfigureCors(ServiceProperties serviceProperties)
        {
            serviceProperties.Cors = new CorsProperties();
            serviceProperties.Cors.CorsRules.Add(new CorsRule()
            {
                AllowedHeaders = new List<string>() { "*" },
                AllowedMethods = CorsHttpMethods.Put | CorsHttpMethods.Get | CorsHttpMethods.Head | CorsHttpMethods.Post,
                AllowedOrigins = new List<string>() { "*" },
                ExposedHeaders = new List<string>() { "*" },
                MaxAgeInSeconds = 1800 // 30 minutes
            });
        }
    }
}