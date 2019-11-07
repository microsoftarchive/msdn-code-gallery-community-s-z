Option Strict On
Public Class Form1
    Const Convert As Double = Math.PI / 180
    Dim pnlInput As New Panel
    Dim WithEvents btnSolve As New Button
    Dim WithEvents btnReset As New Button
    Dim txtbxInput(6) As TextBox
    Dim lblInput(8) As Label
    Dim Side_a, Side_b, Side_c As Double
    Dim Angle_A, Angle_B, Angle_C As Double
    Dim x0, y0, x1, y1, x2, y2, x3, y3, x4, y4, x5, y5 As Single
    Dim a_side, b_side As Double
    Dim factor As Double
    Dim Area As Single
    Dim DrawFlag As Boolean
    Dim NaNFlag As Boolean = False
    Dim TrianglePoints(2) As Point
    Dim LabelFonts As New Font("Arial", 8)
    Dim LgeFont As New Font("Arial", 18, FontStyle.Underline)
    Dim LinePen As Pen = New Pen(Color.Black, 5)
    Dim lblInputText() As String = {"Side Values (Units)", "Side a", "Side b", "Side c",
                                    "Angle (Degrees)", "Angle A", "Angle B", "Angle C"}
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim X, Y As Integer
        Me.Size = New Size(700, 490)
        Me.CenterToScreen()
        Me.Controls.Add(pnlInput)
        With pnlInput
            .Size = New Size(260, 175)
            .Location = New Point(400, 10)
            .BackColor = Color.Beige
            .BorderStyle = BorderStyle.Fixed3D
        End With
        X = 5 : Y = 5
        For I As Integer = 1 To 8
            lblInput(I) = New Label
            With lblInput(I)
                .Parent = pnlInput
                .AutoSize = True
                .BorderStyle = BorderStyle.None
                .Font = New Font("Arial", 9)
                .Text = lblInputText(I - 1)
                .Location = New Point(X, Y)
            End With
            Y += 35
            If Y > 130 Then
                Y = 5
                X = 120
            End If
        Next
        X = 50 : Y = 40
        For I As Integer = 1 To 6
            txtbxInput(I) = New TextBox
            With txtbxInput(I)
                .Parent = pnlInput
                .Font = New Font("Arial", 9)
                .Location = New Point(X, Y)
                .BackColor = Color.Aqua
                .MaximumSize = New Size(65, 20)
            End With
            Y += 35
            If Y > 140 Then
                Y = 40
                X = 180
            End If
        Next
        pnlInput.Controls.Add(btnSolve)
        With btnSolve
            .Text = "Solve Triangle"
            .AutoSize = True
            .Location = New Point(25, 135)
            .Font = New Font("Arial", 9)
        End With
        pnlInput.Controls.Add(btnReset)
        With btnReset
            .Text = "Reset Variables"
            .AutoSize = True
            .Location = New Point(140, 135)
            .Font = New Font("Arial", 9)
        End With
    End Sub
    Sub btnSolveClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSolve.Click
        Dim parseFlag As Boolean = True
        Dim Value As Double
        For I As Integer = 1 To 6
            If Double.TryParse(txtbxInput(I).Text, Value) = False Then
                txtbxInput(I).Text = "0"
            End If
            If Value < 0 Then
                parseFlag = False
                txtbxInput(I).BackColor = Color.Orange
            End If
        Next
        If parseFlag = False Then
            MsgBox("Value must be 0 or greater!")
            For i = 1 To 6
                txtbxInput(i).BackColor = Color.Aqua
            Next
        Else
            Side_a = CDbl(txtbxInput(1).Text)
            Side_b = CDbl(txtbxInput(2).Text)
            Side_c = CDbl(txtbxInput(3).Text)
            Angle_A = CDbl(txtbxInput(4).Text)
            Angle_B = CDbl(txtbxInput(5).Text)
            Angle_C = CDbl(txtbxInput(6).Text)

            AssignSolver()
        End If
    End Sub
    Sub AssignSolver()
        Dim count As Integer
        'Combinations to look for
        'less than 3 variables
        For I As Integer = 1 To 6
            If txtbxInput(I).Text = Nothing Or txtbxInput(I).Text = "0" Then
                count += 1
            End If
        Next
        If count > 3 Then
            MsgBox("Must be at least 3 known variables")
            Exit Sub
        End If
        'ABC (3 angles) only = invalid input
        If Angle_A <> 0 And Angle_B <> 0 And Angle_C <> 0 _
            And Side_a = 0 And Side_b = 0 And Side_c = 0 Then
            MsgBox("Invalid Input" & vbCrLf & "Must include At Least One Side")
        ElseIf Side_a <> 0 And Side_b <> 0 And Side_c <> 0 Then
            'abc  = 3 sides
            If Side_a > Side_b + Side_c _
                Or Side_b > Side_a + Side_c _
                Or Side_c > Side_a + Side_b Then
                MsgBox("Invalid Side dimensions!" & _
                       vbCrLf & "One side cannot be longer" & _
                       vbCrLf & "than the sum of the other two sides!")
                btnReset.PerformClick()
                Exit Sub
            Else
                Angle_A = CosRule1(Side_a, Side_b, Side_c)
                Angle_B = CosRule1(Side_b, Side_a, Side_c)
                Angle_C = CosRule1(Side_c, Side_a, Side_b)
        End If
        ElseIf Side_a <> 0 And Side_b <> 0 And Angle_A <> 0 Then
            'abA  = 2 sides and angle A
            Angle_B = SinRule1(Side_a, Side_b, Angle_A)
            Angle_C = 180 - Angle_A - Angle_B
            Side_c = SinRule2(Side_a, Angle_A, Angle_C)
        ElseIf Side_a <> 0 And Side_b <> 0 And Angle_B <> 0 Then
            'abB  = 2 sides and angle B
            Angle_A = SinRule1(Side_b, Side_a, Angle_B)
            Angle_C = 180 - Angle_A - Angle_B
            Side_c = SinRule2(Side_a, Angle_A, Angle_C)
        ElseIf Side_a <> 0 And Side_b <> 0 And Angle_C <> 0 Then
            'abC  = 2 sides and angle C
            Side_c = CosRule2(Side_a, Side_b, Angle_C)
            Angle_A = SinRule1(Side_c, Side_a, Angle_C)
            Angle_B = 180 - Angle_A - Angle_C
        ElseIf Side_a <> 0 And Side_c <> 0 And Angle_A <> 0 Then
            'acA  = 2 sides and angle A
            Angle_C = SinRule1(Side_a, Side_c, Angle_A)
            Angle_B = 180 - Angle_A - Angle_C
            Side_b = SinRule2(Side_a, Angle_A, Angle_B)
        ElseIf Side_a <> 0 And Side_c <> 0 And Angle_B <> 0 Then
            'acB  = 2 sides and angle B
            Side_b = CosRule2(Side_a, Side_c, Angle_B)
            Angle_C = SinRule1(Side_b, Side_c, Angle_B)
            Angle_A = 180 - Angle_B - Angle_C
        ElseIf Side_a <> 0 And Side_c <> 0 And Angle_C <> 0 Then
            'acC  = 2 sides and angle C
            Angle_A = SinRule1(Side_c, Side_a, Angle_C)
            Angle_B = 180 - Angle_A - Angle_C
            Side_b = SinRule2(Side_a, Angle_A, Angle_B)
        ElseIf Side_b <> 0 And Side_c <> 0 And Angle_A <> 0 Then
            'bcA  = 2 sides and angle A
            Side_a = CosRule2(Side_b, Side_c, Angle_A)
            Angle_B = SinRule1(Side_a, Side_b, Angle_A)
            Angle_C = 180 - Angle_A - Angle_B
        ElseIf Side_b <> 0 And Side_c <> 0 And Angle_B <> 0 Then
            'bcB  = 2 sides and angle B
            Angle_C = SinRule1(Side_b, Side_c, Angle_B)
            Angle_A = 180 - Angle_B - Angle_C
            Side_a = SinRule2(Side_c, Angle_C, Angle_A)
        ElseIf Side_b <> 0 And Side_c <> 0 And Angle_C <> 0 Then
            'bcC  = 2 sides and angle C
            Angle_B = SinRule1(Side_c, Side_b, Angle_C)
            Angle_A = 180 - Angle_B - Angle_C
            Side_a = SinRule2(Side_c, Angle_C, Angle_A)
        ElseIf Angle_A <> 0 And Angle_B <> 0 And Side_a <> 0 Then
            'ABa  = 2 angles and side a
            Angle_C = 180 - Angle_A - Angle_B
            Side_b = SinRule2(Side_a, Angle_A, Angle_B)
            Side_c = SinRule2(Side_b, Angle_B, Angle_C)
        ElseIf Angle_A <> 0 And Angle_B <> 0 And Side_b <> 0 Then
            'ABb  = 2 angles and side b
            Angle_C = 180 - Angle_A - Angle_B
            Side_c = SinRule2(Side_b, Angle_B, Angle_C)
            Side_a = SinRule2(Side_b, Angle_B, Angle_A)
        ElseIf Angle_A <> 0 And Angle_B <> 0 And Side_c <> 0 Then
            'ABc  = 2 angles and side c
            Angle_C = 180 - Angle_A - Angle_B
            Side_a = SinRule2(Side_c, Angle_C, Angle_A)
            Side_b = SinRule2(Side_c, Angle_C, Angle_B)
        ElseIf Angle_A <> 0 And Angle_C <> 0 And Side_a <> 0 Then
            'ACa  = 2 angles and side a
            Angle_B = 180 - Angle_A - Angle_C
            Side_b = SinRule2(Side_a, Angle_A, Angle_B)
            Side_c = SinRule2(Side_a, Angle_A, Angle_C)
        ElseIf Angle_A <> 0 And Angle_C <> 0 And Side_b <> 0 Then
            'ACb  = 2 angles and side b
            Angle_B = 180 - Angle_A - Angle_C
            Side_c = SinRule2(Side_b, Angle_B, Angle_C)
            Side_a = SinRule2(Side_c, Angle_C, Angle_A)
        ElseIf Angle_A <> 0 And Angle_C <> 0 And Side_c <> 0 Then
            'ACc  = 2 angles and side c
            Angle_B = 180 - Angle_A - Angle_C
            Side_a = SinRule2(Side_c, Angle_C, Angle_A)
            Side_b = SinRule2(Side_c, Angle_C, Angle_B)
        ElseIf Angle_B <> 0 And Angle_C <> 0 And Side_a <> 0 Then
            'BCa  = 2 angles and side a
            Angle_A = 180 - Angle_B - Angle_C
            Side_b = SinRule2(Side_a, Angle_A, Angle_B)
            Side_c = SinRule2(Side_a, Angle_A, Angle_C)
        ElseIf Angle_B <> 0 And Angle_C <> 0 And Side_b <> 0 Then
            'BCb  = 2 angles and side b
            Angle_A = 180 - Angle_B - Angle_C
            Side_a = SinRule2(Side_b, Angle_B, Angle_A)
            Side_c = SinRule2(Side_a, Angle_A, Angle_C)
        ElseIf Angle_B <> 0 And Angle_C <> 0 And Side_c <> 0 Then
            'BCc  = 2 angles and side c
            Angle_A = 180 - Angle_B - Angle_C
            Side_b = SinRule2(Side_c, Angle_C, Angle_B)
            Side_a = SinRule2(Side_b, Angle_B, Angle_A)
        End If
        FillTextBoxes()
        If NaNFlag = False Then
            CalculateTriangle()
        Else
            MsgBox("Invalid Variables!" & vbCrLf & "Please Re-Enter Valid Variables")
        End If
    End Sub
    Function CosRule1(ByVal a As Double, ByVal b As Double, ByVal c As Double) As Double
        'Return angle
        Return Math.Acos((b ^ 2 + c ^ 2 - a ^ 2) / (2 * b * c)) / Convert
    End Function
    Function CosRule2(ByVal a As Double, ByVal b As Double, ByVal A1 As Double) As Double
        'Return side
        Return Math.Sqrt(a ^ 2 + b ^ 2 - 2 * a * b * Math.Cos(A1 * Convert))
    End Function
    Function SinRule1(ByVal a As Double, ByVal b As Double, ByVal A1 As Double) As Double
        'Return angle
        Return Math.Asin(b * Math.Sin(A1 * Convert) / a) / Convert
    End Function
    Function SinRule2(ByVal a As Double, ByVal A1 As Double, ByVal A2 As Double) As Double
        'Return side
        Return a * Math.Sin(A2 * Convert) / Math.Sin(A1 * Convert)
    End Function
    Sub btnResetClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        For I As Integer = 1 To 6
            txtbxInput(I).Text = Nothing
        Next
        txtbxInput(1).Focus()
        DrawFlag = False
        Refresh()
    End Sub
    Sub FillTextBoxes()
        txtbxInput(1).Text = CSng(Side_a).ToString
        txtbxInput(2).Text = CSng(Side_b).ToString
        txtbxInput(3).Text = CSng(Side_c).ToString
        txtbxInput(4).Text = CSng(Angle_A).ToString
        txtbxInput(5).Text = CSng(Angle_B).ToString
        txtbxInput(6).Text = CSng(Angle_C).ToString
        NaNFlag = False
        For I As Integer = 1 To 6
            If txtbxInput(I).Text = "NaN" Then
                NaNFlag = True
            End If
        Next
    End Sub
    Sub CalculateTriangle()
        factor = Side_a
        If Side_b > factor Then factor = Side_b
        If Side_c > factor Then factor = Side_c
        factor = 365 / factor
        a_side = Side_a * factor
        b_side = Side_b * factor
        x0 = 20
        y0 = 420
        If Angle_C > 90 Then
            x1 = 370 : x0 = CSng(370 - a_side)
        ElseIf Angle_C = 90 Then
            x0 = 80 : x1 = CSng(x0 + a_side)
        Else : x1 = CSng(x0 + a_side)
        End If
        y1 = 420
        x2 = x0 + CSng(b_side * Math.Cos(Angle_C * Convert))
        y2 = y0 - CSng(b_side * Math.Sin(Angle_C * Convert))
        TrianglePoints(0) = New Point(CInt(x0), CInt(y0))
        TrianglePoints(1) = New Point(CInt(x1), CInt(y1))
        TrianglePoints(2) = New Point(CInt(x2), CInt(y2))
        x3 = (x1 - x0) / 2 + x0 : y3 = y0 - 20
        x4 = (x2 - x0) / 2 + x0 : y4 = y0 - (y0 - y2) / 2
        x5 = (x1 - x2) / 2 + x2 : y5 = y0 - (y0 - y2) / 2
        'calculate Area of Triangle
        Area = CSng((0.5 * Side_a * Side_b * Math.Sin(Angle_C * Convert)))
        DrawFlag = True
        Refresh()
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        e.Graphics.DrawString("Triangle Solver", LgeFont, Brushes.Black, 50, 5)
        If DrawFlag = True Then
            'Draw Triangle
            e.Graphics.DrawPolygon(LinePen, TrianglePoints)
            'Draw labels for sides and angles
            e.Graphics.DrawString("Angle A = " & CSng(Angle_A).ToString & Chr(176), LabelFonts, Brushes.Black, x2 + 10, y2 - 10)
            e.Graphics.DrawString("Angle B = " & CSng(Angle_B).ToString & Chr(176), LabelFonts, Brushes.Black, x1 + 10, y1 - 8)
            e.Graphics.DrawString("Angle C = " & CSng(Angle_C).ToString & Chr(176), LabelFonts, Brushes.Black, x0 + 28, y0 - 20)
            e.Graphics.DrawString("Side a = " & CSng(Side_a).ToString, LabelFonts, Brushes.Black, x3, y3 + 30)
            e.Graphics.DrawString("Side b = " & CSng(Side_b).ToString, LabelFonts, Brushes.Black, x4 + 10, y4)
            e.Graphics.DrawString("Side c = " & CSng(Side_c).ToString, LabelFonts, Brushes.Black, x5 + 40, y5 + 20)
            'Draw Area
            e.Graphics.DrawString("Area = " & CSng(Area).ToString & " Sq Units.", LabelFonts, Brushes.Black, 470, 200)
        End If
    End Sub
End Class
