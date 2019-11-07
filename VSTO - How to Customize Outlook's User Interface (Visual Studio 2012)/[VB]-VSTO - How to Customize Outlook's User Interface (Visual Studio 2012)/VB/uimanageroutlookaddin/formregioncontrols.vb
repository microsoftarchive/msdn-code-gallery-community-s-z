' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office
Imports Microsoft.Vbe.Interop.Forms
Imports UiManagerOutlookAddIn.AddinUtilities


' The FormRegionControls class wraps the references to the controls on the
' custom form region. We'll instantiate a fresh instance of this class for
' each custom form region that gets opened. This way, we ensure that any
' UI response is specific to this instance (eg, when the user clicks our
' commandbutton, we can fetch the textbox text for this same instance.
Public Class FormRegionControls
    Implements IFormRegionControls

    Private _form As UserForm
    Private _inspector As Outlook.Inspector
    Private _coffeeList As Outlook.OlkListBox
    Private _ordersText As Microsoft.Vbe.Interop.Forms.TextBox
    Private _listItems() As String = { _
            "Colombia Supremo", "Ethiopia Longberry Harrar", _
            "Sumatra Mandehling", "Mocha Java", "Jamaica Blue Mountain", _
            "Costa Rica Tarrazu", "Monsooned Malabar"}
    Private _formRegionListBoxName As String = "coffeeListBox"
    Private _ordersTextBoxName As String = "ordersTextBox"
    Private _mailServiceGroup As String = "mailServiceGroup"

    <CLSCompliant(False)> _
    Public Property Inspector() As Outlook.Inspector _
    Implements IFormRegionControls.Inspector
        Get
            Return _inspector
        End Get
        Set(ByVal value As Outlook.Inspector)
            _inspector = value
        End Set
    End Property

    ' This method is not CLSCompliant because of its input parameter.
    <CLSCompliant(False)> _
    Public Sub New(ByVal region As Outlook.FormRegion)
        If (Not region Is Nothing) Then
            Try
                ' Cache a reference to this region, this region's 
                ' inspector, and the controls on this region.
                _inspector = region.Inspector
                _form = CType(region.Form, UserForm)
                _ordersText = CType(_form.Controls.Item(_ordersTextBoxName),  _
                    Microsoft.Vbe.Interop.Forms.TextBox)
                _coffeeList = CType(_form.Controls.Item(_formRegionListBoxName),  _
                        Outlook.OlkListBox)

                ' Fill the listbox with some arbitrary strings.
                For i As Integer = 0 To _listItems.Length - 1
                    _coffeeList.AddItem(_listItems(i), i)
                Next

                AddHandler _coffeeList.Change, _
                AddressOf _coffeeList_Change

            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine(ex.ToString())
            End Try
        End If
    End Sub


    ' The user has changed the selection in the listbox in the custom 
    ' form region.
    Private Sub _coffeeList_Change()
        Dim uiContainer As UserInterfaceContainer
        uiContainer = _
            Globals.ThisAddIn._uiElements.GetUIContainerForInspector( _
            _inspector)

        ' Make the add-in service ribbon buttons visible.
        uiContainer.ShowRibbonControl(_mailServiceGroup)

        ' Get the usercontrol in the task pane, and copy the text of the 
        ' item selected in the form region's listbox into the taskpane's
        ' listbox.
        Dim sc As SimpleControl
        sc = CType(uiContainer.TaskPane.ContentControl, SimpleControl)
        sc._coffeeGroup.Visible = True
        sc._coffeeList.Items.Add(_coffeeList.Text)
    End Sub

    ' Set the text value of the orders TextBox in the form region.
    Public Sub SetControlText( _
    ByVal controlName As String, ByVal text As String) _
    Implements IFormRegionControls.SetControlText
        Select Case (controlName)
            Case _ordersTextBoxName
                _ordersText.Text = text
        End Select
    End Sub

End Class




