using Nest;
using System;
using System.Windows.Forms;

namespace ESsearchTest
{
    public partial class Form1 : Form
    {
        ConnectionSettings connectionSettings;
        ElasticClient elasticClient;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Establishing connection with ES
            connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200/")); //local PC            
            elasticClient = new ElasticClient(connectionSettings);
        }

        //Get suggestion under search textbox
        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            //Search query to retrieve info
            var response = elasticClient.Search<disney>(s => s
                .Index("disney")
                .Type("character")
                .Query(q => q.QueryString(qs => qs.Query(tbxName.Text + "*"))));

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (var hit in response.Hits)
            {
                collection.Add(hit.Source.name);
            }

            tbxName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbxName.AutoCompleteCustomSource = collection;



            if (tbxName.Text == "")
            {
                rtxSearchResult.Clear();
            }
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                rtxSearchResult.Clear();
            }
        }

        //Retrieve information based on search textbox value
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Search query to retrieve info
            var response = elasticClient.Search<disney>(s => s
                .Index("disney")
                .Type("character")
                .Query(q => q.QueryString(qs => qs.Query(tbxName.Text + "*"))));

            if (rtxSearchResult.Text != " ")
            {
                rtxSearchResult.Clear();

                foreach (var hit in response.Hits)
                {
                    rtxSearchResult.AppendText("Name: " + hit.Source.name.ToString()
                    + Environment.NewLine
                    + "Original_voice_actor: " + hit.Source.original_voice_actor.ToString()
                    + Environment.NewLine
                    + "Animated_debut: " + hit.Source.animated_debut.ToString()
                    + Environment.NewLine
                    + Environment.NewLine);
                }
            }
        }
    }
}
