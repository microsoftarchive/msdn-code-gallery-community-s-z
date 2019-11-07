using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureBlobSync
{
    class AzureBlobSync
    {
        static string _containerName;
        static string _localPathName;
        static bool _pause;

        static void Main(string[] args)
        {
            _pause = false;
            try
            {
                if (!ParseArgs(args))
                {
                    PrintUsage();
                    Environment.Exit(-1);
                }

                if (!Directory.Exists(_localPathName))
                {
                    Console.WriteLine("Please ensure that the local target directory exists.");
                    Environment.Exit(-1);
                }

                //
                // Setup Store and Provider
                //
                string accountName = ConfigurationManager.AppSettings.Get("AccountName");
                string accountKey = ConfigurationManager.AppSettings.Get("AccountSharedKey");
                string storageURL = ConfigurationManager.AppSettings.Get("AccountStorageURL");
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey(accountName, accountKey), true);

                AzureBlobStore blobStore = new AzureBlobStore(_containerName, storageAccount);
                Console.WriteLine("Successfully created/attached to container {0}.", _containerName);
                AzureBlobSyncProvider azureProvider = new AzureBlobSyncProvider(_containerName, blobStore);
                azureProvider.ApplyingChange += new EventHandler<ApplyingBlobEventArgs>(UploadingFile);

                FileSyncProvider fileSyncProvider = null;
                try
                {
                    fileSyncProvider = new FileSyncProvider(_localPathName);
                }
                catch (ArgumentException)
                {
                    fileSyncProvider = new FileSyncProvider(Guid.NewGuid(), _localPathName);
                }
                fileSyncProvider.ApplyingChange += new EventHandler<ApplyingChangeEventArgs>(AzureBlobSync.DownloadingFile);

                try
                {
                    SyncOrchestrator orchestrator = new SyncOrchestrator();
                    orchestrator.LocalProvider = fileSyncProvider;
                    orchestrator.RemoteProvider = azureProvider;

                    orchestrator.Synchronize();
                }
                finally
                {
                    fileSyncProvider.Dispose();
                }

                Console.WriteLine("Synchronization Complete");
                if (_pause)
                {
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static bool ParseArgs(string[] args)
        {
            bool foundContainer = false;
            bool foundLocalPath = false;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower() == "-container")
                {
                    if (++i >= args.Length)
                    {
                        break;
                    }
                    foundContainer = true;
                    _containerName = args[i].ToLower();
                }
                else if (args[i].ToLower() == "-path")
                {
                    if (++i >= args.Length)
                    {
                        break;
                    }
                    foundLocalPath = true;
                    _localPathName = args[i];
                }
                else if (args[i].ToLower() == "-p")
                {
                    _pause = true;
                }
                else
                {
                    break;
                }
            }

            return foundContainer && foundLocalPath;
        }


        static void PrintUsage()
        {
            Console.WriteLine("Usage: AzureBlobSync -container [ContainerName] -path [LocalPath]");
        }

        public static void DownloadingFile(object sender, ApplyingChangeEventArgs args)
        {
            switch (args.ChangeType)
            {
                case ChangeType.Create:
                    Console.WriteLine("Creating File: {0}...", args.NewFileData.Name);
                    break;
                case ChangeType.Delete:
                    Console.WriteLine("Deleting File: {0}...", args.CurrentFileData.Name);
                    break;
                case ChangeType.Rename:
                    Console.WriteLine("Renaming File: {0} to {1}...", args.CurrentFileData.Name, args.NewFileData.Name);
                    break;
                case ChangeType.Update:
                    Console.WriteLine("Updating File: {0}...", args.NewFileData.Name);
                    break;
            }
        }

        public static void UploadingFile(object sender, ApplyingBlobEventArgs args)
        {
            switch (args.ChangeType)
            {
                case ChangeType.Create:
                    Console.WriteLine("Creating Azure Blob: {0}...", args.CurrentBlobName);
                    break;
                case ChangeType.Delete:
                    Console.WriteLine("Deleting Azure Blob: {0}...", args.CurrentBlobName);
                    break;
                case ChangeType.Rename:
                    Console.WriteLine("Renaming Azure Blob: {0} to {1}...", args.CurrentBlobName, args.NewBlobName);
                    break;
                case ChangeType.Update:
                    Console.WriteLine("Updating Azure Blob: {0}...", args.CurrentBlobName);
                    break;
            }
        }
    }
}
