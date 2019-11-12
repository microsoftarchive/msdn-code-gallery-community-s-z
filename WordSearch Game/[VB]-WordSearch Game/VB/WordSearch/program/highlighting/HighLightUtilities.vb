''' <summary>
''' Utilities Class with 2 Functions used in selecting and highlighting lines
''' </summary>
''' <remarks></remarks>
Public Class HighLightUtilities

    Private Shared red As New Pen(Color.FromArgb(30, Color.Red.R, Color.Red.G, Color.Red.B), 12) With {.StartCap = Drawing2D.LineCap.Round, .EndCap = Drawing2D.LineCap.Round}
    Private Shared green As New Pen(Color.FromArgb(30, Color.Green.R, Color.Green.G, Color.Green.B), 12) With {.StartCap = Drawing2D.LineCap.Round, .EndCap = Drawing2D.LineCap.Round}
    Private Shared blue As New Pen(Color.FromArgb(30, Color.Blue.R, Color.Blue.G, Color.Blue.B), 12) With {.StartCap = Drawing2D.LineCap.Round, .EndCap = Drawing2D.LineCap.Round}

    Public Shared Function EndCapOffset(ByVal pt1 As Point, ByVal pt2 As Point) As Point
        If pt1.X = pt2.X And pt1.Y < pt2.Y Then 'pt1 above
            Return New Point(5, 5)
        ElseIf pt1.X > pt2.X And pt1.Y < pt2.Y Then 'pt1 above right
            Return New Point(5, 10)
        ElseIf pt1.X > pt2.X And pt1.Y = pt2.Y Then 'pt1 right
            Return New Point(10, 10)
        ElseIf pt1.X > pt2.X And pt1.Y > pt2.Y Then 'pt1 below right
            Return New Point(5, 10)
        ElseIf pt1.X = pt2.X And pt1.Y > pt2.Y Then 'pt1 below
            Return New Point(5, 10)
        ElseIf pt1.X < pt2.X And pt1.Y > pt2.Y Then 'pt1 below left
            Return New Point(5, 10)
        ElseIf pt1.X < pt2.X And pt1.Y = pt2.Y Then 'pt1 left
            Return New Point(5, 10)
        ElseIf pt1.X < pt2.X And pt1.Y < pt2.Y Then 'pt1 above left
            Return New Point(5, 10)
        End If
        Return Point.Empty
    End Function

    Public Shared Function isValidLine(ByVal pt1 As Point, ByVal pt2 As Point) As LineDetails
        Dim cells As New List(Of Point)
        Dim p As Pen = Nothing
        If pt1.X = pt2.X And pt1.Y < pt2.Y Then 'pt1 above
            For x As Integer = pt1.Y To pt2.Y
                cells.Add(New Point(pt1.X, x))
            Next
            p = green
        ElseIf pt1.X > pt2.X And pt1.Y < pt2.Y Then 'pt1 above right
            If pt1.X - pt2.X = pt2.Y - pt1.Y Then
                Dim c As Integer = pt1.X
                For x As Integer = pt1.Y To pt2.Y
                    cells.Add(New Point(c, x))
                    c -= 1
                Next
                p = blue
            End If
        ElseIf pt1.X > pt2.X And pt1.Y = pt2.Y Then 'pt1 right
            For x As Integer = pt1.X To pt2.X Step -1
                cells.Add(New Point(x, pt1.Y))
            Next
            p = red
        ElseIf pt1.X > pt2.X And pt1.Y > pt2.Y Then 'pt1 below right
            If pt1.X - pt2.X = pt1.Y - pt2.Y Then
                Dim r As Integer = pt1.Y
                For x As Integer = pt1.X To pt2.X Step -1
                    cells.Add(New Point(x, r))
                    r -= 1
                Next
                p = blue
            End If
        ElseIf pt1.X = pt2.X And pt1.Y > pt2.Y Then 'pt1 below
            For x As Integer = pt1.Y To pt2.Y Step -1
                cells.Add(New Point(pt1.X, x))
            Next
            p = green
        ElseIf pt1.X < pt2.X And pt1.Y > pt2.Y Then 'pt1 below left
            If pt2.X - pt1.X = pt1.Y - pt2.Y Then
                Dim r As Integer = pt1.Y
                For x As Integer = pt1.X To pt2.X
                    cells.Add(New Point(x, r))
                    r -= 1
                Next
                p = blue
            End If
        ElseIf pt1.X < pt2.X And pt1.Y = pt2.Y Then 'pt1 left
            For x As Integer = pt1.X To pt2.X
                cells.Add(New Point(x, pt1.Y))
            Next
            p = red
        ElseIf pt1.X < pt2.X And pt1.Y < pt2.Y Then 'pt1 above left
            If pt2.X - pt1.X = pt2.Y - pt1.Y Then
                Dim r As Integer = pt1.Y
                For x As Integer = pt1.X To pt2.X
                    cells.Add(New Point(x, r))
                    r += 1
                Next
                p = blue
            End If
        End If

        If cells.Count > 0 Then
            Return New LineDetails(pt1, pt2, p, cells, -1)
        Else
            Return Nothing
        End If

    End Function

End Class
