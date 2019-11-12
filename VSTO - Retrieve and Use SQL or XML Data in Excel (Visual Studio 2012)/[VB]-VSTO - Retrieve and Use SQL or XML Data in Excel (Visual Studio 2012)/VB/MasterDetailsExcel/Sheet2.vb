' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Public Class Sheet2

    Private Sub Sheet2_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        Debug.Assert(Globals.ThisWorkbook.currentCompanyData IsNot Nothing)
        Me.StatusValuesList.SetDataBinding( _
            Globals.ThisWorkbook.currentCompanyData, "Status", "Status")
    End Sub

    Private Sub Sheet2_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End Class
