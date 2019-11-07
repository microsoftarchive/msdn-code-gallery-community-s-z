Imports BulkCopyierLibrary1
Imports Microsoft.VisualBasic.FileIO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.SuspendLayout()
        Dim fields() As String

        Using tfp As New TextFieldParser(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "People.csv"))
            tfp.TextFieldType = FieldType.Delimited
            tfp.SetDelimiters(",")

            Do While Not tfp.EndOfData
                fields = tfp.ReadFields()
                DataGridView1.Rows.Add(New Object() {fields(0), fields(1), fields(2), If(String.IsNullOrWhiteSpace(fields(3)), "9/23/1987", fields(3))})
            Loop
        End Using

        DataGridView1.ExpandColumns()
        DataGridView1.ResumeLayout()

    End Sub

    Private Sub exportButton_Click(sender As Object, e As EventArgs) Handles exportButton.Click
        Dim peopleList As List(Of Person) = DataGridView1.Rows.Cast(Of DataGridViewRow)() _
            .Where(Function(row) (Not row.IsNewRow)) _
            .Select(Function(row) New Person With
                {
                    .FirstName = Convert.ToString(row.Cells("FirstNameColumn").Value),
                    .LastName = Convert.ToString(row.Cells("LastNameColumn").Value),
                    .Gender = Convert.ToInt32(row.Cells("GenderColumn").Value),
                    .BirthDay = Convert.ToDateTime(Convert.ToString(row.Cells("BirthdayColumn").Value))
                }
            ).ToList()


        Dim p = New PersonExporter(peopleList, CInt(Fix(numericUpDown1.Value)))

        If p.Execute(truncateCheckBox.Checked) Then
            Dim ops = New DataOperations()
            Dim dt As DataTable = ops.GetPeople()

            Dim f = New frmResults()
            Try
                '                    
                '  * Note: The DataGridView in the following form has no error handling when 
                '  * changing values e.g. if you attempt an invalid date an alert appears, either
                '  * correct the error or press ESC after the error message is closed. I did this
                '  * to allow you to concentrate on the lesson at hand, a MERGE operation
                '                     
                f.dataGridView1.DataSource = dt

                f.dataGridView1.Columns(0).ReadOnly = True

                If f.ShowDialog() = DialogResult.OK Then

                    '                        
                    ' * IMPORTANT: At this point we have over 5,000 rows but if you press the
                    ' * Update button in the child form the MERGE operation will if nothing else
                    ' * leave you with 8 records because we did a TOP 8 in DataOperations.
                    ' * 
                    ' * So you may very well want to change from TOP 8 to a SELECT w/o the TOP n.
                    '                         
                    p.UpdateData(dt)

                    If p.Exception.HasError Then
                        MessageBox.Show($"Encountered issues{Environment.NewLine}{p.Exception.Message}")
                    Else
                        MessageBox.Show("Updates finished!!!")
                    End If
                Else
                    MessageBox.Show("User cancelled updates")
                End If

            Finally
                f.Dispose()
            End Try
        Else
            MessageBox.Show($"{p.Exception.Message}")
        End If
    End Sub
End Class
