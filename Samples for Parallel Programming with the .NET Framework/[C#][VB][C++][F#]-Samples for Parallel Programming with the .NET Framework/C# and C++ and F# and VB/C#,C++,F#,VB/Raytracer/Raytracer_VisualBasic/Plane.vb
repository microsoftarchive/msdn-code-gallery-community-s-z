'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Plane.vb
'
'--------------------------------------------------------------------------

Public Class Plane
    Inherits SceneObject
    Public Norm As Vector
    Public Offset As Double

    Public Sub New(ByVal norm As Vector, ByVal offset As Double, ByVal surface As Surface)
        MyBase.New(surface)
        Me.Norm = norm
        Me.Offset = offset
    End Sub

    Public Overrides Function Intersect(ByVal ray As Ray) As ISect
        Dim denom = Vector.Dot(Norm, ray.Direction)
        If denom > 0 Then Return Nothing
        Return New ISect(Me, ray, (Vector.Dot(Norm, ray.Start) + Offset) / (-denom))
    End Function

    Public Overrides Function Normal(ByVal position As Vector) As Vector
        Return Norm
    End Function

End Class