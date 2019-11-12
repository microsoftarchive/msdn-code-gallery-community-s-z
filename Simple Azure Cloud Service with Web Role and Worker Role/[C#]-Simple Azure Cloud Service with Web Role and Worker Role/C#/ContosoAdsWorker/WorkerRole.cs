using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using ContosoAdsCommon;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Microsoft.Azure;

namespace ContosoAdsWorker
{
    public class WorkerRole : RoleEntryPoint
    {
        private CloudQueue imagesQueue;
        private CloudBlobContainer imagesBlobContainer;
        private ContosoAdsContext db;

        public override void Run()
        {
            Trace.TraceInformation("ContosoAdsWorker entry point called");
            CloudQueueMessage msg = null;

            // To make the worker role more scalable, implement multi-threaded and 
            // asynchronous code. See:
            // http://msdn.microsoft.com/en-us/library/ck8bc5c6.aspx
            // http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/web-development-best-practices#async
            while (true)
            {
                try
                {
                    // Retrieve a new message from the queue.
                    // A production app could be more efficient and scalable and conserve
                    // on transaction costs by using the GetMessages method to get
                    // multiple queue messages at a time. See:
                    // http://azure.microsoft.com/en-us/documentation/articles/cloud-services-dotnet-multi-tier-app-storage-5-worker-role-b/#addcode
                    msg = this.imagesQueue.GetMessage();
                    if (msg != null)
                    {
                        ProcessQueueMessage(msg);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                catch (StorageException e)
                {
                    if (msg != null && msg.DequeueCount > 5)
                    {
                        this.imagesQueue.DeleteMessage(msg);
                        Trace.TraceError("Deleting poison queue item: '{0}'", msg.AsString);
                    }
                    Trace.TraceError("Exception in ContosoAdsWorker: '{0}'", e.Message);
                    System.Threading.Thread.Sleep(5000);
                }
            }
        }

        private void ProcessQueueMessage(CloudQueueMessage msg)
        {
            Trace.TraceInformation("Processing queue message {0}", msg);

            // Queue message contains AdId.
            var adId = int.Parse(msg.AsString);
            Ad ad = db.Ads.Find(adId);
            if (ad == null)
            {
                throw new Exception(String.Format("AdId {0} not found, can't create thumbnail", adId.ToString()));
            }

            Uri blobUri = new Uri(ad.ImageURL);
            string blobName = blobUri.Segments[blobUri.Segments.Length - 1];

            CloudBlockBlob inputBlob = this.imagesBlobContainer.GetBlockBlobReference(blobName);
            string thumbnailName = Path.GetFileNameWithoutExtension(inputBlob.Name) + "thumb.jpg";
            CloudBlockBlob outputBlob = this.imagesBlobContainer.GetBlockBlobReference(thumbnailName);

            using (Stream input = inputBlob.OpenRead())
            using (Stream output = outputBlob.OpenWrite())
            {
                ConvertImageToThumbnailJPG(input, output);
                outputBlob.Properties.ContentType = "image/jpeg";
            }
            Trace.TraceInformation("Generated thumbnail in blob {0}", thumbnailName);

            ad.ThumbnailURL = outputBlob.Uri.ToString();
            db.SaveChanges();
            Trace.TraceInformation("Updated thumbnail URL in database: {0}", ad.ThumbnailURL);

            // Remove message from queue.
            this.imagesQueue.DeleteMessage(msg);
        }

        public void ConvertImageToThumbnailJPG(Stream input, Stream output)
        {
            int thumbnailsize = 80;
            int width;
            int height;
            var originalImage = new Bitmap(input);

            if (originalImage.Width > originalImage.Height)
            {
                width = thumbnailsize;
                height = thumbnailsize * originalImage.Height / originalImage.Width;
            }
            else
            {
                height = thumbnailsize;
                width = thumbnailsize * originalImage.Width / originalImage.Height;
            }

            Bitmap thumbnailImage = null;
            try
            {
                thumbnailImage = new Bitmap(width, height);

                using (Graphics graphics = Graphics.FromImage(thumbnailImage))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(originalImage, 0, 0, width, height);
                }

                thumbnailImage.Save(output, ImageFormat.Jpeg);
            }
            finally
            {
                if (thumbnailImage != null)
                {
                    thumbnailImage.Dispose();
                }
            }
        }

        // A production app would also include an OnStop override to provide for
        // graceful shut-downs of worker-role VMs.  See
        // http://azure.microsoft.com/en-us/documentation/articles/cloud-services-dotnet-multi-tier-app-storage-3-web-role/#restarts
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections.
            ServicePointManager.DefaultConnectionLimit = 12;

            // Read database connection string and open database.
            var dbConnString = CloudConfigurationManager.GetSetting("ContosoAdsDbConnectionString");
            db = new ContosoAdsContext(dbConnString);

            // Open storage account using credentials from .cscfg file.
            var storageAccount = CloudStorageAccount.Parse
                (RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));

            Trace.TraceInformation("Creating images blob container");
            var blobClient = storageAccount.CreateCloudBlobClient();
            imagesBlobContainer = blobClient.GetContainerReference("images");
            if (imagesBlobContainer.CreateIfNotExists())
            {
                // Enable public access on the newly created "images" container.
                imagesBlobContainer.SetPermissions(
                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
            }

            Trace.TraceInformation("Creating images queue");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            imagesQueue = queueClient.GetQueueReference("images");
            imagesQueue.CreateIfNotExists();

            Trace.TraceInformation("Storage initialized");
            return base.OnStart();
        }
    }
}
