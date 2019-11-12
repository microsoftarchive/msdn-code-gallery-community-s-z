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
using System.Xml;


namespace System.Web.UI.DataVisualization.Charting.Samples 
{
	/// <summary>
	/// Summary description for Content.
	/// </summary>
	public partial  class Content : System.Web.UI.Page
	{
		//ANSEController - contains the XML information about the samples and TOC
		ANSEController controller;

		/// <summary>
		/// Roots the request to the appriopriate rendering function, based off of the given
		/// query string (Content=???, Topic=???, or Overview=???)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Page_Load(object sender, System.EventArgs e)
		{			
			Response.BufferOutput = false;

			//load in the session instance of the ANSEController, if one does not
			//exist then redirect to the index page
			if(this.Session["ANSEController"] == null )
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

			// if a sample was specified in the query string, then create a frame with
			// the sample in the top and the 'InfoPages' in the bottom
			if(Request.QueryString["Sample"] != null)
			{
				ShowSample( Request.QueryString["Sample"] );
			}
			// if a Topic was specified in the query string, then create a page that 
			// shows the thumbnails and description of each child sample within that topic
			else if(Request.QueryString["Topic"] != null)
			{
				ShowTopic( Request.QueryString["Topic"] );
			}
			//if a Content page was specified then show that page
			else if(Request.QueryString["Content"] != null)
			{
				ShowContent(Request.QueryString["Content"] );
			}
			//show content using sequence ID
			else if(Request.QueryString["SampleSequenceID"] != null)
			{
				string	newSequenceId = string.Empty;
				string	id = controller.GetSampleIDFromSequenceID(Request.QueryString["SampleSequenceID"], ref newSequenceId);
				ShowSample( id, newSequenceId );
			}
				//if nothing was specified to be shown, then show a default screen
			else
			{
				ShowDefault();
			}
		}
		/// <summary>
		/// This function is called when there is a 'Sample=xxx' in the query string,
		/// where xxx is the url to the sample.
		/// The funtion will then retrieve the sample's configuration XML data from 
		/// the ANSEController instance by its ID. Next it will create a frameset and
		/// sample pages based off of the configuration data
		/// </summary>
		/// <param name="sampleID">ID of the sample, as specified in the sampleConfig.xml file</param>
		private void ShowSample(String sampleID)
		{
			ShowSample(sampleID, string.Empty);
		}

