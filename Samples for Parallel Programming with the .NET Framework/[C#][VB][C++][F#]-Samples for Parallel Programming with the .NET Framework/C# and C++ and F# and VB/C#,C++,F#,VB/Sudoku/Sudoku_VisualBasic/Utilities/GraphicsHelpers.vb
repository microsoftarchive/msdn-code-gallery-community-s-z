'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: GraphicsHelpers.vb
'
'  Description: Graphics utility class.
' 
'--------------------------------------------------------------------------

Imports System.Drawing.Drawing2D

Namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples.Sudoku.Utilities
	''' <summary>Graphics utility class.</summary>
	Friend NotInheritable Class GraphicsHelpers
		''' <summary>Creates a GraphicsPath that represents a rounded rectangle.</summary>
		''' <param name="width">The width of the rectangle.</param>
		''' <param name="height">The height of the rectangle.</param>
		''' <param name="diameter">The diameter of the rounded corners.</param>
		''' <returns>The rounded rectangle path.</returns>
		Private Sub New()
		End Sub
		Public Shared Function CreateRoundedRectangle(ByVal width As Integer, ByVal height As Integer, ByVal diameter As Integer) As GraphicsPath
			Dim path As New GraphicsPath()

			Dim upperLeft As New Rectangle(0, 0, diameter, diameter)
			Dim upperRight As New Rectangle(width - diameter, 0, diameter, diameter)
			Dim lowerRight As New Rectangle(width - diameter, height - diameter, diameter, diameter)
			Dim lowerLeft As New Rectangle(0, height - diameter, diameter, diameter)

            With path
                .StartFigure()
                .AddArc(upperLeft, 180, 90)
                .AddArc(upperRight, 270, 90)
                .AddArc(lowerRight, 0, 90)
                .AddArc(lowerLeft, 90, 90)
                .CloseFigure()
            End With

            Return path
        End Function

		''' <summary>Determines the maximum font em size to be used within a particular width and height area.</summary>
		''' <param name="text">The text for which we need to know the maximum size.</param>
		''' <param name="graphics">The graphics to use to analyze font size.</param>
		''' <param name="fontFamily">The FontFamily to size.</param>
		''' <param name="fontStyle">The FontStyle to size.</param>
		''' <param name="width">The width of the area to contain the drawn character.</param>
		''' <param name="height">The height of the area to contain the drawn character.</param>
		''' <returns></returns>
        Public Shared Function GetMaximumEMSize(ByVal text As String, ByVal graphics As Graphics, ByVal fontFamily As FontFamily,
            ByVal fontStyle As FontStyle, ByVal width As Single, ByVal height As Single) As Single
            ' Binary search for the best size with at most MAX_ERROR error
            Const MAX_ERROR = 0.25F
            Dim curMin = 1.0F, curMax As Single = width
            Dim emSize = ((curMax - curMin) / 2.0F) + curMin
            Do While curMax - curMin > MAX_ERROR AndAlso curMin >= 1
                Using f As New Font(fontFamily, emSize, fontStyle)
                    Dim size = graphics.MeasureString(text, f)
                    Dim textFits = size.Width < width AndAlso size.Height < height
                    If textFits AndAlso emSize > curMin Then
                        curMin = emSize
                    ElseIf (Not textFits) AndAlso emSize < curMax Then
                        curMax = emSize
                    End If
                End Using
                emSize = ((curMax - curMin) / 2.0F) + curMin
            Loop
            Return curMin ' curMin is the size last known to fit completely, so we use that
        End Function
    End Class
End Namespace