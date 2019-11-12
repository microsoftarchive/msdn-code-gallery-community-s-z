using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Win32;
using Microsoft.Synchronization.Files;
using Microsoft.Synchronization.SimpleProviders;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;


namespace AzureBlobSync
{
    internal struct SyncedBlobAttributes
    {
        internal string _name;
        internal DateTime _lastModifiedTime;

        internal SyncedBlobAttributes(string name, DateTime lastModifiedTime)
        {
            _name = name;
            _lastModifiedTime = lastModifiedTime;
        }
    }


    internal class AzureBlobStore
    {
        public const uint MaxFileNameLength = 255;

        private string _targetContainer = null;
        private CloudBlobClient _blobStorage = null;

        private const string FileNameKey = "FileName";
        private const string AttributesKey = "Attributes";
        private const string CreationTimeKey = "CreationTime";
        private const string LastAccessTimeKey = "LastAccessTime";
        private const string LastWriteTimeKey = "LastWriteTime";
        private const string RelativePathKey = "RelativePath";
        private const string PathWithNameKey = "PathWithName";
        private const string SizeKey = "Size";
        private const string IsDirectory = "IsDirectory";


        internal AzureBlobStore(
            string targetContainer, 
            CloudStorageAccount storageAccount
            )
        {
            _blobStorage = storageAccount.CreateCloudBlobClient();
            _targetContainer = targetContainer;

            CreateContainer();
        }


        void CreateContainer()
        {
            //
            // Azure Blob Storage requires some delay between deleting and recreating containers.  This loop 
            // compensates for that delay if the first attempt to creat the container fails then wait 30 
            // seconds and try again.  While the service actually returns error 409 with the correct description
            // of the failure the storage client interprets that as the container existing and the
            // call to CreateContainer returns false.  For now just work around this by attempting to create
            // a test blob in the container bofore proceeding.
            //
            for (int i = 1; i <= 10; i++)
            {
                CloudBlobContainer blobContainer = Container;
                blobContainer.CreateIfNotExist();

                MemoryStream stream = new MemoryStream();
                try
                {
                    blobContainer.GetBlobReference("__testblob").UploadFromStream(stream);
                    blobContainer.GetBlobReference("__testblob").Delete();

                    var permissions = blobContainer.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    blobContainer.SetPermissions(permissions);

                    break;
                }
                catch (StorageClientException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Failed creating container, retrying in 30 seconds...");
                    
                    // Wait 30 seconds and retry
                    System.Threading.Thread.Sleep(30000);
                    if (i == 10)
                    {
                        // Only retry 10 times
                        throw;
                    }
                }
            }
        }


        private CloudBlobContainer Container
        {
            get
            {
                return _blobStorage.GetContainerReference(_targetContainer);
            }
        }


        // ListBlobs is called by AzureBlobSyncProvider.EnumerateItems.  It walks through the items in the store building up the necessary information
        // to detect changes.
        internal List<ItemFieldDictionary> ListBlobs()
        {
            List<ItemFieldDictionary> items = new List<ItemFieldDictionary>();

            // Include all items in the listing including those with path like ('/') file names
            BlobRequestOptions opts = new BlobRequestOptions();
            opts.UseFlatBlobListing = true;

            foreach (IListBlobItem o in Container.ListBlobs(opts))
            {
                CloudBlob blob = Container.GetBlobReference(o.Uri.ToString());
                blob.FetchAttributes();
                ItemFieldDictionary dict = new ItemFieldDictionary();
                dict.Add(new ItemField(ItemFields.CUSTOM_FIELD_NAME, typeof(string), o.Uri.ToString()));
                dict.Add(new ItemField(ItemFields.CUSTOM_FIELD_TIMESTAMP, typeof(ulong), (ulong)blob.Properties.LastModifiedUtc.ToBinary()));
                items.Add(dict);
            }

            return items;
        }


