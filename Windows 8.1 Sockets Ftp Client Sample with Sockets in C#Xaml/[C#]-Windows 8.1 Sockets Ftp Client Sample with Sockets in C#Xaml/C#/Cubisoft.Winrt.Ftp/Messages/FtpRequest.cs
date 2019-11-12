using System.Linq;

namespace Cubisoft.Winrt.Ftp.Messages
{
    public class FtpRequest
    {
        public string CommandName { get; set; }

        public string[] Arguments { get; set; }

        public string Command {
            get
            {
                if (Arguments != null && Arguments.Length > 0)
                    return string.Format("{0} {1}", CommandName, Arguments.Aggregate((item1,item2)=>item1 + " " + item2));

                return CommandName;
            }
        }

        public FtpRequest()
        {
            
        }

        public FtpRequest(string commandName, params string[] arguments)
        {
            CommandName = commandName;

            if (arguments != null) Arguments = arguments;
        }
    }
}
