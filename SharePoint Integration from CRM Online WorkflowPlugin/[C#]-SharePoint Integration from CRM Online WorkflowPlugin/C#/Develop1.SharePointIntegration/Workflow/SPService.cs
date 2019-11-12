using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Develop1.Workflow.SharePoint
{
    public class SPService : ISharePointService
    {
        private string _username;
        private string _password;
        private string _siteUrl;
        private SpoAuthUtility _spo;
        public SPService(string username, string password)
        {
            _username = username;
            _password = password;

        }
        public void CreateFolder(string siteUrl, string relativePath)
        {

            if (siteUrl != _siteUrl)
            {
                _siteUrl = siteUrl;
                Uri spSite = new Uri(siteUrl);

                _spo = SpoAuthUtility.Create(spSite, _username, WebUtility.HtmlEncode(_password), false);
            }

            string odataQuery = "_api/web/folders";

            byte[] content = ASCIIEncoding.ASCII.GetBytes(@"{ '__metadata': { 'type': 'SP.Folder' }, 'ServerRelativeUrl': '" + relativePath + "'}");


            string digest = _spo.GetRequestDigest();

            Uri url = new Uri(String.Format("{0}/{1}", _spo.SiteUrl, odataQuery));
            // Set X-RequestDigest
            var webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.Headers.Add("X-RequestDigest", digest);

            // Send a json odata request to SPO rest services to fetch all list items for the list.
            byte[] result = HttpHelper.SendODataJsonRequest(
              url,
              "POST", // reading data from SP through the rest api usually uses the GET verb 
              content,
              webRequest,
              _spo // pass in the helper object that allows us to make authenticated calls to SPO rest services
              );

            string response = Encoding.UTF8.GetString(result, 0, result.Length);


        }
    }
}
