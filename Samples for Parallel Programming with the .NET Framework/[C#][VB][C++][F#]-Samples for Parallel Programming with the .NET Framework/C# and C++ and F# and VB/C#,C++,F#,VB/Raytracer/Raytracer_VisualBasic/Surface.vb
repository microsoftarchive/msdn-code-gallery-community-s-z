'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Surface.vb
'
'--------------------------------------------------------------------------

Public Class Surface
    Public Diffuse As Func(Of Vector, Color)
    Public Specular As Func(Of Vector, Color)
    Public Reflect As Func(Of Vector, Double)
    Public Roughness As Double

    Public Sub New(ByVal diffuse As Func(Of Vector, Color), ByVal specular As Func(Of Vector, Color),
                   ByVal reflect As Func(Of Vector, Double), ByVal roughness As Double)
        Me.Diffuse = diffuse
        Me.Specular = specular
        Me.Reflect = reflect
        Me.Roughness = roughness
    End Sub
End Class