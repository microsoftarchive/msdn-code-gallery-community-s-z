namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpUserRequest : FtpRequest
    {
        public FtpUserRequest(string userName) : base("USER", userName)
        {
        }
    }
}