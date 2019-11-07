using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormSubformEquivalent
{
    /// <summary>
    /// This class demonstrates the use of DataTables and DataRelations,
    /// creating Master/Child views to mimic a one-to-many form 
    /// (form/subform) in Microsoft Access.  This should be considered a 
    /// starting point.
    /// </summary>
    public partial class Form1 : Form
    {
        private DataTable tblCustomer;
        private DataTable tblOrder;
        private DataSet tblDataSet;

        public Form1()
        {
            InitializeComponent();

            // Create Tables
            tblCustomer = new DataTable("tblCustomer");
            tblOrder = new DataTable("tblOrder");

            // Create DataSet
            tblDataSet = new DataSet();

            // Create Columns and Add to Tables
            tblCustomer.Columns.Add("ID", typeof(int));
            tblCustomer.Columns.Add("CustomerName", typeof(string));
            tblOrder.Columns.Add("ID", typeof(int));
            tblOrder.Columns.Add("Order", typeof(string));
            tblOrder.Columns.Add("CustomerID", typeof(int));

            // Add Test Data
            tblCustomer.Rows.Add(1, "Jane Doe");
            tblCustomer.Rows.Add(2, "John Smith");
            tblCustomer.Rows.Add(3, "Richard Roe");
            tblOrder.Rows.Add(1, "Order1.1", 1);
            tblOrder.Rows.Add(2, "Order1.2", 1);
            tblOrder.Rows.Add(3, "Order1.3", 1);
            tblOrder.Rows.Add(4, "Order2.1", 2);
            tblOrder.Rows.Add(5, "Order3.1", 3);
            tblOrder.Rows.Add(6, "Order3.2", 3);
            
            // Add Tables to DataSet
            tblDataSet.Tables.Add(tblCustomer);
            tblDataSet.Tables.Add(tblOrder);

            // Create Relation
            tblDataSet.Relations.Add("CustOrderRelation",
                tblCustomer.Columns["ID"], tblOrder.Columns["CustomerID"]);

            BindingSource bsCustomer = new BindingSource();
            bsCustomer.DataSource = tblDataSet;
            bsCustomer.DataMember = "tblCustomer";

            BindingSource bsOrder = new BindingSource();
            bsOrder.DataSource = bsCustomer;
            bsOrder.DataMember = "CustOrderRelation";

            // Bind Data to DataGridViews
            dgvCustomer.DataSource = bsCustomer;
            dgvOrder.DataSource = bsOrder;
        }
    }
}
