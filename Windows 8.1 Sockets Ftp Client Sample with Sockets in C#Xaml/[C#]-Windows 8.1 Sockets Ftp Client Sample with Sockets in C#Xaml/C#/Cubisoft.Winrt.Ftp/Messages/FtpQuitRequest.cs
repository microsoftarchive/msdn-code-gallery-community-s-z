namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpQuitRequest : FtpRequest
    {
        public FtpQuitRequest(): base("QUIT")
        {
        }
    }
}