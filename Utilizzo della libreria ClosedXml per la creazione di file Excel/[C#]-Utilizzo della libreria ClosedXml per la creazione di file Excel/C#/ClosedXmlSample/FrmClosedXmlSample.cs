//dll net framework
using System;
using System.Linq;
using System.Windows.Forms;

//NameSpace ClosedXlmSample
namespace ClosedXmlSample
{
    //FrmClosedXml Class
    public partial class FrmClosedXmlSample : Form
    {
        /*I declare a variable of type bool, this variable is handled when the user
         *select a row in the DataGrid control to allow you to erase and edit data*/
        private bool _checkifrowisselected ;
        
        // Constructor of the class FrmClosedXmlSample
        public FrmClosedXmlSample()
        {
            //InitializeComponent Method
            InitializeComponent();
        }

        //FrmClosedXmlSampleLoad Event
        private void FrmClosedXmlSampleLoad(object sender, EventArgs e)
        {
            /*This method loads the data into the control using the TableAdapter's Fill method, 
            and then the DataGridView control is enhanced with the original data using the DataSource property*/
            LoadDataGrid();
        }

        //BtnNewClick Event
        private void BtnNewClick(object sender, EventArgs e)
        {
            /*Insert this method does nothing but make the exploitation of fields of DataTable after inserting a new record into the table UserData*/
            uSERDATATableAdapter.Insert(txtName.Text.ToUpper(), txtSurname.Text.ToUpper(), txtAddress.Text.ToUpper(), txtTelephoneNumber.Text.ToUpper(),
                                        txtCity.Text.ToUpper(), txtNationality.Text.ToUpper());
            
            /*This method loads the data into the control using the TableAdapter's Fill method, 
            and then the DataGridView control is enhanced with the original data using the DataSource property*/
            LoadDataGrid();
        }

        //BtnDeleteClick Event
        private void BtnDeleteClick(object sender, EventArgs e)
        {
            /*If not _checkifrowisselected equals false*/
            if(!_checkifrowisselected.Equals(false))
            {
                /*check if current row is not null*/
                if (dgvUserData.CurrentRow == null) return;

                /*Delete this method does is erase the fields in the UserData table, execute the passing as argument the number of records that we select using the DataGridView control, 
                 *before removal of the record, it checks to see if the user has selected or least one row of the DataGridView control*/
                uSERDATATableAdapter.Delete(int.Parse(dgvUserData.CurrentRow.Cells[0].Value.ToString()));

                /*This method loads the data into the control using the TableAdapter's Fill method, 
                and then the DataGridView control is enhanced with the original data using the DataSource property*/
                LoadDataGrid();

                /*set to false variable*/
                _checkifrowisselected = false;
            }

            else
            {
                /*Visualize message to user*/
                MessageBox.Show(Properties.Resources.FrmClosedXmlSample_BtnDeleteClick_Select_one_row);
            }
        }

        //BtnUpdate Event
        private void BtnUpdateClick(object sender, EventArgs e)
        {
            /*If not _checkifrowisselected equals false*/
            if (!_checkifrowisselected.Equals(false))
            {

                /*Check if currentrow of DataGric is not null*/
                if (dgvUserData.CurrentRow == null) return;

                uSERDATATableAdapter.Update(txtName.Text.ToUpper(), txtSurname.Text.ToUpper(), txtAddress.Text.ToUpper(),
                                            txtTelephoneNumber.Text.ToUpper(),
                                            txtCity.Text.ToUpper(), txtNationality.Text.ToUpper(),
                                            int.Parse(dgvUserData.CurrentRow.Cells[0].Value.ToString()));

                /*This method loads the data into the control using the TableAdapter's Fill method, 
                    and then the DataGridView control is enhanced with the original data using the DataSource property*/
                LoadDataGrid();

                /*set to false variable*/
                _checkifrowisselected = false;
            }

            else
            {
                /*Visualize message to user*/
                MessageBox.Show(Properties.Resources.FrmClosedXmlSample_BtnDeleteClick_Select_one_row);
            }
        }

        //BtnReportClick Event
        private void BtnReportClick(object sender, EventArgs e)
        {
            /*I declare a new instance of the Form Frmeport*/
            var frm = new FrmReport {DataReport = dgvUserData};
            /*I'm seeing the Forms user*/
            frm.Show();
        }

        //BtnExitClick Event
        private void BtnExitClick(object sender, EventArgs e)
        {
            //Close the application and Exit
            Close();
        }

        //BtnFindClick Event
        private void BtnFindClick(object sender, EventArgs e)
        {
            /*I get the currently selected text to the ComboBox control*/
            var selecteditems = cbxFind.Text;

            /*Executing the control of the variable SelectedItems with a Switch construct*/
            switch(selecteditems)
            {
                /*If SelectedItems equals NAME*/
                case "NAME":
                    /*I run a query LinqToDataSet with extension method and recover all data from the UserData table and visualize the DataGrid control*/
                    var queryname =
                        userDataSet.USERDATA.Where(w => w.NAME.StartsWith(txtName.Text.ToUpper())).Select(
                            s => new {s.NAME, s.SURNAME, s.ADDRESS, s.TELEPHONE, s.CITY, s.NATIONALITI}).OrderBy(o=> o.NAME);
                    dgvUserData.DataSource = queryname.ToArray();
                    /*Exit switch*/
                    break;

                /*If SelectedItems equals CITY*/
                case "CITY":
                    /*I run a query LinqToDataSet with extension method and recover all data from the UserData table and visualize the DataGrid control*/
                    var querycity =
                        userDataSet.USERDATA.Where(w=> w.CITY.StartsWith(txtCity.Text.ToUpper())).Select(
                            s => new { s.NAME, s.SURNAME, s.ADDRESS, s.TELEPHONE, s.CITY, s.NATIONALITI }).OrderBy(o => o.CITY);
                    dgvUserData.DataSource = querycity.ToArray();
                    /*Exit switch*/
                    break;

                /*If SelectedItems equals NATIONALITY*/
                case "NATIONALITY":
                    /*I run a query LinqToDataSet with extension method and recover all data from the UserData table and visualize the DataGrid control*/
                    var querynationality =
                        userDataSet.USERDATA.Where(w => w.NATIONALITI.StartsWith(txtNationality.Text.ToUpper())).Select(
                            s => new { s.NAME, s.SURNAME, s.ADDRESS, s.TELEPHONE, s.CITY, s.NATIONALITI }).OrderBy(o => o.NATIONALITI);
                    dgvUserData.DataSource = querynationality.ToArray();
                    /*Exit switch*/
                    break;
            }
        }

        /*LoadDataGrid Method*/
        private void LoadDataGrid()
        {
            /*Load the data into the control TableAdapter*/
            uSERDATATableAdapter.Fill(userDataSet.USERDATA);
            /*Load data with the DataGrid control*/
            dgvUserData.DataSource = uSERDATABindingSource;
        }

        /*CbxFindSelectedIndexChanged Event*/
        private void CbxFindSelectedIndexChanged(object sender, EventArgs e)
        {
            /*I get the currently selected text to the ComboBox control*/
            var selecteditems = cbxFind.Text;

            /*Using a query LinqToObjects reimposed the Enabled property to true for all the text boxes on the form*/
            Controls.OfType<TextBox>().ToList().ForEach(f => f.Enabled = true);

            /*Executing the control of the variable SelectedItems with a Switch construct*/
            switch (selecteditems)
            {
                /*If SelectedItems equals NAME*/
                case "NAME":
                    /*I run a query linq to objects and imposed enable the property if different from the text box specified*/
                    Controls.OfType<TextBox>().Where(w => !w.Name.Equals("txtName")).ToList().ForEach(
                        f => f.Enabled = false);
                    /*Exit switch*/
                    break;

                /*If SelectedItems equals SURNAME*/
                case "SURNAME":
                    /*I run a query linq to objects and imposed enable the property if different from the text box specified*/
                    Controls.OfType<TextBox>().Where(w => !w.Name.Equals("txtSurname")).ToList().ForEach(
                        f => f.Enabled = false);
                    /*Exit switch*/
                    break;

                /*If SelectedItems equals ADDRESS*/
                case "ADDRESS":
                    /*I run a query linq to objects and imposed enable the property if different from the text box specified*/
                    Controls.OfType<TextBox>().Where(w => !w.Name.Equals("txtAddress")).ToList().ForEach(
                        f => f.Enabled = false);
                    /*Exit switch*/
                    break;

                /*If SelectedItems equals TELEPHONENUMBER*/
                case "TELEPHONENUMBER":
                    /*I run a query linq to objects and imposed enable the property if different from the text box specified*/
                    Controls.OfType<TextBox>().Where(w => !w.Name.Equals("txtTelephoneNumber")).ToList().ForEach(
                        f => f.Enabled = false);
                    /**/
                    break;

                /*If SelectedItems equals CITY*/
                case "CITY":
                    /*I run a query linq to objects and imposed enable the property if different from the text box specified*/
                    Controls.OfType<TextBox>().Where(w => !w.Name.Equals("txtCity")).ToList().ForEach(
                        f => f.Enabled = false);
                    /*Exit switch*/
                    break;

                /*If SelectedItems equals NATIONALITY*/
                case "NATIONALITY":
                    /*I run a query linq to objects and imposed enable the property if different from the text box specified*/
                    Controls.OfType<TextBox>().Where(w => !w.Name.Equals("txtNationality")).ToList().ForEach(
                        f => f.Enabled = false);
                    /*Exit switch*/
                    break;
            }
        }

        //DgvUserDataRowHeaderMouseClick Event
        private void DgvUserDataRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /*set the variable to true */
            _checkifrowisselected = true;
        }
    }
}
