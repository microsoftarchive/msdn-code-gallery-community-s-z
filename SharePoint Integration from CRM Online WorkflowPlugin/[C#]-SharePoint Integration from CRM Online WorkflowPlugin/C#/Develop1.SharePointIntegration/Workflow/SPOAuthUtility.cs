using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Threading;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;




namespace Develop1.Workflow
{
    internal class SamlSecurityToken
    {
        public byte[] Token
        {
            get;
            set;
        }

        public DateTime Expires
        {
            get;
            set;
        }
    }

    internal class SPOAuthCookies
    {
        public string FedAuth
        {
            get;
            set;
        }

        public string RtFA
        {
            get;
            set;
        }

        public Uri Host
        {
            get;
            set;
        }

        public DateTime Expires
        {
            get;
            set;
        }
    }

    public class SpoAuthUtility
    {
        Uri spSiteUrl;
        string username;
        string password;
        Uri adfsIntegratedAuthUrl;
        Uri adfsAuthUrl;
        bool useIntegratedWindowsAuth;
        //static SpoAuthUtility current;
        CookieContainer cookieContainer;
        SamlSecurityToken stsAuthToken;


        const string msoStsUrl = "https://login.microsoftonline.com/extSTS.srf";
        const string msoLoginUrl = "https://login.microsoftonline.com/login.srf";
        const string msoHrdUrl = "https://login.microsoftonline.com/GetUserRealm.srf";
        const string wsse = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd";
        const string wsu = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        const string wst = "http://schemas.xmlsoap.org/ws/2005/02/trust";
        const string saml = "urn:oasis:names:tc:SAML:1.0:assertion";
        const string spowssigninUri = "_forms/default.aspx?wa=wsignin1.0";
        const string contextInfoQuery = "_api/contextinfo";

        public static SpoAuthUtility Create(Uri spSiteUrl, string username, string password, bool useIntegratedWindowsAuth)
        {
            var utility = new SpoAuthUtility(spSiteUrl, username, password, useIntegratedWindowsAuth);
            CookieContainer cc = utility.GetCookieContainer();
            var cookies = from Cookie c in cc.GetCookies(spSiteUrl) where c.Name == "FedAuth" select c;
            if (cookies.Count() > 0)
            {
                //current = utility;
                return utility;
            }
            else
                throw new Exception("Could not retrieve Auth cookies");
        }

        private SpoAuthUtility(Uri spSiteUrl, string username, string password, bool useIntegratedWindowsAuth)
        {
            this.spSiteUrl = spSiteUrl;
            this.username = username;
            this.password = password;
            this.useIntegratedWindowsAuth = useIntegratedWindowsAuth;

            stsAuthToken = new SamlSecurityToken();
        }

        

        public Uri SiteUrl
        {
            get
            {
                return this.spSiteUrl;
            }
        }

        /// <summary>
        /// The method will request the SP ContextInfo and return its FormDigestValue as a String
        /// The FormDigestValue is a second layer of authentication required for several REST queries
        /// </summary>
        /// <returns>FormDigestValue</returns>
        public string GetRequestDigest()
        {
            string digest = String.Empty;
            Uri url = new Uri(String.Format("{0}/{1}", SiteUrl, contextInfoQuery));
            byte[] result = HttpHelper.SendODataJsonRequest(
              url,
              "POST", // Retrieving the Context Info needs a POST Method 
              new byte[0],
              (HttpWebRequest)HttpWebRequest.Create(url),
              this // pass in the helper object that allows us to make authenticated calls to SPO rest services
              );


            ContextInfo ci = Deserialize<ContextInfo>(result);
            digest = (ci != null) ? ci.FormDigestValue : String.Empty;

            return digest;
        }

        private static T Deserialize<T>(byte[] data)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream(data);
            T value = (T)json.ReadObject(ms);
            return value;
        }





        public CookieContainer GetCookieContainer()
        {
            if (stsAuthToken != null)
            {
                if (DateTime.Now > stsAuthToken.Expires)
                {
                    this.stsAuthToken = GetMsoStsSAMLToken();

                    // Check if we have a auth token
                    if (this.stsAuthToken != null)
                    {
                        SPOAuthCookies cookies = GetSPOAuthCookies(this.stsAuthToken);
                        CookieContainer cc = new CookieContainer();

                        Cookie samlAuthCookie = new Cookie("FedAuth", cookies.FedAuth)
                        {
                            Path = "/",
                            Expires = this.stsAuthToken.Expires,
                            Secure = cookies.Host.Scheme.Equals("https"),
                            HttpOnly = true,
                            Domain = cookies.Host.Host
                        };

                        cc.Add(this.spSiteUrl, samlAuthCookie);

                        Cookie rtFACookie = new Cookie("rtFA", cookies.RtFA)
                        {
                            Path = "/",
                            Expires = this.stsAuthToken.Expires,
                            Secure = cookies.Host.Scheme.Equals("https"),
                            HttpOnly = true,
                            Domain = cookies.Host.Host
                        };

                        cc.Add(this.spSiteUrl, rtFACookie);

                        this.cookieContainer = cc;
                    }
                }
            }

            return this.cookieContainer;
        }

        private SPOAuthCookies GetSPOAuthCookies(SamlSecurityToken stsToken)
        {
            // signs in to SPO with the security token issued by MSO STS and gets the fed auth cookies
            // the fed auth cookie needs to be attached to all SPO REST services requests
            SPOAuthCookies spoAuthCookies = new SPOAuthCookies();

            Uri siteUri = this.spSiteUrl;
            Uri wsSigninUrl = new Uri(String.Format("{0}://{1}/{2}", siteUri.Scheme, siteUri.Authority, spowssigninUri));

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(wsSigninUrl);
            request.CookieContainer = new CookieContainer();

            byte[] responseData = HttpHelper.SendHttpRequest(
                wsSigninUrl,
                "POST",
                stsToken.Token,
                "application/x-www-form-urlencoded",
                request,
                null);

            if (request != null && responseData != null)
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    spoAuthCookies.FedAuth = (response.Cookies["FedAuth"] != null) ? response.Cookies["FedAuth"].Value : null;
                    spoAuthCookies.RtFA = (response.Cookies["rtFA"] != null) ? response.Cookies["rtFA"].Value : null;
                    spoAuthCookies.Expires = stsToken.Expires;
                    spoAuthCookies.Host = wsSigninUrl;
                }
            }

            return spoAuthCookies;
        }

        private Uri GetAdfsAuthUrl()
        {
            Uri corpAdfsProxyUrl = null;

            Uri msoHrdUri = new Uri(msoHrdUrl);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(msoHrdUri);
            // make a post request with the user's login name to 
            // MSO HRD (Home Realm Discovery) service so it can find 
            // out the url of the federation service (corporate ADFS) 
            // responsible for authenticating the user

            byte[] response = HttpHelper.SendHttpRequest(
                 new Uri(msoHrdUrl),
                 "POST",
                 Encoding.UTF8.GetBytes(String.Format("handler=1&login={0}", this.username)), // pass in the login name in the body of the form
                 "application/x-www-form-urlencoded",
                 request);



            STSInfo info = Deserialize<STSInfo>(response);

            if (info != null && !String.IsNullOrEmpty(info.AuthURL))
            {
                corpAdfsProxyUrl = new Uri(info.AuthURL);
            }


            return corpAdfsProxyUrl;
        }


        



        private string GetAdfsSAMLTokenUsernamePassword()
        {
            // makes a seurity token request to the corporate ADFS proxy usernamemixed endpoint using
            // the user's corporate credentials. The logon token is used to talk to MSO STS to get
            // an O365 service token that can then be used to sign into SPO.
            string samlAssertion = null;

            // the corporate ADFS proxy endpoint that issues SAML seurity tokens given username/password credentials 
            string stsUsernameMixedUrl = String.Format("https://{0}/adfs/services/trust/2005/usernamemixed/", adfsAuthUrl.Host);

            // generate the WS-Trust security token request SOAP message passing in the user's corporate credentials 
            // and the site we want access to. We send the token request to the corporate ADFS proxy usernamemixed endpoint.
            byte[] requestBody = Encoding.UTF8.GetBytes(ParameterizeSoapRequestTokenMsgWithUsernamePassword(
                "urn:federation:MicrosoftOnline", // we are requesting a logon token to talk to the Microsoft Federation Gateway
                this.username,
                this.password,
                stsUsernameMixedUrl));

            try
            {
                Uri stsUrl = new Uri(stsUsernameMixedUrl);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(stsUrl);

                byte[] responseData = HttpHelper.SendHttpRequest(
                    stsUrl,
                    "POST",
                    requestBody,
                    "application/soap+xml; charset=utf-8",
                    request,
                    null);

                if (responseData != null)
                {
                    StreamReader sr = new StreamReader(new MemoryStream(responseData), Encoding.GetEncoding("utf-8"));
                    XPathNavigator nav = new XPathDocument(sr).CreateNavigator();
                    XmlNamespaceManager nsMgr = new XmlNamespaceManager(nav.NameTable);
                    nsMgr.AddNamespace("t", "http://schemas.xmlsoap.org/ws/2005/02/trust");
                    XPathNavigator requestedSecurityToken = nav.SelectSingleNode("//t:RequestedSecurityToken", nsMgr);

                    // Ensure whitespace is reserved
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(requestedSecurityToken.InnerXml);
                    doc.PreserveWhitespace = true;
                    samlAssertion = doc.InnerXml;
                }

            }
            catch
            {
                // we failed to sign the user using corporate credentials

            }

            return samlAssertion;
        }

        private string GetAdfsSAMLTokenWinAuth()
        {
            // makes a seurity token request to the corporate ADFS proxy integrated auth endpoint.
            // If the user is logged on to a machine joined to the corporate domain with her Windows credentials and connected
            // to the corporate network Kerberos automatically takes care of authenticating the security token 
            // request to ADFS.
            // The logon token is used to talk to MSO STS to get an O365 service token that can then be used to sign into SPO.

            string samlAssertion = null;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.adfsIntegratedAuthUrl);
            request.UseDefaultCredentials = true; // use the default credentials so Kerberos can take care of authenticating our request

            byte[] responseData = HttpHelper.SendHttpRequest(
                this.adfsIntegratedAuthUrl,
                "GET",
                null,
                "text/html; charset=utf-8",
                request);


            if (responseData != null)
            {
                try
                {
                    StreamReader sr = new StreamReader(new MemoryStream(responseData), Encoding.GetEncoding("utf-8"));
                    XPathNavigator nav = new XPathDocument(sr).CreateNavigator();
                    XPathNavigator wresult = nav.SelectSingleNode("/html/body/form/input[@name='wresult']");
                    if (wresult != null)
                    {
                        string RequestSecurityTokenResponseText = wresult.GetAttribute("value", "");

                        sr = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(RequestSecurityTokenResponseText)));
                        nav = new XPathDocument(sr).CreateNavigator();
                        XmlNamespaceManager nsMgr = new XmlNamespaceManager(nav.NameTable);
                        nsMgr.AddNamespace("t", "http://schemas.xmlsoap.org/ws/2005/02/trust");
                        XPathNavigator requestedSecurityToken = nav.SelectSingleNode("//t:RequestedSecurityToken", nsMgr);

                        // Ensure whitespace is reserved
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(requestedSecurityToken.InnerXml);
                        doc.PreserveWhitespace = true;
                        samlAssertion = doc.InnerXml;
                    }

                }
                catch
                {
                    // we failed to sign the user using integrated Windows Auth

                }
            }


            return samlAssertion;

        }


        private SamlSecurityToken GetMsoStsSAMLToken()
        {
            // Makes a request that conforms with the WS-Trust standard to 
            // Microsoft Online Services Security Token Service to get a SAML
            // security token back so we can then use it to sign the user to SPO 

            SamlSecurityToken samlST = new SamlSecurityToken();
            byte[] saml11RTBytes = null;
            string logonToken = null;

            // find out whether the user's domain is a federated domain
            this.adfsAuthUrl = GetAdfsAuthUrl();

            // get logon token using windows integrated auth when the user is connected to the corporate network 
            if (this.adfsAuthUrl != null && this.useIntegratedWindowsAuth)
            {
                UriBuilder ub = new UriBuilder();
                ub.Scheme = this.adfsAuthUrl.Scheme;
                ub.Host = this.adfsAuthUrl.Host;
                ub.Path = string.Format("{0}auth/integrated/", this.adfsAuthUrl.LocalPath);

                // specify in the query string we want a logon token to present to the Microsoft Federation Gateway
                // for the corresponding user
                ub.Query = String.Format("{0}&wa=wsignin1.0&wtrealm=urn:federation:MicrosoftOnline", this.adfsAuthUrl.Query.Remove(0, 1)).
                    Replace("&username=", String.Format("&username={0}", this.username));

                this.adfsIntegratedAuthUrl = ub.Uri;

                // get the logon token from the corporate ADFS using Windows Integrated Auth
                logonToken = GetAdfsSAMLTokenWinAuth();

                if (!string.IsNullOrEmpty(logonToken))
                {
                    // generate the WS-Trust security token request SOAP message passing in the logon token we got from the corporate ADFS
                    // and the site we want access to 
                    saml11RTBytes = Encoding.UTF8.GetBytes(ParameterizeSoapRequestTokenMsgWithAssertion(
                        this.spSiteUrl.ToString(),
                        logonToken,
                        msoStsUrl));
                }
            }

            // get logon token using the user's corporate credentials. Likely when not connected to the corporate network
            if (logonToken == null && this.adfsAuthUrl != null && !string.IsNullOrEmpty(password))
            {
                logonToken = GetAdfsSAMLTokenUsernamePassword(); // get the logon token from the corporate ADFS proxy usernamemixed enpoint

                if (logonToken != null)
                {
                    // generate the WS-Trust security token request SOAP message passing in the logon token we got from the corporate ADFS
                    // and the site we want access to 
                    saml11RTBytes = Encoding.UTF8.GetBytes(ParameterizeSoapRequestTokenMsgWithAssertion(
                      this.spSiteUrl.ToString(),
                      logonToken,
                      msoStsUrl));
                }
            }

            if (logonToken == null && this.adfsAuthUrl == null && !string.IsNullOrEmpty(password)) // login with O365 credentials. Not a federated login.
            {
                // generate the WS-Trust security token request SOAP message passing in the user's credentials and the site we want access to 
                saml11RTBytes = Encoding.UTF8.GetBytes(ParameterizeSoapRequestTokenMsgWithUsernamePassword(
                    this.spSiteUrl.ToString(),
                    this.username,
                    this.password,
                    msoStsUrl));
            }

            if (saml11RTBytes != null)
            {
                Uri MsoSTSUri = new Uri(msoStsUrl);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(MsoSTSUri);


                byte[] responseData = HttpHelper.SendHttpRequest(
                    MsoSTSUri,
                    "POST",
                    saml11RTBytes,
                    "application/soap+xml; charset=utf-8",
                    request,
                    null);

                StreamReader sr = new StreamReader(new MemoryStream(responseData), Encoding.GetEncoding("utf-8"));
                XPathNavigator nav = new XPathDocument(sr).CreateNavigator();
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(nav.NameTable);
                nsMgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                XPathNavigator binarySecurityToken = nav.SelectSingleNode("//wsse:BinarySecurityToken", nsMgr);

                if (binarySecurityToken != null)
                {
                    string binaryST = binarySecurityToken.InnerXml;

                    nsMgr.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                    XPathNavigator expires = nav.SelectSingleNode("//wsu:Expires", nsMgr);

                    if (!String.IsNullOrEmpty(binarySecurityToken.InnerXml) && !String.IsNullOrEmpty(expires.InnerXml))
                    {
                        samlST.Token = Encoding.UTF8.GetBytes(binarySecurityToken.InnerXml);
                        samlST.Expires = DateTime.Parse(expires.InnerXml);
                    }
                }
                else
                {
                    // We didn't get security token
                }
            }

            return samlST;
        }

        private string ParameterizeSoapRequestTokenMsgWithUsernamePassword(string url, string username, string password, string toUrl)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append("<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">");
            s.Append("<s:Header>");
            s.Append("<a:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action>");
            s.Append("<a:ReplyTo>");
            s.Append("<a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>");
            s.Append("</a:ReplyTo>");
            s.Append("<a:To s:mustUnderstand=\"1\">[toUrl]</a:To>");
            s.Append("<o:Security s:mustUnderstand=\"1\" xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">");
            s.Append("<o:UsernameToken>");
            s.Append("<o:Username>[username]</o:Username>");
            s.Append("<o:Password>[password]</o:Password>");
            s.Append("</o:UsernameToken>");
            s.Append("</o:Security>");
            s.Append("</s:Header>");
            s.Append("<s:Body>");
            s.Append("<t:RequestSecurityToken xmlns:t=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">");
            s.Append("<wsp:AppliesTo xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\">");
            s.Append("<a:EndpointReference>");
            s.Append("<a:Address>[url]</a:Address>");
            s.Append("</a:EndpointReference>");
            s.Append("</wsp:AppliesTo>");
            s.Append("<t:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</t:KeyType>");
            s.Append("<t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType>");
            s.Append("<t:TokenType>urn:oasis:names:tc:SAML:1.0:assertion</t:TokenType>");
            s.Append("</t:RequestSecurityToken>");
            s.Append("</s:Body>");
            s.Append("</s:Envelope>");


            string samlRTString = s.ToString();
            samlRTString = samlRTString.Replace("[username]", username);
            samlRTString = samlRTString.Replace("[password]", password);
            samlRTString = samlRTString.Replace("[url]", url);
            samlRTString = samlRTString.Replace("[toUrl]", toUrl);

            return samlRTString;
        }

        private string ParameterizeSoapRequestTokenMsgWithAssertion(string url, string samlAssertion, string toUrl)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append("<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">");
            s.Append("<s:Header>");
            s.Append("<a:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action>");
            s.Append("<a:ReplyTo>");
            s.Append("<a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>");
            s.Append("</a:ReplyTo>");
            s.Append("<a:To s:mustUnderstand=\"1\">[toUrl]</a:To>");
            s.Append("<o:Security s:mustUnderstand=\"1\" xmlns:o=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\">[assertion]");
            s.Append("</o:Security>");
            s.Append("</s:Header>");
            s.Append("<s:Body>");
            s.Append("<t:RequestSecurityToken xmlns:t=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">");
            s.Append("<wsp:AppliesTo xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\">");
            s.Append("<a:EndpointReference>");
            s.Append("<a:Address>[url]</a:Address>");
            s.Append("</a:EndpointReference>");
            s.Append("</wsp:AppliesTo>");
            s.Append("<t:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</t:KeyType>");
            s.Append("<t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType>");
            s.Append("<t:TokenType>urn:oasis:names:tc:SAML:1.0:assertion</t:TokenType>");
            s.Append("</t:RequestSecurityToken>");
            s.Append("</s:Body>");
            s.Append("</s:Envelope>");

            string samlRTString = s.ToString();
            samlRTString = samlRTString.Replace("[assertion]", samlAssertion);
            samlRTString = samlRTString.Replace("[url]", url);
            samlRTString = samlRTString.Replace("[toUrl]", toUrl);

            return samlRTString;
        }

    }

    /// <summary>
    /// Helper class to handle STS Info JSON Deserialisation
    /// </summary>
    [DataContract]
    public class STSInfo
    {
        [DataMember]
        public String AuthURL { get; set; }
    }

    /// <summary>
    /// Helper class to handle ContextInfo JSON Deserialisation
    /// </summary>
    /// 
    [DataContract]
    public class GetContextWebInformationInfo
    {
        [DataMember]
        public DigestInfo GetContextWebInformation { get; set; }

    }
    [DataContract]
    public class DigestInfo
    {
        [DataMember]
        public int FormDigestTimeoutSecond { get; set; }
        [DataMember]
        public string FormDigestValue { get; set; }
        [DataMember]
        public string LibraryVersion { get; set; }
        [DataMember]
        public string SiteFullUrl { get; set; }

    }

    [DataContract]
    public class ContextInfo
    {

        [DataMember]
        public GetContextWebInformationInfo d { get; set; }

        public String FormDigestValue
        {
            get
            {
                return d.GetContextWebInformation.FormDigestValue;
            }
        }
    }

}
