Public Class Form1

    Dim game As Game

    Dim yellow As Pen

    Dim mouseStartPosition As Point
    Dim mouseEndPosition As Point

    Dim lines As List(Of LineDetails)

    ''' <summary>
    ''' Sets up the dgv. Initializes the singleton Game class used throughout the game.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Add(15)
        For c As Integer = 0 To 14
            DataGridView1.Columns(c).Width = TextRenderer.MeasureText("W", DataGridView1.Font).Width
            DataGridView1.Rows(c).Height = DataGridView1.Columns(c).Width
        Next

        DataGridView1.CurrentCell = Nothing
        DataGridView1.ShowCellToolTips = False

        game = New Game

        yellow = New Pen(Color.FromArgb(50, Color.Yellow.R, Color.Yellow.G, Color.Yellow.B), 12)
        yellow.StartCap = Drawing2D.LineCap.Round
        yellow.EndCap = Drawing2D.LineCap.Round
        
    End Sub

    ''' <summary>
    ''' Initiates new game creation, and reloads the dgv and listbox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        Dim frm As New frmProgress(Me, 42, "Creating new game...")
        frm.Show()
        Dim n As NewGame = game.createNew(frm)
        frm.performStep()
        For r As Integer = 0 To 14
            DataGridView1.Rows(r).SetValues(n.letterGrid(r))
            frm.performStep()
        Next
        ListBox1.Items.AddRange(n.wordList)
        frm.performStep()
        lines = New List(Of LineDetails)
        DataGridView1.Refresh()
    End Sub

    ''' <summary>
    ''' Necessary to handle user selections in the dgv.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        DataGridView1.ClearSelection()
    End Sub

    ''' <summary>
    ''' Custom extended DGV event.
    ''' Necessary to avoid user selections in the dgv.
    ''' </summary>
    ''' <param name="p"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_WM_LBUTTONDOWN_AT(ByVal p As System.Drawing.Point) Handles DataGridView1.WM_LBUTTONDOWN_AT
        mouseStartPosition = p
    End Sub

    ''' <summary>
    ''' Used in drawing the rubber band selecting (yellow) line.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            mouseEndPosition = e.Location
            DataGridView1.Refresh()
        End If
    End Sub

    ''' <summary>
    ''' Left Button used in selecting words. Right Button used in removing word highlighting.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim hti1 As DataGridView.HitTestInfo = DataGridView1.HitTest(mouseStartPosition.X, mouseStartPosition.Y)
            Dim hti2 As DataGridView.HitTestInfo = DataGridView1.HitTest(mouseEndPosition.X, mouseEndPosition.Y)
            If hti1.ColumnIndex < 0 OrElse hti1.RowIndex < 0 Then Return
            If hti2.ColumnIndex < 0 OrElse hti2.RowIndex < 0 Then Return
            Dim ld As LineDetails = HighLightUtilities.isValidLine(New Point(hti1.ColumnIndex, hti1.RowIndex), New Point(hti2.ColumnIndex, hti2.RowIndex))
            If ld IsNot Nothing Then
                lines.Add(ld)
                Dim word As String = ld.ToString(DataGridView1)
                Dim i As Integer = ListBox1.FindStringExact(word)
                If i = -1 Then
                    word = StrReverse(word)
                    i = ListBox1.FindStringExact(word)
                End If
                If i > -1 Then
                    ListBox1.Items(i) = ListBox1.Items(i).ToString & " ✔"
                End If
                ld.listIndex = i
            End If
            mouseStartPosition = Nothing
            mouseEndPosition = Nothing
            DataGridView1.Refresh()
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            Dim hti As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)
            Dim ld As LineDetails = lines.FirstOrDefault(Function(d) d.allCells.Contains(New Point(hti.ColumnIndex, hti.RowIndex)))
            If Not ld Is Nothing Then
                Dim response As DialogResult
                If ld.listIndex > -1 Then
                    response = MessageBox.Show("Remove highlight " & Environment.NewLine & "from word '" & _
                                               ListBox1.Items(ld.listIndex).ToString.Split(" "c)(0), "Remove line", _
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If response = Windows.Forms.DialogResult.Yes Then
                        ListBox1.Items(ld.listIndex) = ListBox1.Items(ld.listIndex).ToString.Split(" "c)(0)
                        lines.Remove(ld)
                        DataGridView1.Refresh()
                    End If
                Else
                    response = MessageBox.Show("Remove highlight " & Environment.NewLine & "from word '" & _
                                               ld.ToString(DataGridView1), "Remove line", _
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If response = Windows.Forms.DialogResult.Yes Then
                        lines.Remove(ld)
                        DataGridView1.Refresh()
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Paints all fixed highlighting lines and also the rubber band selecting (yellow) line.
    ''' Paints directly on surface of dgv, rather than cell by cell.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView1.Paint
        If lines Is Nothing Then Return
        For Each ld As LineDetails In lines
            Dim w As Integer = DataGridView1.Columns(0).Width
            Dim o1 As Point = HighLightUtilities.EndCapOffset(New Point(ld.startCell.X, ld.startCell.Y), New Point(ld.endCell.X, ld.endCell.Y))
            Dim o2 As Point = HighLightUtilities.EndCapOffset(New Point(ld.endCell.X, ld.endCell.Y), New Point(ld.startCell.X, ld.startCell.Y))
            Dim p1 As New Point((w * ld.startCell.X) + o1.X, (w * ld.startCell.Y) + o1.Y)
            Dim p2 As New Point((w * ld.endCell.X) + o2.X, (w * ld.endCell.Y) + o2.Y)
            e.Graphics.DrawLine(ld.linePen, p1.X, p1.Y, p2.X, p2.Y)
        Next
        If Not mouseStartPosition = Nothing AndAlso Not mouseEndPosition = Nothing Then
            Dim hti1 As DataGridView.HitTestInfo = DataGridView1.HitTest(mouseStartPosition.X, mouseStartPosition.Y)
            Dim hti2 As DataGridView.HitTestInfo = DataGridView1.HitTest(mouseEndPosition.X, mouseEndPosition.Y)
            Dim o As Point = HighLightUtilities.EndCapOffset(New Point(hti1.ColumnIndex, hti1.RowIndex), New Point(hti2.ColumnIndex, hti2.RowIndex))
            Dim newStartPosition As Point = New Point(hti1.ColumnX + o.X, hti1.RowY + o.Y)
            e.Graphics.DrawLine(yellow, newStartPosition.X, newStartPosition.Y, mouseEndPosition.X, mouseEndPosition.Y)
        End If
    End Sub

    ''' <summary>
    ''' Initiates a print job.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Printer.print(DataGridView1, ListBox1)
    End Sub

End Class
