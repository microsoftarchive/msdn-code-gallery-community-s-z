// -----------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Microsoft">
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

using System;
using System.Globalization;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace CorsBlogSample.Controllers
{
    /// <summary>
    /// Main controller class that handles web requests
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// ListBlobs view controller.
        /// </summary>
        /// <returns>ListBlobs ViewResult</returns>
        public ActionResult ListBlobs()
        {
            return View();
        }

        /// <summary>
        /// UploadImage view controller.
        /// </summary>
        /// <returns>UploadImage ViewResult</returns>
        public ActionResult UploadImage()
        {
            return View();
        }

        /// <summary>
        /// QueryTableEntities view controller.
        /// </summary>
        /// <returns>QueryTableEntites ViewResult</returns>
        public ActionResult QueryTableEntities()
        {
            return View();
        }

        /// <summary>
        /// InsertTableEntities view controller.
        /// </summary>
        /// <returns>InsertTableEntities ViewResult</returns>
        public ActionResult InsertTableEntities()
        {
            return View();
        }

        /// <summary>
        /// Returns a SAS for the specified blob that can be used to upload/download the blob
        /// </summary>
        /// <param name="blobName">The blob Name</param>
        /// <returns>ContentResult with a SAS signed URI or an empty string</returns>
        [HttpGet]
        public ActionResult GetBlobSasUrl(string blobName)
        {
            if (!string.IsNullOrEmpty(blobName))
            {
                CloudBlockBlob blob = AzureCommon.ImagesContainer.GetBlockBlobReference(blobName);
                return Content(GetSasForBlob(blob));
            }

            return Content(string.Empty);
        }

        /// <summary>
        /// Returns a SAS for the specified table that can be used to add entities or query table.
        /// </summary>
        /// <param name="tableName">The table name</param>
        /// <returns>ContentResult with a SAS signed URI or an empty string</returns>
        [HttpGet]
        public ActionResult GetTableSasUrl(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                CloudTable table = AzureCommon.TableClient.GetTableReference(tableName);
                return Content(GetSasForTable(table));
            }

            return Content(string.Empty);
        }

        /// <summary>
        /// Creates the specified table if it doesn't exist
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns>ContentResult to indicate if table creation is successful for the given table name</returns>
        [HttpPost]
        public ActionResult CreateTableIfNotExists(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                CloudTable table = AzureCommon.TableClient.GetTableReference(tableName);
                if (table.Exists())
                {
                    return Content("Table already exist");
                }

                try
                {
                    table.Create();
                }
                catch (Exception)
                {
                    return Content("Failed to create table");
                }

                return Content("Table created");
            }
            else
            {
                return Content("Please specify valid table name");
            }
        }

        /// <summary>
        /// Generate a blob SAS
        /// </summary>
        /// <param name="blob">CloudBlockBlob</param>
        /// <returns>SAS string for the specified CLoudBlockBlob</returns>
        private static string GetSasForBlob(CloudBlockBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob can't be null");
            }

            var sas = blob.GetSharedAccessSignature(
                new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30),
                });
            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri, sas);
        }

        /// <summary>
        /// Generate a table SAS
        /// </summary>
        /// <param name="table">CloudTable</param>
        /// <returns>The SAS string for the CloudTable specified</returns>
        private static string GetSasForTable(CloudTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("Table can't be null");
            }

            string sas = table.GetSharedAccessSignature(
                new SharedAccessTablePolicy()
                {
                    Permissions = SharedAccessTablePermissions.Update | SharedAccessTablePermissions.Query | SharedAccessTablePermissions.Add | SharedAccessTablePermissions.Delete,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(30),
                },
                null, /* accessPolicyIdentifier */
                null, /* startPartitionKey */
                null, /* startRowKey */
                null, /* endPartitionKey */
                null);  /* endRowKey */

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", table.Uri, sas);
        }
    }
}