        // Create a file retriever for the blob with the given name.
        //   Note that this code attempts to handle
        internal FileRetriever GetFileRetriever(
            string name,
            DateTime expectedLastUpdate
            )
        {
            DateTime creationTime;
            DateTime lastAccessTime;
            DateTime lastWriteTime;
            FileStream stream = null;
            long size = 0;
            string relativePath;
            FileAttributes fileAttributes = 0;
            string tempFileName = Path.GetTempFileName();
            CloudBlob blob = Container.GetBlobReference(name);
            BlobProperties props = blob.Properties;

            // Specify an optimistic concurrency check to prevent races with other endpoints syncing at the same time.
            BlobRequestOptions opts = new BlobRequestOptions();
            opts.AccessCondition = AccessCondition.IfNotModifiedSince(expectedLastUpdate);

            try
            {
                blob.DownloadToFile(tempFileName);
            }
            catch (StorageException e)
            {
                if (e.ErrorCode == StorageErrorCode.BlobAlreadyExists || e.ErrorCode == StorageErrorCode.ConditionFailed)
                {
                    throw new ApplicationException("Concurrency Violation", e);
                }
                throw;
            }

            string fileName;
            string pathWithName;

            fileName = blob.Metadata[AzureBlobStore.FileNameKey];
            creationTime = DateTime.Parse(blob.Metadata[AzureBlobStore.CreationTimeKey]);
            lastAccessTime = DateTime.Parse(blob.Metadata[AzureBlobStore.LastAccessTimeKey]);
            lastWriteTime = DateTime.Parse(blob.Metadata[AzureBlobStore.LastWriteTimeKey]);
            relativePath = blob.Metadata[AzureBlobStore.RelativePathKey];
            fileAttributes = (FileAttributes)long.Parse(blob.Metadata[AzureBlobStore.AttributesKey]);
            if( !bool.Parse(blob.Metadata[AzureBlobStore.IsDirectory]) )
            {
                // Special handling for directories
                stream = File.OpenRead(tempFileName);
                size = long.Parse(blob.Metadata[AzureBlobStore.SizeKey]);
            }

            pathWithName = blob.Metadata[AzureBlobStore.PathWithNameKey];

            // Note that the IsDirectory property for the FileData object is pulled from the Attributes 
            FileData fd = new FileData(
                pathWithName,
                fileAttributes,
                creationTime,
                lastAccessTime,
                lastWriteTime,
                size);

            return new FileRetriever(fd, relativePath, stream);
        }


        // Create the name value collection of associated file metadata for the given blob.
        private void SetupMetadata(
            NameValueCollection metadata,
            FileData fileData, 
            string relativePath
            )
        {
            // Create metadata to be associated with the blob 
            metadata[AzureBlobStore.FileNameKey] = fileData.Name;
            metadata[AzureBlobStore.AttributesKey] = ((long)fileData.Attributes).ToString();
            metadata[AzureBlobStore.CreationTimeKey] = fileData.CreationTime.ToString();
            metadata[AzureBlobStore.LastAccessTimeKey] = fileData.LastAccessTime.ToString();
            metadata[AzureBlobStore.LastWriteTimeKey] = fileData.LastWriteTime.ToString();
            
            // Azure Blob Storage does not seem to like null or empty string values.  So if that is what would be written
            // don't write anything at all.
            if( relativePath != "" )
            {
                metadata[AzureBlobStore.RelativePathKey] = relativePath;
            }
            metadata[AzureBlobStore.PathWithNameKey] = fileData.RelativePath;
            metadata[AzureBlobStore.SizeKey] = fileData.Size.ToString();
            metadata[AzureBlobStore.IsDirectory] = fileData.IsDirectory.ToString();
        }


        // Called by AzureBlobSyncProvider.InsertItem.
        internal SyncedBlobAttributes InsertFile(FileData fileData, string relativePath, Stream dataStream)
        {
            if (fileData.Name.Length > MaxFileNameLength)
            {
                throw new ApplicationException("Name Too Long");
            }

            CloudBlob blob = Container.GetBlobReference(fileData.RelativePath.ToLower());
            BlobProperties blobProperties = blob.Properties;
            DateTime uninitTime = blobProperties.LastModifiedUtc;
            SetupMetadata(blob.Metadata, fileData, relativePath);
            blobProperties.ContentType = LookupMimeType(Path.GetExtension(fileData.Name));

            if (fileData.IsDirectory)
            {
                // Directories have no stream
                dataStream = new MemoryStream();
            }

            // Specify an optimistic concurrency check to prevent races with other endpoints syncing at the same time.
            BlobRequestOptions opts = new BlobRequestOptions();
            opts.AccessCondition = AccessCondition.IfNotModifiedSince(uninitTime);
            
            try
            {
                blob.UploadFromStream(dataStream,opts);
            }
            catch (StorageException e)
            {
                if (e.ErrorCode == StorageErrorCode.BlobAlreadyExists || e.ErrorCode == StorageErrorCode.ConditionFailed)
                {
                    throw new ApplicationException("Concurrency Violation", e);
                }
                throw;
            }

            blobProperties = blob.Properties;
            SyncedBlobAttributes attributes = new SyncedBlobAttributes(blob.Uri.ToString(), blobProperties.LastModifiedUtc);

            return attributes;
        }


