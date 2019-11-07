using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.StorageClient;

namespace SampleApp.Controllers
{
    public class AzureBlobStorageMultipartProvider : MultipartFileStreamProvider
    {
        private CloudBlobContainer _container;
        public AzureBlobStorageMultipartProvider(CloudBlobContainer container)
            : base(Path.GetTempPath())
        {
            _container = container;
            Files = new List<FileDetails>();
        }

        public List<FileDetails> Files { get; set; }

        public override Task ExecutePostProcessingAsync()
        {
            // Upload the files to azure blob storage and remove them from local disk
            foreach (var fileData in this.FileData)
            {
                string fileName = Path.GetFileName(fileData.Headers.ContentDisposition.FileName.Trim('"'));

                // Retrieve reference to a blob
                CloudBlob blob = _container.GetBlobReference(fileName);
                blob.Properties.ContentType = fileData.Headers.ContentType.MediaType;
                blob.UploadFile(fileData.LocalFileName);
                File.Delete(fileData.LocalFileName);
                Files.Add(new FileDetails
                {
                    ContentType = blob.Properties.ContentType,
                    Name = blob.Name,
                    Size = blob.Properties.Length,
                    Location = blob.Uri.AbsoluteUri
                });
            }

            return base.ExecutePostProcessingAsync();
        }
    }
}