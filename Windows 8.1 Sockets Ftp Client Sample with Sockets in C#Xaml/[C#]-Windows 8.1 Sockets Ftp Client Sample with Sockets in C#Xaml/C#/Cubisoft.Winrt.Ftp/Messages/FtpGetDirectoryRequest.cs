namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpGetDirectoryRequest : FtpRequest
    {
        public FtpGetDirectoryRequest() : base("PWD")
        {
        }
    }
}