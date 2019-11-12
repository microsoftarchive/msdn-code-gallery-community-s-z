
#region Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;
#endregion

namespace SendSMS
{
    public partial class _Default : System.Web.UI.Page
    {
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region btnSend Click
        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (this.txtMobileNo.Text.Length < 10)
                Response.Write("Incorrect mobile no");
            else
                SendSMS(txtMessage.Text, txtMobileNo.Text);
        }
        #endregion

        #region SendSMS
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
        #endregion
    }
}