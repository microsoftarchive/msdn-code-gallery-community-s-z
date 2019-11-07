Imports DataOperations_vb

Public Class CustomerForm
    Private inAddMode As Boolean
    Private stateItems As List(Of StateItems)
    Private CustomerRow As DataRow
    'currentRow
    Private formTextBoxes As New List(Of TextBox)
    Public Sub New(ByVal AddMode As Boolean, stateInfo As List(Of StateItems), ByRef currentRow As DataRow)
        InitializeComponent()
        inAddMode = AddMode
        stateItems = stateInfo
        CustomerRow = currentRow
    End Sub
    Public Sub New(ByVal AddMode As Boolean, stateInfo As List(Of StateItems))
        InitializeComponent()
        inAddMode = AddMode
        stateItems = stateInfo
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub CustomerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formTextBoxes.AddRange(Controls.OfType(Of TextBox).ToArray)

        cboStates.DataSource = stateItems
        cboStates.DisplayMember = "Name"

        If inAddMode Then
            Text = "Adding new customer"
        Else
            Text = "Editing current customer"

            txtFirstName.Text = CustomerRow.Field(Of String)("FirstName")
            txtLastName.Text = CustomerRow.Field(Of String)("LastName")
            txtAddress.Text = CustomerRow.Field(Of String)("Address")
            txtCity.Text = CustomerRow.Field(Of String)("City")
            txtZipCode.Text = CustomerRow.Field(Of String)("ZipCode")

            Dim currentState As String = CustomerRow.Field(Of String)("State")

            Dim customerState = stateItems.Select(Function(data, index) New With {.Index = index, .Name = data.Name}) _
                .Where(Function(data) data.Name = CustomerRow.Field(Of String)("State")).FirstOrDefault

            If currentState IsNot Nothing Then
                cboStates.SelectedIndex = customerState.Index
            End If
        End If
    End Sub
    ''' <summary>
    ''' For this sample we are requiring all fields to be populated so a check is made to ensure
    ''' this, if the validation fails we present them with a message dialog, otherwise close the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdAccept_Click(sender As Object, e As EventArgs) Handles cmdAccept.Click
        If formTextBoxes.Where(Function(textBox) String.IsNullOrWhiteSpace(textBox.Text)).Any OrElse cboStates.SelectedIndex = 0 Then
            MessageBox.Show("To save a record all fields must have information along with selecting a state.")
            Exit Sub
        Else
            If Not inAddMode Then
                ' remember we pass the data row by ref so these changes take affect to the UI but not the backend database table
                ' so we will handle this in the mainform.
                CustomerRow.SetField(Of String)("FirstName", txtFirstName.Text)
                CustomerRow.SetField(Of String)("LastName", txtLastName.Text)
                CustomerRow.SetField(Of String)("Address", txtAddress.Text)
                CustomerRow.SetField(Of String)("City", txtCity.Text)
                CustomerRow.SetField(Of String)("State", cboStates.Text)
                CustomerRow.SetField(Of String)("ZipCode", txtZipCode.Text)

            End If

            DialogResult = DialogResult.OK

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CustomerRow.RejectChanges()
        DialogResult = DialogResult.Cancel
    End Sub
End Class