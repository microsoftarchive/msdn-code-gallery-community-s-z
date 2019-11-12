
'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Module1.vb
'
'--------------------------------------------------------------------------
Namespace GameOfLife
    Module Module1

        ''' <summary>The main entry point for the application.</summary>
        
        <STAThread()>
        Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Module
End Namespace
