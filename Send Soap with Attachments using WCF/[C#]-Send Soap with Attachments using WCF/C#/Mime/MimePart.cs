using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WcfHelpers.SoapWithAttachments.Mime
{
    public class MimePart
    {
        public string ContentType { get; set; }
        public string TransferEncoding { get; set; }
        public string ContentId { get; set; }
        public string CharSet { get; set; }

        private byte[] _Content;
        public byte[] Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public string GetContentAsString()
        {
            string Result = string.Empty;
            using (StreamReader sr = new StreamReader(GetContentAsStream()))
            {
                Result = sr.ReadToEnd();
            }
            return Result;
        }

        public Stream GetContentAsStream()
        {
            if (Content != null)
                return new MemoryStream(_Content);
            else
                throw new ArgumentNullException("Content is not initialized, no message-part loaded or de-serialized!");
        }
    }
}
