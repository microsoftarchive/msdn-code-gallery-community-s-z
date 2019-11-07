using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpGetListingResponse : FtpDuplexReponse
    {
        private List<FtpItem> m_Items = null; 

        public FtpCapability Features = FtpCapability.NONE;

        public List<FtpItem> Items 
        {
            get 
            {
                if (Success && m_Items == null)
                {
                    if (!string.IsNullOrEmpty(MessageBody))
                        ParseMessageBody();
                    else
                        m_Items = new List<FtpItem>();
                }

                return m_Items;
            }
        }

        private void ParseMessageBody()
        {
            m_Items = new List<FtpItem>();

            var listingItems = MessageBody.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var listingItem in listingItems)
            {
                FtpItem ftpItem;

                if (TryParseDosList(listingItem, out ftpItem) || TryParseMachineList(listingItem, out ftpItem) || TryParseUnixList(listingItem, Features, out ftpItem) || TryParseVaxList(listingItem, out ftpItem))
                {
                    // TODO: we need to be careful about the slashes in the path name
                    ftpItem.FullName = Request.Arguments[0].GetFtpPath(ftpItem.Name);
                    m_Items.Add(ftpItem);
                }
            }
        }

        /// <summary>
        /// Parses MLS* format listings
        /// </summary>
        /// <param name="buf">A line from the listing</param>
        /// <param name="item"></param>
        /// <returns>if the item is able to be parsed</returns>
        static bool TryParseMachineList(string buf, out FtpItem item)
        {
            item = new FtpItem();
            Match m;

            if (!(m = Regex.Match(buf, "type=(?<type>.+?);", RegexOptions.IgnoreCase)).Success)
                return false;

            switch (m.Groups["type"].Value.ToLower())
            {
                case "dir":
                    item.Type = FtpFileSystemObjectType.Directory;
                    break;
                case "file":
                    item.Type = FtpFileSystemObjectType.File;
                    break;
                    // These are not supported for now.
                case "link":
                case "device":
                default:
                    return false;
            }

            if ((m = Regex.Match(buf, "; (?<name>.*)$", RegexOptions.IgnoreCase)).Success)
                item.Name = m.Groups["name"].Value;
            else // if we can't parse the file name there is a problem.
                return false;

            if ((m = Regex.Match(buf, "modify=(?<modify>.+?);", RegexOptions.IgnoreCase)).Success)
                item.Modified = m.Groups["modify"].Value.GetFtpDate(DateTimeStyles.AssumeUniversal);

            if ((m = Regex.Match(buf, "created?=(?<create>.+?);", RegexOptions.IgnoreCase)).Success)
                item.Created = m.Groups["create"].Value.GetFtpDate(DateTimeStyles.AssumeUniversal);

            if ((m = Regex.Match(buf, @"size=(?<size>\d+);", RegexOptions.IgnoreCase)).Success)
            {
                long size;

                if (long.TryParse(m.Groups["size"].Value, out size))
                    item.Size = size;
            }

            if ((m = Regex.Match(buf, @"unix.mode=(?<mode>\d+);", RegexOptions.IgnoreCase)).Success)
            {
                if (m.Groups["mode"].Value.Length == 4)
                {
                    item.SpecialPermissions = (FtpSpecialPermissions)int.Parse(m.Groups["mode"].Value[0].ToString());
                    item.OwnerPermissions = (FtpPermission)int.Parse(m.Groups["mode"].Value[1].ToString());
                    item.GroupPermissions = (FtpPermission)int.Parse(m.Groups["mode"].Value[2].ToString());
                    item.OthersPermissions = (FtpPermission)int.Parse(m.Groups["mode"].Value[3].ToString());
                }
                else if (m.Groups["mode"].Value.Length == 3)
                {
                    item.OwnerPermissions = (FtpPermission)int.Parse(m.Groups["mode"].Value[0].ToString());
                    item.GroupPermissions = (FtpPermission)int.Parse(m.Groups["mode"].Value[1].ToString());
                    item.OthersPermissions = (FtpPermission)int.Parse(m.Groups["mode"].Value[2].ToString());
                }
            }

            return true;
        }

        /// <summary>
        /// Parses LIST format listings
        /// </summary>
        /// <param name="buf">A line from the listing</param>
        /// <param name="capabilities">Server capabilities</param>
        /// <param name="item"></param>
        /// <returns>if the item is able to be parsed</returns>
        static bool TryParseUnixList(string buf, FtpCapability capabilities, out FtpItem item)
        {
            string regex =
                @"(?<permissions>[\w-]{10})\s+" +
                @"(?<objectcount>\d+)\s+" +
                @"(?<user>[\w\d]+)\s+" +
                @"(?<group>[\w\d]+)\s+" +
                @"(?<size>\d+)\s+" +
                @"(?<modify>\w+\s+\d+\s+\d+:\d+|\w+\s+\d+\s+\d+)\s+" +
                @"(?<name>.*)$";

            item = new FtpItem();
            Match m;

            if (!(m = Regex.Match(buf, regex, RegexOptions.IgnoreCase)).Success)
                return false;

            if (m.Groups["permissions"].Value.StartsWith("d"))
                item.Type = FtpFileSystemObjectType.Directory;
            else if (m.Groups["permissions"].Value.StartsWith("-"))
                item.Type = FtpFileSystemObjectType.File;
            else
                return false;

            // if we can't determine a file name then
            // we are not considering this a successful parsing operation.
            if (m.Groups["name"].Value.Length < 1)
                return false;
            item.Name = m.Groups["name"].Value;

            if (item.Type == FtpFileSystemObjectType.Directory && (item.Name == "." || item.Name == ".."))
                return false;

            ////
            // Ignore the Modify times sent in LIST format for files
            // when the server has support for the MDTM command
            // because they will never be as accurate as what can be had 
            // by using the MDTM command. MDTM does not work on directories
            // so if a modify time was parsed from the listing we will try
            // to convert it to a DateTime object and use it for directories.
            ////
            if ((!capabilities.HasFlag(FtpCapability.MDTM) || item.Type == FtpFileSystemObjectType.Directory) && m.Groups["modify"].Value.Length > 0)
                item.Modified = m.Groups["modify"].Value.GetFtpDate(DateTimeStyles.AssumeLocal);

            if (m.Groups["size"].Value.Length > 0)
            {
                long size;

                if (long.TryParse(m.Groups["size"].Value, out size))
                    item.Size = size;
            }

            if (m.Groups["permissions"].Value.Length > 0)
            {
                Match perms = Regex.Match(m.Groups["permissions"].Value,
                                          @"[\w-]{1}(?<owner>[\w-]{3})(?<group>[\w-]{3})(?<others>[\w-]{3})",
                                          RegexOptions.IgnoreCase);

                if (perms.Success)
                {
                    if (perms.Groups["owner"].Value.Length == 3)
                    {
                        if (perms.Groups["owner"].Value[0] == 'r')
                            item.OwnerPermissions |= FtpPermission.Read;
                        if (perms.Groups["owner"].Value[1] == 'w')
                            item.OwnerPermissions |= FtpPermission.Write;
                        if (perms.Groups["owner"].Value[2] == 'x' || perms.Groups["owner"].Value[2] == 's')
                            item.OwnerPermissions |= FtpPermission.Execute;
                        if (perms.Groups["owner"].Value[2] == 's' || perms.Groups["owner"].Value[2] == 'S')
                            item.SpecialPermissions |= FtpSpecialPermissions.SetUserID;
                    }

                    if (perms.Groups["group"].Value.Length == 3)
                    {
                        if (perms.Groups["group"].Value[0] == 'r')
                            item.GroupPermissions |= FtpPermission.Read;
                        if (perms.Groups["group"].Value[1] == 'w')
                            item.GroupPermissions |= FtpPermission.Write;
                        if (perms.Groups["group"].Value[2] == 'x' || perms.Groups["group"].Value[2] == 's')
                            item.GroupPermissions |= FtpPermission.Execute;
                        if (perms.Groups["group"].Value[2] == 's' || perms.Groups["group"].Value[2] == 'S')
                            item.SpecialPermissions |= FtpSpecialPermissions.SetGroupID;
                    }

                    if (perms.Groups["others"].Value.Length == 3)
                    {
                        if (perms.Groups["others"].Value[0] == 'r')
                            item.OthersPermissions |= FtpPermission.Read;
                        if (perms.Groups["others"].Value[1] == 'w')
                            item.OthersPermissions |= FtpPermission.Write;
                        if (perms.Groups["others"].Value[2] == 'x' || perms.Groups["others"].Value[2] == 't')
                            item.OthersPermissions |= FtpPermission.Execute;
                        if (perms.Groups["others"].Value[2] == 't' || perms.Groups["others"].Value[2] == 'T')
                            item.SpecialPermissions |= FtpSpecialPermissions.Sticky;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Parses IIS DOS format listings
        /// </summary>
        /// <param name="buf">A line from the listing</param>
        /// <param name="item"></param>
        /// <returns>if the item is able to be parsed</returns>
        static bool TryParseDosList(string buf, out FtpItem item)
        {
            item = new FtpItem();
            string[] datefmt = new string[] {
                "MM-dd-yy  hh:mmtt",
                "MM-dd-yyyy  hh:mmtt"
            };
            Match m;

            // directory
            if ((m = Regex.Match(buf, @"(?<modify>\d+-\d+-\d+\s+\d+:\d+\w+)\s+<DIR>\s+(?<name>.*)$", RegexOptions.IgnoreCase)).Success)
            {
                DateTime modify;

                item.Type = FtpFileSystemObjectType.Directory;
                item.Name = m.Groups["name"].Value;

                //if (DateTime.TryParse(m.Groups["modify"].Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out modify))
                if (DateTime.TryParseExact(m.Groups["modify"].Value, datefmt, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out modify))
                    item.Modified = modify;
            }
                // file
            else if ((m = Regex.Match(buf, @"(?<modify>\d+-\d+-\d+\s+\d+:\d+\w+)\s+(?<size>\d+)\s+(?<name>.*)$", RegexOptions.IgnoreCase)).Success)
            {
                DateTime modify;
                long size;

                item.Type = FtpFileSystemObjectType.File;
                item.Name = m.Groups["name"].Value;

                if (long.TryParse(m.Groups["size"].Value, out size))
                    item.Size = size;

                //if (DateTime.TryParse(m.Groups["modify"].Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out modify))
                if (DateTime.TryParseExact(m.Groups["modify"].Value, datefmt, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out modify))
                    item.Modified = modify;
            }
            else
                return false;

            return true;
        }

        static bool TryParseVaxList(string buf, out FtpItem item)
        {
            string regex =
                @"(?<name>.+)\.(?<extension>.+);(?<version>\d+)\s+" +
                @"(?<size>\d+)\s+" +
                @"(?<modify>\d+-\w+-\d+\s+\d+:\d+)";
            Match m;

            item = new FtpItem();

            if ((m = Regex.Match(buf, regex)).Success)
            {


                item.FullName = string.Format("{0}.{1};{2}",
                                              m.Groups["name"].Value,
                                              m.Groups["extension"].Value,
                                              m.Groups["version"].Value);

                if (m.Groups["extension"].Value.ToUpper() == "DIR")
                    item.Type = FtpFileSystemObjectType.Directory;
                else
                    item.Type = FtpFileSystemObjectType.File;

                long size;
                if (!long.TryParse(m.Groups["size"].Value, out size))
                    item.Size = -1;
                else
                    item.Size = size;

                DateTime date;
                if (!DateTime.TryParse(m.Groups["modify"].Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out date))
                    item.Modified = DateTime.MinValue;
                else
                    item.Modified = date;

                return true;
            }

            return false;
        }
    }
}