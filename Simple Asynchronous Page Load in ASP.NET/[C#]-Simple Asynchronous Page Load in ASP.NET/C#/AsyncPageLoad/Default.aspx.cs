using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using AjaxControlToolkit;

namespace AsyncPageLoad
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoading.Text = "Loading News...";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            try
            {
                XDocument news = XDocument.Load(@"http://www.engadget.com/rss.xml");

                var p = from c in news.Descendants("rss").Descendants("channel").Descendants("item")
                        select new
                        {
                            pubDate = c.Element("pubDate").Value,
                            title = c.Element("title").Value,
                            description = c.Element("description").Value,
                        };
                int i = 0;
                foreach (var er in p)
                {
                    i++;
                    Label header = new Label();
                    header.CssClass = "accordionLink";
                    header.Text = er.title;

                    Label date = new Label();
                    date.Font.Size = 8;
                    date.Font.Underline = true;
                    date.ForeColor = System.Drawing.Color.FromArgb(55, 130, 205);
                    date.Text = er.pubDate.Remove(er.pubDate.Length - 7);

                    Label content = new Label();
                    content.Text = er.description;

                    AccordionPane accp = new AccordionPane();
                    accp.ID = "accp" + i.ToString();
                    accp.HeaderContainer.Controls.Add(header);
                    accp.ContentContainer.Controls.Add(date);
                    accp.ContentContainer.Controls.Add(content);

                    Accordion1.Panes.Add(accp);
                }

                lblLoading.Visible = false;
            }
            catch
            {
                lblLoading.Text = "News could not be loaded!";
            }
            finally
            {
                imgLoading.Visible = false;
            }
        }
    }
}
