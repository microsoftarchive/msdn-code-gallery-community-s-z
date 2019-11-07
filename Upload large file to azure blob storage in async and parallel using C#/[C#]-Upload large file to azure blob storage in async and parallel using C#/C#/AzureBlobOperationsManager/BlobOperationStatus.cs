using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobOperationsManager
{
    /// <summary>
    /// class to represent the status of blob operation
    /// </summary>
    public class BlobOperationStatus
    {
        public string Name { get; set; }

        public Uri BlobUri { get; set; }

        public OperationStatus OperationStatus { get; set; }

        public Exception ExceptionDetails { get; set; }
    }

    public enum OperationStatus
    {
        Failed, Succeded
    }
}
