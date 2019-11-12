using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerClientChat1._3.Classes
{
    class PublicIP
    {

        public delegate void PublicIPKnownHandler(string PublicIP);
        public event PublicIPKnownHandler PublicIPKnown;
        public delegate void PublicIPErrorHandler(string Message);
        public event PublicIPErrorHandler PublicIPError;

        private int RetryAttempts = 0;

        public void GetPublicIpAddress()
        {
         
                Task tGetIP = new Task(() => GetPublicIpAddressAsync());
                tGetIP.Start();
           
        }

        /// <summary>
        /// Contact the ifConfig.Me webservice to get our public IP Address
        /// </summary>
        /// <returns>
        /// String indicating our public IP Address
        /// </returns>
        private void GetPublicIpAddressAsync()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

                request.UserAgent = "curl"; // this simulate curl linux command

                string publicIPAddress;

                request.Method = "GET";
                using (WebResponse response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        publicIPAddress = reader.ReadToEnd();
                    }
                }

                PublicIPKnown(publicIPAddress.Replace("\n", ""));
            }
            catch (Exception ex)
            {
                if (RetryAttempts < 4) // If we just keep calling ourselves without any limit we will get a StackOverFlow Error
                {
                    GetPublicIpAddressAsync();
                    RetryAttempts++;
                }
                else
                {
                    PublicIPError(ex.Message);
                }
            }
           
            
        }

    }
}
