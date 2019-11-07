'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Light.vb
'
'--------------------------------------------------------------------------

Public Class Light
    Public Position As Vector
    Public Color As Color

    Public Sub New(ByVal position As Vector, ByVal color As Color)
        Me.Position = position
        Me.Color = color
    End Sub
End Class
