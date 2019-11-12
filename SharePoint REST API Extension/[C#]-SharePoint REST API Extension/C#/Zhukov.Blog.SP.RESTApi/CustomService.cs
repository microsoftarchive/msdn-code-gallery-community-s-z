using Microsoft.SharePoint.Client;

namespace Zhukov.Blog.SP.REST
{
    [ClientCallableType(
        Name = "CustomService",
        ServerTypeId = "{7954fe10-6ba6-4cc0-9fcf-e23a04816790}")]
    public class CustomService
    {
        [ClientCallableMethod]
        public string GetString()
        {
            return "Hello, world!";
        }

        [ClientCallableProperty]
        public string About => "Simple REST service";
    }
}