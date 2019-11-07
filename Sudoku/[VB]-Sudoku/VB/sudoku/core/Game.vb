Public Class Game

    Public Event ShowClues(ByVal grid()() As Integer)
    Public Event ShowSolution(ByVal grid()() As Integer)

    Private HRow(8) As List(Of Integer)
    Private VRow(8) As List(Of Integer)
    Private ThreeSquare(8) As List(Of Integer)
    Private grid(8)() As Integer

    Private r As Random

    Public Sub NewGame(ByVal rn As Random)
        Me.r = rn
        createNewGame()
    End Sub

    Private Sub initializeLists()
        For x As Integer = 0 To 8
            HRow(x) = New List(Of Integer)(New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9})
            VRow(x) = New List(Of Integer)(New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9})
            ThreeSquare(x) = New List(Of Integer)(New Integer() {1, 2, 3, 4, 5, 6, 7, 8, 9})
            Dim row(8) As Integer
            grid(x) = row
        Next
    End Sub

    Private Sub createNewGame()
        Do
            initializeLists()
            For y As Integer = 0 To 8
                For x As Integer = 0 To 8
                    grid(y)(x) = Nothing
                    Dim si As Integer = (y \ 3) * 3 + (x \ 3)
                    Dim useful() As Integer = HRow(y).Intersect(VRow(x)).Intersect(ThreeSquare(si)).ToArray
                    If useful.Count = 0 Then Continue Do
                    Dim randomNumber As Integer = useful(r.Next(0, useful.Count))
                    HRow(y).Remove(randomNumber)
                    VRow(x).Remove(randomNumber)
                    ThreeSquare(si).Remove(randomNumber)
                    grid(y)(x) = randomNumber
                    If y = 8 And x = 8 Then Exit Do
                Next
            Next
        Loop

        RaiseEvent ShowClues(grid)

    End Sub

    Public Sub showGridSolution()

        RaiseEvent ShowSolution(grid)

    End Sub

End Class
