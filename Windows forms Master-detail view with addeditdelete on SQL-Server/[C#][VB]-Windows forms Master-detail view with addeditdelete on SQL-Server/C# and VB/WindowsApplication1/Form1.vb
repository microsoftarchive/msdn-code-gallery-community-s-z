Imports System.Data.SqlClient
Public Class Form1
    Private ConnectionString As String = "Data Source=KARENS-PC;Initial Catalog=ForumExamples;Integrated Security=True"

    Private Sub TableRowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        If e.Action = DataRowAction.Add Then
            If Not IsDBNull(e.Row.Item("Code")) Then
                Dim ops As New DataOperations
                Dim code As Integer = e.Row.Field(Of Integer)("Code")
                If ops.FindCode(code) Then
                    e.Row.SetField(Of Integer)("id", ops.id)
                    e.Row.SetField(Of String)("Description", ops.Description)
                    e.Row.SetField(Of Integer)("Quantity", ops.Quantity)
                Else
                    e.Row.RejectChanges()
                    MessageBox.Show("Code not found " & code.ToString)
                End If
            Else
                e.Row.RejectChanges()
                MessageBox.Show("No code entered")
            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dt As New DataTable

        dt.Columns.Add(New DataColumn With {.ColumnName = "id", .DataType = GetType(Integer), .ColumnMapping = MappingType.Hidden})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Code", .DataType = GetType(Integer)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Description", .DataType = GetType(String)})
        dt.Columns.Add(New DataColumn With {.ColumnName = "Quantity", .DataType = GetType(Integer)})
        AddHandler dt.RowChanged, AddressOf TableRowChanged

        DataGridView1.DataSource = dt
        DataGridView1.Columns("Description").ReadOnly = True
        DataGridView1.Columns("Quantity").ReadOnly = True

    End Sub
    ''' <summary>
    ''' Triggered when typing into the code column, we get all available codes so the user
    ''' has auto-complete feature
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) _
        Handles DataGridView1.EditingControlShowing

        Dim titleText As String = DataGridView1.Columns(0).HeaderText
        If titleText.Equals("Code") Then
            Dim autoText As TextBox = TryCast(e.Control, TextBox)
            If autoText IsNot Nothing Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                Dim ops As New DataOperations
                autoText.AutoCompleteCustomSource = ops.AvailableCode
            End If
        End If
    End Sub
End Class
Public Class DataOperations
    Private ConnectionString As String = "Data Source=KARENS-PC;Initial Catalog=ForumExamples;Integrated Security=True"
    Public Property id As Integer
    Public Property Code As Integer
    Public Property Description As String
    Public Property Quantity As Integer
    ''' <summary>
    ''' Get record details if row is located by a code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    Public Function FindCode(ByVal sender As Integer) As Boolean
        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SELECT id,Description,Quantity FROM Products WHERE Code = @Code"}
                cmd.Parameters.AddWithValue("@Code", sender)
                cn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    id = reader.GetInt32(0)
                    Code = sender
                    Description = reader.GetString(1)
                    Quantity = reader.GetInt32(2)

                    Return True

                Else
                    Return False
                End If
            End Using
        End Using
    End Function
    ''' <summary>
    ''' Get all available code
    ''' </summary>
    ''' <returns></returns>
    Public Function AvailableCode() As AutoCompleteStringCollection
        Dim DataCollection As New AutoCompleteStringCollection()

        Using cn As New SqlConnection With {.ConnectionString = ConnectionString}
            Using cmd As New SqlCommand With {.Connection = cn, .CommandText = "SELECT Code FROM Products"}

                cn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    While reader.Read
                        DataCollection.Add(reader.GetInt32(0).ToString)
                    End While
                End If
            End Using
        End Using

        Return DataCollection

    End Function
End Class
