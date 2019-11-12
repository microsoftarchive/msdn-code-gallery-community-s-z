' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports UiManagerOutlookAddIn.AddinUtilities


<ComVisible(True)> _
<ProgId("UiManager.SimpleControl")> _
<Guid("E2F1F0E8-254A-4ddc-A500-273D6EFB172B")> _
Partial Public Class SimpleControl
    Inherits UserControl

    Public Sub New()
        InitializeComponent()
    End Sub

    Private _mailServiceGroup As String = "mailServiceGroup"

    Private Sub closeCoffeeList_Click(ByVal sender As Object, ByVal e As EventArgs) _
     Handles _closeCoffeeList.Click
        ' Clear and hide the listbox.
        Me._coffeeList.Items.Clear()
        Me._coffeeGroup.Visible = False

        ' Make the add-in service ribbon buttons invisible again.
        Dim uiContainer As UserInterfaceContainer
        uiContainer = _
            Globals.ThisAddIn._uiElements.GetUIContainerForUserControl(Me)
        uiContainer.HideRibbonControl(_mailServiceGroup)
    End Sub

End Class


