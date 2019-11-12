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

// Win32.cs : Provides the interop details for this sample app to call Win32 APIs.

using System;
using System.Runtime.InteropServices;

namespace Win7UIAClientManaged
{
    public class Win32
    {
        // FindWindow() is used by the MailReader to find a Windows Live Mail window.

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);
    }
}
