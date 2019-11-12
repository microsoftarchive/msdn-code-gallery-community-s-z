Imports System.Collections.ObjectModel

Namespace My
    Partial Friend Class MyApplication
        Protected Overrides Function Oninitialize(commandLineArgs As ReadOnlyCollection(Of String)) As Boolean
            If Not My.Settings.AppDisplaySplashScreen Then
                commandLineArgs = New ReadOnlyCollection(Of String)(commandLineArgs.Concat({"/nosplash"}).ToArray())
            End If
            'Me.MinimumSplashScreenDisplayTime = 5000
            Return MyBase.OnInitialize(commandLineArgs)
        End Function
    End Class
End Namespace

