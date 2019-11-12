using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Storage.Streams;
using Cubisoft.Winrt.Ftp.Messages;

namespace Cubisoft.Winrt.Ftp
{
    /// <summary>
    /// This interfaces was added for users using the MoQ framework
    /// for unit testing.
    /// </summary>
    public interface IFtpClient
    {
        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        FtpCapability Capabilities { get; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        HostName HostName { get; set; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        NetworkCredential Credentials { get; set; }


        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        bool DataConnectionEncryption { get; set; }


        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        FtpDataConnectionType DataConnectionType { get; set; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        string ServiceName { get; set; }

        FtpClientConfiguration Configuration { get; set; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        //bool EnableThreadSafeDataConnections { get; set; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        Encoding Encoding { get; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        //FtpEncryptionMode EncryptionMode { get; set; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        //bool SocketKeepAlive { get; set; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        //string SystemType { get; }

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        Task ConnectAsync();

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="force"></param>
        Task CreateDirectoryAsync(string path, bool force);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="force"></param>
        /// <param name="options"></param>
        Task DeleteDirectoryAsync(string path, bool force, FtpListOption options);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        Task DeleteFileAsync(string path);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<bool> DirectoryExistsAsync(string path);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        Task DisconnectAsync();

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<FtpResponse> ExecuteAsync(string command, params object[] args);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<bool> FileExistsAsync(string path, FtpListOption options);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<long> GetFileSizeAsync(string path);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        Task<IEnumerable<FtpItem>> GetListingAsync(string path, FtpListOption options);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<DateTime> GetModifiedTimeAsync(string path);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetNameListingAsync(string path);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <returns></returns>
        Task<string> GetWorkingDirectoryAsync();

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<IOutputStream> OpenAppendAsync(string path, FtpDataType type);

        /// <summary>
        /// Opens the specified file for reading
        /// </summary>
        /// <param name="path">The full or relative path of the file</param>
        /// <param name="type">ASCII/Binary</param>
        /// <param name="restart">Resume location</param>
        /// <returns>A stream for reading the file on the server</returns>
        Task<IInputStream> OpenReadAsync(string path, FtpDataType type = FtpDataType.Binary, long restart = 0);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<IOutputStream> OpenWriteAsync(string path, FtpDataType type);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dest"></param>
        Task RenameAsync(string path, string dest);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="type"></param>
        Task SetDataTypeAsync(FtpDataType type);

        /// <summary>
        /// Added for the MoQ unit testing framework
        /// </summary>
        /// <param name="path"></param>
        Task SetWorkingDirectoryAsync(string path);
    }
}
