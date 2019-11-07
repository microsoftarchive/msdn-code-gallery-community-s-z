using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace XPathHero.Forms
{
    public partial class AboutThisTool : Form
    {
        public AboutThisTool()
        {
            InitializeComponent();
        }

        private void AboutThisTool_Load(object sender, EventArgs e)
        {
            // Add links to LinkLabels.
            LinkLabel.Link ithero = new LinkLabel.Link();
            ithero.LinkData = "http://www.ithero.nl/";
            itheroLink.Links.Add(ithero);
       
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
              

        private void itheroLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }


        private void snefsBlogLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
       
    }
}
