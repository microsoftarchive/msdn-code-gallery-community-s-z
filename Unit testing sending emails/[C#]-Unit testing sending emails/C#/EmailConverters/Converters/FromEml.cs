using MsgReader.Outlook;
using Revenue.EmailUtilities.Containers;
using Revenue.EmailUtilities.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Revenue.EmailUtilities.Converters
{
    public class FromEml
    {
        Exception mException;
        /// <summary>
        /// Returns exception when ToMsgResult.FailedWithException is
        /// returned from a method in this class.
        /// </summary>
        public Exception Exception { get; set; }
        int mConvertedCount;
        /// <summary>
        /// Total number of MSG files generated from EML files in a single folder
        /// </summary>
        public int ConvertedCount { get { return mConvertedCount; } }
        int mExpectedConvertedCount;
        /// <summary>
        /// Count of EML files in a folder
        /// </summary>
        public int ExpectedConvertedCount { get { return mExpectedConvertedCount; } }
        /// <summary>
        /// Given a folder all EML files are to generate MSG files
        /// </summary>
        /// <param name="pFolder"></param>
        /// <param name="pRemoveEmlFiles"></param>
        /// <param name="pRemoveMsgFiles"></param>
        /// <returns></returns>
        public ToMsgResult EmlToMessageFiles(string pFolder, bool pRemoveEmlFiles = false, bool pRemoveMsgFiles = false)
        {
            if (Directory.Exists(pFolder))
            {
                var files = Directory.GetFiles(pFolder, "*.eml");
                mExpectedConvertedCount = files.Count();

                if (pRemoveMsgFiles)
                {
                    if (!RemoveFiles(pRemoveEmlFiles, files))
                    {
                        return ToMsgResult.FailedWithException;
                    }
                }

                var count = 0;
                try
                {
                    foreach (var file in files)
                    {
                        MsgKit.Converter.ConvertEmlToMsg(file, Path.ChangeExtension(file, ".msg"));
                        count += 1;
                    }
                    mConvertedCount = count;
                    return ToMsgResult.Success;
                }
                catch (Exception ohSnap)
                {
                    mException = ohSnap;
                    return ToMsgResult.FailedWithException;
                }
                finally
                {
                    if (pRemoveMsgFiles)
                    {
                        RemoveFiles(pRemoveEmlFiles, files);
                    }
                }
            }
            else
            {
                return ToMsgResult.FolderNotFound;
            }
        }
        /// <summary>
        /// Reads all .msg files and extracts properties
        /// </summary>
        /// <param name="pFolder"></param>
        /// <returns></returns>
        public List<MailInformation> GetMailInformation(string pFolder)
        {
            List<MailInformation> items = new List<MailInformation>();

            var files = new DirectoryInfo(pFolder).GetFiles("*.msg");
            foreach (var file in files)
            {
                using (var message = new Storage.Message(file.FullName))
                {
                    items.Add(new MailInformation(message));
                }
            }
            return items;
        }
        /// <summary>
        /// Return information on one file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <returns></returns>
        public MailInformation GetSingleMailItem(string pFileName)
        {
            if (File.Exists(pFileName))
            {
                using (var message = new Storage.Message(pFileName))
                {
                    return new MailInformation(message);
                }
            }
            else
            {
                throw new FileNotFoundException(pFileName);
            }
        }
        /// <summary>
        /// Used to delete a specfic file type in a folder.
        /// This should be removed in favor of methods in 
        /// Revenue.EmailUtilities.Utilities.Cleaner class
        /// </summary>
        /// <param name="pFiles"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        private bool RemoveFiles(bool pFiles, string[] files)
        {
            try
            {
                if (pFiles)
                {
                    files.ToList().ForEach(f => File.Delete(f));
                }
                return true;
            }
            catch (Exception ohSnap)
            {
                mException = ohSnap;
                return false;
            }
        }
    }
}