		/// <summary>
		/// This function is called when there is a 'Sample=xxx' in the query string,
		/// where xxx is the url to the sample.
		/// The funtion will then retrieve the sample's configuration XML data from 
		/// the ANSEController instance by its ID. Next it will create a frameset and
		/// sample pages based off of the configuration data
		/// </summary>
		/// <param name="sampleID">ID of the sample, as specified in the sampleConfig.xml file</param>
		/// <param name="newSequenceID">New sample sequence ID.</param>
		private void ShowSample(String sampleID, String newSequenceID)
		{
			//find the XML data for the specified sample
			XmlNode node = controller.GetSamplesByID(sampleID);

			// Ensure the visibility of the sample
			Response.Write("<script>");
			Response.Write("parent.parent.document.frames[1].ensureVisible(\"" + newSequenceID + "\", \"" + node.Attributes["ParentNodeID"].InnerText + "\");");
			Response.Write("</script>");

			//create the url to the sample
			String samplePageURL = node.Attributes["Path"].Value + "\\" + node["Content"].InnerText;
			samplePageURL = samplePageURL.Replace("\\", "/");

			// Show sample tittle
			string url = "HeaderSupplemental.aspx?Title=" + node["ShortBlurb"].InnerText;
			string outputHTMLScript = "<script>" +
				"if(parent.document.all[\"headerSupplemental\"] != null)"+
				"{"+
				"parent.document.all[\"headerSupplemental\"].src=\"" + url + "\";"+
				"}"+
				"</script>";
			Response.Write(outputHTMLScript);

			// Check if sample is part of the "InfoPages" nodes
			string	nodeTitle = "Sample";
			bool	addSampleNode = false;
			if(node["InfoPages"] == null)
			{
				nodeTitle = node["Title"].InnerText;
				addSampleNode = true;
				XmlNode newInfoPagesNode = node.OwnerDocument.CreateNode(XmlNodeType.Element, "InfoPages", "");
				node.AppendChild(newInfoPagesNode);
			}
			else
			{
				addSampleNode = true;
				XmlNode infoPageNode = node["InfoPages"]["InfoPage"];
				while(infoPageNode != null)
				{
					if(infoPageNode.InnerText == node["Content"].InnerText)
					{
						addSampleNode = false;
						break;
					}
					infoPageNode = infoPageNode.NextSibling;						
				}
			}

			// Create new node
			if(addSampleNode)
			{
				XmlNode newSampleNode = node["InfoPages"].OwnerDocument.CreateNode(XmlNodeType.Element, "InfoPage", "");
				XmlAttribute titleAttr = node["InfoPages"].OwnerDocument.CreateAttribute("Title");
				titleAttr.Value = nodeTitle;
				newSampleNode.Attributes.Append(titleAttr);
				newSampleNode.InnerText = node["Content"].InnerText;

				// Add sample node
				if(node["InfoPages"].FirstChild == null)
				{
					node["InfoPages"].AppendChild(newSampleNode);
				}
				else
				{
					node["InfoPages"].InsertBefore(newSampleNode, node["InfoPages"].FirstChild);
				}
			}

			//if there are info pages, then create a frameset, else just show the main page
			if(node["InfoPages"] != null)
			{
				String page = "na";

				//create the URL to the InfoPages page			
				String infoPagesPageUrl = "GetInfoPage.aspx?SampleID=" + sampleID + "&Page=" + Server.UrlEncode(page);
				if(newSequenceID.Length == 0)
				{
					if(Request.QueryString["SampleSequenceID"] != null)
					{
						newSequenceID = Request.QueryString["SampleSequenceID"];
					}
					else
					{
						// Find sample sequence ID
						newSequenceID = controller.GetSampleSequenceID(sampleID);
					}
				}
				infoPagesPageUrl += "&SampleSequenceID=" + newSequenceID;

				Response.Write("<frameset rows=\"23,*\" ID=\"contentSampleFrameSet\" frameSpacing=\"0\" frameBorder=\"0\">");
				Response.Write("<frame scrolling=\"no\" noresize ID=\"sampleTab\" src=\"" + infoPagesPageUrl + "&ShowTab=true&DoNotLoadSample=true\">");
				Response.Write("<frame noresize ID=\"sampleView\" src=\"" + samplePageURL + "\" style=\"border-right-style:solid; border-right-width:1px; border-right-color:#BFBFBF; border-bottom-style:solid; border-bottom-width:1px; border-bottom-color:#BFBFBF; border-left-style:solid; border-left-width:1px; border-left-color:#BFBFBF;\">");
				Response.Write("</frameset>");
			}
			else
			{
				// Redirect to the sample (as the whole page)
				Response.Redirect(samplePageURL);
			}

		}

		/// <summary>
		/// This function is called when there is a 'Topic=xxx' in the query string,
		/// where xxx is the url to the sample.
		/// The funtion will then retrieve each sample configuration XML data from 
		/// the ANSEController instance that specified topicID as its parent. Next 
		/// it will create a page that displays the thumbnails and descriptions of 
		/// each sample found
		/// </summary>
		/// <param name="topicID"></param>
		private void ShowTopic(String topicID)
		{
			Response.Write("Topic: " + topicID);

			Response.Write("<BR>");

			XmlNode node = controller.FindNodeByAttribute(
				controller.GetSamplesXmlDoc,
				"ParentNodeID",
				topicID);

			while(node != null)
			{
				Response.Write(node["Title"].Name +": " + node["Title"].InnerText + "<BR>");

				node = controller.FindNextNodeByAttribute(
					node,
					controller.GetSamplesXmlDoc,
					"ParentID",
					topicID);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="contentURL"></param>
		private void ShowContent(String contentURL)
		{
			Response.Redirect(contentURL);
		}

		/// <summary>
		/// 
		/// </summary>
		private void ShowDefault()
		{
			Response.Write(" --- No Content Was Specified ---");
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
