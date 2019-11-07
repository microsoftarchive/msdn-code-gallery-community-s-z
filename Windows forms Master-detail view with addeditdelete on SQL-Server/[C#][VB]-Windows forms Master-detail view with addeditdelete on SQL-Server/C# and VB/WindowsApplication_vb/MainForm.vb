Imports DataOperations_vb

''' <summary>
''' Notes
''' * The child/order DataGridView shows a button on each row, it's possible to do it only for the visible row
'''   but that is outside this code sample.
''' * The child DataGridView makes use of a Calendar column for Order Dates field
''' </summary>
Public Class MainForm
    ''' <summary>
    ''' Containers for our customer and orders data
    ''' which are setup in Operations class.
    ''' </summary>
    WithEvents bsMaster As New BindingSource()
    WithEvents bsDetails As New BindingSource()
    WithEvents bsOrderDetails As New BindingSource

    Private StateInformation As List(Of StateItems)

    ''' <summary>
    ''' Load add data from customer and details tables
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ops As New Operations

        ops.LoadData()

        If Not ops.HasErrors Then

            StateInformation = ops.StateInformation

            bsMaster = ops.Master
            bsDetails = ops.Details

            MasterDataGridView.DataSource = bsMaster
            DetailsDataGridView.AutoGenerateColumns = False

            DetailsDataGridView.DataSource = bsDetails
            OrderDateColumn.ReadOnly = False
            UpdateButtonColumn.UseColumnTextForButtonValue = True

            MasterBindingNavigator.BindingSource = bsMaster

            bsOrderDetails = ops.OrderDetails

            OrderDetailsDataGridView.DataSource = bsOrderDetails
            OrderDetailsDataGridView.Columns("id").Visible = False
            OrderDetailsDataGridView.Columns("OrderId").Visible = False

            DetailBindingNavigator.BindingSource = bsDetails

            OrderDetailsDataGridView.Columns("ProductName").HeaderText = "Product"
            OrderDetailsDataGridView.Columns("UnitPrice").HeaderText = "Unit price"

        Else
            MessageBox.Show(ops.ExceptionMessage)
        End If

    End Sub
    ''' <summary>
    ''' Startup code for edting the current customer.
    ''' I advice to popup a dialog to edit, if user accepts changes
    ''' then you write code in Operations class to update the backend database table
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MasterDataGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles MasterDataGridView.KeyDown
        If e.KeyData = Keys.Enter Then

            e.Handled = True
            EditCurrentCustomer()
        End If
    End Sub
    ''' <summary>
    ''' master BindingNavigator edit button click event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BindingNavigatorEditCustomer_Click(sender As Object, e As EventArgs) Handles MasterBindingNavigatorEditCustomer.Click
        EditCurrentCustomer()
    End Sub
    ''' <summary>
    ''' Point of entry for editing current customer from either
    ''' a button on the BindingNavigator or pressing the enter key
    ''' on the master DataGridView
    ''' </summary>
    Private Sub EditCurrentCustomer()
        Dim CustomerRow As DataRow = CType(bsMaster.Current, DataRowView).Row
        Dim f As New CustomerForm(False, StateInformation, CustomerRow)

        Try
            If f.ShowDialog() = DialogResult.OK Then
                Dim ops As New Operations
                If Not ops.UpdateCustomer(CustomerRow) Then
                    MessageBox.Show($"Failed to update: {ops.ExceptionMessage}")
                End If
            End If
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles MasterBindingNavigatorAddNewItem.Click

        Dim f As New CustomerForm(True, StateInformation)

        Try

            If f.ShowDialog() = DialogResult.OK Then

                Dim ops As New Operations
                Dim NewId As Integer = 0

                If ops.AddCustomer(f.txtFirstName.Text, f.txtLastName.Text, f.txtAddress.Text, f.txtCity.Text, f.cboStates.Text, f.txtZipCode.Text, NewId) Then
                    Dim dt = CType(bsMaster.DataSource, DataSet).Tables("Customer")
                    dt.Rows.Add(New Object() {NewId, f.txtFirstName.Text, f.txtLastName.Text, f.txtAddress.Text, f.txtCity.Text, f.cboStates.Text, f.txtZipCode.Text})
                Else
                    MessageBox.Show($"Failed to add new row: {ops.ExceptionMessage}")
                End If
            End If

        Finally
            f.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' Remove current customer and all orders
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BindingNavigatorDeleteCustomer_Click(sender As Object, e As EventArgs) Handles MasterBindingNavigatorDeleteCustomer.Click

        If My.Dialogs.Question("Do you really want to remove this customer and all their orders?") Then
            Dim ops As New Operations
            Dim CustomerId As Integer = CType(bsMaster.Current, DataRowView).Row.Field(Of Integer)("id")
            If ops.RemoveCustomerAndOrders(CustomerId) Then
                bsMaster.RemoveCurrent()
            Else
                MessageBox.Show($"Failed to remove data{Environment.NewLine}{ops.ExceptionMessage}")
            End If
        End If

    End Sub
    ''' <summary>
    ''' Update the order date for current row. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' It's possible that there are no changes but for this code sample there is no check.
    ''' If you wanted to implement this refer to DataTable events to peek at the current and
    ''' proposed value for, in this case the data column.
    ''' See my code sample on this
    ''' https://code.msdn.microsoft.com/Working-with-DataTable-2ff5f158
    ''' </remarks>
    Private Sub DetailsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DetailsDataGridView.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            If bsDetails.Current IsNot Nothing Then

                Dim OrderDate As Date = CType(bsDetails.Current, DataRowView).Row.Field(Of Date)("OrderDate")
                Dim OrderId As Integer = CType(bsDetails.Current, DataRowView).Row.Field(Of Integer)("id")

                Dim ops As New Operations

                If Not ops.UpdateOrder(OrderId, OrderDate) Then
                    MessageBox.Show($"Failed to update: {ops.ExceptionMessage}")
                End If

            End If
        End If
    End Sub
    ''' <summary>
    ''' Edit current order date
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DetailsDataGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles DetailsDataGridView.KeyDown

        If e.KeyData = Keys.Enter Then

            e.Handled = True

            If bsDetails.Current IsNot Nothing Then
                Dim f As New OrderForm
                Try
                    Dim OrderDate As Date = CType(bsDetails.Current, DataRowView).Row.Field(Of Date)("OrderDate")
                    f.DateTimePicker1.Value = OrderDate

                    If f.ShowDialog = DialogResult.OK Then

                        OrderDate = f.DateTimePicker1.Value

                        Dim OrderId As Integer = CType(bsDetails.Current, DataRowView).Row.Field(Of Integer)("id")
                        Dim ops As New Operations

                        If Not ops.UpdateOrder(OrderId, OrderDate) Then
                            MessageBox.Show($"Failed to update: {ops.ExceptionMessage}")
                        Else
                            CType(bsDetails.Current, DataRowView).Row.SetField(Of Date)("OrderDate", OrderDate)
                        End If
                    End If

                Finally
                    f.Dispose()
                End Try
                'MessageBox.Show($"Edit this row {String.Join(",", CType(bsDetails.Current, DataRowView).Row.ItemArray)}")
            End If

        End If
    End Sub
    ''' <summary>
    ''' Add a new order
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DetailsBindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles DetailsBindingNavigatorAddNewItem.Click

        Dim f As New OrderForm

        Try
            If f.ShowDialog = DialogResult.OK Then
                Dim id As Integer = 0
                Dim CurrentCustomerId As Integer = CType(bsMaster.Current, DataRowView).Row.Field(Of Integer)("id")
                Dim InvoiceValue As String = ""
                Dim ops As New Operations

                ops.AddOrder(CurrentCustomerId, f.DateTimePicker1.Value, InvoiceValue, id)

                If Not ops.HasErrors Then
                    Dim detailTable As DataTable = CType(CType(bsDetails.DataSource, BindingSource).DataSource, DataSet).Tables("Orders")
                    detailTable.Rows.Add(New Object() {id, CurrentCustomerId, Now, InvoiceValue})
                Else
                    MessageBox.Show(ops.ExceptionMessage)
                End If

            End If
        Finally
            f.Dispose()
        End Try
    End Sub
    Private Sub DetailsBindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles DetailsBindingNavigatorDeleteItem.Click
        If My.Dialogs.Question("Remove this order?") Then

            Dim OrderId As Integer = CType(bsDetails.Current, DataRowView).Row.Field(Of Integer)("id")

            Dim ops As New Operations

            If Not ops.RemoveSingleOrder(OrderId) Then
                MessageBox.Show($"Failed to update: {ops.ExceptionMessage}")
            Else
                bsDetails.RemoveCurrent()
            End If

        End If
    End Sub

End Class
