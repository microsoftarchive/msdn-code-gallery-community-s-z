// Copyright 2013 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.

using System.Collections.Generic;

namespace ASPNETSimpleMVC4.Models
{
    public class SimpleDirectory
    {
        public static List<SimpleDirectoryEntry> Entries = new List<SimpleDirectoryEntry>()
        {
           new SimpleDirectoryEntry(){Name="Andrew Dixon", Email="andrew@contoso.com", Title="Developer"},
           new SimpleDirectoryEntry(){Name="Iben Thorello", Email="iben@contoso.com", Title="Developer"},
           new SimpleDirectoryEntry(){Name="Terry Adams", Email="terry@contoso.com", Title="Developer"},
           new SimpleDirectoryEntry(){Name="Kim Abercrombie", Email="kim@contoso.com", Title="Developer"},
           new SimpleDirectoryEntry(){Name="David Hamilton", Email="david@contoso.com", Title="Painter"},
           new SimpleDirectoryEntry(){Name="Michael Patton", Email="michael@contoso.com", Title="Fire Dancer"},
           new SimpleDirectoryEntry(){Name="Mark Hanson", Email="mark@contoso.com", Title="Chief Yodeller"},
        };
    }
}