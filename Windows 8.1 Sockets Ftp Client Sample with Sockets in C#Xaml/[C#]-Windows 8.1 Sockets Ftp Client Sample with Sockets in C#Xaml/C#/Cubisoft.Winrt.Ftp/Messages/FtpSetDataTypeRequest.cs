namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpSetDataTypeRequest : FtpRequest
    {
        public FtpSetDataTypeRequest(FtpDataType type) : base("TYPE")
        {
            Arguments = new string[1];
            Arguments[0] = type == FtpDataType.ASCII ? "A" : "I";
        }
    }
}