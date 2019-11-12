//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Text;
using System.Xaml;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Activities.Design.ExpressionTranslation;
using Microsoft.Workflow.Client;

namespace Microsoft.Workflow.Samples.Common
{
    public class WorkflowUtils
    {
        public static WorkflowManagementClient CreateForSample(string rootScope, string scopeName)
        {
            var rootClient = new WorkflowManagementClient(new Uri(rootScope));

            return rootClient.CurrentScope.PublishChildScope(scopeName,
                new ScopeDescription()
                {
                    UserComments = string.Format("For {0} sample only", scopeName)
                });
        }

        public static XElement Translate(string xamlFile)
        {
            string translatedWorkflowString = null;

            using (XamlReader xamlReader = new XamlXmlReader(xamlFile))
            {
                TranslationResults result = ExpressionTranslator.Translate(xamlReader);
                if (result.Errors.Count == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    using (XmlWriter xmlWriter = XmlWriter.Create(sb, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
                    {
                        using (XamlXmlWriter writer = new XamlXmlWriter(xmlWriter, result.Output.SchemaContext))
                        {
                            XamlServices.Transform(result.Output, writer);
                        }
                    }
                    translatedWorkflowString = sb.ToString();
                }
                else
                {
                    throw new InvalidOperationException("Translation errors");
                }
            }

            return XElement.Parse(translatedWorkflowString);
        }

        public static void PrintDone()
        {
            Print("[Done]", ConsoleColor.Green);
        }

        public static void Print(string message, ConsoleColor color)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
