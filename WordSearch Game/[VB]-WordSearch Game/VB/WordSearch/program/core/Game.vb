''' <summary>
''' The Game class is the singleton core class initiated on app. load and used for the duration of app. running time.
''' </summary>
''' <remarks></remarks>
Public Class Game

    Dim cells As New List(Of Cell)
    Dim words() As String

    Dim rn As New Random

    ''' <summary>
    ''' This default constructor initializes the cells list containing the 225 Cells used throughout the game.
    ''' Also the 46K+ words used are read into the words array.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        cells.AddRange(Enumerable.Range(0, 15 * 15).Select(Function(x) New Cell))
        For r As Integer = 1 To 15
            For c As Integer = 1 To 15
                cells((r - 1) * 15 + c - 1).line(0) = r
                cells((r - 1) * 15 + c - 1).line(1) = c + 15
            Next
        Next
        For r As Integer = 4 To 15
            Dim c As Integer = 0
            For r2 As Integer = r - 1 To 0 Step -1
                cells((r2) * 15 + c).line(2) = 30 + r - 3
                c += 1
            Next
        Next
        For c As Integer = 1 To 11
            Dim r As Integer = 14
            For c2 As Integer = c To 14
                cells(r * 15 + c2).line(2) = 42 + c
                r -= 1
            Next
        Next
        For r As Integer = 4 To 15
            Dim c As Integer = 14
            For r2 As Integer = r - 1 To 0 Step -1
                cells((r2) * 15 + c).line(3) = 53 + r - 3
                c -= 1
            Next
        Next
        For c As Integer = 13 To 3 Step -1
            Dim r As Integer = 14
            For c2 As Integer = c To 0 Step -1
                cells(r * 15 + c2).line(3) = 65 + (14 - c)
                r -= 1
            Next
        Next

        words = My.Resources._429Wild.Split(New String() {vbCr, vbLf}, StringSplitOptions.None)

    End Sub

    ''' <summary>
    ''' The createNew function creates a 15 by 15 grid of single letters, comprised of 25 random words, 
    ''' then random letters in the remaining empty cells.
    ''' No 2 words in the same line (horizontal, vertical, 2 * diagonal) will overlap.
    ''' Words on different lines can overlap.
    ''' </summary>
    ''' <param name="frm">Instance of frmProgress. Provides graphical indication of progress.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function createNew(ByVal frm As frmProgress) As NewGame

        Dim wordList As New List(Of String)

        Do
            Dim lineIndex As Integer = rn.Next(1, 77)
            Dim lineCells() As Cell = cells.Where(Function(c) c.line.Contains(lineIndex)).ToArray
            Dim reversed As Boolean = CBool(rn.Next(0, 2))

            Select Case lineIndex
                Case 16 To 30
                    If Not reversed Then
                        lineCells = lineCells.OrderBy(Function(c) c.line(0)).ToArray
                    Else
                        lineCells = lineCells.OrderByDescending(Function(c) c.line(0)).ToArray
                    End If
                Case Else
                    If Not reversed Then
                        lineCells = lineCells.OrderBy(Function(c) c.line(1)).ToArray
                    Else
                        lineCells = lineCells.OrderByDescending(Function(c) c.line(1)).ToArray
                    End If
            End Select

            Dim x2 As Integer = 0


            Dim availableIndex As Integer = If(lineIndex >= 1 And lineIndex <= 15, 0, _
                                                If(lineIndex >= 16 And lineIndex <= 30, 1, _
                                                   If(lineIndex >= 31 And lineIndex <= 53, 2, _
                                                      If(lineIndex >= 54 And lineIndex <= 76, 3, -1))))


            Dim noSpace As Boolean = False
            Dim startAt As Integer = 0
            If Not lineCells(0).available(availableIndex) Then
                For x As Integer = 1 To lineCells.GetUpperBound(0)
                    If lineCells(x).available(availableIndex) Then
                        startAt = x
                        Exit For
                    End If
                Next
                If startAt = 0 Then noSpace = True
            End If

            If noSpace Then Continue Do

            Dim spaces As New List(Of Point)
            spaces.Add(New Point(startAt, startAt))

            For x As Integer = startAt To lineCells.GetUpperBound(0)
                If lineCells(x).available(availableIndex) Then
                    spaces(spaces.Count - 1) = New Point(spaces.Last.X, x)
                Else
                    For x2 = x + 1 To lineCells.GetUpperBound(0)
                        If lineCells(x2).available(availableIndex) Then
                            spaces.Add(New Point(x2, x2))
                            x = x2 + 1
                            Exit For
                        End If
                    Next
                End If
            Next

            Dim maxLength As Integer = spaces.Max(Function(p) p.Y - p.X + 1)
            Dim maxLengthPoint As Point = spaces.First(Function(p) p.Y - p.X + 1 = maxLength)

            If maxLength < 4 Then Continue Do

            Dim wordlength As Integer = rn.Next(4, Math.Min(10, maxLength + 1))
            Dim startIndex As Integer = rn.Next(maxLengthPoint.X, maxLengthPoint.X + maxLength - wordlength)

            Dim matches() As String = words.Where(Function(w) w.Length = wordlength AndAlso _
                                                      Enumerable.Range(startIndex, wordlength).All(Function(x) _
                                                        lineCells(x).text = "" OrElse lineCells(x).text = w(x - startIndex).ToString)).ToArray

            If matches.Length > 0 Then
                Dim selectedWord As String = matches(rn.Next(0, matches.Length))
                If wordList.Contains(selectedWord) Then Continue Do

                For x As Integer = startIndex To startIndex + wordlength - 1
                    lineCells(x).text = selectedWord(x - startIndex).ToString
                    lineCells(x).available(availableIndex) = False
                Next
                If startIndex > 0 Then
                    lineCells(startIndex - 1).available(availableIndex) = False
                End If
                If startIndex + wordlength <= lineCells.GetUpperBound(0) Then
                    lineCells(startIndex + wordlength).available(availableIndex) = False
                End If

                wordList.Add(selectedWord)
                frm.performStep()
            End If

        Loop While wordList.Count < 25

        Dim grid(14)() As String

        For r As Integer = 0 To 14
            Dim columns(14) As String
            grid(r) = columns
            For c As Integer = 0 To 14
                If cells(r * 15 + c).text <> "" Then
                    grid(r)(c) = cells(r * 15 + c).text
                    cells(r * 15 + c).text = ""
                Else
                    grid(r)(c) = Chr(rn.Next(97, 123)).ToString
                End If
                cells(r * 15 + c).available = New Boolean() {True, True, True, True}
            Next
        Next

        Return New NewGame(grid, wordList.ToArray)

    End Function

End Class
