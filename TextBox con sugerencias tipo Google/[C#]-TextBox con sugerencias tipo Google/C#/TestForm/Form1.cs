using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dtProductos = new DataTable("Products");
            dtProductos.ReadXml(Path.Combine(Application.StartupPath, @"Datos\Products.xml"));
            textSuggestion1.SuggestDataSource = dtProductos.Rows.Cast<DataRow>();
            textSuggestion1.MatchElement = SuggestionMatch;
            textSuggestion1.TextFromElement = TextForSuggestion;
        }

        private bool SuggestionMatch(object row, string userText)
        {
            if (string.IsNullOrEmpty(userText)) return false;

            bool match = true;
            string[] words = userText.Split(' ');
            DataRow datarow = (DataRow)row;
            foreach (string word in words)
            {
                if (!datarow["Name"].ToString().ToUpper().Contains(word.ToUpper())
                    && (datarow["Color"]==DBNull.Value 
                    || !datarow["Color"].ToString().ToUpper().Contains(word.ToUpper())))
                {
                    match = false;
                    break;
                }
            }
            return match;
        }

        private string TextForSuggestion(object row)
        {
            DataRow datarow = (DataRow)row;
            string color = "";
            if (datarow["Color"] != DBNull.Value)
                color = string.Format(" ({0})", datarow["Color"].ToString());
            return string.Format("{0}{1}", datarow["Name"].ToString(), color);
        }
    }
}
