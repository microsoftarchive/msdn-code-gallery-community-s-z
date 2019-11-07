using System;
using System.Runtime.Serialization;

namespace Microsoft.Samples.SqlServer.SSIS.SharePointListAdapters
{
    /// <summary>
    /// Used to designate an exception while processing the pipeline for an adapter
    /// </summary>
    [Serializable()]
    public class PipelineProcessException : Exception
    {
        public PipelineProcessException() 
            : base() { }

        public PipelineProcessException(string message) 
            : base(message) { }
        
        public PipelineProcessException(string message, Exception ex) 
            : base(message, ex) { }
        
        protected PipelineProcessException(SerializationInfo info, StreamingContext context) 
            : base(info, context) { }
    }
}
