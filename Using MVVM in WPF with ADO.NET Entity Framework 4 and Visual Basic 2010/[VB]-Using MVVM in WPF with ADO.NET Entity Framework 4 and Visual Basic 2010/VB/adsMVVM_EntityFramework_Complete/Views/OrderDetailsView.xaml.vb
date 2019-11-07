Public Class OrderDetailsView

    Private _orderID As Integer
    Private WithEvents OrderDetailsVM As OrderDetailsViewModel

    Sub New(ByVal OrderID As Integer)
        InitializeComponent()
        ' TODO: Complete member initialization 
        Me._orderID = OrderID
    End Sub

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Me.Title = "Order details for order nr. " & Me._orderID.ToString
        Me.OrderDetailsVM = New OrderDetailsViewModel(_orderID)
        Me.DataContext = Me.OrderDetailsVM

        Application.Msn.Register(Application.VIEW_DETAILS_CLOSE, Sub()
                                                                     Me.Close()
                                                                 End Sub)
    End Sub
End Class
