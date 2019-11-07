namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpRetrieveRequest : FtpRequest
    {
        public FtpRetrieveRequest(string path) : base("RETR")
        {
            Arguments = new string[1];
            Arguments[0] = path.TrimEnd('/').GetFtpPath();
        }
    }
}