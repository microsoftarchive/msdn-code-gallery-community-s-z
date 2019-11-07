'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Module1.vb
'
'--------------------------------------------------------------------------


Namespace ShakespeareanMonkeys
    Module Program
        ''' <summary>The main entry point for the application.</summary>MakeSuggestions.
       
        <STAThread()>
        Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Module
End Namespace
