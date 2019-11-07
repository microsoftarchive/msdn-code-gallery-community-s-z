//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Net;

namespace MyLibrary
{
    /// <summary>
    /// ExternalContent is a helper class that gets content from sources outside of an application.
    /// It is used by CustomAssembly\ReportWithCustomAssembly.rdlc.
    /// </summary>
    public static class ExternalContent
    {
        /// <summary>
        /// Returns a HTML page from the supplied URL.
        /// This method requires the System.Net.NetworkAccess.Connect permission to the URL specified in the input parameter.
        /// </summary>
        /// <param name="pageUrl">URL of the Web page.</param>
        /// <returns>The HTML of the Web page.</returns>
        public static string GetPage(Uri pageUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (Exception) 
            { 
                throw; 
            }
        }

        /// <summary>
        /// Returns the content of a text file.
        /// This method requires the System.Security.Permissions.FileIOPermission permission to the path specified in the input parameter.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The file content.</returns>
        public static string GetFileContent(string filePath)
        {
            FileStream file = null;
            try
            {
                file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string content = reader.ReadToEnd();

                return content;
            }
            catch (Exception) 
            { 
                throw; 
            }
            finally 
            {
                if (file != null)
                    file.Dispose();
            }
        }
    }
}

