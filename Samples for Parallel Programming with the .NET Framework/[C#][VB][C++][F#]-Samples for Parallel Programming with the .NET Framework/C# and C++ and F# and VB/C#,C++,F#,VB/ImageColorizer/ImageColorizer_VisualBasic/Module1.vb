
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D


Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
    Module Module1
        Friend NotInheritable Class Program
            ''' <summary>The entry point for the application.</summary>
            Private Sub New()
            End Sub
            <STAThread()>
                Shared Sub Main(ByVal args() As String)
                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)
                Application.Run(New MainForm())
            End Sub
        End Class

    End Module

End Namespace

