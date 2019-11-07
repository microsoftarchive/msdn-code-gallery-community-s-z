'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Surfaces.vb
'
'--------------------------------------------------------------------------

Public Class Surfaces
    ' Only works with X-Z plane.
    Public Shared ReadOnly CheckerBoard As Surface = New Surface(
        Function(pos) If(((Math.Floor(pos.Z) + Math.Floor(pos.X)) Mod 2 <> 0), New Color(1, 1, 1), New Color(0.02, 0.0, 0.14)),
        Function(pos) New Color(1, 1, 1),
        Function(pos) If(((Math.Floor(pos.Z) + Math.Floor(pos.X)) Mod 2 <> 0), 0.1, 0.5),
        150)

    Public Shared ReadOnly Shiny As Surface = New Surface(
        Function(pos) New Color(1, 1, 1),
        Function(pos) New Color(0.5, 0.5, 0.5),
        Function(pos) 0.7,
        250)

    Public Shared ReadOnly MatteShiny As Surface = New Surface(
        Function(pos) New Color(1, 1, 1),
        Function(pos) New Color(0.25, 0.25, 0.25),
        Function(pos) 0.7,
        250)
End Class