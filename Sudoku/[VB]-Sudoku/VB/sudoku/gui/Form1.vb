Public Class Form1

    Private WithEvents game As New Game
    Private r As New Random

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Add(9)
        ComboBox1.SelectedIndex = 0
        btnNew.PerformClick()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        game.NewGame(r)
    End Sub

    Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
        e.Graphics.DrawLine(New Pen(Color.Black, 2), 75, 0, 75, 228)
        e.Graphics.DrawLine(New Pen(Color.Black, 2), 150, 0, 150, 228)
        e.Graphics.DrawLine(New Pen(Color.Black, 2), 0, 66, 228, 66)
        e.Graphics.DrawLine(New Pen(Color.Black, 2), 0, 132, 228, 132)
    End Sub

    Private Sub btnSolution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSolution.Click
        game.showGridSolution()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        btnNew.PerformClick()
    End Sub

    Public Sub game_ShowClues(ByVal grid()() As Integer) Handles game.ShowClues
        For y As Integer = 0 To 8
            Dim cells As New List(Of Integer)(New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9})
            For c As Integer = 1 To 9 - (5 - ComboBox1.SelectedIndex)
                Dim randomNumber As Integer = cells(r.Next(0, cells.Count))
                cells.Remove(randomNumber)
            Next
            For x As Integer = 0 To 8
                If cells.Contains(x + 1) Then
                    DataGridView1.Rows(y).Cells(x).Value = grid(y)(x)
                    DataGridView1.Rows(y).Cells(x).Style.ForeColor = Color.Red
                    DataGridView1.Rows(y).Cells(x).ReadOnly = True
                Else
                    DataGridView1.Rows(y).Cells(x).Value = ""
                    DataGridView1.Rows(y).Cells(x).Style.ForeColor = Color.Black
                    DataGridView1.Rows(y).Cells(x).ReadOnly = False
                End If
            Next
        Next
    End Sub

    Public Sub game_ShowSolution(ByVal grid()() As Integer) Handles game.ShowSolution
        For y As Integer = 0 To 8
            For x As Integer = 0 To 8
                If DataGridView1.Rows(y).Cells(x).Style.ForeColor = Color.Black Then
                    If DataGridView1.Rows(y).Cells(x).Value.ToString = "" Then
                        DataGridView1.Rows(y).Cells(x).Style.ForeColor = Color.Blue
                        DataGridView1.Rows(y).Cells(x).Value = grid(y)(x)
                    Else
                        If grid(y)(x).ToString <> DataGridView1.Rows(y).Cells(x).Value.ToString Then
                            DataGridView1.Rows(y).Cells(x).Style.ForeColor = Color.Blue
                            DataGridView1.Rows(y).Cells(x).Value = grid(y)(x)
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    
End Class
