'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Scene.vb
'
'--------------------------------------------------------------------------

Imports System.Collections.Generic

Public Class Scene
    Public Things As SceneObject()
    Public Lights As Light()
    Public Camera As Camera

    Public Sub New(ByVal things As SceneObject(), ByVal lights As Light(), ByVal camera As Camera)
        Me.Things = things
        Me.Lights = lights
        Me.Camera = camera
    End Sub

    Public Function Intersect(ByVal r As Ray) As IEnumerable(Of ISect)
        Dim objects = New List(Of ISect)()
        For Each obj In Things
            objects.Add(obj.Intersect(r))
        Next
        Return objects
    End Function
End Class