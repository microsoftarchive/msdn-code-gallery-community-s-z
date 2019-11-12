namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpPasswordRequest : FtpRequest
    {
        public FtpPasswordRequest(string password): base("PASS", password)
        {
        }
    }
}