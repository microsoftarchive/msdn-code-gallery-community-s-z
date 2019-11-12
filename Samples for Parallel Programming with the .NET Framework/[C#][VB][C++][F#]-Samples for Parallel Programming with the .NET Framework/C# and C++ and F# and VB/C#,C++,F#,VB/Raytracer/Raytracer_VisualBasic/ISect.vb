'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: ISect.vb
'
'--------------------------------------------------------------------------

Public Class ISect
    Public Thing As SceneObject
    Public Ray As Ray
    Public Dist As Double

    Public Sub New(ByVal thing As SceneObject, ByVal ray As Ray, ByVal dist As Double)
        Me.Thing = thing
        Me.Ray = ray
        Me.Dist = dist
    End Sub
End Class