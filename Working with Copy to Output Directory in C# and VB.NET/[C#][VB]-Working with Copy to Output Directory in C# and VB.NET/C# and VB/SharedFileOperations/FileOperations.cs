using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SharedFileOperations
{
    public static class FileOperations
    {
        /// <summary>
        /// Returns a path set in the project's settings
        /// </summary>
        /// <param name="settingFromProject"></param>
        /// <returns></returns>
        public static string DatabaseLocation(string settingFromProject)
        {
            string Marker = "|DataDirectory|\\";

            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, settingFromProject.Split(';')
                .Where((item) => item.Contains(Marker))
                .FirstOrDefault()
                .Replace(Marker, "")
                .Replace("AttachDbFilename=", ""));
        }
    }
}
