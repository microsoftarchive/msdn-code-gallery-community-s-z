Public Class grid
    Inherits System.Windows.Forms.Panel

    Private matrix As cell()() = New cell(2)() {}
    Private first As Char = "X"c
    Private current As Char = "X"c
    Private gameOver As Boolean = False
    Private moveCounter As Integer = 0

    Public Sub New()
        Me.Size = New Size(210, 210)
        For r As Integer = 0 To 2
            matrix(r) = New cell(2) {}
        Next
        For r As Integer = 0 To 2
            For c As Integer = 0 To 2
                matrix(r)(c) = New cell()
                matrix(r)(c).display = " "c
                matrix(r)(c).color = Color.Black
            Next
        Next
    End Sub

    Protected Overrides Sub OnMouseClick(e As System.Windows.Forms.MouseEventArgs)
        If Not gameOver Then
            Dim r As Integer = CInt(Math.Floor(CDbl(e.Y) / 70))
            Dim c As Integer = CInt(Math.Floor(CDbl(e.X) / 70))
            If matrix(r)(c).display = " "c Then
                matrix(r)(c).display = current
                current = "0"c
                Me.Invalidate()
                moveCounter += 1
                gameOver = checkLines()
                If Not gameOver AndAlso moveCounter < 9 Then
                    playMove()
                    moveCounter += 1
                End If
            End If
        End If
        MyBase.OnMouseClick(e)
    End Sub

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawLine(Pens.Black, 70, 0, 70, 210)
        e.Graphics.DrawLine(Pens.Black, 140, 0, 140, 210)
        e.Graphics.DrawLine(Pens.Black, 0, 70, 210, 70)
        e.Graphics.DrawLine(Pens.Black, 0, 140, 210, 140)

        For r As Integer = 0 To 2
            For c As Integer = 0 To 2
                If matrix(r)(c).display <> " "c Then
                    e.Graphics.DrawString(matrix(r)(c).display.ToString(), New Font("Times New Roman", 20, FontStyle.Bold), New SolidBrush(matrix(r)(c).color), CSng((c * 70) + 25), CSng((r * 70) + 25))
                End If
            Next
        Next
    End Sub



    Public Function checkLines() As Boolean
        For r As Integer = 0 To 2
            If matrix(r)(0).display <> " "c AndAlso matrix(r)(0).display = matrix(r)(1).display AndAlso matrix(r)(0).display = matrix(r)(2).display Then
                matrix(r)(0).color = Color.Red
                matrix(r)(1).color = Color.Red
                matrix(r)(2).color = Color.Red
                Return True
            End If
        Next
        For c As Integer = 0 To 2
            If matrix(0)(c).display <> " "c AndAlso matrix(0)(c).display = matrix(1)(c).display AndAlso matrix(0)(c).display = matrix(2)(c).display Then
                matrix(0)(c).color = Color.Red
                matrix(1)(c).color = Color.Red
                matrix(2)(c).color = Color.Red
                Return True
            End If
        Next
        If matrix(0)(0).display <> " "c AndAlso matrix(0)(0).display = matrix(1)(1).display AndAlso matrix(0)(0).display = matrix(2)(2).display Then
            matrix(0)(0).color = Color.Red
            matrix(1)(1).color = Color.Red
            matrix(2)(2).color = Color.Red
            Return True
        End If
        If matrix(0)(2).display <> " "c AndAlso matrix(0)(2).display = matrix(1)(1).display AndAlso matrix(0)(2).display = matrix(2)(0).display Then
            matrix(0)(2).color = Color.Red
            matrix(1)(1).color = Color.Red
            matrix(2)(0).color = Color.Red
            Return True
        End If
        Return False
    End Function

    Public Sub newGame()
        gameOver = False
        For r As Integer = 0 To 2
            For c As Integer = 0 To 2
                matrix(r)(c).display = " "c
                matrix(r)(c).color = Color.Black
            Next
        Next
        first = If((first = "X"c), "0"c, "X"c)
        current = first
        Me.Invalidate()
        moveCounter = 0
        If current = "0"c Then
            playMove()
        End If
    End Sub

    Public Sub playMove()

        For r As Integer = 0 To 2
            For c As Integer = 0 To 2
                If matrix(r)(c).display = " "c Then
                    matrix(r)(c).priority = 0
                Else
                    matrix(r)(c).priority = -1
                End If
            Next
        Next

        If matrix(1)(1).display = " "c Then
            matrix(1)(1).priority = 2
        End If
        If matrix(0)(0).display = " "c Then
            matrix(0)(0).priority = 1
        End If
        If matrix(0)(2).display = " "c Then
            matrix(0)(2).priority = 1
        End If
        If matrix(2)(0).display = " "c Then
            matrix(2)(0).priority = 1
        End If
        If matrix(2)(2).display = " "c Then
            matrix(2)(2).priority = 1
        End If

        For r As Integer = 0 To 2
            If matrix(r)(0).display <> " "c AndAlso matrix(r)(0).display = matrix(r)(1).display AndAlso matrix(r)(2).display = " "c Then
                matrix(r)(2).priority += 3
            End If
            If matrix(r)(0).display <> " "c AndAlso matrix(r)(0).display = matrix(r)(2).display AndAlso matrix(r)(1).display = " "c Then
                matrix(r)(1).priority += 3
            End If
            If matrix(r)(1).display <> " "c AndAlso matrix(r)(1).display = matrix(r)(2).display AndAlso matrix(r)(0).display = " "c Then
                matrix(r)(0).priority += 3
            End If
        Next
        For c As Integer = 0 To 2
            If matrix(0)(c).display <> " "c AndAlso matrix(0)(c).display = matrix(1)(c).display AndAlso matrix(2)(c).display = " "c Then
                matrix(2)(c).priority += 3
            End If
            If matrix(0)(c).display <> " "c AndAlso matrix(0)(c).display = matrix(2)(c).display AndAlso matrix(1)(c).display = " "c Then
                matrix(1)(c).priority += 3
            End If
            If matrix(1)(c).display <> " "c AndAlso matrix(1)(c).display = matrix(2)(c).display AndAlso matrix(0)(c).display = " "c Then
                matrix(0)(c).priority += 3
            End If
        Next
        If matrix(0)(0).display <> " "c AndAlso matrix(0)(0).display = matrix(1)(1).display AndAlso matrix(2)(2).display = " "c Then
            matrix(2)(2).priority += 3
        End If
        If matrix(0)(0).display <> " "c AndAlso matrix(0)(0).display = matrix(2)(2).display AndAlso matrix(1)(1).display = " "c Then
            matrix(1)(1).priority += 3
        End If
        If matrix(1)(1).display <> " "c AndAlso matrix(1)(1).display = matrix(2)(2).display AndAlso matrix(0)(0).display = " "c Then
            matrix(0)(0).priority += 3
        End If
        If matrix(0)(2).display <> " "c AndAlso matrix(0)(2).display = matrix(1)(1).display AndAlso matrix(2)(0).display = " "c Then
            matrix(2)(0).priority += 3
        End If
        If matrix(0)(2).display <> " "c AndAlso matrix(0)(2).display = matrix(2)(0).display AndAlso matrix(1)(1).display = " "c Then
            matrix(1)(1).priority += 3
        End If
        If matrix(1)(1).display <> " "c AndAlso matrix(1)(1).display = matrix(2)(0).display AndAlso matrix(0)(2).display = " "c Then
            matrix(0)(2).priority += 3
        End If

        'int maxC=-1;
        Dim maxC As New List(Of Integer)()
        'int maxR=-1;
        Dim maxR As New List(Of Integer)()
        Dim maxPriority As Integer = -1

        For r As Integer = 0 To 2
            For c As Integer = 0 To 2
                If matrix(r)(c).priority > maxPriority Then
                    maxPriority = matrix(r)(c).priority
                End If
            Next
        Next

        For r As Integer = 0 To 2
            For c As Integer = 0 To 2
                If matrix(r)(c).priority = maxPriority Then
                    maxC.Add(c)
                    maxR.Add(r)
                End If
            Next
        Next

        Dim rnd As New Random()
        Dim index As Integer = rnd.[Next](maxC.Count())

        matrix(maxR(index))(maxC(index)).display = "0"c
        current = "X"c
        gameOver = checkLines()
        Me.Invalidate()
    End Sub

End Class
