'--------------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved. 
' 
'  File: PizzaOrder.vb
'
'--------------------------------------------------------------------------

Namespace AcmePizza
	Public Enum PizzaToppings
		Mushrooms
		Olives
		Sausage
		Pepperoni
		Cheese
		Onions
		BellPeppers
		Bacon
		Chicken
		Artichokes
	End Enum

	Public Enum OrderSource
		Phone
		Internet
		WalkIn
		Fax
	End Enum

	Public Structure PizzaOrder
		Public Property Source() As OrderSource
		Public Property PhoneNumber() As String
		Public Property Size() As Integer
		Public Property IsDelivery() As Boolean
		Public Property Toppings() As PizzaToppings()
	End Structure
End Namespace
