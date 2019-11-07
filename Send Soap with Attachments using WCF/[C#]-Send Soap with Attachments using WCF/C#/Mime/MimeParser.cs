using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WcfHelpers.SoapWithAttachments.Mime
{
    public class MimeParser
    {
        public Encoding ParserEncoding { get; set; }
        public Encoding SoapXmlEncoding { get; set; }

        public MimeParser()
        {
            ParserEncoding = Encoding.UTF8;
            SoapXmlEncoding = Encoding.UTF8;
        }

        public MimeParser(Encoding encoding)
            : this()
        {
            ParserEncoding = encoding;
        }

        public MimeParser(Encoding encoding, Encoding soapEncoding)
            : this(encoding)
        {
            SoapXmlEncoding = soapEncoding;
        }

        public byte[] SerializeMimeContent(MimeContent content)
        {
            MemoryStream ContentStream = new MemoryStream();
            SerializeMimeContent(content, ContentStream);
            return ContentStream.ToArray();
        }

        public void SerializeMimeContent(MimeContent content, Stream contentStream)
        {
            byte[] WriteHelper;
            byte[] CarriageReturnLineFeed = new byte[] { (byte)'\r', (byte)'\n' };

            //
            // Prepare some bytes written more than once
            //
            byte[] BoundaryBytes = ParserEncoding.GetBytes("--" + content.Boundary);

            //
            // Write every part into the stream
            //
            foreach (var item in content.Parts)
            {
                //
                // First of all write the boundary
                //
                contentStream.Write(CarriageReturnLineFeed, 0, CarriageReturnLineFeed.Length);
                contentStream.Write(BoundaryBytes, 0, BoundaryBytes.Length);
                contentStream.Write(CarriageReturnLineFeed, 0, 2);

                //
                // Write the content-type for the current element
                //
                StringBuilder Builder = new StringBuilder();
                Builder.Append(string.Format("Content-Type: {0}", item.ContentType));
                if (!string.IsNullOrEmpty(item.CharSet)) Builder.Append(string.Format("; charset={0}", item.CharSet));
                Builder.Append(new char[] { '\r', '\n' });
                Builder.Append(string.Format("Content-Transfer-Encoding: {0}", item.TransferEncoding));
                Builder.Append(new char[] { '\r', '\n' });
                Builder.Append(string.Format("Content-Id: {0}", item.ContentId));

                WriteHelper = ParserEncoding.GetBytes(Builder.ToString());
                contentStream.Write(WriteHelper, 0, WriteHelper.Length);
                contentStream.Write(CarriageReturnLineFeed, 0, CarriageReturnLineFeed.Length);
                contentStream.Write(CarriageReturnLineFeed, 0, CarriageReturnLineFeed.Length);

                //
                // Write the actual content
                //
                contentStream.Write(item.Content, 0, item.Content.Length);
            }

            //
            // Write one last content boundary
            //
            contentStream.Write(CarriageReturnLineFeed, 0, CarriageReturnLineFeed.Length);
            contentStream.Write(BoundaryBytes, 0, BoundaryBytes.Length);
            contentStream.Write(new byte[] { 45, 45 }, 0, 2);
            contentStream.Write(CarriageReturnLineFeed, 0, CarriageReturnLineFeed.Length);
        }

        public MimeContent DeserializeMimeContent(string httpContentType, byte[] binaryContent)
        {
            //
            // First of all parse the http content type
            //
            string MimeType = null, MimeBoundary = null, MimeStart = null;
            ParseHttpContentTypeHeader(httpContentType, ref MimeType, ref MimeBoundary, ref MimeStart);

            //
            // Create the mime-content
            //
            MimeContent Content = new MimeContent()
            {
                Boundary = MimeBoundary
            };

            // 
            // Start finding the parts in the mime message
            // Note: in MIME RFC a "--" represents the end of something
            //
            int EndBoundaryHelperIdx = 0;
            byte[] MimeBoundaryBytes = ParserEncoding.GetBytes("\r\n--" + MimeBoundary);
            for (int i = 0; i < binaryContent.Length; i++)
            {
                if (AreArrayPartsForTextEqual(MimeBoundaryBytes, 0, binaryContent, i, MimeBoundaryBytes.Length))
                {
                    EndBoundaryHelperIdx = i + MimeBoundaryBytes.Length;
                    if ((EndBoundaryHelperIdx + 1) < binaryContent.Length)
                    {
                        // The end of the MIME-message is the boundary followed by "--"
                        if (binaryContent[EndBoundaryHelperIdx] == '-' && binaryContent[EndBoundaryHelperIdx + 1] == '-')
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new ApplicationException("Invalid MIME content parsed, premature End-Of-File detected!");
                    }
                    // Start reading the mime part after the boundary
                    MimePart Part = ReadMimePart(binaryContent, ref i, MimeBoundaryBytes);
                    if (Part != null)
                    {
                        Content.Parts.Add(Part);
                    }
                }
            }

            //
            // Finally return the ready-to-use object model
            //
            return Content;
        }

        private static void ParseHttpContentTypeHeader(string httpContentType, ref string MimeType, ref string MimeBoundary, ref string MimeStart)
        {
            string[] ContentTypeParsed = httpContentType.Split(new char[] { ';' });
            for (int i = 0; i < ContentTypeParsed.Length; i++)
            {
                string ContentTypePart = ContentTypeParsed[i].Trim();
                int EqualsIdx = ContentTypePart.IndexOf('=');
                if (EqualsIdx > 0)
                {
                    string Key = ContentTypePart.Substring(0, EqualsIdx);
                    string Value = ContentTypePart.Substring(EqualsIdx + 1);
                    if (Value[0] == '\"') Value = Value.Remove(0, 1);
                    if (Value[Value.Length - 1] == '\"') Value = Value.Remove(Value.Length - 1);

                    switch (Key.ToLower())
                    {
                        case "type":
                            MimeType = Value;
                            break;
                        case "start":
                            MimeStart = Value;
                            break;
                        case "boundary":
                            MimeBoundary = Value;
                            break;
                    }
                }
            }
            if ((MimeType == null) || (MimeStart == null) || (MimeBoundary == null))
            {
                throw new ApplicationException("Invalid HTTP content header - please verify if type, start and boundary are available in the multipart/related content type header!");
            }
        }

        private MimePart ReadMimePart(byte[] binaryContent, ref int currentIndex, byte[] mimeBoundaryBytes)
        {
            byte[] ContentTypeKeyBytes = ParserEncoding.GetBytes("Content-Type:");
            byte[] TransferEncodingKeyBytes = ParserEncoding.GetBytes("Content-Transfer-Encoding:");
            byte[] ContentIdKeyBytes = ParserEncoding.GetBytes("Content-Id:");

            //
            // Find the appropriate content header indexes
            //
            int ContentTypeIdx = -1, TransferEncodingIdx = -1, ContentIdIdx = -1;
            while (currentIndex < binaryContent.Length)
            {
                // Try compare for keys
                if ((ContentTypeIdx < 0) && AreArrayPartsForTextEqual(ContentTypeKeyBytes, 0, binaryContent, currentIndex, ContentTypeKeyBytes.Length))
                {
                    ContentTypeIdx = currentIndex;
                }
                else if ((TransferEncodingIdx < 0) && AreArrayPartsForTextEqual(TransferEncodingKeyBytes, 0, binaryContent, currentIndex, TransferEncodingKeyBytes.Length))
                {
                    TransferEncodingIdx = currentIndex;
                }
                else if ((ContentIdIdx < 0) && AreArrayPartsForTextEqual(ContentIdKeyBytes, 0, binaryContent, currentIndex, ContentIdKeyBytes.Length))
                {
                    ContentIdIdx = currentIndex;
                }

                // All content headers found, last content header split by Carriage Return Line Feed
                // TODO: Check index out of bounds!
                if (binaryContent[currentIndex] == 13 && binaryContent[currentIndex + 1] == 10 && binaryContent[currentIndex + 2] == 13 && binaryContent[currentIndex + 3] == 10)
                {
                    break;
                }

                // Next array index
                currentIndex++;
            }

            // After the last content header, we have \r\n\r\n, always
            currentIndex += 4;

            //
            // If not all indices found, error
            //
            if (!((ContentIdIdx >= 0) && (ContentTypeIdx >= 0) && (ContentIdIdx >= 0)))
            {
                // A '0' at the end of the message indicates that the previous part was the last one
                if (binaryContent[currentIndex - 1] == 0)
                    return null;
                else if (binaryContent[currentIndex - 2] == 13 && binaryContent[currentIndex - 1] == 10)
                    return null;
                else
                    throw new ApplicationException("Invalid mime content passed into mime parser! Content-Type, Content-Transfer-Encoding or ContentId headers for mime part are missing!");
            }

            // 
            // Convert the content header information into strings
            //
            string ContentType = ParserEncoding.GetString(binaryContent, ContentTypeIdx + ContentTypeKeyBytes.Length, TransferEncodingIdx - (ContentTypeIdx + ContentTypeKeyBytes.Length)).TrimStart().TrimEnd();
            string CharSet = string.Empty;
            if (ContentType.Contains(';'))
            {
                int ContentTypeSplitIdx = ContentType.IndexOf(';');
                int EqualsCharSetIdx = ContentType.IndexOf('=', ContentTypeSplitIdx + 1);
                if (EqualsCharSetIdx < 0)
                    CharSet = ContentType.Substring(ContentTypeSplitIdx + 1).TrimStart().TrimEnd();
                else
                    CharSet = ContentType.Substring(EqualsCharSetIdx + 1).TrimStart().TrimEnd();
                ContentType = ContentType.Substring(0, ContentTypeSplitIdx).TrimStart().TrimEnd();
            }
            string TransferEncoding = ParserEncoding.GetString(binaryContent, TransferEncodingIdx + TransferEncodingKeyBytes.Length, ContentIdIdx - (TransferEncodingIdx + TransferEncodingKeyBytes.Length)).TrimStart().TrimEnd();
            string ContentId = ParserEncoding.GetString(binaryContent, ContentIdIdx + ContentIdKeyBytes.Length, currentIndex - (ContentIdIdx + ContentIdKeyBytes.Length)).TrimStart().TrimEnd();

            //
            // Current mime content starts now, therefore find the end
            //
            int StartContentIndex = currentIndex;
            int EndContentIndex = -1;
            while (currentIndex < binaryContent.Length)
            {
                if (AreArrayPartsForTextEqual(mimeBoundaryBytes, 0, binaryContent, currentIndex, mimeBoundaryBytes.Length))
                {
                    EndContentIndex = currentIndex - 1;
                    break;
                }
                currentIndex++;
            }
            if (EndContentIndex == -1) EndContentIndex = currentIndex - 1;

            // 
            // Tweak start- and end-indexes, cut all Carriage Return Line Feeds
            //
            while (true)
            {
                if ((binaryContent[StartContentIndex] == 13) && (binaryContent[StartContentIndex + 1] == 10))
                    StartContentIndex += 2;
                else
                    break;

                if (StartContentIndex > binaryContent.Length)
                    throw new ApplicationException("Error in content, start index cannot go beyond overall content array!");
            }
            while (true)
            {
                if ((binaryContent[EndContentIndex - 1] == 13) && (binaryContent[EndContentIndex] == 10))
                    EndContentIndex -= 2;
                else
                    break;

                if (EndContentIndex < 0)
                    throw new ApplicationException("Error in content, end content index cannot go beyond smallest index of content array!");
            }

            //
            // Now create a byte array for the current mime-part content
            //
            MimePart Part = new MimePart()
            {
                ContentId = ContentId,
                TransferEncoding = TransferEncoding,
                ContentType = ContentType,
                CharSet = CharSet,
                Content = new byte[EndContentIndex - StartContentIndex + 1]
            };
            Array.Copy(binaryContent, StartContentIndex, Part.Content, 0, Part.Content.Length);

            // Go to the last sign before the next boundary starts
            currentIndex--;

            return Part;
        }

        private static bool AreArrayPartsForTextEqual(byte[] firstArray, int firstOffset, byte[] secondArray, int secondOffset, int length)
        {
            // Check array boundaries
            if ((firstOffset + length) > firstArray.Length) return false;
            if ((secondOffset + length) > secondArray.Length) return false;

            // Run through the arrays and compare byte-by-byte
            for (int i = 0; i < length; i++)
            {
                char c1 = Char.ToLower((char)firstArray[firstOffset + i]);
                char c2 = char.ToLower((char)secondArray[secondOffset + i]);
                if (c1 != c2)
                {

                    return false;
                }
            }

            return true;
        }
    }
}
