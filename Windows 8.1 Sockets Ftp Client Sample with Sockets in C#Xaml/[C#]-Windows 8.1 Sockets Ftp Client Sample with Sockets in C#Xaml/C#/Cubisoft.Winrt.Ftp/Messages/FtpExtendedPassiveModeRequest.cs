namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpExtendedPassiveModeRequest : FtpRequest
    {
        public FtpExtendedPassiveModeRequest() : base("EPSV")
        {
        }
    }
}