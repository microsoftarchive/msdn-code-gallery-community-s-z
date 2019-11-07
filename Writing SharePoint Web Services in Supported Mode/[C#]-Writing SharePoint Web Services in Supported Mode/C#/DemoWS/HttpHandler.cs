using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;

namespace DemoWS
{
    public class HttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            StringWriter sw1 = new StringWriter();
            // Original - cop spdisco.aspx
            context.Server.Execute("spdisco.disco.aspx", sw1);
            XmlDocument spdiscoXml = new XmlDocument();
            spdiscoXml.LoadXml(sw1.ToString());

            var files = Directory.GetFiles(context.Server.MapPath(""), "*.spdisco.aspx");
            foreach (var file in files)
            {
                StringWriter sw2 = new StringWriter();
                context.Server.Execute(System.IO.Path.GetFileName(file), sw2);

                XmlDocument otherSPDiscoXml = new XmlDocument();
                otherSPDiscoXml.LoadXml(sw2.ToString());
                foreach (XmlNode importedNode in otherSPDiscoXml.DocumentElement.ChildNodes)
                {
                    spdiscoXml.DocumentElement.AppendChild(spdiscoXml.ImportNode(importedNode, true));
                }
            }

            context.Response.Write(String.Format("<?xml version='1.0' encoding='utf-8' ?> {0}", spdiscoXml.InnerXml));
        }
    }
}