        // Called by AzureBlobSyncProvider.UpdateItem to help with writing item updates
        internal SyncedBlobAttributes UpdateFile(
            string oldName,
            FileData fileData, 
            string relativePath,
            Stream dataStream, 
            DateTime expectedLastModified
            )
        {
            CloudBlob blob = Container.GetBlobReference(oldName);
            try
            {
                blob.FetchAttributes();
            }
            catch (StorageClientException e)
            {
                // Someone may have deleted the blob in the mean time
                if (e.ErrorCode == StorageErrorCode.BlobNotFound)
                {
                    throw new ApplicationException("Concurrency Violation", e);
                }
                throw;
            }
            BlobProperties blobProperties = blob.Properties;

            //
            // For directories create an empty data stream
            //
            if (dataStream == null)
            {
                dataStream = new MemoryStream();
            }

            SetupMetadata(blob.Metadata, fileData, relativePath);
            blobProperties.ContentType = LookupMimeType(Path.GetExtension(fileData.Name));

            // Specify an optimistic concurrency check to prevent races with other endpoints syncing at the same time.
            BlobRequestOptions opts = new BlobRequestOptions();
            opts.AccessCondition = AccessCondition.IfNotModifiedSince(expectedLastModified);

            try
            {
                blob.UploadFromStream(dataStream, opts);
            }
            catch (StorageClientException e)
            {
                // Someone must have modified the file in the mean time
                if (e.ErrorCode == StorageErrorCode.BlobNotFound || e.ErrorCode == StorageErrorCode.ConditionFailed)
                {
                    throw new ApplicationException("Storage Error", e);
                }
                throw;
            }

            blobProperties = blob.Properties;
            SyncedBlobAttributes attributes = new SyncedBlobAttributes(blob.Uri.ToString(), blobProperties.LastModifiedUtc);

            return attributes;
        }


        // Called by AzureBlobSyncProvider.DeleteItem to help with removing blobs.
        internal void DeleteFile(
            string name,
            DateTime expectedLastModified
            )
        {
            CloudBlob blob = Container.GetBlobReference(name);
            try
            {
                blob.FetchAttributes();
            }
            catch (StorageClientException e)
            {
                // Someone may have deleted the blob in the mean time
                if (e.ErrorCode == StorageErrorCode.BlobNotFound)
                {
                    throw new ApplicationException("Concurrency Violation", e);
                }
                throw;
            }
            BlobProperties blobProperties = blob.Properties;

            bool isDirectory = bool.Parse(blob.Metadata[AzureBlobStore.IsDirectory]);
            // If this is a directory then we need to look for children.
            if (isDirectory)
            {
                IEnumerable<IListBlobItem> items = Container.ListBlobs();
                if (items.Count() > 0)
                {
                    throw new ApplicationException("Constraint Violation - Directory Not Empty");
                }
            }

            // Specify an optimistic concurrency check to prevent races with other endpoints syncing at the same time.
            BlobRequestOptions opts = new BlobRequestOptions();
            opts.AccessCondition = AccessCondition.IfNotModifiedSince(expectedLastModified);

            try
            {
                blob.Delete(opts);
            }
            catch( StorageClientException e )
            {
                // Someone must have modified the file in the mean time
                if (e.ErrorCode == StorageErrorCode.BlobNotFound || e.ErrorCode == StorageErrorCode.ConditionFailed)
                {
                    throw new ApplicationException("Concurrency Violation", e);
                }
                throw;
             }
        }
        
        
        // Specify the mime type correctly for uploaded files.
        private string LookupMimeType(string extension)
        {
            extension = extension.ToLower();

            RegistryKey key = Registry.ClassesRoot.OpenSubKey("MIME\\Database\\Content Type");
            try
            {
                foreach (string keyName in key.GetSubKeyNames())
                {
                    RegistryKey temp = key.OpenSubKey(keyName);
                    if (extension.Equals(temp.GetValue("Extension")))
                    {
                        return keyName;
                    }
                }
            }
            finally
            {
                key.Close();
            }
            return "";
        }


        // Helper method called to figure out the root path for all files in blob storage.
        internal string GetRootPath()
        {
            return Container.Uri.AbsoluteUri;
        }
    }
}
