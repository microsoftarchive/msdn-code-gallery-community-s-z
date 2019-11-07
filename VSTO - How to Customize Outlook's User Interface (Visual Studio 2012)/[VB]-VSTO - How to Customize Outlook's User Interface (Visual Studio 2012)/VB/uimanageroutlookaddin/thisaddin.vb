' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Microsoft.VisualStudio.Tools.Applications.Runtime
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports System.Collections
Imports System.Collections.Generic
Imports Office = Microsoft.Office
Imports UiManagerOutlookAddIn.AddinUtilities

<CLSCompliant(False)> _
Public Class ThisAddIn

    Private Sub ThisAddIn_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Me.Shutdown
    End Sub

    Friend _taskPaneConnector As TaskPaneConnector
    Friend _ribbonConnector As RibbonConnector
    Private _formRegionConnector As FormRegionConnector
    Private _inspectors As Outlook.Inspectors
    Private _controlProgId As String = "UiManager.SimpleControl"
    Private _controlTitle As String = "SimpleControl"
    Friend _uiElements As UserInterfaceElements

    ' We override RequestService to return a suitable object for each
    ' of the new extensibility interfaces that we implement.
    Protected Overrides Function RequestService( _
    ByVal serviceGuid As Guid) As Object
        If (serviceGuid = GetType(Office.Core.IRibbonExtensibility).GUID) Then
            If (_ribbonConnector Is Nothing) Then
                _ribbonConnector = New RibbonConnector()
            End If
            Return _ribbonConnector
        ElseIf (serviceGuid = GetType(Office.Core.ICustomTaskPaneConsumer).GUID) Then
            If (_taskPaneConnector Is Nothing) Then
                _taskPaneConnector = New TaskPaneConnector()
            End If
            Return _taskPaneConnector
        ElseIf (serviceGuid = GetType(Outlook.FormRegionStartup).GUID) Then
            If (_formRegionConnector Is Nothing) Then
                _formRegionConnector = New FormRegionConnector()
            End If
            Return _formRegionConnector
        End If

        Return MyBase.RequestService(serviceGuid)
    End Function

    Private Sub ThisAddIn_Startup(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles Me.Startup

        System.Windows.Forms.Application.EnableVisualStyles()

        Try
            ' Initialize our UI elements collection, and hook up the 
            ' NewInspector event so that we can add each inspector to 
            ' the collection as it is created.
            _uiElements = New UserInterfaceElements()
            _inspectors = Me.Application.Inspectors
            AddHandler _inspectors.NewInspector, AddressOf inspectors_NewInspector
        Catch ex As COMException
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        End Try

    End Sub

    ' When a new Inspector opens, create a taskpane and attach 
    ' it to this Inspector.
    Sub inspectors_NewInspector(ByVal Inspector As Outlook.Inspector)
        CreateTaskPane(Inspector)
    End Sub


    ' We factor this behavior out to a public method, so that 
    ' it can be called independently of the NewInspector event.
    ' This is to allow for the race condition where ribbon
    ' callbacks can come in before the NewInspector event is
    ' hooked up.
    Public Function CreateTaskPane( _
    ByVal inspector As Outlook.Inspector) As Office.Core.CustomTaskPane

        Dim taskpane As Office.Core.CustomTaskPane = Nothing

        Try
            If (Not _taskPaneConnector._ctpFactory Is Nothing) Then
                ' Create a new task pane, and set its width to match our 
                ' SimpleControl width.
                taskpane = _taskPaneConnector._ctpFactory.CreateCTP( _
                    _controlProgId, _controlTitle, inspector)
                taskpane.Width = 230

                ' Map the task pane to the inspector and cache it 
                ' in our collection.
                _uiElements.Add(New UserInterfaceContainer( _
                    inspector, taskpane, _ribbonConnector))
            End If

        Catch ex As COMException
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        End Try

        Return taskpane

    End Function

End Class
