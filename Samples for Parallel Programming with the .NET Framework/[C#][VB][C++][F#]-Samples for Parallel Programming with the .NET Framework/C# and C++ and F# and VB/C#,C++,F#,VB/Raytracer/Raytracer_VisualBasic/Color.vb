'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Color.vb
'
'--------------------------------------------------------------------------

Public Structure Color
    Public R As Double
    Public G As Double
    Public B As Double

    Public Sub New(ByVal r As Double, ByVal g As Double, ByVal b As Double)
        Me.R = r
        Me.G = g
        Me.B = b
    End Sub

    Public Sub New(ByVal str As String)
        Dim nums = str.Split(CChar(","))
        If nums.Length <> 3 Then Throw New ArgumentException("str")
        Me.R = Double.Parse(nums(0))
        Me.G = Double.Parse(nums(1))
        Me.B = Double.Parse(nums(2))
    End Sub

    Public Shared Function Times(ByVal n As Double, ByVal c As Color) As Color
        Return New Color(n * c.R, n * c.G, n * c.B)
    End Function

    Public Shared Function Times(ByVal c1 As Color, ByVal c2 As Color) As Color
        Return New Color(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B)
    End Function

    Public Shared Function Plus(ByVal c1 As Color, ByVal c2 As Color) As Color
        Return New Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B)
    End Function

    Public Shared Function Minus(ByVal c1 As Color, ByVal c2 As Color) As Color
        Return New Color(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B)
    End Function

    Public Shared ReadOnly Background As Color = New Color(0, 0, 0)
    Public Shared ReadOnly DefaultColor As Color = New Color(0, 0, 0)

    Public Shared Function Legalize(ByVal d As Double) As Double
        Return If(d > 1, 1, d)
    End Function

    Public Shared Function ToByte(ByVal d As Double) As Byte
        Return CType(255 * Legalize(d), Byte)
    End Function

    Public Shared Function ToInt32(ByVal c As Double) As Int32
        Dim r = CType(255 * c, Int32)
        Return If(r > 255, 255, r)
    End Function

    Public Function ToInt32() As Int32
        Return ToInt32(B) Or ToInt32(G) << 8 Or ToInt32(R) << 16 Or CType(255 << 24, Int32)
    End Function

    Friend Function ToDrawingColor() As System.Drawing.Color
        Return System.Drawing.Color.FromArgb(ToInt32())
    End Function

    Public Sub ChangeHue(ByVal hue As Double)

        Dim S = 0.9
        Dim L = ((System.Drawing.Color.FromArgb(ToInt32()).GetBrightness() - 0.5) * 0.5) + 0.5
        Dim H = hue

        If L = 0 Then
            R = 0.0
            G = 0.0
            B = 0.0
        ElseIf S = 0 Then
            R = L
            G = L
            B = L
        Else
            Dim temp2 = If(L <= 0.5, L * (1.0 + S), L + S - (L * S))
            Dim temp1 = 2.0 * L - temp2

            Dim t3 = New Double() {H + 1.0 / 3.0, H, H - 1.0 / 3.0}
            Dim clr = New Double() {0, 0, 0}

            For i = 0 To 2
                If (t3(i) < 0) Then t3(i) += 1.0
                If (t3(i) > 1) Then t3(i) -= 1.0
                If (6.0 * t3(i) < 1.0) Then
                    clr(i) = temp1 + (temp2 - temp1) * t3(i) * 6.0
                ElseIf (2.0 * t3(i) < 1.0) Then
                    clr(i) = temp2
                ElseIf (3.0 * t3(i) < 2.0) Then
                    clr(i) = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3(i)) * 6.0)
                Else
                    clr(i) = temp1
                End If
            Next

            R = clr(0)
            G = clr(1)
            B = clr(2)
        End If
    End Sub
End Structure