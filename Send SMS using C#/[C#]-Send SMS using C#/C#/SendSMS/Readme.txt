Summary:

In order to send a SMS, you need an account with a SMS gateway. In order to send a SMS, we need to pass all required parameters. These parameters may vary gateway to gateway. Please check with your SMS gateway for more details. 

This sample demonstrates how to use HTTPWebRequest/Response to send the SMS through a SMS gateway. 

Demo:

The following steps walk through a demonstration of using HTTPWebRequest/Response to send SMS from a SMS gateway.

Step 1: Register an account with a SMS gateway

Step 2: Add/Replace SMS gateway detail in AppSettings section of the Web.config
    <!-- SMS Gateway Settings -->
    <add key="SMSGatewayUserID" value="UserID" />
    <add key="SMSGatewayPassword" value="Password" />
    <add key="SMSGatewayGSMSenderID" value="SenderID-If-Any" />
    <add key="SMSGatewayPostURL" value="http://SomeGateway/" />  

Step 3: Add/Replace parameters (Please refer to your SMS gateway API)
   // Prepare POST data 
   postData.Append("action=send");
   postData.Append("&username=" + userId);
   postData.Append("&passphrase=" + pwd);
   postData.Append("&phone=" + sendTo);
   postData.Append("&message=" + smsText);

Step 4: Build and run the sample web site in Visual Studio 2010

Step 5: Enter a valid Mobile no in the ‘Mobile no’ input box, a message in the ‘Message’ box and click on ‘Send SMS’ button which will send the request to the SMS gateway.


Implementation:

Send SMS (Refer to: SendSMS)

The basic code logic is following:

1. Build a HTTPWebRequest object from a valid user details registered with the SMS gateway
2. Send the HTTP request and get a response back

 public void SendSMS(string smsText, string sendTo)
        {
            #region Variables
            string userId = ConfigurationManager.AppSettings["SMSGatewayUserID"];
            string pwd = ConfigurationManager.AppSettings["SMSGatewayPassword"];
            string postURL = ConfigurationManager.AppSettings["SMSGatewayPostURL"];
            
            StringBuilder postData = new StringBuilder();
            string responseMessage = string.Empty;
            HttpWebRequest request = null;
            #endregion

            try
            {
                // Prepare POST data 
                postData.Append("action=send");
                postData.Append("&username=" + userId);
                postData.Append("&passphrase=" + pwd);
                postData.Append("&phone=" + sendTo);
                postData.Append("&message=" + smsText);
                byte[] data = new System.Text.ASCIIEncoding().GetBytes(postData.ToString());

                // Prepare web request
                request = (HttpWebRequest)WebRequest.Create(postURL);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                // Write data to stream
                using (Stream newStream = request.GetRequestStream())
                {
                    newStream.Write(data, 0, data.Length);
                }

                // Send the request and get a response
                using(HttpWebResponse  response = (HttpWebResponse)request.GetResponse())
                {
                    // Read the response
                    using (StreamReader srResponse = new StreamReader(response.GetResponseStream()))
                    {
                        responseMessage = srResponse.ReadToEnd();
                    }

                    // Logic to interpret response from your gateway goes here
                    Response.Write(String.Format("Response from gateway: {0}", responseMessage)); 
                }
            }
            catch (Exception objException)
            {
                Response.Write(objException.ToString());
            }            
        }

References:

How to: Send Data Using the WebRequest Class
http://msdn.microsoft.com/en-us/library/debx8sh9.aspx

