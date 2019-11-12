Imports System
Imports System.Windows.Forms

Namespace UserControls
    Public Class TimeColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New()
            MyBase.CellTemplate = New CalendarCell1()
        End Sub

        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)
                If Not ((value Is Nothing)) AndAlso Not (value.GetType().IsAssignableFrom(GetType(CalendarCell1))) Then
                    Throw New InvalidCastException("Must be a CalendarCell")
                End If
                MyBase.CellTemplate = value
            End Set
        End Property
    End Class
    Public Class CalendarCell1
        Inherits DataGridViewTextBoxCell

        Public Sub New()
            Me.Style.Format = "hh:mm tt"
        End Sub
        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

            Dim ctl As CalendarEditingControl1 = CType(DataGridView.EditingControl, CalendarEditingControl1)
            If Me.RowIndex >= 0 Then
                If ((Not Object.ReferenceEquals(Me.Value, DBNull.Value))) Then
                    If Me.Value IsNot Nothing Then
                        If Me.Value IsNot String.Empty Then
                            Try
                                ctl.Value = Date.Parse(Me.Value.ToString())
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
            End If
        End Sub
        Public Overrides ReadOnly Property EditType() As System.Type
            Get
                Return GetType(CalendarEditingControl1)
            End Get
        End Property
        Public Overrides ReadOnly Property ValueType() As System.Type
            Get
                Return GetType(Date)
            End Get
        End Property
        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                Return Date.Now.ToShortTimeString()
            End Get
        End Property
    End Class
    Friend Class CalendarEditingControl1
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub New()
            Me.Format = DateTimePickerFormat.Time
        End Sub
        Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
            Get
                Return Me.Value.ToShortTimeString()
            End Get
            Set(ByVal value As Object)
                If TypeOf value Is String Then
                    Me.Value = Date.Parse(System.Convert.ToString(value))
                End If
            End Set
        End Property
        Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
            Return Me.Value.ToShortTimeString()
        End Function
        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
            Me.Font = dataGridViewCellStyle.Font
            Me.ShowUpDown = True
            Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
            Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
        End Sub

        Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set
        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
            If Keys.KeyCode = Keys.Left OrElse Keys.KeyCode = Keys.Up OrElse Keys.KeyCode = Keys.Down OrElse Keys.KeyCode = Keys.Right OrElse Keys.KeyCode = Keys.Home OrElse Keys.KeyCode = Keys.End OrElse Keys.KeyCode = Keys.PageDown OrElse Keys.KeyCode = Keys.PageUp Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
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

        Public ReadOnly Property EditingControlCursor() As Cursor
            Get
                Return MyBase.Cursor
            End Get
        End Property

        Protected Overrides Sub OnValueChanged(ByVal eventargs As System.EventArgs)
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(eventargs)
        End Sub
        Private ReadOnly Property IDataGridViewEditingControl_EditingPanelCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
            Get 'throw new Exception("The method or operation is not implemented."); }
                Return MyBase.Cursor
            End Get
        End Property
    End Class
End Namespace