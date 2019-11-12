'FrmClodedXmlSample
Public Class FrmClosedXmlSample

    'I declare a variable of type bool, this variable is handled when the user 
    'select a row in the DataGrid control to allow you to erase and edit data
    Dim _checkifrowisselected As Boolean

    'FrmClosedXmlSampleLoad event
    Private Sub FrmClosedXmlSampleLoad(sender As System.Object, e As EventArgs) Handles MyBase.Load
        'This method loads the data into the control using the TableAdapter's Fill method,  
        'and then the DataGridView control is enhanced with the original data using the DataSource property
        LoadDataGrid()
    End Sub

    'LoadDataGrid Method
    Private Sub LoadDataGrid()
        'Load the data into the control TableAdapter
        USERDATATableAdapter.Fill(UserDataSet.USERDATA)
        'Load data with the DataGrid control
        dgvUserData.DataSource = USERDATABindingSource
    End Sub

    'BtnEsciClick event
    Private Sub BtnEsciClick(sender As System.Object, e As EventArgs) Handles btnEsci.Click
        'Close application
        Close()
    End Sub

    'BtnNewClick Event
    Private Sub BtnNuovoClick(sender As System.Object, e As EventArgs) Handles btnNuovo.Click
        'Insert this method does nothing but make the exploitation of fields of DataTable after inserting a new record into the table UserData
        USERDATATableAdapter.Insert(txtName.Text.ToUpper(), txtSurname.Text.ToUpper(), txtAddress.Text.ToUpper(), txtTelephoneNumber.Text.ToUpper(),
                                    txtCity.Text.ToUpper(), txtNationality.Text.ToUpper())

        'This method loads the data into the control using the TableAdapter's Fill method,  
        'and then the DataGridView control is enhanced with the original data using the DataSource property
        LoadDataGrid()
    End Sub

    'BtnDeleteClick Event
    Private Sub BtnEliminaClick(sender As System.Object, e As EventArgs) Handles btnElimina.Click
        'If not _checkifrowisselected equals false
        If Not _checkifrowisselected.Equals(False) Then
            'check if current row is not null
            If dgvUserData.CurrentRow Is Nothing Then
                Return
            End If

            'Delete this method does is erase the fields in the UserData table, execute the passing as argument the number of records that we select using the DataGridView control, 
            'before removal of the record, it checks to see if the user has selected or least one row of the DataGridView control
            USERDATATableAdapter.Delete(Integer.Parse(dgvUserData.CurrentRow.Cells(0).Value.ToString()))

            'This method loads the data into the control using the TableAdapter's Fill method, 
            'and then the DataGridView control is enhanced with the original data using the DataSource property
            LoadDataGrid()

            'set to false variable
            _checkifrowisselected = False
        Else
            'Visualize message to user
            MessageBox.Show(My.Resources.FrmClosedXmlSample_BtnDeleteClick_Select_one_row)
        End If
    End Sub

    'BtnUpdate Event
    Private Sub BtnModificaClick(sender As System.Object, e As EventArgs) Handles btnModifica.Click
        'If not _checkifrowisselected equals false
        If Not _checkifrowisselected.Equals(False) Then
            'Check if currentrow of DataGric is not null
            If dgvUserData.CurrentRow Is Nothing Then
                Return
            End If

            USERDATATableAdapter.Update(txtName.Text.ToUpper(), txtSurname.Text.ToUpper(), txtAddress.Text.ToUpper(), txtTelephoneNumber.Text.ToUpper(), txtCity.Text.ToUpper(), txtNationality.Text.ToUpper(), _
             Integer.Parse(dgvUserData.CurrentRow.Cells(0).Value.ToString()))

            'This method loads the data into the control using the TableAdapter's Fill method, 
            'and then the DataGridView control is enhanced with the original data using the DataSource property
            LoadDataGrid()

            'set to false variable
            _checkifrowisselected = False
        Else
            'Visualize message to user
            MessageBox.Show(My.Resources.FrmClosedXmlSample_BtnDeleteClick_Select_one_row)
        End If
    End Sub

    'BtnReportClick Event
    Private Sub BtnReportClick(sender As System.Object, e As EventArgs) Handles btnReport.Click
        'I declare a new instance of the Form Frmeport
        Dim frm = New FrmReport
        'Pass data form dgvUserData to Datagrin in FrmReport
        frm.FrmReport(dgvUserData)
        'I'm seeing the Forms user
        frm.Show()
    End Sub

    'BtnFindClick Event
    Private Sub BtnFindClick(sender As System.Object, e As EventArgs) Handles btnFind.Click
        'I get the currently selected text to the ComboBox control*/
        Dim selecteditems = cbxFind.Text

        'Executing the control of the variable SelectedItems with a Switch construct
        Select Case selecteditems
            'if equals "NAME"
            Case "NAME"
                'I run a query LinqToDataSet with extension method and recover all data from the UserData table and visualize the DataGrid control
                Dim queryname = UserDataSet.USERDATA.Where(Function(f) f.NAME.StartsWith(txtName.Text.ToUpper)).Select(Function(f) New With {f.NAME _
                                , f.SURNAME, f.ADDRESS, f.TELEPHONE, f.CITY, f.NATIONALITI})
                dgvUserData.DataSource = queryname.ToArray

                'if eqUals "CITY"
            Case "CITY"
                'I run a query LinqToDataSet with extension method and recover all data from the UserData table and visualize the DataGrid control
                Dim querycity = UserDataSet.USERDATA.Where(Function(f) f.NAME.StartsWith(txtCity.Text.ToUpper)).Select(Function(f) New With {f.NAME _
                                , f.SURNAME, f.ADDRESS, f.TELEPHONE, f.CITY, f.NATIONALITI})
                dgvUserData.DataSource = querycity.ToArray

                'if eqUals "NATIONALITY"
            Case "NATIONALITY"
                'I run a query LinqToDataSet with extension method and recover all data from the UserData table and visualize the DataGrid control
                Dim querynationality = UserDataSet.USERDATA.Where(Function(f) f.NAME.StartsWith(txtNationality.Text.ToUpper)).Select(Function(f) New With {f.NAME _
                , f.SURNAME, f.ADDRESS, f.TELEPHONE, f.CITY, f.NATIONALITI})
                dgvUserData.DataSource = querynationality.ToArray
        End Select

    End Sub

    'CbxFindSelectedIndexChanged event
    Private Sub CbxFindSelectedIndexChanged(sender As System.Object, e As EventArgs) Handles cbxFind.SelectedIndexChanged
        'I get the currently selected text to the ComboBox control*/
        Dim selecteditems = cbxFind.Text

        'Using a query LinqToObjects reimposed the Enabled property to true for all the text boxes on the form
        For Each c In Controls.OfType(Of TextBox)()
            c.Enabled = True
        Next

        'Executing the control of the variable SelectedItems with a Switch construct
        Select Case selecteditems
            'if equals "NAME"
            Case "NAME"
                'I run a query linq to objects and imposed enable the property if different from the text box specified
                For Each c In From c1 In Controls.OfType(Of TextBox)() Where Not c1.Name.Equals(txtName.Name)
                    c.Enabled = False
                Next

                'if equals "SURNAME"
            Case "SURNAME"
                'I run a query linq to objects and imposed enable the property if different from the text box specified
                For Each c In From c1 In Controls.OfType(Of TextBox)() Where Not c1.Name.Equals(txtSurname.Name)
                    c.Enabled = False
                Next

                'if equals "ADDRESS"
            Case "ADDRESS"
                'I run a query linq to objects and imposed enable the property if different from the text box specified
                For Each c In From c1 In Controls.OfType(Of TextBox)() Where Not c1.Name.Equals(txtAddress.Name)
                    c.Enabled = False
                Next

                'if equals "TELEPHONE"
            Case "TELEPHONENUMBER"
                'I run a query linq to objects and imposed enable the property if different from the text box specified
                For Each c In From c1 In Controls.OfType(Of TextBox)() Where Not c1.Name.Equals(txtTelephoneNumber.Name)
                    c.Enabled = False
                Next

                'if eqUals "CITY"
            Case "CITY"
                'I run a query linq to objects and imposed enable the property if different from the text box specified
                For Each c In From c1 In Controls.OfType(Of TextBox)() Where Not c1.Name.Equals(txtCity.Name)
                    c.Enabled = False
                Next
                'if eqUals "NATIONALITY"
            Case "NATIONALITY"
                'I run a query linq to objects and imposed enable the property if different from the text box specified
                For Each c In From c1 In Controls.OfType(Of TextBox)() Where Not c1.Name.Equals(txtNationality.Name)
                    c.Enabled = False
                Next
        End Select

    End Sub
End Class