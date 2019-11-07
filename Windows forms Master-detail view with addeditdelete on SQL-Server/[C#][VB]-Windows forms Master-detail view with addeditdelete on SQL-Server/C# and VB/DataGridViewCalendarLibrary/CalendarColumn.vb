Imports System.Windows.Forms
''' <summary>
''' Provides a DataGridView column which presents date fields in a drop down
''' Calendar control. Editing capabilities are in the class CalendarEditingControl
''' within this class module.
''' </summary>
''' <remarks>
''' 
''' Originally from MSDN
''' http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
''' 
''' Kevininstructor modified by adding the ability to alter the format via 
''' CalendarColumn.DateFormat
''' </remarks>
Public Class CalendarColumn
    Inherits DataGridViewColumn
    Private mFormat As String = ""

    <System.ComponentModel.Category("Behavior"),
    System.ComponentModel.Description("Date time format"),
    System.ComponentModel.DefaultValue(GetType(String), "d")>
    Public Property DateFormat() As String
        Get
            Return mFormat
        End Get
        Set(ByVal value As String)
            mFormat = value
        End Set
    End Property
    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' kevininstructor
    ''' This is needed to persist our custom property DateFormat
    ''' </remarks>
    Public Overrides Function Clone() As Object
        Dim TheCopy As CalendarColumn = DirectCast(MyBase.Clone(), CalendarColumn)
        TheCopy.DateFormat = Me.DateFormat
        Return TheCopy
    End Function
    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub
    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)
            ' Ensure that the cell used for the template is a CalendarCell.
            If Not (value Is Nothing) AndAlso Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class
Public Class CalendarCell
    Inherits DataGridViewTextBoxCell
    Public Sub New()
    End Sub
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

        Dim TheControl As CalendarEditingControl = CType(DataGridView.EditingControl, CalendarEditingControl)
        If Not Me.Value.GetType Is GetType(DateTime) Then
            Me.Value = Now
        End If

        TheControl.Value = CType(Me.Value, DateTime)
        Dim MyOwner As CalendarColumn = CType(OwningColumn, CalendarColumn)
        Me.Style.Format = MyOwner.DateFormat
        TheControl.Format = DateTimePickerFormat.Custom
        TheControl.CustomFormat = MyOwner.DateFormat
    End Sub
    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property
    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property
    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Kevininstructor changed from  "Use the current date and time as the default value" to DbNullValue
            Return DBNull.Value
        End Get
    End Property
End Class
''' <summary>
''' Provides Calendar popup within the GridView.
''' </summary>
''' <remarks></remarks>
Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNumber As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Custom
    End Sub
    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToString(Me.CustomFormat)
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is [String] Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set
    End Property
    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Value.ToString(Me.CustomFormat)
    End Function
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Font = dataGridViewCellStyle.Font
        CalendarForeColor = dataGridViewCellStyle.ForeColor
        CalendarMonthBackground = dataGridViewCellStyle.BackColor
    End Sub
    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNumber
        End Get
        Set(ByVal value As Integer)
            rowIndexNumber = value
        End Set
    End Property
    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ' No preparation needs to be done.
    End Sub
    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property
    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property
    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property
    Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property
    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub
End Class
