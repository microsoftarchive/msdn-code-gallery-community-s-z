namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpStoreRequest : FtpRequest
    {
        public FtpStoreRequest(string path) : base("STOR")
        {
            Arguments = new string[1];
            Arguments[0] = path.TrimEnd('/').GetFtpPath();
        }
    }
}