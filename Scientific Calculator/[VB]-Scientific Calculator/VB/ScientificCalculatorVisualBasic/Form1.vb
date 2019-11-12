Public Class Form1
    Dim num1 As Decimal
    Dim num2 As Decimal
    Dim operation As String
    Private Sub input(a As String)
        If textBox1.Text = "0" Then
            textBox1.Text = a
        Else
            textBox1.Text += a
        End If
    End Sub

    Private Sub btn_n1_Click(sender As Object, e As EventArgs) Handles btn_n1.Click
        input("1")
    End Sub

    Private Sub btn_n2_Click(sender As Object, e As EventArgs) Handles btn_n2.Click
        input("2")
    End Sub

    Private Sub btn_n3_Click(sender As Object, e As EventArgs) Handles btn_n3.Click
        input("3")
    End Sub

    Private Sub btn_n4_Click(sender As Object, e As EventArgs) Handles btn_n4.Click
        input("4")
    End Sub

    Private Sub btn_n5_Click(sender As Object, e As EventArgs) Handles btn_n5.Click
        input("5")
    End Sub

    Private Sub btn_n6_Click(sender As Object, e As EventArgs) Handles btn_n6.Click
        input("6")
    End Sub

    Private Sub btn_n7_Click(sender As Object, e As EventArgs) Handles btn_n7.Click
        input("7")
    End Sub

    Private Sub btn_n8_Click(sender As Object, e As EventArgs) Handles btn_n8.Click
        input("8")
    End Sub

    Private Sub btn_n9_Click(sender As Object, e As EventArgs) Handles btn_n9.Click
        input("9")
    End Sub

    Private Sub btn_n0_Click(sender As Object, e As EventArgs) Handles btn_n0.Click
        input(".")
    End Sub

    Private Sub btn_O1_Click(sender As Object, e As EventArgs) Handles btn_O1.Click
        num1 = Decimal.Parse(textBox1.Text)
        operation = "/"
        textBox1.Text = "0"
    End Sub

    Private Sub btn_O2_Click(sender As Object, e As EventArgs) Handles btn_O2.Click
        num1 = Decimal.Parse(textBox1.Text)
        operation = "+"
        textBox1.Text = "0"
    End Sub

    Private Sub btn_O3_Click(sender As Object, e As EventArgs) Handles btn_O3.Click
        num1 = Decimal.Parse(textBox1.Text)
        operation = "-"
        textBox1.Text = "0"
    End Sub

    Private Sub btn_O4_Click(sender As Object, e As EventArgs) Handles btn_O4.Click
        num1 = Decimal.Parse(textBox1.Text)
        operation = "*"
        textBox1.Text = "0"
    End Sub

    Private Sub btn_Calculate_Click(sender As Object, e As EventArgs) Handles btn_Calculate.Click
        num2 = Decimal.Parse(textBox1.Text)
        '''/////////////////////////////
        Select Case operation
            Case "+"
                textBox1.Text = (num1 + num2).ToString()
                Exit Select
            Case "-"
                textBox1.Text = (num1 - num2).ToString()
                Exit Select
            Case "*"
                textBox1.Text = (num1 * num2).ToString()
                Exit Select
            Case "/"
                textBox1.Text = (num1 / num2).ToString()
                Exit Select
            Case "^"
                textBox1.Text = (Integer.Parse(num1.ToString()) Xor Integer.Parse(num2.ToString())).ToString()
                Exit Select
            Case "%"
                textBox1.Text = (num1 Mod num2).ToString()
                Exit Select
        End Select
    End Sub

    Private Sub btn_Sin_Click(sender As Object, e As EventArgs) Handles btn_Sin.Click
        textBox1.Text = (Math.Sin(Double.Parse(textBox1.Text))).ToString()
    End Sub

    Private Sub btn_Cos_Click(sender As Object, e As EventArgs) Handles btn_Cos.Click
        textBox1.Text = (Math.Cos(Double.Parse(textBox1.Text))).ToString()
    End Sub

    Private Sub btn_fact_Click(sender As Object, e As EventArgs) Handles btn_fact.Click
        Dim f As Long = 1
        For i As Long = 1 To Long.Parse(textBox1.Text)
            f = f * i
        Next
        textBox1.Text = f.ToString()
    End Sub

    Private Sub btn_log_Click(sender As Object, e As EventArgs) Handles btn_log.Click
        textBox1.Text = (Math.Log(Double.Parse(textBox1.Text))).ToString()
    End Sub

    Private Sub btn_Sqrt_Click(sender As Object, e As EventArgs) Handles btn_Sqrt.Click
        textBox1.Text = (Math.Sqrt(Double.Parse(textBox1.Text))).ToString()
    End Sub

    Private Sub btn_Pow_Click(sender As Object, e As EventArgs) Handles btn_Pow.Click
        num1 = Decimal.Parse(textBox1.Text)
        operation = "^"
        textBox1.Text = "0"
    End Sub

    Private Sub btn_Tan_Click(sender As Object, e As EventArgs) Handles btn_Tan.Click
        textBox1.Text = (Math.Tan(Double.Parse(textBox1.Text))).ToString()
    End Sub

    Private Sub btn_Mod_Click(sender As Object, e As EventArgs) Handles btn_Mod.Click
        num1 = Decimal.Parse(textBox1.Text)
        operation = "%"
        textBox1.Text = "0"
    End Sub
End Class
