//*******************************************************************************
//   Copyright 2012 Guy Barker
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//*******************************************************************************

///////////////////////////////////////////////////////////////////////////////////////////////////////////
//
// UI Automation Client Sample.
//
// This sample app accesses the text from a Windows Live Mail e-mail window using the 
// UI Automation Text pattern. The app then speaks the text using a SpeechSynthesizer.
// 
// IMPORTANT: This is a C# sample which demonstrates use of the unmanaged Windows 7 UI Automation API.
// An interop layer was generated to allow the C# sample to call the Windows 7 API with the following 
// steps in Visual Studio 2010:
//  (1) In the Solution Explorer, right click and select Add Reference.
//  (2) Browse to the %windir%\system32 folder and select UIAutomationCore.dll.
//
// By doing the above, references to a UIAutomationClient interop namespace can be added to the C# code.
//
// So it is important to note that this sample does not use the managed UI Automation API which
// is included in the .NET Framework. Nor does it use a managed wrapper for the Windows 7 unmanaged
// UI Automation which has been structured in such a way as to be usable by C# clients which have been 
// build to use the managed UIA API.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////

// Win7UIAClientForm_MailReader.cs : Defines the entry point for the application and controls the sample's own UI.

using System;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Win7UIAClientManaged
{
    public partial class Win7UIAClientForm_MailReader : Form
    {
        private MailProcessor _mailProcessor;
        private SpeechSynthesizer _synth;

        // Keep track of whether we're currently speaking text or not.
        private bool _fReadingMail = false;

        // A shipping app would use localized text here.
        string strButtonLabelDefault = "Read mail";
        string strButtonLabelReading = "Stop speaking";
        string strMailNotFound = "A Windows Live Mail e-mail could not be found.";

        public Win7UIAClientForm_MailReader()
        {
            InitializeComponent();

            InitializeSample();

            this.FormClosed += new FormClosedEventHandler(Win7UIAClientForm_FormClosed);
        }

        void InitializeSample()
        {
            _synth = new SpeechSynthesizer();

            // This sample app is only interested in when the text has been completely spoken.
            _synth.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(_synth_SpeakCompleted);

            _mailProcessor = new MailProcessor();
            _mailProcessor.Initialize();
        }

        void Win7UIAClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mailProcessor.Uninitialize();
            _mailProcessor = null;

            _synth.SpeakAsyncCancelAll();
            _synth = null;
        }

        void _synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            // We're no longer speaking, so update the UI accordingly.
            buttonRead.Text = strButtonLabelDefault;

            _fReadingMail = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            // Stop any speaking that may be in progress.
            _synth.SpeakAsyncCancelAll();

            // Are we currently speaking text?
            if (!_fReadingMail)
            {
                // We're not speaking text, so get all the text to be spoken.
                string strMailContent = _mailProcessor.GetMail();

                // If we couldn't find any text, let the user know that.
                if (strMailContent != "")
                {
                    _synth.SpeakAsync(strMailContent);
                }
                else
                {
                    _synth.SpeakAsync(strMailNotFound);
                }

                buttonRead.Text = strButtonLabelReading;
            }
            else
            {
                // We were speaking text, so we're not anymore.
                buttonRead.Text = strButtonLabelDefault;
            }

            _fReadingMail = !_fReadingMail;
        }
    }
}
