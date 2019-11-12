Friend Class methods

    Public Overloads Shared Sub calculate(ByVal tb As TextBox, ByRef part1 As Double, ByVal part2 As Double, ByVal [operator] As String)
        Select Case [operator]
            Case "+"
                part1 += part2
            Case "-"
                part1 -= part2
            Case "/"
                part1 /= part2
            Case "*"
                part1 *= part2
            Case ""
                Double.TryParse(tb.Text, part1)
        End Select
    End Sub

    Public Overloads Shared Sub calculate(ByRef tbText As String, ByVal part1 As Double, ByVal part2 As Double, ByVal [operator] As String)
        Select Case [operator]
            Case "+"
                tbText = (part1 + part2).ToString
            Case "-"
                tbText = (part1 - part2).ToString
            Case "/"
                tbText = (part1 / part2).ToString
            Case "*"
                tbText = (part1 * part2).ToString
        End Select
    End Sub

    Public Overloads Shared Function calculate(ByRef tbText As String, ByVal part1 As Double, ByVal part2 As Double, ByVal [operator] As String, ByVal percentage As Boolean) As Boolean
        Select Case [operator]
            Case "+"
                tbText = (part1 + (part1 * (part2 / 100))).ToString
            Case "-"
                tbText = (part1 - (part1 * (part2 / 100))).ToString
            Case "/"
                tbText = (part1 / (part1 * (part2 / 100))).ToString
            Case "*"
                tbText = (part1 * (part1 * (part2 / 100))).ToString
        End Select
        Return percentage
    End Function

    Public Overloads Shared Sub calculate(ByRef part1 As Double, ByVal part2 As Double, ByVal [operator] As String)
        Select Case [operator]
            Case "+"
                part1 -= part2
            Case "-"
                part1 += part2
            Case "/"
                part1 *= part2
            Case "*"
                part1 /= part2
        End Select
    End Sub

    Public Shared Sub changeText(ByRef lblText As String, ByVal replacement As String)
        lblText = lblText.TrimEnd(New Char() {"+"c, "-"c, "*"c, "/"c, " "c}) & replacement
    End Sub

End Class
