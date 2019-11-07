// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// You must install the following NuGet Packages for the following namespaces to work:
// https://www.nuget.org/packages/Microsoft.CrmSdk.CoreAssemblies/
// https://www.nuget.org/packages/AjaxMin/
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Ajax.Utilities;

namespace Microsoft.Crm.Sdk.Samples
{
    class ActionMessageGenerator
    {
        private OrganizationServiceProxy _serviceProxy;

        /// <summary>
        /// This method first connects to the Organization service. Afterwards,
        /// the files are generated
        /// </summary>
        /// <param name="serverConfig">Contains server connection information.</param>
        public void Run(ServerConnection.Configuration serverConfig)
        {
            try
            {
                // Connect to the Organization service. 
                // The using statement assures that the service proxy will be properly disposed.
                using (_serviceProxy = ServerConnection.GetOrganizationProxy(serverConfig))
                {
                    // This statement is required to enable early-bound type support.
                    _serviceProxy.EnableProxyTypes();

                    using (ServiceContext svcContext = new ServiceContext(_serviceProxy))
                    {

                        var messages = from sm in svcContext.SdkMessageSet
                                       join smp in svcContext.SdkMessagePairSet
                                       on sm.SdkMessageId equals smp.SdkMessageId.Id
                                       join smreq in svcContext.SdkMessageRequestSet
                                       on smp.SdkMessagePairId equals smreq.SdkMessagePairId.Id
                                       join smresp in svcContext.SdkMessageResponseSet
                                       on smreq.SdkMessageRequestId equals smresp.SdkMessageRequestId.Id
                                       join wkflw in svcContext.WorkflowSet
                                       on sm.SdkMessageId equals wkflw.SdkMessageId.Id
                                       where smreq.CustomizationLevel.Equals(1)
                                       where sm.Template.Equals(false)
                                       where wkflw.Type.Equals(1) //Definition

                                       orderby sm.Name
                                       select new
                                       {
                                           sm.Name,
                                           wkflw.Description,
                                           smreq.SdkMessageRequestId,
                                           smresp.SdkMessageResponseId
                                       };

                        int actionCount = 0;
                        foreach (var a in messages)
                        {
                         actionCount++;
                        }
                        Console.WriteLine("{0} custom actions found.", actionCount);

                        foreach (var m in messages)
                        {
                            var parameters = from req in svcContext.SdkMessageRequestFieldSet
                                             where req.SdkMessageRequestId.Id.Equals(m.SdkMessageRequestId)
                                             where !req.FieldMask.Equals(4)
                                             orderby req.Position
                                             select new RequestParameter
                                             {
                                                 Name = req.Name,
                                                 InternalPropertyName = "_" + req.Name,
                                                 ParameterName = Char.ToLowerInvariant(req.Name[0]) + req.Name.Substring(1),
                                                 PropertyName = Char.ToUpperInvariant(req.Name[0]) + req.Name.Substring(1),
                                                 TypeName = req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")),
                                                 JavaScriptValidationType = (
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Boolean") ? "Boolean" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.DateTime") ? "Date" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Decimal") ? "Number" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Entity") ? "Sdk.Entity" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityCollection") ? "Sdk.EntityCollection" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityReference") ? "Sdk.EntityReference" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Double") ? "Number" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Int32") ? "Number" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Money") ? "Number" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.OptionSetValue") ? "Number" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.String") ? "String" : "UnexpectedType"

                                                 ),
                                                 JavaScriptValidationExpression = (
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Boolean") ? "typeof value == \"boolean\"" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.DateTime") ? "value instanceof Date" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Decimal") ? "typeof value == \"number\"" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Entity") ? "value instanceof Sdk.Entity" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityCollection") ? "value instanceof Sdk.EntityCollection" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityReference") ? "value instanceof Sdk.EntityReference" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Double") ? "typeof value == \"number\"" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Int32") ? "typeof value == \"number\"" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Money") ? "typeof value == \"number\"" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.OptionSetValue") ? "typeof value == \"number\"" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.String") ? "typeof value == \"string\"" : "UnexpectedType"

                                                 ),
                                                 NamespacedType = (
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Boolean") ? "c:boolean" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.DateTime") ? "c:dateTime" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Decimal") ? "c:decimal" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Entity") ? "a:Entity" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityCollection") ? "a:EntityCollection" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityReference") ? "a:EntityReference" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Double") ? "c:double" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.Int32") ? "c:int" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Money") ? "a:Money" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.OptionSetValue") ? "a:OptionSetValue" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.String") ? "c:string" : "UnexpectedType"

                                                 ),
                                                 SerializeExpression = (
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "System.DateTime") ? ".toISOString()" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.Entity") ? ".toValueXml()" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityCollection") ? ".toValueXml()" :
                                                     (req.ClrParser.Substring(0, req.ClrParser.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityReference") ? ".toValueXml()" : ""

                                                 ),
                                                 Optional = (!req.Optional.HasValue) ? false : (Boolean)req.Optional
                                             };

                            var responseFields = from rf in svcContext.SdkMessageResponseFieldSet
                                                 where rf.SdkMessageResponseId.Id.Equals(m.SdkMessageResponseId)
                                                 orderby rf.Position
                                                 select new ResponseField
                                                 {
                                                     Name = rf.Name,
                                                     InternalPropertyName = "_" + Char.ToLowerInvariant(rf.Name[0]) + rf.Name.Substring(1),
                                                     PropertyName = Char.ToUpperInvariant(rf.Name[0]) + rf.Name.Substring(1),
                                                     TypeName = rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")),
                                                     ValueNodeParser = (
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Boolean") ? "(Sdk.Xml.getNodeText(valueNode) == \"true\") ? true : false" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.DateTime") ? "new Date(Sdk.Xml.getNodeText(valueNode))" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Decimal") ? "parseFloat(Sdk.Xml.getNodeText(valueNode))" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.Entity") ? "Sdk.Util.createEntityFromNode(valueNode)" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityCollection") ? "Sdk.Util.createEntityCollectionFromNode(valueNode)" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityReference") ? "Sdk.Util.createEntityReferenceFromNode(valueNode)" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Double") ? "parseFloat(Sdk.Xml.getNodeText(valueNode))" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Int32") ? "parseInt(Sdk.Xml.getNodeText(valueNode), 10)" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.Money") ? "parseFloat(Sdk.Xml.getNodeText(valueNode))" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.OptionSetValue") ? "parseInt(Sdk.Xml.getNodeText(valueNode), 10)" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.String") ? "Sdk.Xml.getNodeText(valueNode)" : "UnexpectedType"
                                                     ),
                                                     JavaScriptType = (
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Boolean") ? "Boolean" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.DateTime") ? "Date" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Decimal") ? "Number" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.Entity") ? "Sdk.Entity" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityCollection") ? "Sdk.EntityCollection" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.EntityReference") ? "Sdk.EntityReference" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Double") ? "Number" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.Int32") ? "Number" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.Money") ? "Number" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "Microsoft.Xrm.Sdk.OptionSetValue") ? "Number" :
                                                     (rf.ClrFormatter.Substring(0, rf.ClrFormatter.IndexOf(",")) == "System.String") ? "String" : "UnexpectedType"
                                                     )
                                                 };

                            String fileName = Path.GetFullPath("Messages\\vsdoc\\Sdk." + m.Name + ".vsdoc.js");
                            
                            using (StreamWriter sw = new StreamWriter(fileName))
                            {

                                sw.WriteLine("\"use strict\";");
                                sw.WriteLine("(function () {");
                                sw.WriteLine("this.{0}Request = function (", m.Name);


                                int parameterCount = 0;
                                foreach (var item in parameters)
                                {
                                    parameterCount++;
                                }
                                

                                String[] parameterNames = new String[parameterCount];
                                int count = 0;
                                foreach (var item in parameters)
                                {
                                    parameterNames[count] = item.ParameterName;
                                    count++;
                                }
                                sw.WriteLine(string.Join(",\r\n", parameterNames));
                                sw.WriteLine(")");
                                sw.WriteLine("{");
                                sw.WriteLine("///<summary>");
                                sw.WriteLine("/// {0}", m.Description);
                                sw.WriteLine("///</summary>");
                                foreach (RequestParameter rp in parameters)
                                {
                                    sw.WriteLine("///<param name=\"{0}\" {1} type=\"{2}\">",
                                         rp.ParameterName,
                                         (rp.Optional) ? "optional=\"true\"" : "",
                                         rp.JavaScriptValidationType);
                                    sw.WriteLine("/// [Add Description]");
                                    sw.WriteLine("///</param>");
                                }
                                sw.WriteLine("if (!(this instanceof Sdk.{0}Request)) {{", m.Name);
                                sw.WriteLine("return new Sdk.{0}Request({1});", m.Name, string.Join(", ", parameterNames));
                                sw.WriteLine("}");
                                sw.WriteLine("Sdk.OrganizationRequest.call(this);");
                                sw.WriteLine();

                                if (parameterCount == 0)
                                {
                                    sw.WriteLine("  // This message has no parameters");
                                }
                                else
                                {
                                    sw.WriteLine("  // Internal properties");
                                }

                                foreach (RequestParameter rp in parameters)
                                {
                                    sw.WriteLine("var {0} = null;", rp.InternalPropertyName);
                                }
                                sw.WriteLine();
                                sw.WriteLine((parameterCount == 0) ? "" : "// internal validation functions");
                                foreach (RequestParameter rp in parameters)
                                {
                                    sw.WriteLine();
                                    sw.WriteLine("function _setValid{0}(value) {{", rp.PropertyName);                 
                                    sw.WriteLine(" if ({0}{1}) {{", (rp.Optional) ? "value == null || " : "", rp.JavaScriptValidationExpression);
                                    sw.WriteLine("  {0} = value;", rp.InternalPropertyName);
                                    sw.WriteLine(" }");
                                    sw.WriteLine(" else {");
                                    sw.WriteLine("  throw new Error(\"Sdk.{0}Request {1} property {2}must be a {3}{4}.\")", m.Name, rp.PropertyName, (rp.Optional) ? "" : "is required and ", rp.JavaScriptValidationType, (rp.Optional) ? " or null" : "");
                                    sw.WriteLine(" }");
                                    sw.WriteLine("}");
                                }
                                sw.WriteLine();
                                sw.WriteLine((parameterCount == 0) ? "" : "//Set internal properties from constructor parameters");
                                foreach (RequestParameter rp in parameters) {
                                    sw.WriteLine("  if (typeof {0} != \"undefined\") {{", rp.ParameterName);
                                    sw.WriteLine("   _setValid{0}({1});", rp.PropertyName, rp.ParameterName);
                                    sw.WriteLine("  }");
                                }

                                sw.WriteLine();
                                sw.WriteLine("  function getRequestXml() {");
                                sw.WriteLine("return [\"<d:request>\",");
                                sw.WriteLine((parameterCount == 0) ? "        \"<a:Parameters />\"," : "        \"<a:Parameters>\",");

                                foreach (RequestParameter rp in parameters)
                                {

                                    sw.WriteLine("");
                                    sw.WriteLine("          \"<a:KeyValuePairOfstringanyType>\",");
                                    sw.WriteLine("            \"<b:key>{0}</b:key>\",", rp.Name);
                                    sw.WriteLine("           ({0} == null) ? \"<b:value i:nil=\\\"true\\\" />\" :", rp.InternalPropertyName);
                                    switch (rp.TypeName)
                                    {     
                                        case "Microsoft.Xrm.Sdk.OptionSetValue":
                                            sw.WriteLine("           [\"<b:value i:type=\\\"a:OptionSetValue\\\">\",");
                                            sw.WriteLine("            \"<a:Value>\",{0},\"</a:Value>\",", rp.InternalPropertyName);
                                            sw.WriteLine("           \"</b:value>\"].join(\"\"),");
                                            break;
                                        case "Microsoft.Xrm.Sdk.Money":
                                            sw.WriteLine("           [\"<b:value i:type=\\\"a:Money\\\">\",");
                                            sw.WriteLine("            \"<a:Value>\",{0},\"</a:Value>\",", rp.InternalPropertyName);
                                            sw.WriteLine("           \"</b:value>\"].join(\"\"),");
                                            break;
                                        default:
                                            sw.WriteLine("           [\"<b:value i:type=\\\"{0}\\\">\", {1}{2}, \"</b:value>\"].join(\"\"),", rp.NamespacedType, rp.InternalPropertyName, rp.SerializeExpression);
                                            break;

                                    }
                                    sw.WriteLine("          \"</a:KeyValuePairOfstringanyType>\",");
                                }

                                sw.WriteLine();
                                sw.WriteLine((parameterCount == 0) ? "" : "        \"</a:Parameters>\",");
                                sw.WriteLine("        \"<a:RequestId i:nil=\\\"true\\\" />\",");
                                sw.WriteLine("        \"<a:RequestName>{0}</a:RequestName>\",", m.Name);
                                sw.WriteLine("      \"</d:request>\"].join(\"\");");
                                sw.WriteLine("  }");
                                sw.WriteLine();
                                sw.WriteLine("  this.setResponseType(Sdk.{0}Response);", m.Name);
                                sw.WriteLine("  this.setRequestXml(getRequestXml());");
                                sw.WriteLine();
                                sw.WriteLine((parameterCount == 0) ? "" : "  // Public methods to set properties");

                                foreach (RequestParameter rp in parameters)
                                {
                                    sw.WriteLine("  this.set{0} = function (value) {{", rp.PropertyName);
                                    sw.WriteLine("  ///<summary>");
                                    sw.WriteLine("  /// [Add Description]");
                                    sw.WriteLine("  ///</summary>");
                                    sw.WriteLine("  ///<param name=\"value\" type=\"{0}\">", rp.JavaScriptValidationType);
                                    sw.WriteLine("  /// [Add Description]");
                                    sw.WriteLine("  ///</param>");
                                    sw.WriteLine("   _setValid{0}(value);", rp.PropertyName);
                                    sw.WriteLine("   this.setRequestXml(getRequestXml());");
                                    sw.WriteLine("  }");
                                    sw.WriteLine();

                                }
                                sw.WriteLine(" }");
                                sw.WriteLine(" this.{0}Request.__class = true;", m.Name);
                                sw.WriteLine();
                                sw.WriteLine("this.{0}Response = function (responseXml) {{", m.Name);
                                sw.WriteLine("  ///<summary>");
                                sw.WriteLine("  /// Response to {0}Request", m.Name);
                                sw.WriteLine("  ///</summary>");
                                sw.WriteLine("  if (!(this instanceof Sdk.{0}Response)) {{", m.Name);
                                sw.WriteLine("   return new Sdk.{0}Response(responseXml);", m.Name);
                                sw.WriteLine("  }");
                                sw.WriteLine("  Sdk.OrganizationResponse.call(this)");
                                sw.WriteLine();

                                int responseFieldsCount = 0;

                                foreach (ResponseField rf in responseFields)
                                {
                                    responseFieldsCount++;
                                }
                                if (responseFieldsCount == 0)
                                {
                                    sw.WriteLine("  // This message returns no values");
                                }
                                else
                                {
                                    sw.WriteLine("  // Internal properties");
                                }
                                foreach (ResponseField rf in responseFields)
                                {
                                    sw.WriteLine("  var {0} = null;", rf.InternalPropertyName);
                                }
                                sw.WriteLine();
                                sw.WriteLine((responseFieldsCount == 0) ? "" : "  // Internal property setter functions");
                                sw.WriteLine();
                                foreach (ResponseField rf in responseFields)
                                {
                                    sw.WriteLine("  function _set{0}(xml) {{", rf.PropertyName);
                                    sw.WriteLine("   var valueNode = Sdk.Xml.selectSingleNode(xml, \"//a:KeyValuePairOfstringanyType[b:key='{0}']/b:value\");", rf.Name);
                                    sw.WriteLine("   if (!Sdk.Xml.isNodeNull(valueNode)) {");
                                    sw.WriteLine("    {0} = {1};", rf.InternalPropertyName, rf.ValueNodeParser);
                                    sw.WriteLine("   }");
                                    sw.WriteLine("  }");
                                }
                                sw.WriteLine((responseFieldsCount == 0) ? "" : "  //Public Methods to retrieve properties");
                                foreach (ResponseField rf in responseFields)
                                {
                                    sw.WriteLine("  this.get{0} = function () {{", rf.PropertyName);
                                    sw.WriteLine("  ///<summary>");
                                    sw.WriteLine("  /// [Add Description]");
                                    sw.WriteLine("  ///</summary>");
                                    sw.WriteLine("  ///<returns type=\"{0}\">", rf.JavaScriptType);
                                    sw.WriteLine("  /// [Add Description]");
                                    sw.WriteLine("  ///</returns>");
                                    sw.WriteLine("   return {0};", rf.InternalPropertyName);
                                    sw.WriteLine("  }");
                                }
                                sw.WriteLine();
                                sw.WriteLine((responseFieldsCount == 0) ? "" : "  //Set property values from responseXml constructor parameter");
                                foreach (ResponseField rf in responseFields)
                                {
                                    sw.WriteLine("  _set{0}(responseXml);", rf.PropertyName);
                                }
                                sw.WriteLine(" }");
                                sw.WriteLine(" this.{0}Response.__class = true;", m.Name);
                                sw.WriteLine("}).call(Sdk)");
                                sw.WriteLine();
                                sw.WriteLine("Sdk.{0}Request.prototype = new Sdk.OrganizationRequest();", m.Name);
                                sw.WriteLine("Sdk.{0}Response.prototype = new Sdk.OrganizationResponse();", m.Name);

                                Console.WriteLine(fileName.Replace(Environment.CurrentDirectory,"\\bin\\Debug"));
                            }

                            //Create a minimized version of the file
                            string source;
                            using (var inputFile = new StreamReader(fileName))
                            {
                                source = inputFile.ReadToEnd();
                            }
                            var minifier = new Minifier();
                            String minifiedSource = minifier.MinifyJavaScript(source);
                            foreach (var error in minifier.ErrorList)
                            {
                                Console.Error.WriteLine(error.ToString());
                            }
                            String MinimizedFileName = Path.GetFullPath("Messages\\min\\Sdk." + m.Name + ".min.js");
                            using (StreamWriter sw2 = new StreamWriter(MinimizedFileName))
                            {
                                sw2.WriteLine(minifiedSource);
                            }
                            Console.WriteLine(MinimizedFileName.Replace(Environment.CurrentDirectory, "\\bin\\Debug"));
                        }

                    }

                }
            }

            // Catch any service fault exceptions that Microsoft Dynamics CRM throws.
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                // You can handle an exception here or pass it back to the calling method.
                throw;
            }
        }


        /// <summary>
        /// Standard Main() method used by most SDK samples.
        /// </summary>
        /// <param name="args"></param>
        static public void Main(string[] args)
        {
            try
            {
                // Obtain the target organization's Web address and client logon 
                // credentials from the user.
                ServerConnection serverConnect = new ServerConnection();
                ServerConnection.Configuration config = serverConnect.GetServerConfiguration();

                ActionMessageGenerator app = new ActionMessageGenerator();
                app.Run(config);
            }
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
            {
                Console.WriteLine("The application terminated with an error.");
                Console.WriteLine("Timestamp: {0}", ex.Detail.Timestamp);
                Console.WriteLine("Code: {0}", ex.Detail.ErrorCode);
                Console.WriteLine("Message: {0}", ex.Detail.Message);
                Console.WriteLine("Plugin Trace: {0}", ex.Detail.TraceText);
                Console.WriteLine("Inner Fault: {0}",
                    null == ex.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault");
            }
            catch (System.TimeoutException ex)
            {
                Console.WriteLine("The application terminated with an error.");
                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Stack Trace: {0}", ex.StackTrace);
                Console.WriteLine("Inner Fault: {0}",
                    null == ex.InnerException.Message ? "No Inner Fault" : ex.InnerException.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("The application terminated with an error.");
                Console.WriteLine(ex.Message);

                // Display the details of the inner exception.
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);

                    FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> fe = ex.InnerException
                        as FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>;
                    if (fe != null)
                    {
                        Console.WriteLine("Timestamp: {0}", fe.Detail.Timestamp);
                        Console.WriteLine("Code: {0}", fe.Detail.ErrorCode);
                        Console.WriteLine("Message: {0}", fe.Detail.Message);
                        Console.WriteLine("Plugin Trace: {0}", fe.Detail.TraceText);
                        Console.WriteLine("Inner Fault: {0}",
                            null == fe.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault");
                    }
                }
            }
            // Additonal exceptions to catch: SecurityTokenValidationException, ExpiredSecurityTokenException,
            // SecurityAccessDeniedException, MessageSecurityException, and SecurityNegotiationException.

            finally
            {
                Console.WriteLine("Press <Enter> to exit.");
                Console.ReadLine();
            }
        }
    }
}
