'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ToolStripTrackBar.vb
'
'--------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Windows.Forms.Design

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
	''' <summary>A TrackBar that can live in a ToolStrip.</summary>
    <System.ComponentModel.DesignerCategory("code"), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip Or
        ToolStripItemDesignerAvailability.StatusStrip)>
    Partial Friend Class ToolStripTrackBar
        Inherits ToolStripControlHost
        ''' <summary>Initializes the ToolStripTrackBar.</summary>
        Public Sub New()
            MyBase.New(CreateControlInstance())
        End Sub

        ''' <summary>Gets the actual TrackBar instance.</summary>
        Public ReadOnly Property TrackBar() As TrackBar
            Get
                Return TryCast(Control, TrackBar)
            End Get
        End Property

        ''' <summary>Create the actual TrackBar control.</summary>
        Private Shared Function CreateControlInstance() As Control
            Dim t As New TrackBar()
            t.AutoSize = False
            t.Height = 16
            t.TickStyle = TickStyle.None
            t.Minimum = 0
            t.Maximum = 100
            t.Value = 0
            Return t
        End Function

        ''' <summary>Gets the current TrackBar value.</summary>
        <DefaultValue(0)>
        Public Property Value() As Integer
            Get
                Return TrackBar.Value
            End Get
            Set(ByVal value As Integer)
                TrackBar.Value = value
            End Set
        End Property

        ''' <summary>Gets the minimum TrackBar value.</summary>
        <DefaultValue(0)>
        Public Property Minimum() As Integer
            Get
                Return TrackBar.Minimum
            End Get
            Set(ByVal value As Integer)
                TrackBar.Minimum = value
            End Set
        End Property

        ''' <summary>Gets the maximum TrackBar value.</summary>
        <DefaultValue(100)>
        Public Property Maximum() As Integer
            Get
                Return TrackBar.Maximum
            End Get
            Set(ByVal value As Integer)
                TrackBar.Maximum = value
            End Set
        End Property

        ''' <summary>Attach to events that need to be wrapped.</summary>
        Protected Overrides Sub OnSubscribeControlEvents(ByVal control As Control)
            MyBase.OnSubscribeControlEvents(control)
            AddHandler (CType(control, TrackBar)).ValueChanged, AddressOf trackBar_ValueChanged
        End Sub

        ''' <summary>Detach from events that were wrapped.</summary>
        Protected Overrides Sub OnUnsubscribeControlEvents(ByVal control As Control)
            MyBase.OnUnsubscribeControlEvents(control)
            RemoveHandler (CType(control, TrackBar)).ValueChanged, AddressOf trackBar_ValueChanged
        End Sub

        ''' <summary>Raise the ValueChanged event.</summary>
        Private Sub trackBar_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent ValueChanged(sender, e)
        End Sub

        ''' <summary>Event used to notify when the TrackBar's value changes.</summary>
        Public Event ValueChanged As EventHandler

        ''' <summary>Gets the default size for the control.</summary>
        Protected Overrides ReadOnly Property DefaultSize() As Size
            Get
                Return New Size(200, 16)
            End Get
        End Property
    End Class
End Namespace