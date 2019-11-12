'Public Class MyShoppingCart

'End Class

Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports ShoppingCartFinal.Data_Access
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Security
Imports Microsoft.VisualBasic.ApplicationServices



'--------------------------------------------------------------------------------------------------------------------------------------------------+
' TODO: In a future version of this application we will seperate this logic into a seperate Business Objets Layer
'--------------------------------------------------------------------------------------------------------------------------------------------------+

Public Structure ShoppingCartUpdates
    Public ProductId As Integer
    Public PurchaseQuantity As Integer
    Public RemoveItem As Boolean
End Structure


Partial Public Class MyShoppingCart
    Public Const CartId As String = "TailSpinSpyWorks_CartID"

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Function GetShoppingCartId() As [String]
        If System.Web.HttpContext.Current.Session(CartId) Is Nothing Then
            System.Web.HttpContext.Current.Session(CartId) = If(System.Web.HttpContext.Current.Request.IsAuthenticated, System.Web.HttpContext.Current.User.Identity.Name, Guid.NewGuid().ToString())
        End If
        Return System.Web.HttpContext.Current.Session(CartId).ToString()
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Function GetTotal(cartID As String) As Decimal

        Using db As New CommerceEntities()
            Dim cartTotal As Decimal = 0
            Try
                Dim myCart = (From c In db.ViewCarts Where c.CartID = cartID Select c)
                If myCart.Count() > 0 Then
                    cartTotal = myCart.Sum(Function(od) CDec(od.Quantity) * CDec(od.UnitCost))
                End If
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Calculate Order Total - " & exp.Message.ToString(), exp)
            End Try
            Return (cartTotal)
        End Using
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Sub RemoveItem(cartID As String, productID As Integer)
        Using db As New CommerceEntities()
            Try
                Dim myItem = (From c In db.ShoppingCarts Where c.CartID = cartID AndAlso c.ProductID = productID Select c).FirstOrDefault()
                If myItem IsNot Nothing Then
                    db.DeleteObject(myItem)
                    db.SaveChanges()

                End If
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Remove Cart Item - " & exp.Message.ToString(), exp)
            End Try
        End Using

    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Sub UpdateItem(cartID As String, productID As Integer, quantity As Integer)
        Using db As New CommerceEntities()
            Try
                Dim myItem = (From c In db.ShoppingCarts Where c.CartID = cartID AndAlso c.ProductID = productID Select c).FirstOrDefault()
                If myItem IsNot Nothing Then
                    myItem.Quantity = quantity
                    db.SaveChanges()
                End If
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Update Cart Item - " & exp.Message.ToString(), exp)
            End Try
        End Using

    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Sub UpdateShoppingCartDatabase(cartId As [String], CartItemUpdates As ShoppingCartUpdates())
        Using db As New CommerceEntities()
            Try
                Dim CartItemCOunt As Integer = CartItemUpdates.Count()
                Dim myCart = (From c In db.ViewCarts Where c.CartID = cartId Select c)
                For Each cartItem As ViewCart In myCart
                    ' Iterate through all rows within shopping cart list
                    For i As Integer = 0 To CartItemCOunt - 1
                        If cartItem.ProductID = CartItemUpdates(i).ProductId Then
                            If CartItemUpdates(i).PurchaseQuantity < 1 OrElse CartItemUpdates(i).RemoveItem = True Then
                                RemoveItem(cartId, cartItem.ProductID)
                            Else
                                UpdateItem(cartId, cartItem.ProductID, CartItemUpdates(i).PurchaseQuantity)
                            End If
                        End If
                    Next
                Next
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Update Cart Database - " & exp.Message.ToString(), exp)
            End Try
        End Using
    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Sub AddItem(cartID As String, productID As Integer, quantity As Integer)
        Using db As New CommerceEntities()
            Try
                Dim myItem = (From c In db.ShoppingCarts Where c.CartID = cartID AndAlso c.ProductID = productID Select c).FirstOrDefault()
                If myItem Is Nothing Then
                    Dim cartadd As New ShoppingCart()
                    cartadd.CartID = cartID
                    cartadd.Quantity = quantity
                    cartadd.ProductID = productID
                    cartadd.DateCreated = DateTime.Now
                    db.ShoppingCarts.AddObject(cartadd)
                Else
                    myItem.Quantity += quantity
                End If

                db.SaveChanges()
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Add Item to Cart - " & exp.Message.ToString(), exp)
            End Try
        End Using

    End Sub

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Function SubmitOrder(UserName As String) As Boolean
        Using db As New CommerceEntities()
            Try
                '------------------------------------------------------------------------+
                '  Add New Order Record                                                  |
                '------------------------------------------------------------------------+
                Dim newOrder As New Order()
                newOrder.CustomerName = UserName
                newOrder.OrderDate = DateTime.Now
                newOrder.ShipDate = CalculateShipDate()
                db.Orders.AddObject(newOrder)
                db.SaveChanges()

                '------------------------------------------------------------------------+
                '  Create a new OderDetail Record for each item in the Shopping Cart     |
                '------------------------------------------------------------------------+
                Dim cartId As [String] = GetShoppingCartId()
                Dim myCart = (From c In db.ViewCarts Where c.CartID = cartId Select c)
                For Each item As ViewCart In myCart
                    Dim i As Integer = 0
                    If i < 1 Then
                        Dim od As New OrderDetail()
                        od.OrderID = newOrder.OrderID
                        od.ProductID = item.ProductID
                        od.Quantity = item.Quantity
                        od.UnitCost = item.UnitCost
                        db.OrderDetails.AddObject(od)
                        i += 1
                    End If

                    Dim myItem = (From c In db.ShoppingCarts Where c.CartID = item.CartID AndAlso c.ProductID = item.ProductID Select c).FirstOrDefault()
                    If myItem IsNot Nothing Then
                        db.DeleteObject(myItem)
                    End If
                Next
                db.SaveChanges()
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Submit Order - " & exp.Message.ToString(), exp)
            End Try
        End Using

        Return (True)
    End Function


    '------------------------------------------------------------------------------------------------------------------------------------------+
    Private Function CalculateShipDate() As DateTime
        Dim shipDate As DateTime = DateTime.Now.AddDays(2)
        Return (shipDate)
    End Function

    '------------------------------------------------------------------------------------------------------------------------------------------+
    Public Sub MigrateCart(oldCartId As [String], UserName As [String])
        Using db As New CommerceEntities()
            Try
                Dim myShoppingCart = From cart In db.ShoppingCarts Where cart.CartID = oldCartId Select cart

                For Each item As ShoppingCart In myShoppingCart
                    item.CartID = UserName
                Next
                db.SaveChanges()
                System.Web.HttpContext.Current.Session(CartId) = UserName
            Catch exp As Exception
                Throw New Exception("ERROR: Unable to Migrate Shopping Cart - " & exp.Message.ToString(), exp)
            End Try
        End Using
    End Sub
End Class

