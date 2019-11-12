namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpPassiveModeRequest : FtpRequest
    {
        public FtpPassiveModeRequest(): base("PASV")
        {
        }
    }
}