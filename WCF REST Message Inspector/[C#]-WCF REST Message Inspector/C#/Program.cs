using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace InspectNonXmlMessages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(ContactManagerService), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(IContactManager), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new WebHttpBehavior());
            endpoint.Behaviors.Add(new IncomingMessageLogger());
            host.Open();
            Console.WriteLine("Host opened");

            string johnId = SendRequest(
                "POST",
                baseAddress + "/Contacts",
                "application/json",
                CreateJsonContact(null, "John Doe", "john@doe.com", "206-555-3333"));
            string janeId = SendRequest(
                "POST",
                baseAddress + "/Contacts",
                "application/json",
                CreateJsonContact(null, "Jane Roe", "jane@roe.com", "202-555-4444 202-555-8888"));

            Console.WriteLine("All contacts");
            SendRequest("GET", baseAddress + "/Contacts", null, null);

            Console.WriteLine("Updating Jane");
            SendRequest(
                "PUT",
                baseAddress + "/Contacts/" + janeId,
                "application/json",
                CreateJsonContact(janeId, "Jane Roe", "jane@roe.org", "202-555-4444 202-555-8888"));

            Console.WriteLine("All contacts, text format");
            SendRequest("GET", baseAddress + "/ContactsAsText", null, null);

            Console.WriteLine("Deleting John");
            SendRequest("DELETE", baseAddress + "/Contacts/" + johnId, null, null);

            Console.WriteLine("Is John still here?");
            SendRequest("GET", baseAddress + "/Contacts/" + johnId, null, null);

            Console.WriteLine("It also works with XML payloads:");
            string xmlPayload = @"<Contact>
  <Email>johnjr@doe.com</Email>
  <Name>John Doe Jr</Name>
  <Telephones xmlns:a=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
    <a:string>333-333-3333</a:string>
  </Telephones>
</Contact>";
            SendRequest(
                "POST",
                baseAddress + "/Contacts",
                "text/xml",
                xmlPayload);

            Console.WriteLine("All contacts:");
            SendRequest("GET", baseAddress + "/Contacts", null, null);
        }

        static string SendRequest(string method, string uri, string contentType, string body)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = method;
            if (contentType != null)
            {
                req.ContentType = contentType;
            }

            if (body != null)
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                Stream reqStream = req.GetRequestStream();
                reqStream.Write(bodyBytes, 0, bodyBytes.Length);
                reqStream.Close();
            }

            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Response to request to {0} - {1}", method, uri);
            Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            foreach (var headerName in resp.Headers.AllKeys)
            {
                Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
            }

            Stream respStream = resp.GetResponseStream();
            string result = null;
            if (respStream != null)
            {
                result = new StreamReader(respStream).ReadToEnd();
                Console.WriteLine(result);
            }

            Console.WriteLine();
            Console.WriteLine("  -*-*-*-*-*-*-*-*");
            Console.WriteLine();

            Console.ResetColor();

            // Removing the string markers from results (for contact ids)
            if (result.StartsWith("\"") && result.EndsWith("\""))
            {
                result = result.Substring(1, result.Length - 2);
            }

            return result;
        }

        static string CreateJsonContact(string id, string name, string email, string telephones)
        {
            string[] phoneNumbers = telephones.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            if (id != null)
            {
                sb.AppendFormat("\"Id\":\"{0}\", ", id);
            }

            sb.AppendFormat("\"Name\":\"{0}\", ", name);
            sb.AppendFormat("\"Email\":\"{0}\", ", email);
            sb.Append("\"Telephones\":[");
            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.AppendFormat("\"{0}\"", phoneNumbers[i]);
            }

            sb.Append(']');
            sb.Append('}');
            return sb.ToString();
        }
    }
}
