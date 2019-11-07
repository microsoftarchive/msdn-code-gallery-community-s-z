'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: Window1.xaml.vb
'
'--------------------------------------------------------------------------

Imports System.Collections.Concurrent
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows

Namespace AcmePizza
	''' <summary>
    ''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Private m_orders As IProducerConsumerCollection(Of PizzaOrder)
		Private Shared m_rand As Random = New ThreadSafeRandom()

		Public Sub New()
			InitializeComponent()

            ' Intialize the bindable collection and set it as the data context.
			Dim orders = New ObservableConcurrentCollection(Of PizzaOrder)()
            ' Store the observable collection as an explicity producer consumer.
            ' Collection that has tryadd and tryremove operations.
			m_orders = orders
            ' Set the AcmePizza as the defaut.
			Me.DataContext = orders
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As EventArgs)
            ' Launch four threads that mimic various sources
            With Task.Factory
                .StartNew(Sub() OrdererThread(OrderSource.Fax), TaskCreationOptions.AttachedToParent)
                .StartNew(Sub() OrdererThread(OrderSource.Internet), TaskCreationOptions.AttachedToParent)
                .StartNew(Sub() OrdererThread(OrderSource.Phone), TaskCreationOptions.AttachedToParent)
                .StartNew(Sub() OrdererThread(OrderSource.WalkIn), TaskCreationOptions.AttachedToParent)
            End With
        End Sub

		Private Sub OrdererThread(ByVal source As OrderSource)
            For i = 0 To 9
                ' Submit random order.
                m_orders.TryAdd(GenerateRandomOrder(source))
                ' Sleep for a random period.
                Thread.Sleep(m_rand.Next(1000, 4001))
            Next i
		End Sub

		Private Shared Function GenerateRandomOrder(ByVal source As OrderSource) As PizzaOrder
            ' Source.
            Dim order = New PizzaOrder With {.Source = source}
            ' Delivery.
			order.IsDelivery = If(m_rand.Next(0, 2) = 0, True, False)
            ' Phone number.
			Dim areaCode = If(m_rand.Next(0, 2) = 0, 425, 206)
			Dim firstThreeDigits = m_rand.Next(100, 1000)
			Dim lastFourDigits = m_rand.Next(0, 10000)
			order.PhoneNumber = String.Format("({0}) {1}-{2}", areaCode, firstThreeDigits, lastFourDigits.ToString("D4"))
            ' Size.
			Select Case m_rand.Next(0, 3)
				Case 0
					order.Size = 11
				Case 1
					order.Size = 13
				Case 2
					order.Size = 17
			End Select
            ' Toppings.
			Dim availToppings = New List(Of PizzaToppings)(System.Enum.GetValues(GetType(PizzaToppings)).Cast(Of PizzaToppings)())
			order.Toppings = New PizzaToppings(m_rand.Next(1, 5) - 1){}
            For j = 0 To order.Toppings.Length - 1
                Dim toppingIndex = m_rand.Next(0, availToppings.Count)
                order.Toppings(j) = availToppings(toppingIndex)
                availToppings.RemoveAt(toppingIndex)
            Next j
			Return order
		End Function

		Private Sub processNextOrderButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Attempt to get an order from the queue.
            ' Dim nextOrder As PizzaOrder.
            Dim nextOrder = New PizzaOrder()
            If Not m_orders.TryTake(nextOrder) Then
                MsgBox("No orders available.  Please try again later.")
                Return
            End If
            ' If successful launch an order window.
			Dim currentOrderWindow = New CurrentOrderWindow(nextOrder)
			currentOrderWindow.Show()
		End Sub
	End Class
End Namespace