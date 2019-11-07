using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CallService_Clicked(object sender, EventArgs e)
        {
            using (CompressedService.Service1Client client = new WcfService.CompressedService.Service1Client())
            {
                string value = client.GetData(10);
                CallService.Text = value;
            }
        }
    }
}
