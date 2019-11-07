'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Vector.vb
'
'--------------------------------------------------------------------------

Public Structure Vector
    Public X As Double
    Public Y As Double
    Public Z As Double

    Public Sub New(ByVal x As Double, ByVal y As Double, ByVal z As Double)
        Me.X = x
        Me.Y = y
        Me.Z = z
    End Sub

    Public Sub New(ByVal str As String)
        Dim nums = str.Split(CChar(","))
        If nums.Length <> 3 Then Throw New ArgumentException("str")
        Me.X = Double.Parse(nums(0))
        Me.Y = Double.Parse(nums(1))
        Me.Z = Double.Parse(nums(2))
    End Sub

    Public Shared Function Times(ByVal n As Double, ByVal v As Vector) As Vector
        Return New Vector(v.X * n, v.Y * n, v.Z * n)
    End Function

    Public Shared Function Minus(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z)
    End Function

    Public Shared Function Plus(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z)
    End Function

    Public Shared Function Dot(ByVal v1 As Vector, ByVal v2 As Vector) As Double
        Return (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z)
    End Function

    Public Shared Function Mag(ByVal v As Vector) As Double
        Return Math.Sqrt(Dot(v, v))
    End Function

    Public Shared Function Norm(ByVal v As Vector) As Vector
        Dim magnitude = Mag(v)
        Dim div = If(magnitude = 0, Double.PositiveInfinity, 1 / magnitude)
        Return Times(div, v)
    End Function

    Public Shared Function Cross(ByVal v1 As Vector, ByVal v2 As Vector) As Vector
        Return New Vector(((v1.Y * v2.Z) - (v1.Z * v2.Y)),
                          ((v1.Z * v2.X) - (v1.X * v2.Z)),
                          ((v1.X * v2.Y) - (v1.Y * v2.X)))
    End Function
End Structure
