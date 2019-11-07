using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Script.Serialization;
using System.IO;
using System.Drawing;
using System.ServiceModel.Activation;
using System.Text.RegularExpressions;

namespace RestfulService
{
    // NOTE: If you change the class name "IRestServiceImpl" here, you must also update the reference to "IRestServiceImpl" in Web.config.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestServiceImpl : IRestServiceImpl
    {

        public string SignUpUser(string name, string email, string language, string phoneno, string gender, string country, string image)
        {
            List<WebId> jsonWebIdList = new List<WebId>();
            WebId objWebId = new WebId();
            objWebId.filetype = "webid";
            objWebId.signed = 1234567890;
            UserData userInfo = new UserData();
            userInfo.name = name;
            userInfo.gender = gender;
            userInfo.phone = phoneno;
            userInfo.country = country;
            userInfo.language = language;
            userInfo.image = image;
            Image countryimage = Image.FromFile("..\\RestfulService\\flags\\" + country + ".png");
            userInfo.countryImage = "data:image/png;base64,"+ImageToBase64(countryimage, System.Drawing.Imaging.ImageFormat.Png);
            List<UserData> lst = new List<UserData>();
            lst.Add(userInfo);
            objWebId.userdata = lst;
            jsonWebIdList.Add(objWebId);

            // serlized list into json string.
            // Also i used stupid method to trim base 64 string so do'nt mind 
            #region JsonSerlization and triming
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(jsonWebIdList);
            sJSON = sJSON.Replace("[", "");
            sJSON = sJSON.Replace("]", "");
            #endregion
            //Sent Mail to user email id
            bool result = SentMail(sJSON, email);
            if (result)
            {
                return "Successful";
            }
            else
            {
                return "Fail";
            }
        }

        #region Sentmail
        public bool SentMail(string json, string email)
        {
            try
            {
                string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|" +
               @"0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z]" +
               @"[a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
               System.Text.RegularExpressions.Match match = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
               if (match.Success)
               {
                   SmtpClient mail = new SmtpClient();
                   MailMessage msg = new MailMessage("Your Mail ID", email);
                   msg.Body = "This is Webid. PFA";
                   mail.Credentials = new NetworkCredential("Your Mail ID", "Your PWD");
                   mail.Host = "smtp.googlemail.com";
                   mail.DeliveryMethod = SmtpDeliveryMethod.Network;
                   mail.EnableSsl = true;
                   mail.Port = 587;
                   Attachment a = System.Net.Mail.Attachment.CreateAttachmentFromString(json.ToString(), "User.webid");
                   msg.Attachments.Add(a);
                   mail.Send(msg);
                   return true;
               }
               else
               {
                   return false;
               }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region convert image to base64
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        #endregion
    }

}
