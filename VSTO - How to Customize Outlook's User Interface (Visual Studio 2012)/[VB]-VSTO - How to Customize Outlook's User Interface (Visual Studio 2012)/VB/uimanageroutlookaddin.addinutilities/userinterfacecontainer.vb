' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office


Public Class UserInterfaceContainer

    Private WithEvents _inspectorEvents As Outlook.InspectorEvents_10_Event

    Private _inspector As Outlook.Inspector

    <CLSCompliant(False)> _
    Public Property Inspector() As Outlook.Inspector
        Get
            Return _inspector
        End Get

        Set(ByVal value As Outlook.Inspector)
            _inspector = value
        End Set
    End Property

    Private _taskPane As Office.Core.CustomTaskPane

    <CLSCompliant(False)> _
    Public Property TaskPane() As Office.Core.CustomTaskPane
        Get
            Return _taskPane
        End Get
        Set(ByVal value As Office.Core.CustomTaskPane)
            _taskPane = value
        End Set
    End Property

    Private _formRegionControls As IFormRegionControls

    <CLSCompliant(False)> _
    Public Property FormRegionControls() As IFormRegionControls
        Get
            Return _formRegionControls
        End Get
        Set(ByVal value As IFormRegionControls)
            _formRegionControls = value
        End Set
    End Property

    Private _ribbonConnector As IRibbonConnector

    <CLSCompliant(False)> _
    Public Property RibbonConnector() As IRibbonConnector
        Get
            Return _ribbonConnector
        End Get
        Set(ByVal value As IRibbonConnector)
            _ribbonConnector = value
        End Set
    End Property

    Private _isControlVisible As Boolean
    Public Property IsControlVisible() As Boolean
        Get
            Return _isControlVisible
        End Get
        Set(ByVal value As Boolean)
            _isControlVisible = value
        End Set
    End Property

    Public Sub ShowRibbonControl(ByVal ribbonControlId As String)
        _isControlVisible = True
        _ribbonConnector.Ribbon.InvalidateControl(ribbonControlId)
    End Sub

    Public Sub HideRibbonControl(ByVal ribbonControlId As String)
        _isControlVisible = False
        _ribbonConnector.Ribbon.InvalidateControl(ribbonControlId)
    End Sub

    ' This method is not CLS compliant because of its Office parameters.
    <CLSCompliant(False)> _
    Public Sub New( _
    ByVal inspector As Outlook.Inspector, _
    ByVal taskPane As Office.Core.CustomTaskPane, _
    ByVal ribbonConnector As IRibbonConnector)

        If (Not inspector Is Nothing) Then
            _inspector = inspector
            _taskPane = taskPane
            _ribbonConnector = ribbonConnector

            ' Sink the InspectorClose event so that we can clean up.
            _inspectorEvents = CType(_inspector, Outlook.InspectorEvents_10_Event)
        End If
    End Sub

    Public Event InspectorClose As EventHandler

    <CLSCompliant(False)> _
    Public Sub inspectorEvents_Close() Handles _inspectorEvents.Close

        ' Remove ourselves from the collection of UI objects, 
        ' and clean up all references.
        RaiseEvent InspectorClose(Me, New EventArgs())

        _inspector = Nothing
        _inspectorEvents = Nothing
        _taskPane = Nothing
        _formRegionControls = Nothing
        _ribbonConnector = Nothing
    End Sub

End Class
