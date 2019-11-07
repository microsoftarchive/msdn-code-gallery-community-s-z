' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Office = Microsoft.Office
Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class UserInterfaceElements

    Private _items As List(Of UserInterfaceContainer)

    Public Sub New()
        _items = New List(Of UserInterfaceContainer)
    End Sub

    Public Sub Add(ByVal uiContainer As UserInterfaceContainer)
        _items.Add(uiContainer)
        AddHandler uiContainer.InspectorClose, AddressOf uiContainer_InspectorClose
    End Sub

    ' When the inspector is closed, so is the form region, so we need 
    ' to remove this instance from our collection.
    Public Sub uiContainer_InspectorClose(ByVal sender As Object, ByVal e As EventArgs)
        _items.Remove(sender)
    End Sub

    Public Function Remove(ByVal uiContainer As UserInterfaceContainer) As Boolean
        Return _items.Remove(uiContainer)
    End Function

    ' Update the UI container object in our collection indicated by the
    ' given inspector, by attaching the given FormRegionControls object.
    ' This method is not CLS compliant because of its Office parameters.
    <CLSCompliant(False)> _
    Public Function AttachFormRegion( _
    ByVal inspector As Outlook.Inspector, _
    ByVal formRegionControls As IFormRegionControls) As Boolean
        Dim updateOK As Boolean
        updateOK = False

        ' Find this inspector in the our collection of containers.
        Dim uiContainer As UserInterfaceContainer
        uiContainer = GetUIContainerForInspector(inspector)
        If (Not uiContainer Is Nothing) Then
            uiContainer.FormRegionControls = formRegionControls
            updateOK = True
        End If

        Return updateOK
    End Function

    ' Given an inspector, find the matching UI container object.
    ' This method is not CLS compliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Function GetUIContainerForInspector( _
    ByVal inspector As Outlook.Inspector) As UserInterfaceContainer
        Dim uiContainer As UserInterfaceContainer
        uiContainer = Nothing

        For Each uic As UserInterfaceContainer In _items
            If (uic.Inspector Is inspector) Then
                uiContainer = uic
                Exit For
            End If
        Next

        Return uiContainer
    End Function

    ' Given an inspector, return the matching task pane.
    ' This method is not CLS compliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Function GetTaskPaneForInspector( _
    ByVal inspector As Outlook.Inspector) As Office.Core.CustomTaskPane

        Dim taskpane As Office.Core.CustomTaskPane = Nothing

        For Each uic As UserInterfaceContainer In _items
            If (uic.Inspector Is inspector) Then
                taskpane = uic.TaskPane
                Exit For
            End If
        Next

        Return taskpane
    End Function

    ' Given an inspector, return the matching ribbon.
    ' This method is not CLS compliant because of its Office parameter.
    <CLSCompliant(False)> _
    Public Function GetRibbonForInspector( _
    ByVal inspector As Outlook.Inspector) As IRibbonConnector
        Dim ribbonConnector As IRibbonConnector
        ribbonConnector = Nothing

        For Each uic As UserInterfaceContainer In _items
            If (uic.Inspector Is inspector) Then
                ribbonConnector = uic.RibbonConnector
                Exit For
            End If
        Next

        Return ribbonConnector
    End Function

    ' Given a UserControl, return the matching ribbon.
    ' This method is not CLS compliant because of its return type.
    <CLSCompliant(False)> _
    Public Function GetRibbonForUserControl( _
    ByVal userControl As UserControl) As IRibbonConnector
        Dim ribbonConnector As IRibbonConnector
        ribbonConnector = Nothing

        For Each uic As UserInterfaceContainer In _items
            If (uic.TaskPane.ContentControl Is userControl) Then
                ribbonConnector = uic.RibbonConnector
                Exit For
            End If
        Next

        Return ribbonConnector
    End Function

    ' Given a UserControl, return the matching UI container object.
    Public Function GetUIContainerForUserControl( _
    ByVal userControl As UserControl) As UserInterfaceContainer

        Dim uiContainer As UserInterfaceContainer
        uiContainer = Nothing

        For Each uic As UserInterfaceContainer In _items
            If (uic.TaskPane.ContentControl Is userControl) Then
                uiContainer = uic
                Exit For
            End If
        Next

        Return uiContainer
    End Function

End Class
