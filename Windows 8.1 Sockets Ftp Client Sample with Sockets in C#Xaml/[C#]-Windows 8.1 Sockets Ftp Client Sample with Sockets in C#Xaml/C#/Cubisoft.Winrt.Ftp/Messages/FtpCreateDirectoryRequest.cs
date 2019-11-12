namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpCreateDirectoryRequest : FtpRequest
    {
        public FtpCreateDirectoryRequest(string path) : base("MKD")
        {
            Arguments = new string[1];
            Arguments[0] = path.TrimEnd('/').GetFtpPath();
        }
    }
}