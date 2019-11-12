'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: SceneObject.vb
'
'--------------------------------------------------------------------------

Public MustInherit Class SceneObject
    Public Surface As Surface
    Public MustOverride Function Intersect(ByVal ray As Ray) As ISect
    Public MustOverride Function Normal(ByVal position As Vector) As Vector

    Public Sub New(ByVal surface As Surface)
        Me.Surface = surface
    End Sub
End Class