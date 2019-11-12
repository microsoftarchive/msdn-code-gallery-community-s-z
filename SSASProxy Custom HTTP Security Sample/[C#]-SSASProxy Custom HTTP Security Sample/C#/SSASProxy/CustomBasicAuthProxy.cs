//===============================================================================
// Copyright © 2012 Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================


using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Web.SessionState;

namespace Microsoft.Samples.SSASProxy
{
  public class CustomBasicAuthProxy : IHttpHandler, IRequiresSessionState
  {
    /// <summary>
    /// This handler is a proxy for the SSAS data pump.  It implements HTTP Basic Auth with a custom
    /// identity store, and rewrites the XMLA BeginSession request, putting the userName from the 
    /// credentials into the CustomData field, so it can be used in custom cube security.
    /// 
    /// This HTTP Handler does its own security, so the web site it's in should be configured to
    /// with only Anonymous logins.  The handler will send the 401 on unauthenticated requests
    /// and will process Basic credentials and store the user's identity in ASP.NET session state.
    /// 
    /// </summary>
    #region IHttpHandler Members

    public bool IsReusable
    {
      get { return true; }
    }

    static bool alwaysParseRequest = System.Diagnostics.Debugger.IsAttached;
    public void ProcessRequest(HttpContext context)
    {

      var req = (HttpWebRequest)WebRequest.Create("http://localhost/ssas/msmdpump.dll");

      //set the credentials to connect to the SSAS datapump in IIS
      //Needs to be set in the properties of the Anonymous Authentication module 
      //and no other Authenticaion protocol should be enabled in IIS
      req.UseDefaultCredentials = true;

      req.Method = context.Request.HttpMethod;
      bool hasSSASSessionIdHeader = false;
      context.Response.DisableKernelCache();

      #region Handle HTTP Basic Auth and Session
      if (context.Session.Contents["customData"] == null)
      {
        var auth = context.Request.Headers["Authorization"];
        if (auth == null || !auth.ToLower().StartsWith("basic "))
        {
          context.Response.StatusCode = 401;
          context.Response.AddHeader("WWW-Authenticate", "Basic realm=cube");
          context.Response.End();
          return;
        }
        auth = auth.Substring("Basic ".Length);
        var authString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(auth));
        var aa = authString.Split(':');
        var user = aa[0];
        var pwd = aa[1];

        if (!ValidateCredentials(user, pwd))
        {
          context.Response.StatusCode = 401;
          context.Response.AddHeader("WWW-Authenticate", "Basic realm=cube");
          context.Response.End();
          return;
        }

        //save the user's identity for pushing into the BeginSession request
        //Here we're just setting the user name as the CustomData.  Custom cube security
        //would then consume that.
        context.Session.Add("customData", user);
      }
      #endregion

      #region Process Request Headers

      foreach (string h in context.Request.Headers.Keys)
      {
        if (h.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
        {
          req.ContentType = context.Request.Headers[h];
        }
        else if (h.Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
        {
          req.ContentLength = int.Parse(context.Request.Headers[h]);
        }
        else if (h.Equals("Connection", StringComparison.OrdinalIgnoreCase))
        {
          req.KeepAlive = (context.Request.Headers[h].Equals("Keep-Alive", StringComparison.OrdinalIgnoreCase));
        }
        else if (h.Equals("Accept", StringComparison.OrdinalIgnoreCase))
        {
          req.Accept = context.Request.Headers[h];
        }
        else if (h.Equals("User-Agent", StringComparison.OrdinalIgnoreCase))
        {
          req.UserAgent = context.Request.Headers[h];
        }
        else if (h.Equals("SOAPAction", StringComparison.OrdinalIgnoreCase))
        {
          req.Headers.Add(h, context.Request.Headers[h]);
        }
        else if (h.Equals("X-Transport-Caps-Negotiation-Flags", StringComparison.OrdinalIgnoreCase))
        {
          req.Headers.Add(h, context.Request.Headers[h]);
        }
        else if (h.Equals("X-AS-GetSessionToken", StringComparison.OrdinalIgnoreCase))
        {
          // hasGetSessionTokenHeader = true;
          req.Headers.Add(h, context.Request.Headers[h]);
        }
        else if (h.Equals("X-AS-SessionID", StringComparison.OrdinalIgnoreCase))
        {
          hasSSASSessionIdHeader = true;
          req.Headers.Add(h, context.Request.Headers[h]);
        }

      }
      #endregion

      #region Process Request Body


      if (context.Request.HttpMethod == "POST" || context.Request.HttpMethod == "PUT")
      {
        using (var ss = context.Request.GetBufferlessInputStream())
        {
          if (!hasSSASSessionIdHeader || alwaysParseRequest)
          {
            XDocument doc = XDocument.Load(ss);

            //For a BeginSesion request remove any security-related properties sent by the client
            //and push the session's customData string into the CustomData property on the BeginSession request
            if (IsBeginSessionRequest(doc.Root))
            {
              ScrubSecrityProperties(doc.Root);
              SetCustomData(doc.Root, context.Session["customData"].ToString());
            }

            var ms = new MemoryStream();
            var xw = XmlWriter.Create(ms, new XmlWriterSettings() { Encoding = context.Request.ContentEncoding });
            doc.Save(xw);
            xw.Flush();
            ss.Close();
            doc = null;

            var bytes = ms.Length;
            ms.Position = 0;
            req.ContentLength = bytes;
            using (var ds = req.GetRequestStream())
            {
              ms.CopyTo(ds);
            }

          }
          else //just copy the incoming request stream to the data pump request
          {
            using (var ds = req.GetRequestStream())
            {
              ss.CopyTo(ds);
            }
          }
        }
      }
      #endregion

      //Forward the request to SSAS
      HttpWebResponse resp = null;
      try
      {
        resp = (HttpWebResponse)req.GetResponse();
      }
      catch (WebException we)  //if we got a valid http response, just pass it on to the client
      {
        resp = (HttpWebResponse)we.Response;
        if (resp == null)
          throw we;
      }

      context.Response.StatusCode = (int)resp.StatusCode;
      context.Response.StatusDescription = resp.StatusDescription;

      #region Process Response Headers

      foreach (string h in resp.Headers.Keys)
      {
        if (h.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
        {
          context.Response.ContentType = resp.Headers[h];
        }
        else if (h.Equals("Transfer-Encoding", StringComparison.OrdinalIgnoreCase))
        {
          //skip.  ASP.NET will add this if necessary
        }
        else if (h.Equals("WWW-Authenticate", StringComparison.OrdinalIgnoreCase))
        {
          //skip
        }
        else if (h.Equals("Persistent-Auth", StringComparison.OrdinalIgnoreCase))
        {
          //skip
        }
        else if (h.Equals("X-Transport-Caps-Negotiation-Flags", StringComparison.OrdinalIgnoreCase))
        {
          context.Response.AddHeader(h, resp.Headers[h]);
        }

      }
      #endregion

      //Copy the SSAS respons body to the client
      using (var ss = resp.GetResponseStream())
      using (var ds = context.Response.OutputStream)
      {
        ss.CopyTo(ds);
      }
      context.Response.End();

    }


    /*
     * 
     * Sample BeginSession request
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
<soap:Header>
<BeginSession xmlns="urn:schemas-microsoft-com:xml-analysis" />
<Version xmlns="http://schemas.microsoft.com/analysisservices/2008/engine/100" Sequence="400" />
</soap:Header>
<soap:Body>
<Execute xmlns="urn:schemas-microsoft-com:xml-analysis">
  <Command>
    <Statement xmlns="urn:schemas-microsoft-com:xml-analysis" />
  </Command>
  <Properties>
    <PropertyList>
      <SafetyOptions>2</SafetyOptions>
      <MdxMissingMemberMode>Error</MdxMissingMemberMode>
      <DbpropMsmdOptimizeResponse>1</DbpropMsmdOptimizeResponse>
      <LocaleIdentifier>1033</LocaleIdentifier>
      <DbpropMsmdMDXCompatibility>1</DbpropMsmdMDXCompatibility>
      <DbpropMsmdSubqueries>2</DbpropMsmdSubqueries>
    </PropertyList>
  </Properties>
</Execute>
</soap:Body>
</soap:Envelope>
     * */
    static XNamespace xmla = "urn:schemas-microsoft-com:xml-analysis";
    static XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
    /**
     * Read the SOAP envelope to determine if this request is the XMLA BeginSession request.
     * If so we will need to rewrite it.
     */
    bool IsBeginSessionRequest(XElement soapEnvelope)
    {
      var e = soapEnvelope.Element(soap + "Header").Element(xmla + "BeginSession");
      return e != null;

    }
    void ScrubSecrityProperties(XElement soapEnvelope)
    {
      var propertyList = soapEnvelope.Element(soap + "Body")
                         .Element(xmla + "Execute")
                         .Element(xmla + "Properties")
                         .Element(xmla + "PropertyList");

      var elementsToRemove = new List<XElement>();
      var elementNamesToRemove = new HashSet<XName>() 
                { 
                    xmla+"DataSourceInfo", 
                    xmla+"EffectiveRoles",
                    xmla+"EffectiveUserName",
                    xmla+"Roles",
                    xmla+"CustomData"
                };

      foreach (var pe in propertyList.Elements())
      {
        if (elementNamesToRemove.Contains(pe.Name))
        {
          elementsToRemove.Add(pe);
        }
      }
      foreach (var pe in elementsToRemove)
      {
        pe.Remove();
      }
    }
    /**
     * Push a custom string into the customData field on the SOAP request.  Typically this will be the 
     * user's identity.  The cube would then use this to implement custom security.
     */
    void SetCustomData(XElement soapEnvelope, string customData)
    {
      var propertyList = soapEnvelope.Element(soap + "Body")
                                     .Element(xmla + "Execute")
                                     .Element(xmla + "Properties")
                                     .Element(xmla + "PropertyList");

      var customDataElement = propertyList.Element(xmla + "CustomData");
      if (customDataElement == null)
      {
        customDataElement = new XElement(xmla + "CustomData");
        propertyList.Add(customDataElement);
      }

      customDataElement.Value = customData;
    }

    /**
     * This is the custom credential validation procedure.  Check the credentials
     * against some credential store. 
     */
    bool ValidateCredentials(string userName, string password)
    {
      return true;
      //return (password == "P@ssword");
    }

    #endregion
  }
}
