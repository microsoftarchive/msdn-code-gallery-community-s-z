using Revenue.EmailUtilities.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revenue.EmailUtilities.Utilities
{
    public class Cleaner
    {
        Exception mException;

        /// <summary>
        /// Returns exception when ToMsgResult.FailedWithException is
        /// returned from a method in this class.
        /// </summary>
        public Exception Exception { get { return mException; } }
        /// <summary>
        /// Removes all files from pFolder
        /// </summary>
        /// <param name="pFolder"></param>
        /// <returns></returns>
        public CleanFolder All(string pFolder)
        {
            if (Directory.Exists(pFolder))
            {
                try
                {
                    Directory.GetFiles(pFolder).ToList().ForEach(File.Delete);
                    return CleanFolder.Success;
                }
                catch (Exception ex)
                {
                    mException = ex;
                    return CleanFolder.Failed;
                }
            }
            else
            {
                return CleanFolder.FolderNotFound;
            }
        }
        /// <summary>
        /// Remove all .eml files from pFolder
        /// </summary>
        /// <param name="pFolder"></param>
        /// <returns></returns>
        public CleanFolder PlainMessages(string pFolder)
        {
            if (Directory.Exists(pFolder))
            {
                try
                {
                    Directory.GetFiles(pFolder,"*.eml").ToList().ForEach(File.Delete);
                    return CleanFolder.Success;
                }
                catch (Exception ex)
                {
                    mException = ex;
                    return CleanFolder.Failed;
                }
            }
            else
            {
                return CleanFolder.FolderNotFound;
            }
        }
        /// <summary>
        /// Remove all .msg files from pFolder
        /// </summary>
        /// <param name="pFolder"></param>
        /// <returns></returns>
        public CleanFolder Messages(string pFolder)
        {
            if (Directory.Exists(pFolder))
            {
                try
                {
                    Directory.GetFiles(pFolder, "*.msg").ToList().ForEach(File.Delete);
                    return CleanFolder.Success;
                }
                catch (Exception ex)
                {
                    mException = ex;
                    return CleanFolder.Failed;
                }
            }
            else
            {
                return CleanFolder.FolderNotFound;
            }
        }
    }
}
