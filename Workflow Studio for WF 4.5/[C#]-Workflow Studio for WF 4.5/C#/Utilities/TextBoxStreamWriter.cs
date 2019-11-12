//-----------------------------------------------------------------------
// <copyright file="TextBoxStreamWriter.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Utilities
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Windows.Controls;

    public class TextBoxStreamWriter : TextWriter
    {
        private TextBox output = null;
        private TraceSource traceSource;
        private TraceSource allTraceSource;
        private string workflowName;

        public TextBoxStreamWriter(TextBox output, string workflowName)
        {
            this.output = output;
            this.workflowName = workflowName;
            this.traceSource = new TraceSource(workflowName + "Output", SourceLevels.Verbose);
            this.allTraceSource = new TraceSource("AllOutput", SourceLevels.Verbose);
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }

        public override void WriteLine(string value)
        {
            if (value != null)
            {
                base.WriteLine(value);
                this.traceSource.TraceData(TraceEventType.Verbose, 0, value.ToString());
                this.allTraceSource.TraceData(TraceEventType.Verbose, 0, this.workflowName, value.ToString());
            }
        }

        public override void Write(char value)
        {
            base.Write(value);
            this.output.Dispatcher.BeginInvoke(new Action(() =>
                {
                    this.output.AppendText(value.ToString());
                }));
        }
    }
}