using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Revenue.EmailUtilities.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Given a string obtained from a msg file where the string
        /// represents a email address remove the brackets
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string RemoveAngleBrackets(this string sender)
        {
            return sender.Replace("<", "").Replace(">", "");
        }
        /// <summary>
        /// Count number of EML files in a folder
        /// </summary>
        /// <param name="pFolder"></param>
        /// <returns></returns>
        public static int EmlFileCount(this string pFolder)
        {
            if (Directory.Exists(pFolder))
            {
                return Directory.GetFiles(pFolder, "*.eml").Count();
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Count number of MSG files in a folder
        /// </summary>
        /// <param name="pFolder"></param>
        /// <returns></returns>
        public static int MsgFileCount(this string pFolder)
        {
            if (Directory.Exists(pFolder))
            {
                return Directory.GetFiles(pFolder, "*.msg").Count();
            }
            else
            {
                return -1;
            }
        }
    }
}

