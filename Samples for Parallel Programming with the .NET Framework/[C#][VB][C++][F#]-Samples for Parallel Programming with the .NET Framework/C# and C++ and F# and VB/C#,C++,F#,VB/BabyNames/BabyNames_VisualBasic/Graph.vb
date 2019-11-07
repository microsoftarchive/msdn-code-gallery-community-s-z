'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Graph.vb
'
'--------------------------------------------------------------------------


Namespace BabyNames
	Public Class Graph
		Inherits Control
		Shared Sub New()
			DefaultStyleKeyProperty.OverrideMetadata(GetType(Graph), New FrameworkPropertyMetadata(GetType(Graph)))
		End Sub

		Private _babyResults As List(Of BabyInfo)
        Private _minYear As Integer = -1, _maxYear As Integer = -1, _maxValue As Integer = -1

		Friend Sub Configure(ByVal babyResults As List(Of BabyInfo))
			_babyResults = babyResults
			If _babyResults IsNot Nothing AndAlso _babyResults.Count > 0 Then
				_maxValue = _babyResults.Max(Function(b) b.Count)
				_minYear = _babyResults.Min(Function(b) b.Year)
				_maxYear = _babyResults.Max(Function(b) b.Year)
			End If
		End Sub

		Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
			MyBase.OnInitialized(e)
			ToolTip = New ToolTip With {.Content = "Results"}
		End Sub

		Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
			MyBase.OnMouseMove(e)
			If _minYear >= 0 AndAlso _maxYear >= 0 AndAlso _maxValue >= 0 Then
                Dim s = RenderSize
                Dim p = e.GetPosition(Me)
                Dim year = _minYear + CInt(Fix((CType((p.X), Long) \ CType((s.Width), Long)) * (_maxYear - _minYear)))

                Dim tt = CType(Me.ToolTip, ToolTip)
				tt.Content = "Year: " & year
				tt.Visibility = Visibility.Visible
			End If
		End Sub

		Protected Overrides Sub OnRender(ByVal drawingContext As DrawingContext)
			MyBase.OnRender(drawingContext)

			' Draw the babies
			If _babyResults IsNot Nothing AndAlso _babyResults.Count > 0 Then
                Dim width = CInt(Fix(RenderSize.Width)), height As Integer = CInt(Fix(RenderSize.Height))

				If _minYear <> _maxYear Then
					' Note: X axis is years, Y axis is the counts per year.
					' These are the dimensions everything will be scaled to.
                    Dim per_x = CSng(width) / (_maxYear - _minYear), per_y As Single = CSng(height) / _maxValue

					' Draw axis lines:
					Dim paxis As New Pen(New SolidColorBrush(Color.FromArgb(128, 128, 128, 128)), 1)
                    For i = (height \ 10) To height - 1 Step (height \ 10)
                        drawingContext.DrawLine(paxis, New Point(0, i), New Point(width, i))
                    Next i
                    Dim xvalues = (_maxYear - _minYear)
                    Dim xincrement = CSng(width) / xvalues
                    For i = xincrement To width - 1 Step xincrement
                        drawingContext.DrawLine(paxis, New Point(i, 0), New Point(i, height))
                    Next i

					' Draw data:
					Dim p As New Pen(New SolidColorBrush(Colors.White), 4)
                    Dim curr_x = 0.0F, curr_y = 0.0F, last_x As Single = -1, last_y As Single = -1
                    Dim last_year = -1

                    For Each b In _babyResults
                        If b.Year <> last_year Then
                            curr_x = (b.Year - _minYear) * per_x
                            curr_y = height - (b.Count * per_y)
                            If last_x <> -1 AndAlso last_y <> -1 Then
                                drawingContext.DrawLine(p, New Point(curr_x, height), New Point(curr_x, curr_y))
                            End If
                            last_x = curr_x
                            last_y = curr_y
                            last_year = b.Year
                        End If
                    Next b
				End If
			End If
		End Sub
	End Class
End Namespace
