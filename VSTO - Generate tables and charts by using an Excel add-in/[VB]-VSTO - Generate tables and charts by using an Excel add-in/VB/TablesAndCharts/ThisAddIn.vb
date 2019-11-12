Public Class ThisAddIn

    Dim _tableAndChartPane As TableAndChartPane
    Dim _taskPane As CustomTaskPane
    Private Sub ThisAddIn_Startup() Handles Me.Startup

        _tableAndChartPane = New TableAndChartPane()
        _taskPane = Me.CustomTaskPanes.Add(_tableAndChartPane, "Tables and Charts")
        _taskPane.Visible = True
        _taskPane.Width = 250

    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

End Class
