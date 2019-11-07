using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for GetInfoPage.
	/// </summary>
	public partial class GetInfoPage : System.Web.UI.Page
	{
		//ANSEController - contains the XML information about the samples and TOC
		private ANSEController controller;

		private void Page_Load(object sender, System.EventArgs e)
		{
			String currentPageUrl ="";
			String outputHTML ="";

			//load in the session instance of the ANSEController, if one does not
			//exist then redirect to the index page
			if(this.Session["ANSEController"] == null)
			{
				controller = new ANSEController();
				controller.Init(this.Server.MapPath("."));				
				this.Session["ANSEController"] = controller;

				if(this.Session["ANSEController"] == null )
				{
					Response.Write("Failed to read ASP.NET session variable.");
				}
			}
			controller = (ANSEController)Session["ANSEController"];

			//find the XML data for the specified sample
			String sampleID = Request.QueryString["SampleID"];
			String page = Request.QueryString["Page"];
			String showTab = Request.QueryString["ShowTab"];
			String doNotLoadSample = Request.QueryString["DoNotLoadSample"];
			XmlNode sampleNode = controller.GetSamplesByID(sampleID);

			//see if the the page exists, if not then select a new page
			XmlNode selPageNode = controller.FindNodeByAttribute(sampleNode["InfoPages"],"Title",page);

			if(page == null || page.Length == 0 || selPageNode == null)
			{
				try
				{
					page = sampleNode["InfoPages"]["InfoPage"].Attributes["Title"].InnerText;
				}
				catch(Exception)
				{
					page = "";
				}
			}
			
			if(page.Length > 0)
				Response.SetCookie(new HttpCookie("CurrentInfoPage",page));

			//create the tabs for the info pages, then display the selected page
			string selectedURL = string.Empty;
			if(sampleNode["InfoPages"] != null)
			{
				outputHTML += "<STYLE>" + 
					"td { color:#1A3B69; font-family: Verdana; font-size: 8pt; font-weight: bold; }" +
					"</STYLE>";

				outputHTML += "<TABLE style=\"Z-INDEX: 102; LEFT: 0px; POSITION: absolute; TOP: 0px\" scroll=\"no\" unselectable=\"on\" BORDER=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
				outputHTML += "<TR><TD><IMG SRC=\"images/tabs/Tab-Background.gif\"></TD><TD><IMG SRC=\"images/tabs/Tab-Background.gif\"></TD>";
				
				int tabNum = 0;
				int activeTab = -2;
				bool lastTab = false;

				XmlNode infoPageNode = sampleNode["InfoPages"]["InfoPage"];
				while(infoPageNode != null)
				{
					if(infoPageNode.NextSibling == null)
						lastTab = true;

					String title = infoPageNode.Attributes["Title"].InnerText;
					String url = "GetInfoPage.aspx?SampleID=" + sampleID + "&Page=" + Server.UrlEncode(title) + "&ShowTab=true&SampleSequenceID=" + Request.QueryString["SampleSequenceID"];
					string aStyle = "style=\"color:#757575; text-decoration:none;\"";
					if(title == page) //if drawing the active tab
					{
						aStyle = "style=\"color:#1A3B69; text-decoration:none;\"";
					}
					String aTag = "<A " + aStyle + " HREF=\"" + url + "\">" + title + "</A>";

					if(title == page) //if drawing the active tab
					{
						selectedURL = url;
						currentPageUrl = sampleNode.Attributes["Path"].Value + "\\" + infoPageNode.InnerText;
						activeTab = tabNum;


						if(tabNum == 0)
							outputHTML += "<TD><IMG SRC=\"images/tabs/Tab-Body-EndLeftActive.gif\"></TD><TD nowrap BACKGROUND=\"images/tabs/Tab-Body-BGActive.gif\">";
						else
							outputHTML += "<TD><IMG SRC=\"images/tabs/Tab-Body-RightisActive.gif\"></TD><TD nowrap BACKGROUND=\"images/tabs/Tab-Body-BGActive.gif\">";
						outputHTML += aTag;
						if(lastTab)
							outputHTML += "</TD><TD><IMG SRC=\"images/tabs/Tab-Body-EndRightActive.gif\">";
					}
					else
					{
						if(tabNum == 0)
							outputHTML += "<TD><IMG SRC=\"images/tabs/Tab-Body-EndLeftInactive.gif\"></TD><TD nowrap BACKGROUND=\"images/tabs/Tab-Body-BGInactive.gif\">";
						else if(activeTab == tabNum -1)
							outputHTML += "<TD><IMG SRC=\"images/tabs/Tab-Body-LeftisActive.gif\"></TD><TD nowrap BACKGROUND=\"images/tabs/Tab-Body-BGInactive.gif\">";
						else
							outputHTML += "<TD><IMG SRC=\"images/tabs/Tab-Body-NoneActive.gif\"></TD><TD nowrap BACKGROUND=\"images/tabs/Tab-Body-BGInactive.gif\">";

						outputHTML += aTag;
						if(lastTab)
							outputHTML += "</TD><TD><IMG SRC=\"images/tabs/Tab-Body-EndRightInactive.gif\">";
					}						

					tabNum++;
					infoPageNode = infoPageNode.NextSibling;						
				}

				outputHTML += "<TD width=\"100%\" BACKGROUND=\"images/tabs/Tab-Background.gif\">&nbsp;</TD>";


				// Add Previous/Next sample buttons
				if(sampleID.Length > 6 && sampleID.StartsWith("Sample"))
				{
					if(Request.QueryString["SampleSequenceID"] != null)
					{
						int sequenseId = int.Parse(Request.QueryString["SampleSequenceID"]);

						string linkStyle = "style=\"line-height:23px; padding-bottom:1px; padding-top:1px; padding-right:10px; padding-left:10px; border:1 solid #1A3B69; background-color:#FFFFFF; color:#1A3B69; text-decoration:none; margin-right:20px;\"";
						outputHTML += "<TD nowrap BACKGROUND=\"images/tabs/Tab-Background.gif\"><A HIDEFOCUS TARGET=\"Content\" " + linkStyle + " HREF=\"content.aspx?SampleSequenceID=" + (sequenseId - 1).ToString() + "\">< Previous</A></TD>";
						outputHTML += "<TD nowrap BACKGROUND=\"images/tabs/Tab-Background.gif\"><A HIDEFOCUS TARGET=\"Content\" " + linkStyle + " HREF=\"content.aspx?SampleSequenceID=" + (sequenseId + 1).ToString() + "\">Next ></A></TD>";
					}
				}
				outputHTML += "</TR></TABLE>";

				if(showTab == "true")
				{
					Response.Write("<HTML><HEAD><TITLE>InfoPages</TITLE></HEAD>");
					string outputHTMLScript = string.Empty;
					if(doNotLoadSample == "true")
					{
						outputHTMLScript = "<SCRIPT>" +
							"function onLoad()" +
							"{"+
							"  onResize();"+
							"}"+
							"</SCRIPT>";
					}
					else
					{
						outputHTMLScript = "<SCRIPT>" +
							"function onLoad()" +
							"{"+
							"if(parent.document.getElementById(\"sampleView\")!= null)"+
							"   {"+
							"	   parent.document.getElementById(\"sampleView\").src=\"" + selectedURL.Replace("ShowTab=true", "ShowTab=false") + "\";"+
							"   }"+
							"  onResize();"+
							"}"+
							"</SCRIPT>";
					}
					Response.Write(outputHTMLScript);

					Response.Write("<BODY scroll=\"no\" unselectable=\"on\" ID=\"SampleTabBody\" onresize=\"onResize();\" onload=\"onLoad();\" style=\"background-repeat:no-repeat;\" topmargin=\"0\" leftmargin=\"0\" rightmargin=\"0\">");
					Response.Write("<IMG ID=\"BackImage3\" style=\"Z-INDEX: 101; LEFT: 200px; POSITION: absolute; TOP: 0px\" src=\"images/HeaderRight3.bmp\">");

					// Reload sample content script
					if(selectedURL.Length > 0)
					{
						outputHTMLScript = "<SCRIPT>" +
							"function onResize()" +
							"{"+
							"if(parent.parent.parent.document.getElementById(\"navigationFrame\") != null && document.getElementById(\"BackImage3\") != null)"+
							"{"+
							"var imageLeft = document.body.clientWidth - 382;"+
							"var imageLeftMost = 370 - parent.parent.parent.document.getElementById(\"navigationFrame\").offsetWidth;"+
							"imageLeftMost = imageLeftMost - 2;"+
							"if(imageLeft < imageLeftMost)"+
							"{"+
							"	imageLeft = imageLeftMost;"+
							"}"+
							"document.getElementById(\"BackImage3\").style.left = imageLeft;"+
							"}"+
							"}"+
							"</SCRIPT>";
						Response.Write(outputHTMLScript);
					}

					// Write tab control output
					Response.Write(outputHTML);

					Response.Write("</BODY></HTML>");
				}
				else
				{
					//display the selected page
					if(currentPageUrl.Length > 0)
					{
						if(currentPageUrl.ToUpper().IndexOf(".ASPX") > 0 ||
							currentPageUrl.ToUpper().IndexOf(".HTM") > 0 ||
							currentPageUrl.ToUpper().IndexOf(".HTML") > 0 )
						{	
							Response.Redirect(currentPageUrl);
						}
						else
						{
                            currentPageUrl = currentPageUrl.ToLower().Replace("._aspx", ".aspx");
                            currentPageUrl = currentPageUrl.ToLower().Replace("._htm", ".htm");
                            currentPageUrl = currentPageUrl.ToLower().Replace("._html", ".html");
                            page = " " + page;
							currentPageUrl = Server.MapPath(currentPageUrl);

                            if (page.IndexOf("C#") > 0 || page.IndexOf("C #") > 0 || page.IndexOf("C Sharp") > 0)
                            {
                                SourceRenderer scth = new SourceRenderer();
                                Response.Write(scth.ProcessFile(currentPageUrl, "c#"));
                            }
                            else if (page.IndexOf("VB.") > 0 || page.IndexOf("VB .") > 0 || page.IndexOf("VisualBasic") > 0
                                                            || page.IndexOf("Visual Basic") > 0)
                            {
                                SourceRenderer scth = new SourceRenderer();
                                Response.Write(scth.ProcessFile(currentPageUrl, "vb"));
                            }
                            else if (page.IndexOf("HTML") > 0 || page.IndexOf("ASPX") > 0)
                            {
                                SourceRenderer scth = new SourceRenderer();
                                Response.Write(scth.ProcessFile(currentPageUrl, "aspx"));
                            }
							else
							{
								StreamReader	file;
								file = new StreamReader(currentPageUrl);
								if(currentPageUrl.IndexOf(".htm") <= 0)
									Response.Write("<pre>");
								Response.Write(file.ReadToEnd());					
								if(currentPageUrl.IndexOf(".htm") <= 0)
									Response.Write("</pre>");
								file.Close();
							}
						}
					}
				}


			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
