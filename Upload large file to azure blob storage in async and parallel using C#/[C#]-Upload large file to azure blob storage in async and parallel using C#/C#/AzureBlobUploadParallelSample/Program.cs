using AzureBlobOperationsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureBlobUploadParallelSample
{
    class Program
    {
        public delegate List<BlobOperationStatus> AsyncBlockBlobUploadCaller(List<FileBlobNameMapper> blobFileMapperList, string containerName);

        static void Main(string[] args)
        {
            //define file paths of your choice and size. 
            string file1 = @"C:\Kunal_Apps\Sample hours1.xlsx";
            string file2 = @"C:\Kunal_Apps\Sample hours2.xlsx";
            string file3 = @"C:\Kunal_Apps\Sample hours3.xlsx";
            string file4 = @"C:\Kunal_Apps\Boot Camp.zip";
            
            //map the file names to blob names
            List<FileBlobNameMapper> blobFileMapperList = new List<FileBlobNameMapper>();
            blobFileMapperList.Add(new FileBlobNameMapper("blob1", file1));
            blobFileMapperList.Add(new FileBlobNameMapper("blob2", file2));
            blobFileMapperList.Add(new FileBlobNameMapper("blob3", file3));
            blobFileMapperList.Add(new FileBlobNameMapper("blob4", file4));
            

            //specify the container name
            string containerName = "mycontainer";

            //start blob upload async operation
            AsyncBlockBlobUpload blobUploadManager = new AsyncBlockBlobUpload();
            AsyncBlockBlobUploadCaller caller = new AsyncBlockBlobUploadCaller(blobUploadManager.UploadBlockBlobsInParallel);
            caller.BeginInvoke(blobFileMapperList, containerName, new AsyncCallback(OnUploadBlockBlobsInParallelCompleted), null);
            Console.WriteLine("Async operation of blob storage upload started...");

            //to keep main thread alive I am using While(true). Because Async operations here will be based on ThreadPool and if main thread is ended then async operation child threads will also end.
            //Note: If you are using worker role here then it usually run's the operation in Run method in While(true) method keeping your main thread alive always.
            while (true)
            {
                Console.WriteLine("continue the main thread work...");
                Thread.Sleep(90000);                
            }
        }

        /// <summary>
        /// Callback method for upload to azure blob operation
        /// </summary>
        /// <param name="result">async result</param>
        public static void OnUploadBlockBlobsInParallelCompleted(IAsyncResult result)
        {
            // Retrieve the delegate.
            AsyncResult asyncResult = (AsyncResult)result;
            AsyncBlockBlobUploadCaller caller = (AsyncBlockBlobUploadCaller)asyncResult.AsyncDelegate;

            //retrive the blob upload operation status list to take necessary action
            List<BlobOperationStatus> operationStausList = caller.EndInvoke(asyncResult);

            //print the status of upload operation for each blob
            foreach (BlobOperationStatus blobStatus in operationStausList)
            {
                Console.WriteLine("Blob name:" + blobStatus.Name + Environment.NewLine);
                Console.WriteLine("Blob operation status:" + blobStatus.OperationStatus + Environment.NewLine);
                if (blobStatus.ExceptionDetails != null)
                {
                    Console.WriteLine("Blob operation exception if any:" + blobStatus.ExceptionDetails.Message + Environment.NewLine);
                }

                //Note:This is where you can write the failed blob operation entry in table/ queue and again make worker role traverse th' to perform upload again.
            }

        }
    }
}
