using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Cubisoft.Winrt.Ftp.Messages;

namespace Cubisoft.Winrt.Ftp
{
    public class FtpStreamChannel: IDisposable, IFtpChannel
    {
        private Encoding m_Encoding = new System.Text.ASCII();

        private bool m_IsConnected = false;

        private StreamSocket m_StreamSocket = null;

        /// <summary>
        /// Gets a value indicating if this socket stream is connected
        /// </summary>
        public bool IsConnected
        {
            get { return m_IsConnected; }
        }

        /// <summary>
        /// Gets the local end point of the socket
        /// </summary>
        public HostName LocalEndPoint
        {
            get
            {
                if (m_StreamSocket == null)
                    return null;
                return (HostName)m_StreamSocket.Information.LocalAddress;
            }
        }

        /// <summary>
        /// Gets the remote end point of the socket
        /// </summary>
        public HostName RemoteEndPoint
        {
            get
            {
                if (m_StreamSocket == null)
                    return null;
                return (HostName)m_StreamSocket.Information.RemoteAddress;
            }
        }

        public IInputStream InputStream 
        {
            get
            {
                if (m_StreamSocket == null) return null;

                return m_StreamSocket.InputStream;
            }
        }

        public IOutputStream OutputStream
        {
            get
            {
                if (m_StreamSocket == null) return null;

                return m_StreamSocket.OutputStream;
            }
        }

        public Encoding Encoding
        {
            get { return m_Encoding; }
            set { m_Encoding = value; }
        }

        #region Internal Methods

        public async Task<bool> ConnectAsync(HostName host, string service)
        {
            m_StreamSocket = new StreamSocket();

            try
            {
                await m_StreamSocket.ConnectAsync(host, service, SocketProtectionLevel.PlainSocket);

                m_IsConnected = true;
            }
            catch (Exception ex)
            {
                var socketError = SocketError.GetStatus(ex.HResult);

                System.Diagnostics.Debug.WriteLine("There was a connection problem: {0}", ex.Message);

                System.Diagnostics.Debug.WriteLine("Socket Error: {0}", socketError);

                return false;
            }

            return true;
        }

        public Task<FtpResponse> DisconnectAsync()
        {
            return ExecuteAsync<FtpResponse>(new FtpQuitRequest());
        }

        public Task<FtpFeaturesResponse> GetFeaturesAsync()
        {
            return ExecuteAsync<FtpFeaturesResponse>(new FtpFeaturesRequest());
        }

        public Task<FtpResponse> SetOptionsAsync(string option)
        {
            return SetOptionsAsync(new FtpOptionsRequest(option));
        }

