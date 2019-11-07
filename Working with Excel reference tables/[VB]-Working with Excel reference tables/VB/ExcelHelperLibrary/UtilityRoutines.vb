Public Module UtilityRoutines
    ''' <summary>
    ''' Determines if Microsoft Excel process is currently in memory.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ExcelInMemory() As Boolean
        Return Process.GetProcesses().Any(Function(p) p.ProcessName.Contains("EXCEL"))
    End Function
    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Sub releaseObject(ByVal obj As Object, ByVal Collect As Boolean)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            If Collect Then
                GC.Collect()
            End If
        End Try
    End Sub
    Public Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        End Try
    End Sub
End Module
