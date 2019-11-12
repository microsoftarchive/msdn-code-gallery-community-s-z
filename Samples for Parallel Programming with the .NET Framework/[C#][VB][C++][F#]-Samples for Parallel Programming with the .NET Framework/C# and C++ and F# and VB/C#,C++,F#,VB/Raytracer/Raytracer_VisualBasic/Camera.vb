'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Camera.vb
'
'--------------------------------------------------------------------------

Public Class Camera
    Public Position As Vector
    Public Forward As Vector
    Public Up As Vector
    Public Right As Vector

    Public Sub New(ByVal position As Vector, ByVal forward As Vector, ByVal up As Vector, ByVal right As Vector)
        Me.Position = position
        Me.Forward = forward
        Me.Up = up
        Me.Right = right
    End Sub

    Public Shared Function Create(ByVal pos As Vector, ByVal lookat As Vector) As Camera
        Dim forward = Vector.Norm(Vector.Minus(lookat, pos))
        Dim down = New Vector(0, -1, 0)
        Dim right = Vector.Times(1.5, Vector.Norm(Vector.Cross(forward, down)))
        Dim up = Vector.Times(1.5, Vector.Norm(Vector.Cross(forward, right)))
        Return New Camera(pos, forward, up, right)
    End Function
End Class