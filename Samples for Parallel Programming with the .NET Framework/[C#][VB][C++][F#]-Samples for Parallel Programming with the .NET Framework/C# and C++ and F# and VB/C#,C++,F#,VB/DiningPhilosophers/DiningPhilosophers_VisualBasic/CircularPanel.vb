'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: CircularPanel.xaml.vb
'
'--------------------------------------------------------------------------


Namespace DiningPhilosophers
	Public Class CircularPanel
		Inherits Panel
		Protected Overrides Function MeasureOverride(ByVal availableSize As Size) As Size
			Dim maxChildSize = New Size()
            For Each child As UIElement In InternalChildren
                child.Measure(availableSize)
                If maxChildSize.Width < child.DesiredSize.Width Then
                    maxChildSize.Width = child.DesiredSize.Width
                End If
                If maxChildSize.Height < child.DesiredSize.Height Then
                    maxChildSize.Height = child.DesiredSize.Height
                End If
            Next child
			Return maxChildSize
		End Function

		Protected Overrides Function ArrangeOverride(ByVal finalSize As Size) As Size
			Dim children = InternalChildren.OfType(Of UIElement)().ToArray()
			If children.Length > 0 Then
                Dim midPanel = New Point(finalSize.Width / 2, finalSize.Height / 2)
				Dim maxChild = New Size(children.Max(Function(u) u.DesiredSize.Width), children.Max(Function(u) u.DesiredSize.Height))
				Dim radius = New Size((finalSize.Width - maxChild.Width) / 2, (finalSize.Height - maxChild.Height) / 2)
                Dim arcRadiansPerChild = Math.PI * 2 / children.Length

                Dim curPos = 0
				For Each child In children
					Dim childAngleInRadians = curPos * arcRadiansPerChild
                    Dim childPosition = New Point((Math.Sin(childAngleInRadians) * radius.Width) + (midPanel.X - (child.DesiredSize.Width / 2)),
                                                  (Math.Cos(childAngleInRadians) * radius.Height) + (midPanel.Y - (child.DesiredSize.Height / 2)))
					child.Arrange(New Rect(childPosition, child.DesiredSize))
					curPos += 1
				Next child
			End If
			Return finalSize
		End Function
	End Class
End Namespace