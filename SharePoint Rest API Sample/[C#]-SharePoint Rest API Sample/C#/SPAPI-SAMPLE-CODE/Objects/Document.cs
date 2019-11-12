using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAPI_SAMPLE_CODE.Objects {
    public class Document {

        public byte[] DocumentByteArray { get; set; }

        public string FileName { get; set; }

        public Dictionary<string, string> MetaData { get; set; }

        public Document() {
            MetaData = new Dictionary<string, string>();
        }

        public Document (byte[] byteArray, string fileName, Dictionary<string, string> metaData) {
            DocumentByteArray = byteArray;
            FileName = fileName;
            MetaData = metaData;
        }

    }
}
