namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpFeaturesRequest : FtpRequest
    {
        public FtpFeaturesRequest(): base("FEAT")
        {
        }
    }
}