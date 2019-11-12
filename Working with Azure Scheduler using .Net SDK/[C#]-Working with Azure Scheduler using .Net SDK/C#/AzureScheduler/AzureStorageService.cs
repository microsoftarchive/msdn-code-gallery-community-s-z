using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;

namespace AzureScheduler
{
    public class AzureStorageService
    {
        CloudStorageAccount storageAccount;

        public  AzureStorageService()
        {

            storageAccount = CloudStorageAccount.Parse(AzureScheduler.Properties.Settings.Default["AzureConnectionString"].ToString());
            
            
        }

       
        public  void FileOperations(string fileSharename,string Directory,string filePath)
        {
            CloudFileClient fileClient = storageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference(fileSharename);
            fileShare.CreateIfNotExists(null,null);
            CloudFileDirectory rootDirectory = fileShare.GetRootDirectoryReference();
            CloudFileDirectory fileDirectory = rootDirectory.GetDirectoryReference(Directory);
            fileDirectory.CreateIfNotExists();
            CloudFile file = fileDirectory.GetFileReference("testfile");
            //Deleting If File Exists
            file.DeleteIfExistsAsync();
            if (file.Exists() == false)
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                file.Create(fs.Length);
                fs.Close();
            }
            file.OpenWrite(null);
            //Upload File Operation
            file.UploadFromFile(filePath, FileMode.Open);
            //Write File Operation
            file.WriteRange(new FileStream(filePath,FileMode.Open), 0);
            Stream azureFile=file.OpenRead();
            //Read File Operation
            azureFile.Position = 0;
            byte[] buffer = new byte[azureFile.Length - 1];
            int n=azureFile.Read(buffer,(int)0,14050);
            for (int i = 0; i < buffer.Length;i++ )
            {
                Console.Write(buffer[i].ToString());
            }
            //Download File Operation
            file.DownloadToFile(@"D:\TestFile.pptx",FileMode.Create);

        }
    }
}
