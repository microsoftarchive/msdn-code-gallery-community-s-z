'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Program.vb
'
'  Description: Application entry-point.
' 
'--------------------------------------------------------------------------

Imports System.Security
Imports System.Security.Permissions
Imports System.Runtime.InteropServices

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku
	''' <summary>Contains the entrypoint for the application.</summary>
    Module Program
        ''' <summary>The main application form.</summary>
        Private _mainForm As MainForm

        ''' <summary>Main entrypoint.</summary>
        Sub New()
        End Sub
        <STAThread()>
        Public Sub Main(ByVal args() As String)
            ' Setup visual styles. Do this first so that any error message boxes
            ' displayed get the visual styles to match.
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(True)

            ' Create the main form and run the app
            _mainForm = New MainForm() ' purposely not using 'using' as, in the event of an exception, we want to access MainForm's state
            Application.Run(_mainForm)
            _mainForm.Dispose()
            _mainForm = Nothing
        End Sub
    End Module
End Namespace