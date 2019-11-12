//*******************************************************************************
//   Copyright 2011 Guy Barker
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
// IMPORTANT: This is a C# sample which demonstrates use of the unmanaged Windows 7 UI Automation API.
// An interop layer is generated with a custom build step which calls tlbimp.exe to process the unmanaged
// COM UIAutomationCore.dll. By doing this, references to the UIAutomationCore interop namespace can be 
// added to the C# code.
//
// It is important to note that this sample does not use the managed UI Automation API which is included 
// in the .NET Framework. Nor does it use a managed wrapper for the Windows 7 unmanaged UI Automation 
// which has been structured in such a way as to be usable by C# clients which have been build to use 
// the managed UIA API.
//
//
// This sample application demonstrates how to use a UI Automation Focus Changed event handler.
// As keyboard focus changes, the sample will use the information accessible through UIA to highlight
// the element with focus, (using the Windows Magnification API) and to speak the name of the element.
//
// *** Note: Threading issues are important to the implementation of a UIA client.
// All UIA event handlers must run in a background MTA thread, (and a call to remove a handler 
// must be made on the same thread that on which the matching add-related call was made.) 
// The following link relates to how threading affects the use of UIAutomation:
//     http://msdn.microsoft.com/en-us/library/ee671692(v=VS.85).aspx
//
//
// This sample app has three threads of interest.
//
// (1) The main UI thread. (Only this thread can interact with the UI shown in the app.)
// (2) A background MTA thread used to add and remove a UIA event handler.
// (3) A background MTA thread created by UIA itself, on which our event handler is called.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////

// Win7UIAClientForm_FocusTracking.cs : Defines the entry point for the application and controls the sample's own UI.

using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Win7UIAClientManaged
{
    public partial class Win7UIAClientForm_FocusTracking : Form
    {
        private SampleFocusEventHandler _sampleFocusEventHandler;
        private Highlight _highlight;
        private SpeechSynthesizer _synth;

        // SampleUIEventHandlerDelegate is used to allow the main UI thread to be
        // notified by the UIA event handler thread when action is to be taken.
        public delegate void SampleUIEventHandlerDelegate(string strName, Rectangle rectBounds);

        public Win7UIAClientForm_FocusTracking()
        {
            InitializeComponent();

            InitializeSample();

            this.FormClosed += new FormClosedEventHandler(Win7UIAClientForm_FormClosed);
        }

        void InitializeSample()
        {
            // Initialize the highlighting used to magnify the element with focus.
            _highlight = new Highlight();
            _highlight.Initialize();

            try
            {
                _synth = new SpeechSynthesizer();
            }
            catch
            {
                // Allow this sample to run even if speech is not available.
                _synth = null;
            }

            // Initialize the event handler which is called when focus changes.
            SampleUIEventHandlerDelegate sampleUIEventHandlerDelegate = new SampleUIEventHandlerDelegate(HandleEventOnUIThread);
            _sampleFocusEventHandler = new SampleFocusEventHandler(this, sampleUIEventHandlerDelegate);

            // Now tell the sample event handler to register for events from UIA.
            _sampleFocusEventHandler.StartEventHandler();
        }

        void Win7UIAClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_synth != null)
            {
                _synth.SpeakAsyncCancelAll();
                _synth = null;
            }

            if (_highlight != null)
            {
                _highlight.Uninitialize();
                _highlight = null;
            }

            if (_sampleFocusEventHandler != null)
            {
                _sampleFocusEventHandler.Uninitialize();
                _sampleFocusEventHandler = null;
            }

            // Give any background threads created on startup a chance to close down gracefully.
            Thread.Sleep(200);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //
        // HandleEventOnUIThread() 
        //
        // This is invoked on the main UI thread by the sample UIA event handler when a focus 
        // change occurs. (The event handler itself runs on a background MTA created by UIA.)
        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        private void HandleEventOnUIThread(string strName, Rectangle rectBounding)
        {
            _highlight.HighlightRect(rectBounding);

            if (_synth != null)
            {
                _synth.SpeakAsyncCancelAll();
                _synth.SpeakAsync(strName);
            }
        }
    }
}
