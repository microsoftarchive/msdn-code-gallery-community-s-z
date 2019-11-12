'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: CurrentOrderWindow.xaml.vb
'
'--------------------------------------------------------------------------

Imports System.Collections.ObjectModel

Namespace AcmePizza
	''' <summary>
	''' Interaction logic for CurrentOrder.xaml
	''' </summary>
	Partial Public Class CurrentOrderWindow
		Inherits Window
		Private m_currentOrder As ObservableCollection(Of PizzaOrder)

		Public Sub New(ByVal order As PizzaOrder)
			InitializeComponent()
            ' Show the current order by binding to a collection of one.
			m_currentOrder = New ObservableCollection(Of PizzaOrder)()
			Me.DataContext = m_currentOrder
			m_currentOrder.Add(order)
		End Sub

		Private Sub Image_MouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Me.Close()
		End Sub

	End Class
End Namespace
