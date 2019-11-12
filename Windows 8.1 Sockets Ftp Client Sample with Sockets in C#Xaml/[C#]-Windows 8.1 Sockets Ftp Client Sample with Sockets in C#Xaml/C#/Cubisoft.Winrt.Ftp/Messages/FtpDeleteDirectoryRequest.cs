namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpDeleteDirectoryRequest : FtpRequest
    {
        public FtpDeleteDirectoryRequest(string path)
            : base("RMD")
        {
            Arguments = new string[1];
            Arguments[0] = path.TrimEnd('/').GetFtpPath();
        }
    }
}
