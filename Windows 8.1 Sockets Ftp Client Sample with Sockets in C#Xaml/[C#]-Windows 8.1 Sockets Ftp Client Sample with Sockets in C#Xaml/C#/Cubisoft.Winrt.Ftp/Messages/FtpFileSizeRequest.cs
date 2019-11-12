namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpFileSizeRequest : FtpRequest
    {
        public FtpFileSizeRequest(string filePath) : base("SIZE")
        {
            Arguments = new string[1];
            Arguments[0] = filePath.GetFtpPath();
        }
    }
}
