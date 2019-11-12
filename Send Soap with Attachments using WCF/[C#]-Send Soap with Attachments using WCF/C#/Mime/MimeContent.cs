using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfHelpers.SoapWithAttachments.Mime
{
    public class MimeContent
    {
        private int StartPartIndex;

        public string Boundary 
        { 
            get; 
            set; 
        }

        public string Start
        {
            get
            {
                return Parts[StartPartIndex].ContentId;
            }
        }

        public string StartType
        {
            get
            {
                return Parts[StartPartIndex].ContentType;
            }
        }

        public string ContentType
        {
            get
            {
                if (StartPartIndex < 0)
                    throw new ArgumentException("Start-part not set, yet! Please call SetAsStartPart() before querying the content type!");

                return string.Format("multipart/related; type=\"{0}\"; start=\"{1}\"; boundary=\"{2}\"",
                                     StartType, Start, Boundary);
            }
        }

        private List<MimePart> _Parts;
        public List<MimePart> Parts
        {
            get
            {
                return _Parts;
            }
        }

        public MimeContent()
        {
            StartPartIndex = -1;
            _Parts = new List<MimePart>();
        }

        public void SetAsStartPart(MimePart part)
        {
            if (Parts.Contains(part))
            {
                StartPartIndex = Parts.IndexOf(part);
            }
            else
            {
                throw new ArgumentException("Part must be in the list of mime parts before being used as start item!");
            }
        }
    }
}
