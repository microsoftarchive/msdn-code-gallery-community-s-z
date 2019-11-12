Public Class Form1

    Private lastOperator As String
    Private firstPart As Double

    Private previousLastOperator As String
    Private previousLastPart As Double

    Private Sub btns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn10.Click, btn11.Click
        If Label1.Text.EndsWith("= ") Then
            btnClear.PerformClick()
        End If
        TextBox1.Text &= DirectCast(sender, Button).Text
    End Sub

    Private Sub btnOperator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnOperator1.Click, btnOperator2.Click, btnOperator3.Click, btnOperator4.Click
        Dim nextPart As Double
        Double.TryParse(TextBox1.Text, nextPart)
        If nextPart = 0 Then
            If DirectCast(sender, Button).Text = "-" AndAlso TextBox1.Text = "" Then
                TextBox1.Text &= "-"
            End If
            Return
        End If

        previousLastOperator = lastOperator
        previousLastPart = nextPart

        methods.calculate(TextBox1, firstPart, nextPart, lastOperator)

        If lastOperator <> "" Then
            Label1.Text &= nextPart.ToString
        Else
            Label1.Text &= firstPart.ToString
        End If
        lastOperator = DirectCast(sender, Button).Text
        Label1.Text &= " " & lastOperator & " "
        TextBox1.Text = ""
    End Sub

    Private Sub btnEquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquals.Click
        Dim lastPart As Double
        Double.TryParse(TextBox1.Text, lastPart)
        If lastPart <> 0 Then
            methods.calculate(TextBox1.Text, firstPart, lastPart, lastOperator)
            Label1.Text &= " " & lastPart.ToString & " = "
        Else
            methods.changeText(Label1.Text, " = ")
            TextBox1.Text = firstPart.ToString
        End If
        firstPart = 0
        lastOperator = ""
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        TextBox1.Text = ""
        firstPart = 0
        lastOperator = ""
        Label1.Text = ""
        previousLastOperator = ""
        previousLastPart = 0
    End Sub

    Private Sub btnSquareRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSquareRoot.Click
        Dim nextPart As Double
        Double.TryParse(TextBox1.Text, nextPart)
        If nextPart <> 0 Then

            methods.calculate(TextBox1, firstPart, nextPart, lastOperator)

            If lastOperator <> "" Then
                Label1.Text &= " " & nextPart.ToString & " √ = "
            Else
                Label1.Text &= firstPart.ToString & " √ = "
            End If
        End If
        If nextPart = 0 AndAlso firstPart <> 0 Then
            methods.changeText(Label1.Text, " √ = ")
        End If
        TextBox1.Text = Math.Sqrt(firstPart).ToString
        Double.TryParse(TextBox1.Text, firstPart)
        lastOperator = ""
    End Sub

    Private Sub btnPercentage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPercentage.Click
        Dim lastPart As Double
        If Double.TryParse(TextBox1.Text, lastPart) AndAlso lastPart <> 0 Then
            methods.calculate(TextBox1.Text, firstPart, lastPart, lastOperator, True)
            If lastOperator <> "" Then
                Label1.Text &= " " & lastPart.ToString & " % = "
            End If
            Double.TryParse(TextBox1.Text, firstPart)
            lastOperator = ""
        ElseIf lastPart = 0 AndAlso previousLastOperator <> "" Then
            methods.calculate(firstPart, previousLastPart, previousLastOperator)
            lastPart = previousLastPart
            methods.calculate(TextBox1.Text, firstPart, lastPart, previousLastOperator, True)
            methods.changeText(Label1.Text, " % = ")
            Double.TryParse(TextBox1.Text, firstPart)
            lastOperator = ""
            previousLastOperator = ""
            previousLastPart = 0
        End If
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim ktp = From btn As Button In Me.Controls.OfType(Of Button)() _
                  Where btn.Text.ToLower = Char.ToLower(e.KeyChar) _
                  Select btn

        If ktp.Count > 0 Then ktp.First.PerformClick()
    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim r As New Rectangle(TextBox1.Left - 1, Label1.Top - 1, Label1.Width + 2, Label1.Height + TextBox1.Height + 2)
        ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.SunkenInner)
    End Sub

End Class
