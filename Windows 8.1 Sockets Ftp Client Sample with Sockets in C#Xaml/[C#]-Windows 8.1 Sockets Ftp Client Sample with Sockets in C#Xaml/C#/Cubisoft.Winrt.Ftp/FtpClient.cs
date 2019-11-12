using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Storage;
using Windows.Storage.Streams;
using Cubisoft.Winrt.Ftp.Messages;

namespace Cubisoft.Winrt.Ftp
{
    public class FtpClient : IDisposable
    {
        #region Private Members

        /// <summary>
        /// Control connection socket stream
        /// </summary>
        private FtpStreamChannel m_Stream;

        private HostName m_HostName;

        private string m_ServiceName;

        private Encoding m_Encoding = new ASCII();

        private NetworkCredential m_Credentials;

        private FtpDataConnectionType m_DataConnectionType = FtpDataConnectionType.AutoPassive;

        private FtpClientConfiguration m_Configuration = new FtpClientConfiguration();

        private FtpCapability m_Caps = FtpCapability.NONE;

        private bool m_DataConnectionEncryption;

        #endregion

        public FtpClient(Uri host = null, NetworkCredential credential = null)
        {
            if (host != null)
            {
                m_HostName = new HostName(host.Host);
                m_ServiceName = "21";
            }

            if (credential != null)
            {
                m_Credentials = credential;
            }
        }

        #region Public Properties