        public Task<FtpResponse> SetOptionsAsync(FtpOptionsRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpResponse> SetDataTypeAsync(FtpDataType type)
        {
            return ExecuteAsync<FtpResponse>(new FtpSetDataTypeRequest(type));
        }

        public Task<FtpResponse> SetUserAsync(string username)
        {
            return SetUserAsync(new FtpUserRequest(username));
        }

        public Task<FtpResponse> SetUserAsync(FtpUserRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpResponse> SetPasswordAsync(string password)
        {
            return SetPasswordAsync(new FtpPasswordRequest(password));
        }

        public Task<FtpResponse> SetPasswordAsync(FtpPasswordRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpResponse> SetDirectoryAsync(string directory)
        {
            return SetDirectoryAsync(new FtpSetDirectoryRequest(directory));
        }

        public Task<FtpResponse> SetDirectoryAsync(FtpSetDirectoryRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpGetDirectoryResponse> GetDirectoryAsync()
        {
            return ExecuteAsync<FtpGetDirectoryResponse>(new FtpGetDirectoryRequest());
        }

        public Task<FtpResponse> CreateDirectoryAsync(string path)
        {
            return CreateDirectoryAsync(new FtpCreateDirectoryRequest(path));
        }

        public Task<FtpResponse> CreateDirectoryAsync(FtpCreateDirectoryRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpResponse> DeleteDirectoryAsync(string path)
        {
            return DeleteDirectoryAsync(new FtpDeleteDirectoryRequest(path));
        }

        public Task<FtpResponse> DeleteDirectoryAsync(FtpDeleteDirectoryRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpFileSizeResponse> GetFileSizeAsync(string path)
        {
            return GetFileSizeAsync(new FtpFileSizeRequest(path));
        }

        public Task<FtpFileSizeResponse> GetFileSizeAsync(FtpFileSizeRequest request)
        {
            return ExecuteAsync<FtpFileSizeResponse>(request);
        }

        public Task<FtpModifiedTimeResponse> GetModifiedTimeAsync(string path)
        {
            return GetModifiedTimeAsync(new FtpModifiedTimeRequest(path));
        }

        public Task<FtpModifiedTimeResponse> GetModifiedTimeAsync(FtpModifiedTimeRequest request)
        {
            return ExecuteAsync<FtpModifiedTimeResponse>(request);
        }

        public Task<FtpResponse> DeleteFileAsync(string path)
        {
            return DeleteFileAsync(new FtpDeleteFileRequest(path));
        }

        public Task<FtpResponse> DeleteFileAsync(FtpDeleteFileRequest request)
        {
            return ExecuteAsync<FtpResponse>(request);
        }

        public Task<FtpPassiveModeResponse> SetPassiveMode()
        {
            return ExecuteAsync<FtpPassiveModeResponse>(new FtpPassiveModeRequest());
        }

        public Task<FtpExtendedPassiveModeResponse> SetExtendedPassiveMode()
        {
            return ExecuteAsync<FtpExtendedPassiveModeResponse>(new FtpExtendedPassiveModeRequest())
                .ContinueWith(task =>
                    {
                        var response = task.Result;
                        response.HostName = RemoteEndPoint;
                        return response;
                    });
        }

        public async Task<FtpGetListingResponse> GetListingAsync(string path = null)
        {
            if (path == null || path.Trim().Length == 0)
                path = (await GetDirectoryAsync()).Directory;

            // always get the file listing in binary
            // to avoid any potential character translation
            // problems that would happen if in ASCII.
            await SetDataTypeAsync(FtpDataType.Binary);

            return await ExecuteInDuplexAsync<FtpGetListingResponse>(FtpDataConnectionType.AutoPassive, new FtpListRequest(path));
        }

        public async Task<FtpStreamChannel> OpenPassiveDataStreamAsync(FtpDataConnectionType connectionType, FtpRequest request)
        {
            FtpPassiveModeResponse reply;

            if (connectionType == FtpDataConnectionType.EPSV || connectionType == FtpDataConnectionType.AutoPassive)
            {
                if (!(reply = await SetExtendedPassiveMode()).Success)
                {
                    // if we're connected with IPv4 and data channel type is AutoPassive then fallback to IPv4
                    if (reply.Type == FtpResponseType.PermanentNegativeCompletion && connectionType == FtpDataConnectionType.AutoPassive && LocalEndPoint.Type == HostNameType.Ipv4)
                        return await OpenPassiveDataStreamAsync(FtpDataConnectionType.PASV, request);

                    throw new FtpCommandException(reply);
                }
            }
            else
            {
                if (LocalEndPoint.Type != HostNameType.Ipv4)
                    throw new FtpException("Only IPv4 is supported by the PASV command. Use EPSV instead.");

                if (!(reply = await SetPassiveMode()).Success)
                    throw new FtpCommandException(reply);
            }

            var passiveConnection = new FtpStreamChannel();

            await passiveConnection.ConnectAsync(reply.HostName, reply.ServiceName);


            // NOTE: Maybe it is better to just to open the passive channel, and execute the command else where.. 
            if (!(await ExecuteAsync<FtpResponse>(request)).Success)
            {
                passiveConnection.Dispose();
                throw new FtpCommandException(reply);
            }

            return passiveConnection;
        }

        /// <summary>
        /// Executes a request on the ftp server
        /// </summary>
        /// <typeparam name="T">Type of the expected response</typeparam>
        /// <param name="request">Request to execute</param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync<T>(FtpRequest request) where T:FtpResponse
        {
            //if (!IsConnected) await ConnectAsync();

            // TODO: Implement NotConnectedException
            if(!IsConnected) throw new FtpException("Not Connected");

            System.Diagnostics.Debug.WriteLine("EXEC\t:" + (request.Command.StartsWith("PASS") ? "PASS <omitted>" : request.Command));

            await WriteLineAsync(Encoding, request.Command);

            await FlushAsync();

            return await GetReplyAsync<T>();
        }

        public async Task<T> ExecuteInDuplexAsync<T>(FtpDataConnectionType connectionType, FtpRequest request) where T : FtpDuplexReponse
        {
            var response = Activator.CreateInstance<T>();
            response.Request = request;

            if (!IsConnected) throw new FtpException("Not Connected");

            var passiveChannel = await OpenPassiveDataStreamAsync(connectionType, request);

            string bufferResult;

            while ((bufferResult = await passiveChannel.ReadLineAsync(Encoding)) != null)
            {
                if (bufferResult.Length > 0)
                {
                    response.MessageBody += bufferResult;
                    System.Diagnostics.Debug.WriteLine(bufferResult);
                }
            }

            var finalResponse = await GetReplyAsync<FtpResponse>();
            response.Code = finalResponse.Code;
            response.InfoMessages += finalResponse.Message;

            return response;
        }

        /// <summary>
        /// Retreives a reply from the server. Do not execute this method
        /// unless you are sure that a reply has been sent, i.e., you
        /// executed a command. Doing so will cause the code to hang
        /// indefinitely waiting for a server reply that is never comming.
        /// </summary>
        /// <returns>FtpReply representing the response from the server</returns>
        internal async Task<T> GetReplyAsync<T>() where T:FtpResponse
        {
            var reply = Activator.CreateInstance<T>();

            if (!IsConnected)
                throw new InvalidOperationException("No connection to the server has been established.");

            string buf;

            while ((buf = await ReadLineAsync(Encoding)) != null)
            {
                Match m;


                // TODO: Do this inside the response.
                System.Diagnostics.Debug.WriteLine("REPLY\t:" + buf);

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
        /// Writes a line to the stream using the specified encoding
        /// </summary>
        /// <param name="encoding">Encoding used for writing the line</param>
        /// <param name="buf">The data to write</param>
        public IAsyncOperationWithProgress<uint, uint> WriteLineAsync(Encoding encoding, string buf)
        {
            byte[] data = encoding.GetBytes(string.Format("{0}\r\n", buf));

            return WriteAsync(data.AsBuffer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        internal async Task<string> ReadLineAsync(Encoding encoding)
        {
            var data = new List<byte>();

            string result = null;

            using (var dataReader = new DataReader(InputStream))
            {
                try
                {
                    while (await dataReader.LoadAsync(1) > 0)
                    {
                        byte currentChar = dataReader.ReadByte();

                        data.Add(currentChar);

                        if ((char)currentChar != '\n') continue;

                        result = encoding.GetString(data.ToArray(), 0, data.Count);

                        break;
                    }
                }
                finally
                {
                    dataReader.DetachStream();
                }
            }

            return result;
        }

        /// <summary>
        /// Returns an asynchronous byte reader object.
        /// </summary>
        /// <returns>
        /// The asynchronous operation. 
        /// </returns>
        /// <param name="buffer">The buffer into which the asynchronous read operation places the bytes that are read.</param>
        /// <param name="count">The number of bytes to read that is less than or equal to the Capacity value.</param>
        /// <param name="options">Specifies the type of the asynchronous read operation.</param>
        public IAsyncOperationWithProgress<IBuffer, uint> ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
        {
            return InputStream.ReadAsync(buffer, count, options);
        }

        /// <summary>
        /// Writes data asynchronously in a sequential stream.
        /// </summary>
        /// <returns>
        /// The byte writer operation.
        /// </returns>
        /// <param name="buffer">The buffer into which the asynchronous writer operation writes.</param>
        public IAsyncOperationWithProgress<uint, uint> WriteAsync(IBuffer buffer)
        {
            return OutputStream.WriteAsync(buffer);
        }

        /// <summary>
        /// Flushes data asynchronously in a sequential stream.
        /// </summary>
        /// <returns>
        /// The stream flush operation.
        /// </returns>
        public IAsyncOperation<bool> FlushAsync()
        {
            return OutputStream.FlushAsync();
        }

        #endregion


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            m_StreamSocket.Dispose();
            
            m_StreamSocket = null;

            m_IsConnected = false;
        }

        #endregion
    }
}
