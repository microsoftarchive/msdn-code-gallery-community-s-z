using System;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using Microsoft.SharePoint.Client;

namespace Zhukov.Demo.SharePointUploadDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            // SharePoint Site URL
            var siteUrl = "https://sharepointsiteurl";
            // Login
            var userLogin = "userLogin@domain";
            // Password
            var userPassword = "P@ssw0rd";
            // Document Library Name
            var docLibTitle = "Documents";

            var pwd = new SecureString();
            foreach (var c in userPassword) pwd.AppendChar(c);

            // Credentials for SharePoint Online
            var SPOCredentials = new SharePointOnlineCredentials(userLogin, pwd);

            // Credentials for SharePoint on-premise
            var SPCredentials = new NetworkCredential(userLogin, pwd);

            using (var ctx = new ClientContext(siteUrl))
            {
                try
                {
                    // try to use SharePoint Online Credentials
                    ctx.Credentials = SPOCredentials;
                    ctx.ExecuteQuery();
                    Console.WriteLine("SharePoint Online");
                }
                catch (ClientRequestException)
                {
                    // switch to NetworkCredential
                    ctx.Credentials = SPCredentials;
                    ctx.ExecuteQuery();
                    Console.WriteLine("SharePoint On-premise");
                }
                catch (NotSupportedException)
                {
                    // switch to NetworkCredential
                    ctx.Credentials = SPCredentials;
                    ctx.ExecuteQuery();
                    Console.WriteLine("SharePoint On-premise");
                }

                var library = ctx.Web.Lists.GetByTitle(docLibTitle);
                ctx.Load(library, x => x.RootFolder.ServerRelativeUrl);
                ctx.ExecuteQuery();

                // File generation in memory
                var fileBytes = new byte[] { };

                using (var ms = new MemoryStream())
                {
                    using (TextWriter tw = new StreamWriter(ms, Encoding.UTF8))
                    {
                        // Append 100 lines of the text
                        for (var i = 0; i < 100; i++)
                        {
                            tw.WriteLine(@"The quick brown fox jumps over the lazy dog");
                        }
                        // Array of bytes
                        fileBytes = ms.ToArray();
                    }
                }

                Console.WriteLine("Uploading fileName.txt");

                // Information about the file
                var fileInformation = new FileCreationInformation
                {
                    // Server relative url of the document
                    Url = library.RootFolder.ServerRelativeUrl + "/fileName.txt",
                    // Overwrite file if it's already exist
                    Overwrite = true,
                    // Content of the file
                    Content = fileBytes
                };
                // Upload the file to root folder of the Document library
                library.RootFolder.Files.Add(fileInformation);

                ctx.ExecuteQuery();




                Console.WriteLine("Uploading fileName2.txt");

                Microsoft.SharePoint.Client.File.SaveBinaryDirect(
                    //Client Context
                    ctx,
                    // Server relative url of the document
                    library.RootFolder.ServerRelativeUrl + "/fileName2.txt",
                    // Content of the file
                    new MemoryStream(fileBytes),
                    // Overwrite file if it's already exist
                    true);



                Console.WriteLine("Uploading fileName3.txt");

                // Information about chunked file
                var fileChunkedInformation = new FileCreationInformation
                {
                    // Server relative url of the document
                    Url = library.RootFolder.ServerRelativeUrl + "/fileName3.txt",
                    // Overwrite file if it's already exist
                    Overwrite = true,
                    Content = new byte[] { }
                };
                // Upload the file to root folder of the Document library
                var fileChunked = library.RootFolder.Files.Add(fileChunkedInformation);

                ctx.ExecuteQuery();

                // Upload Id
                var uploadId = Guid.NewGuid();

                // Offset of the byte array (file content)
                var fileBytesOffset = 0;

                // Offset of the uploaded file
                long fileChunkedOffset = 0;

                // Size of a chunk
                var fileChunkArrayBuffer = new byte[1024];

                while (fileBytesOffset < fileBytes.Length)
                {
                    Console.WriteLine("\toffset: " + fileBytesOffset);
                    // How many bytes will be readed from file content
                    var length = Math.Min(fileChunkArrayBuffer.Length, fileBytes.Length - fileBytesOffset);

                    // Copy bytes to buffer array
                    Buffer.BlockCopy(fileBytes, fileBytesOffset, fileChunkArrayBuffer, 0, length);

                    // Buffer array to stream
                    using (var ms = new MemoryStream(fileChunkArrayBuffer))
                    {
                        // If the offset equals 0 - Start Upload
                        if (fileChunkedOffset == 0)
                        {
                            Console.WriteLine("\tStart Upload");
                            var fileChunkedOffsetResult = fileChunked.StartUpload(uploadId, ms);
                            ctx.ExecuteQuery();
                            fileChunkedOffset = fileChunkedOffsetResult.Value;
                        }
                        // Continue uploading
                        else if (fileBytesOffset + length <= fileBytes.Length)
                        {
                            Console.WriteLine("\tContinue Upload:" + fileChunkedOffset);
                            var fileChunkedOffsetResult = fileChunked.ContinueUpload(uploadId, fileChunkedOffset, ms);
                            ctx.ExecuteQuery();
                            fileChunkedOffset = fileChunkedOffsetResult.Value;
                        }
                        // Last chunk- Finish uploading
                        else
                        {
                            Console.WriteLine("\tFinish Upload");
                            fileChunked.FinishUpload(uploadId, fileChunkedOffset, ms);
                            ctx.ExecuteQuery();
                        }
                    }

                    fileBytesOffset += length;
                }
            }
        }
    }
}