        /// <summary>
        /// Gets the server capabilties represented by flags
        /// </summary>
        public FtpCapability Capabilities
        {
            get
            {
                if (m_Stream == null || !m_Stream.IsConnected)
                {
                    //Connect();
                }

                return m_Caps;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected FtpStreamChannel BaseStream
        {
            get { return m_Stream; }
        }

        /// <summary>
        /// Gets a value indicating if the connection is alive
        /// </summary>
        public bool IsConnected
        {
            get { return m_Stream != null && m_Stream.IsConnected; }
        }

        /// <summary>
        /// 
        /// </summary>
        public HostName HostName
        {
            get { return m_HostName; }
            set { m_HostName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ServiceName
        {
            get { return m_ServiceName; }
            set { m_ServiceName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool DataConnectionEncryption
        {
            get { return m_DataConnectionEncryption; }
            set { m_DataConnectionEncryption = value; }
        }

        /// <summary>
        /// Data connection type, default is AutoPassive which tries
        /// a connection with EPSV first and if it fails then tries
        /// PASV before giving up. If you know exactly which kind of
        /// connection you need you can slightly increase performance
        /// by defining a speicific type of passive or active data
        /// connection here.
        /// </summary>
        public FtpDataConnectionType DataConnectionType
        {
            get { return m_DataConnectionType; }
            set { m_DataConnectionType = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Encoding Encoding
        {
            get { return m_Encoding; }
        }

        /// <summary>
        /// Credentials used for authentication
        /// </summary>
        public NetworkCredential Credentials
        {
            get { return m_Credentials; }
            set { m_Credentials = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public FtpClientConfiguration Configuration
        {
            get { return m_Configuration; }
            set { m_Configuration = value; }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Retreives a reply from the server. Do not execute this method
        /// unless you are sure that a reply has been sent, i.e., you
        /// executed a command. Doing so will cause the code to hang
        /// indefinitely waiting for a server reply that is never comming.
        /// </summary>
        /// <returns>FtpReply representing the response from the server</returns>
        internal async Task<FtpResponse> GetReplyAsync()
        {
            var reply = new FtpResponse();

            if (!IsConnected)
                throw new InvalidOperationException("No connection to the server has been established.");

            string buf;

            while ((buf = await m_Stream.ReadLineAsync(Encoding)) != null)
            {
                Match m;

                System.Diagnostics.Debug.WriteLine(buf);

                if ((m = Regex.Match(buf, "^(?<code>[0-9]{3}) (?<message>.*)$")).Success)
                {
                    reply.Code = m.Groups["code"].Value;
                    reply.Message = m.Groups["message"].Value;
                    break;
                }

                reply.InfoMessages += string.Format("{0}\n", buf);
            }

            return reply;
        }

        /// <summary>
        /// Populates the capabilities flags based on capabilities
        /// supported by this server. This method is overridable
        /// so that new features can be supported
        /// </summary>
        /// <param name="reply">The reply object from the FEAT command. The InfoMessages property will
        /// contain a list of the features the server supported delimited by a new line '\n' character.</param>
        internal void ParseFeatures(FtpResponse reply)
        {
            foreach (string feat in reply.InfoMessages.Split(new []{"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (feat.ToUpper().Trim().StartsWith("MLST") || feat.ToUpper().Trim().StartsWith("MLSD"))
                    m_Caps |= FtpCapability.MLSD;
                else if (feat.ToUpper().Trim().StartsWith("MDTM"))
                    m_Caps |= FtpCapability.MDTM;
                else if (feat.ToUpper().Trim().StartsWith("REST STREAM"))
                    m_Caps |= FtpCapability.REST;
                else if (feat.ToUpper().Trim().StartsWith("SIZE"))
                    m_Caps |= FtpCapability.SIZE;
                else if (feat.ToUpper().Trim().StartsWith("UTF8"))
                    m_Caps |= FtpCapability.UTF8;
                else if (feat.ToUpper().Trim().StartsWith("PRET"))
                    m_Caps |= FtpCapability.PRET;
                else if (feat.ToUpper().Trim().StartsWith("MFMT"))
                    m_Caps |= FtpCapability.MFMT;
                else if (feat.ToUpper().Trim().StartsWith("MFCT"))
                    m_Caps |= FtpCapability.MFCT;
                else if (feat.ToUpper().Trim().StartsWith("MFF"))
                    m_Caps |= FtpCapability.MFF;
            }
        }

        /// <summary>
        /// Performs a login on the server.
        /// </summary>
        internal async Task AuthenticateAsync(NetworkCredential credential)
        {
            FtpResponse reply;

            if (!(reply = await m_Stream.SetUserAsync(credential.UserName)).Success)
                System.Diagnostics.Debug.WriteLine(reply.Message);

            if (reply.Type == FtpResponseType.PositiveIntermediate && !(reply = await m_Stream.SetPasswordAsync(credential.Password)).Success)
                System.Diagnostics.Debug.WriteLine(reply.Message);
        }

        #endregion

        #region Public Methods

        #region General Methods

        /// <summary>
        /// Connect to the server
        /// </summary>
        public async Task ConnectAsync()
        {
            if (m_Stream == null)
            {
                m_Stream = new FtpStreamChannel();
            }
            else
            {
                if (IsConnected) await DisconnectAsync();
            }

            if (HostName == null)
                throw new FtpException("No host has been specified");

            if (Credentials == null)
                throw new FtpException("No credentials have been specified");

            FtpResponse reply;

            if (await m_Stream.ConnectAsync(HostName, ServiceName))
            {
                if (!(reply = await GetReplyAsync()).Success)
                {
                    if (reply.Code == null)
                    {
                        throw new IOException("The connection was terminated before a greeting could be read.");
                    }

                    throw new FtpCommandException(reply);
                }
            }

            // TODO: If the encryption mode is set to explicit, raise to SSL

            if (Credentials != null)
            {
                await AuthenticateAsync(Credentials);
            }

            if ((reply = await m_Stream.GetFeaturesAsync()).Success)
                m_Caps = ((FtpFeaturesResponse) reply).Features;

            // Enable UTF8 if it's available
            if (m_Caps.HasFlag(FtpCapability.UTF8))
            {
                // If the server supports UTF8 it should already be enabled and this
                // command should not matter however there are conflicting drafts
                // about this so we'll just execute it to be safe. 
                await m_Stream.SetOptionsAsync("UTF8 ON");
                m_Stream.Encoding = Encoding.UTF8;
            }
        }

        /// <summary>
        /// Disconnect from the server
        /// </summary>
        public async Task DisconnectAsync()
        {
            if (m_Stream == null || !m_Stream.IsConnected) return;

            try
            {
                await m_Stream.DisconnectAsync();
            }
            catch (IOException e)
            {
                System.Diagnostics.Debug.WriteLine("IOException thrown closing control connectin: " + e);
            }
            finally
            {
                m_Stream.Dispose();
            }
        }

        /// <summary>
        /// Sets the data type of information sent over the data stream
        /// </summary>
        /// <param name="type">ASCII/Binary</param>
        public async Task SetDataTypeAsync(FtpDataType type)
        {
            FtpResponse reply;

            if (!(reply = await m_Stream.SetDataTypeAsync(type)).Success)
                throw new FtpCommandException(reply);
        }

        #endregion

        #region Directory Methods

        /// <summary>
        /// Sets the work directory on the server
        /// </summary>
        /// <param name="path">The path of the directory to change to</param>
        public async Task SetWorkingDirectoryAsync(string path)
        {
            FtpResponse reply;

            if (!(reply = await m_Stream.SetDirectoryAsync(path.GetFtpPath())).Success)
                throw new FtpCommandException(reply);
        }


        /// <summary>
        /// Gets the current working directory
        /// </summary>
        /// <returns>The current working directory</returns>
        public async Task<string> GetWorkingDirectoryAsync()
        {
            FtpGetDirectoryResponse reply;

            if (!(reply = await m_Stream.GetDirectoryAsync()).Success)
                throw new FtpCommandException(reply);

            return reply.Directory;

        }

        /// <summary>
        /// Tests if the specified directory exists on the server. This
        /// method works by trying to change the working directory to
        /// the path specified. If it succeeds, the directory is changed
        /// back to the old working directory and true is returned. False
        /// is returned otherwise and since the CWD failed it is assumed
        /// the working directory is still the same.
        /// </summary>
        /// <param name="path">The path of the directory</param>
        /// <returns>True if it exists, false otherwise.</returns>
        public async Task<bool> DirectoryExistsAsync(string path)
        {
            if (path.GetFtpPath() == "/")
                return true;

            string pwd = await GetWorkingDirectoryAsync();

            // If the current directory is the one we are trying to set, return
            if (pwd.GetFtpPath() == path.GetFtpPath()) return true;

            // Try to set the working directory to the path
            if ((await m_Stream.SetDirectoryAsync(path)).Success)
            {
                // If result is successful, set it back to the current working directory
                FtpResponse reply = await m_Stream.SetDirectoryAsync(pwd);

                if (!reply.Success)
                    throw new FtpException("DirectoryExists(): Failed to restore the working directory.");

                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a directory on the server
        /// </summary>
        /// <param name="path">The full or relative path to the directory to create</param>
        /// <param name="force">Try to force all non-existant pieces of the path to be created</param>
        public async Task CreateDirectoryAsync(string path, bool force = true)
        {
            FtpResponse reply;

            if (path.GetFtpPath() == "/") return;

            var workingDirectory = await GetWorkingDirectoryAsync();
            workingDirectory = workingDirectory.GetFtpPath();

            if (workingDirectory.GetFtpPath() == path.GetFtpPath()) return;

            path = path.GetFtpPath().TrimEnd('/');

            if (force && !(await DirectoryExistsAsync(path.GetFtpDirectoryName())))
            {
                System.Diagnostics.Debug.WriteLine("CreateDirectory(\"{0}\", true): Create non-existent parent: {1}", path, path.GetFtpDirectoryName());
                await CreateDirectoryAsync(path.GetFtpDirectoryName());
            }
            else if (await DirectoryExistsAsync(path))
                return;

            System.Diagnostics.Debug.WriteLine("CreateDirectory(\"{0}\", {1})", path.GetFtpPath(), force);

            if (!(reply = await m_Stream.CreateDirectoryAsync(path)).Success)
                throw new FtpCommandException(reply);
        }

        /// <summary>
        /// Deletes the specified directory on the server
        /// </summary>
        /// <param name="path">The full or relative path of the directory to delete</param>
        /// <param name="force">If the directory is not empty, remove its contents</param>
        public async Task DeleteDirectoryAsync(string path, bool force = false)
        {
            FtpResponse reply;

            if (force)
            {
                var listing = await GetListingAsync(path);

                // force the LIST -a command so hidden files
                // and folders get removed too
                foreach (FtpItem item in listing)
                {
                    switch (item.Type)
                    {
                        case FtpFileSystemObjectType.File:
                            await DeleteFileAsync(item.FullName);
                            break;
                        case FtpFileSystemObjectType.Directory:
                            await DeleteDirectoryAsync(item.FullName, true);
                            break;
                        default:
                            throw new FtpException("Don't know how to delete object type: " + item.Type);
                    }
                }
            }

            if (!(reply = await m_Stream.DeleteDirectoryAsync(path.GetFtpPath())).Success)
                throw new FtpCommandException(reply);
        }

        #endregion

        /// <summary>
        /// Deletes a file on the server
        /// </summary>
        /// <param name="path">The full or relative path to the file</param>
        public async Task DeleteFileAsync(string path)
        {
            FtpResponse reply;

            if (!(reply = await m_Stream.DeleteFileAsync(path.GetFtpPath())).Success)
                throw new FtpCommandException(reply);
        }

        /// <summary>
        /// Checks if a file exsts on the server by taking a 
        /// file listing of the parent directory in the path
        /// and comparing the results the path supplied.
        /// </summary>
        /// <param name="path">The full or relative path to the file</param>
        /// <param name="options">Options for controling the file listing used to
        /// determine if the file exists.</param>
        /// <returns>True if the file exists</returns>
        public async Task<bool> FileExistsAsync(string path, FtpListOption options = 0)
        {
            string dirname = path.GetFtpDirectoryName();

            if (!(await DirectoryExistsAsync(dirname)))
                return false;

            var directoryListing = await GetListingAsync(dirname);

            if (directoryListing.Any(item => item.Type == FtpFileSystemObjectType.File && item.Name.GetFtpFileName() == path.GetFtpFileName()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the size of the file
        /// </summary>
        /// <param name="path">The full or relative path of the file</param>
        /// <returns>-1 if the command fails, otherwise the file size</returns>
        public Task<long> GetFileSizeAsync(string path)
        {
            return m_Stream.GetFileSizeAsync(path).ContinueWith(task => task.Result.Size);
        }

        public Task<List<FtpItem>> GetListingAsync(string path = null)
        {
            return m_Stream.GetListingAsync(path).ContinueWith(task =>
                {
                    var ftpResponse = task.Result;
                    ftpResponse.Features = m_Caps;
                    return ftpResponse.Items;
                });
        }

        /// <summary>
        /// Gets the modified time of the file
        /// </summary>
        /// <param name="path">The full path to the file</param>
        /// <returns>The modified time, DateTime.MinValue if there was a problem</returns>
        public Task<DateTime> GetModifiedTimeAsync(string path)
        {
            return m_Stream.GetModifiedTimeAsync(path).ContinueWith(task => task.Result.Modified);
        }

        /// <summary>
        /// Renames an object on the remote file system.
        /// </summary>
        /// <param name="path">The full or relative path to the object</param>
        /// <param name="dest">The old or new full or relative path including the new name of the object</param>
        public Task RenameAsync(string path, string dest)
        {
            // TODO: Implement RenameAsync
            throw new NotImplementedException();
        }

        public async Task<StorageFile> RetrieveFileAsync(string path)
        {
            if (!(await FileExistsAsync(path)))
            {
                throw new FileNotFoundException("FTP file could not be retrieved", path);
            }

            StorageFile resultantFile;
            FtpResponse reply;

            //
            // A more efficient way, maybe a DataReader can be used here
            using (var stream = await OpenReadAsync(path))
            {
                var buffer = new byte[512].AsBuffer();
                var resultingBuffer = new byte[0];

                while (true)
                {
                    IBuffer readBuffer = await stream.ReadAsync(buffer, 512, InputStreamOptions.Partial);

                    if (readBuffer.Length == 0) break;

                    resultingBuffer = resultingBuffer.Concat(readBuffer.ToArray()).ToArray();
                }

                resultantFile = await StorageFile.CreateStreamedFileAsync(path.GetFtpFileName(), async (fileStream) =>
                {
                    await fileStream.WriteAsync(resultingBuffer.AsBuffer());
                    fileStream.FlushAsync();
                    fileStream.Dispose();
                }, null);
            }

            if (!(reply = await CloseDataStreamAsync(null)).Success)
            {
                throw new FtpCommandException(reply);
            }

            return resultantFile;
        }

        public async Task UploadFileAsync(StorageFile file, string destination)
        {
            using (var stream = await OpenWriteAsync(destination))
            {
                //
                // A more efficient way, maybe a DataReader can be used here
                using (var readStream = await file.OpenReadAsync())
                {
                    var buffer = new byte[512].AsBuffer();
                    var resultingBuffer = new byte[0];

                    while (true)
                    {
                        IBuffer readBuffer = await readStream.ReadAsync(buffer, 512, InputStreamOptions.Partial);

                        if (readBuffer.Length == 0) break;

                        resultingBuffer = resultingBuffer.Concat(readBuffer.ToArray()).ToArray();
                    }

                    await stream.WriteAsync(resultingBuffer.AsBuffer());
                    await stream.FlushAsync();
                }
            }
        }

        #region Stream Methods

        /// <summary>
        /// Opens the specified file to be appended to
        /// </summary>
        /// <param name="path">The full or relative path to the file to be opened</param>
        /// <param name="type">ASCII/Binary</param>
        /// <returns>A stream for writing to the file on the server</returns>
        public async Task<IOutputStream> OpenAppendAsync(string path, FtpDataType type = FtpDataType.Binary)
        {
            // TODO: Implement OpenReadAsync
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens the specified file for reading
        /// </summary>
        /// <param name="path">The full or relative path of the file</param>
        /// <param name="type">ASCII/Binary</param>
        /// <param name="restart">Resume location</param>
        /// <returns>A stream for reading the file on the server</returns>
        public async Task<IInputStream> OpenReadAsync(string path, FtpDataType type = FtpDataType.Binary, long restart = 0)
        {
            await SetWorkingDirectoryAsync(path.GetFtpDirectoryName());

            await SetDataTypeAsync(type);

            var stream = await OpenDataStreamAsync(new FtpRetrieveRequest(path));

            return stream.InputStream;
        }

        /// <summary>
        /// Opens the specified file for writing
        /// </summary>
        /// <param name="path">Full or relative path of the file</param>
        /// <param name="type">ASCII/Binary</param>
        /// <returns>A stream for writing to the file on the server</returns>
        public async Task<IOutputStream> OpenWriteAsync(string path, FtpDataType type = FtpDataType.Binary)
        {
            await SetWorkingDirectoryAsync(path.GetFtpDirectoryName());

            await SetDataTypeAsync(type);

            var stream = await OpenDataStreamAsync(new FtpStoreRequest(path));

            return stream.OutputStream;
        }

        /// <summary>
        /// Opens a data stream.
        /// </summary>
        /// <param name='request'>The command to execute that requires a data stream</param>
        /// <returns>The data stream.</returns>
        public async Task<FtpStreamChannel> OpenDataStreamAsync(FtpRequest request)
        {
            FtpStreamChannel stream = null;
            FtpDataConnectionType type = m_DataConnectionType;

            // The PORT and PASV commands do not work with IPv6 so
            // if either one of those types are set change them
            // to EPSV or EPRT appropriately.
            if (m_Stream.LocalEndPoint.Type == HostNameType.Ipv6)
            {
                switch (type)
                {
                    case FtpDataConnectionType.PORT:
                        type = FtpDataConnectionType.EPRT;
                        Debug.WriteLine("Changed data connection type to EPRT because we are connected with IPv6.");
                        break;
                    case FtpDataConnectionType.PASV:
                    case FtpDataConnectionType.PASVEX:
                        type = FtpDataConnectionType.EPSV;
                        Debug.WriteLine("Changed data connection type to EPSV because we are connected with IPv6.");
                        break;
                }
            }

            switch (type)
            {
                case FtpDataConnectionType.AutoPassive:
                case FtpDataConnectionType.EPSV:
                case FtpDataConnectionType.PASV:
                case FtpDataConnectionType.PASVEX:
                    stream = await m_Stream.OpenPassiveDataStreamAsync(type, request);
                    break;
                case FtpDataConnectionType.AutoActive:
                case FtpDataConnectionType.EPRT:
                case FtpDataConnectionType.PORT:
                    // TODO:
                    break;
            }

            if (stream == null)
            {
                throw new InvalidOperationException("The specified data channel type is not implemented.");
            }


            return stream;
        }

        public async Task<FtpResponse> CloseDataStreamAsync(FtpStreamChannel channel)
        {
            var finalResponse = await m_Stream.GetReplyAsync<FtpResponse>();

            return finalResponse;
        }

        #endregion

        #endregion


        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
