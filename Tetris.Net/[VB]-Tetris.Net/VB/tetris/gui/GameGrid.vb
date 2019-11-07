''' <summary>
''' Extended DataGridView 
''' DoubleBuffered. Restricts user selection of cells.
''' </summary>
''' <remarks></remarks>
Public Class GameGrid
    Inherits DataGridView

    'constants used with Keypresses
    Const WM_LBUTTONDOWN As Integer = &H201
    Const WM_LBUTTONDBLCLK As Integer = &H203
    Const WM_KEYDOWN As Integer = &H100
    Const VK_LEFT As Integer = &H25
    Const VK_RIGHT As Integer = &H27
    Const VK_DOWN As Integer = &H28
    Const VK_UP As Integer = &H26

    'custom events
    Public Event IncrementScore(newPoints As Integer)
    Public Event ShapeChanged(shapePoints() As Point, shapeColor As String)

    Private rowCounter As Integer = 0

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

    ''' <summary>
    ''' OnRowPrePaint
    ''' Avoid DGV cell focussing
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnRowPrePaint(ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs)
        e.PaintParts = e.PaintParts And Not DataGridViewPaintParts.Focus
        MyBase.OnRowPrePaint(e)
    End Sub

    ''' <summary>
    ''' WndProc
    ''' Avoid DGV focussing, and catch Keypresses
    ''' </summary>
    ''' <param name="m"></param>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_LBUTTONDBLCLK OrElse m.Msg = WM_LBUTTONDOWN Then
            Return
        ElseIf m.Msg = WM_KEYDOWN Then
            If m.WParam.ToInt32 = VK_LEFT Then
                moveLeft()
            ElseIf m.WParam.ToInt32 = VK_RIGHT Then
                moveRight()
            ElseIf m.WParam.ToInt32 = VK_DOWN Then
                moveDown()
            ElseIf m.WParam.ToInt32 = VK_UP Then
                rotateShape()
            End If
            Return
        End If
        MyBase.WndProc(m)
    End Sub

    'timers used in game play
    Private WithEvents tmr As New Timer With {.Interval = 500}
    Private WithEvents flashtmr As New Timer With {.Interval = 125}

    'variables used with flashtmr tick event
    Private flashCounter As Integer = 1
    Private flashRow As Integer
    Private missATick As Boolean = False

    'variables holding cell colors and shapes
    Private gameGrid()() As String
    Private currentShape As Shape
    Private listShapes As New List(Of Shape)

    Private r As New Random
    Private moveCounter As Integer = 0

    'clears the game board and score and initiates a new game
    Public Sub newGame()
        tmr.Stop()
        tmr.Interval = 500
        listShapes.Clear()
        moveCounter = 0

        ReDim gameGrid(29)
        For x As Integer = 1 To 30
            Dim row(19) As String
            gameGrid(x - 1) = DirectCast(row.Clone, String())
        Next
        newShape()
        currentShape = listShapes(0)
        RaiseEvent ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor)
        rowCounter = 0
        tmr.Start()
        flashtmr.Start()
    End Sub

    'creates a new falling shape
    Private Sub newShape()
        Dim sc() As String = {"R", "G", "B", "Y"}
        Dim ns As New Shape(r.Next(0, 7), sc(r.Next(0, 4)))
        listShapes.Add(ns)
        'currentShape = ns
        AddHandler ns.TouchDown, AddressOf currentShape_TouchDown
        HasChanged(gameGrid, False, -1)
    End Sub

    'responds to LEFT arrow button keydown
    Public Sub moveLeft()
        If currentShape Is Nothing Then Return
        gameGrid = currentShape.moveLeft(gameGrid)
        HasChanged(gameGrid, False, -1)
    End Sub

    'responds to RIGHT arrow button keydown
    Public Sub moveRight()
        If currentShape Is Nothing Then Return
        gameGrid = currentShape.moveRight(gameGrid)
        HasChanged(gameGrid, False, -1)
    End Sub

    'responds to DOWN arrow button keydown
    Public Sub moveDown()
        Do
            For x As Integer = 0 To listShapes.Count - 1
                If x > listShapes.Count - 1 Then Continue Do
                gameGrid = listShapes(x).moveDown(gameGrid)
                HasChanged(gameGrid, False, -1)
            Next
            Exit Do
        Loop
        moveCounter += 1
    End Sub
    '
    'responds to UP arrow button keydown
    Public Sub rotateShape()
        If currentShape Is Nothing Then Return
        gameGrid = currentShape.rotateShape(gameGrid)
        HasChanged(gameGrid, False, -1)
        RaiseEvent ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor)
    End Sub

    'on tick, all shapes move down one row
    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        If missATick Then Return
        If moveCounter >= 27 Then
            moveCounter = 0

            newShape()
            If listShapes.Count = 1 Then
                currentShape = listShapes(0)
                RaiseEvent ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor)
            End If
        End If
        moveDown()
    End Sub

    'responds to shape touchdown
    Private Sub currentShape_TouchDown(sender As Shape)
        If sender.CurrentPoints.Any(Function(p) p.Y < 0) Then tmr.Stop()
        RemoveHandler currentShape.TouchDown, AddressOf currentShape_TouchDown
        listShapes.Remove(sender)
        If listShapes.Count < 1 Then
            currentShape = Nothing
            moveCounter = 27
        Else
            currentShape = listShapes(0)
            RaiseEvent ShapeChanged(currentShape.CurrentPoints, currentShape.ShapeColor)
        End If
    End Sub

    'clears full rows as they occur
    Private Sub flashtmr_Tick(sender As Object, e As EventArgs) Handles flashtmr.Tick
        Select Case flashCounter
            Case 1
                flashRow = findFullRow()
                If flashRow > -1 Then
                    flashCounter = 2
                    HasChanged(gameGrid, True, flashRow)
                End If
            Case 2
                flashCounter = 3
                HasChanged(gameGrid, False, -1)
            Case 3
                flashCounter = 4
                HasChanged(gameGrid, True, flashRow)
            Case 4
                Dim newGrid As New List(Of String())(gameGrid)
                For Each p As Point In listShapes.Last.CurrentPoints
                    If p.Y > -1 Then
                        newGrid(p.Y)(p.X) = ""
                    End If
                Next
                Dim newRow(19) As String
                newGrid.RemoveAt(flashRow)
                newGrid.Insert(0, newRow)
                missATick = True
                gameGrid = newGrid.ToArray
                flashCounter = 1
                moveDown()
                HasChanged(gameGrid, False, -1)
                missATick = False
                rowCounter += 1
                If rowCounter Mod 10 = 0 Then
                    tmr.Interval -= 40
                    RaiseEvent IncrementScore(((1000 - tmr.Interval) * 0.35))
                ElseIf rowCounter Mod 5 = 0 Then
                    tmr.Interval -= 20
                    RaiseEvent IncrementScore(((1000 - tmr.Interval) * 0.25))
                Else
                    RaiseEvent IncrementScore(((1000 - tmr.Interval) * 0.05))
                End If
        End Select
    End Sub

    'finds full rows in DGV
    Private Function findFullRow() As Integer
        For x As Integer = 29 To 0 Step -1
            If gameGrid(x).All(Function(s) Not String.IsNullOrEmpty(s)) Then Return x
        Next
        Return -1
    End Function

    'renders the colors in the DGV
    Private Sub HasChanged(grid As String()(), flash As Boolean, flashRow As Integer)
        Dim colors As New Dictionary(Of String, Color) From {{"R", Color.Red}, {"G", Color.Green}, {"B", Color.Blue}, {"Y", Color.Yellow}}
        Dim flashColors As New Dictionary(Of String, Color) From {{"R", Color.FromArgb(255, 165, 165)}, {"G", Color.FromArgb(165, 255, 165)}, {"B", Color.FromArgb(165, 165, 255)}, {"Y", Color.FromArgb(255, 255, 230)}}
        For y As Integer = 0 To 29
            For x As Integer = 0 To 19
                If String.IsNullOrEmpty(grid(y)(x)) Then
                    Me.Rows(y).Cells(x).Style.BackColor = Color.Black
                Else
                    If Not flash OrElse (flash And Not flashRow = y) Then
                        Me.Rows(y).Cells(x).Style.BackColor = colors(grid(y)(x))
                    Else
                        Me.Rows(y).Cells(x).Style.BackColor = flashColors(grid(y)(x))
                    End If
                End If
            Next
        Next
    End Sub

End Class
