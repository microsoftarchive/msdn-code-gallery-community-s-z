'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Sphere.vb
'
'--------------------------------------------------------------------------

Public Class Sphere
    Inherits SceneObject

    Public Center As Vector
    Public Radius As Double

    Public Sub New(ByVal center As Vector, ByVal radius As Double, ByVal surface As Surface)
        MyBase.New(surface)
        Me.Center = center
        Me.Radius = radius
    End Sub

    Public Overrides Function Intersect(ByVal ray As Ray) As ISect
        Dim eo = Vector.Minus(Center, ray.Start)
        Dim v = Vector.Dot(eo, ray.Direction)
        Dim dist As Double
        If v < 0 Then
            dist = 0
        Else
            Dim disc = Math.Pow(Radius, 2) - (Vector.Dot(eo, eo) - Math.Pow(v, 2))
            dist = If(disc < 0, 0, v - Math.Sqrt(disc))
        End If
        If dist = 0 Then Return Nothing
        Return New ISect(Me, ray, dist)
    End Function

    Public Overrides Function Normal(ByVal position As Vector) As Vector
        Return Vector.Norm(Vector.Minus(position, Center))
    End Function
End Class
