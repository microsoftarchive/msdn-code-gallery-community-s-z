' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office
Imports System.Globalization
Imports UiManagerOutlookAddIn.AddinUtilities


<ComVisible(True)> _
<Guid("66299133-E2CC-46c1-8C47-B73DA7203067")> _
<ProgId("UiManager.RibbonConnector")> _
Public Class RibbonConnector
    Implements Office.Core.IRibbonExtensibility, IRibbonConnector

    Public Sub New()
    End Sub

    ' This method is not CLSCompliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Sub OnLoad(ByVal ribbonUI As Office.Core.IRibbonUI)
        Me._ribbon = ribbonUI
    End Sub

    Public Function GetCustomUI(ByVal RibbonID As String) As String _
    Implements Office.Core.IRibbonExtensibility.GetCustomUI
        Dim xml As String = Nothing

        ' We have two different ribbon customizations: one for Task
        ' inspectors, and one for all other inspectors.
        Select Case (RibbonID)
            Case _taskItemName
                xml = My.Resources.TaskRibbon
            Case Else
                xml = My.Resources.SimpleRibbon
        End Select

        Return xml
    End Function


    ' Our ribbon XML specifies that the addinServiceButtons group, which
    ' contains the sendList controls, is conditionally visible. This 
    ' method is not CLSCompliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Function GetVisible(ByVal control As Office.Core.IRibbonControl) As Boolean
        If (control Is Nothing) Then
            Return False
        End If

        ' Match up this control instance (determined by its inspector) in
        ' the collection, and return the current value of the cached 
        ' visibility state.
        Dim inspector As Outlook.Inspector
        inspector = CType(control.Context, Outlook.Inspector)
        Dim uiContainer As UserInterfaceContainer
        uiContainer = _
            Globals.ThisAddIn._uiElements.GetUIContainerForInspector(inspector)
        Return uiContainer.IsControlVisible

    End Function

    Private _ribbon As Office.Core.IRibbonUI

    <CLSCompliant(False)> _
    Public Property Ribbon() As Office.Core.IRibbonUI _
    Implements IRibbonConnector.Ribbon
        Get
            Return _ribbon
        End Get
        Set(ByVal value As Office.Core.IRibbonUI)
            _ribbon = value
        End Set
    End Property

    Private _taskItemName As String = "Microsoft.Outlook.Task"
    Private _customerName As String = "someone@example.com"
    Private _orderName As String = "Coffee"
    Private _ordersTextBoxName As String = "ordersTextBox"
    Private _orderCount As Integer

    ' This method is not CLSCompliant because of its input parameter.
    <CLSCompliant(False)> _
    Public Sub OnToggleTaskPane( _
    ByVal control As Office.Core.IRibbonControl, ByVal isPressed As Boolean)
        ' Toggle the visibility of the custom taskpane.
        If (Not control Is Nothing) Then

            ' Find the inspector for this ribbon, so that we can find the 
            ' corresponding task pane from our collection.
            Dim inspector As Outlook.Inspector
            inspector = CType(control.Context, Outlook.Inspector)
            Dim taskpane As Office.Core.CustomTaskPane
            taskpane = _
                Globals.ThisAddIn._uiElements.GetTaskPaneForInspector( _
                    inspector)

            ' If we've been called before we've had a chance to add this 
            ' Inspector/task pane to the collection, we can add it now.
            If (taskpane Is Nothing) Then
                taskpane = Globals.ThisAddIn.CreateTaskPane(inspector)
            End If
            taskpane.Visible = isPressed
        End If

    End Sub

    Private Function GetTextFromTaskPane(ByVal inspector As Outlook.Inspector) As String
        Dim coffeeText As String = Nothing

        If (Not inspector Is Nothing) Then

            ' Get the usercontrol in the task pane.
            Dim taskpane As Office.Core.CustomTaskPane
            taskpane = _
            Globals.ThisAddIn._uiElements.GetTaskPaneForInspector(inspector)
            Dim sc As SimpleControl
            sc = CType(taskpane.ContentControl, SimpleControl)

            ' Compose the mail body from the strings in the task pane listbox.
            Dim builder As New StringBuilder()
            For Each s As String In sc._coffeeList.Items
                builder.AppendLine(s)
            Next
            coffeeText = builder.ToString()

        End If

        Return coffeeText
    End Function

    ' This method is not CLSCompliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Sub OnSendList(ByVal control As Office.Core.IRibbonControl)

        If (Not control Is Nothing) Then
            Try
                Dim inspector As Outlook.Inspector
                inspector = CType(control.Context, Outlook.Inspector)
                Dim coffeeText As String
                coffeeText = GetTextFromTaskPane(inspector)

                ' Create a new email from the input parameters, and send it.
                Dim mi As Outlook._MailItem
                mi = CType(Globals.ThisAddIn.Application.CreateItem( _
                    Outlook.OlItemType.olMailItem), Outlook._MailItem)
                mi.Subject = _orderName
                mi.Body = coffeeText
                mi.To = _customerName
                mi.Send()

                ' Update the count of orders in the form region.
                Dim uiContainer As UserInterfaceContainer
                uiContainer = _
                    Globals.ThisAddIn._uiElements.GetUIContainerForInspector( _
                    inspector)
                Dim cultureInfo As CultureInfo
                cultureInfo = New CultureInfo("en-us")
                _orderCount = _orderCount + 1
                uiContainer.FormRegionControls.SetControlText( _
                    _ordersTextBoxName, _orderCount.ToString(cultureInfo))
            Catch ex As COMException
                System.Diagnostics.Debug.WriteLine(ex.ToString())
            End Try
        End If
    End Sub

End Class


