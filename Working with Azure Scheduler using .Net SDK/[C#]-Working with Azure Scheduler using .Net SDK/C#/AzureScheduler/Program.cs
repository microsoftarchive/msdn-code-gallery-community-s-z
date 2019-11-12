using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Scheduler;
using Microsoft.WindowsAzure.Scheduler.Models;
using Microsoft.WindowsAzure.Management.Scheduler;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Scheduler.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;

namespace AzureScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var AzureStorage = new AzureStorageService();
            AzureStorage.FileOperations("testshare", "testdirectory", @"D:\HDInsight Test Strategy.docx");
            

        }
    }
}
