'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Ray.vb
'
'--------------------------------------------------------------------------

Public Structure Ray

    Public Start As Vector
    Public Direction As Vector

    Public Sub New(ByVal start As Vector, ByVal dir As Vector)
        Me.Start = start
        Me.Direction = dir
    End Sub

End Structure