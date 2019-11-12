using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for ANSEController
	/// </summary>
	public class ANSEController
	{
		//class members
		protected	XmlDocument samplesXMLDoc;
		protected	XmlDocument TocXMLDoc;
		protected	XmlDocument TocSequenceXMLDoc;
		private		ArrayList	contentIndexList = new ArrayList();
		private		int			sequenceID = 1;
		private		bool		expandLevels = true;

		protected String rootAppDir;	//absolute path to the root of the sample environment

		public ANSEController()
		{
			
		}

		public XmlDocument GetTocXmlDoc
		{
			get
			{
				return TocXMLDoc;
			}
		}

		public XmlDocument GetSamplesXmlDoc
		{
			get
			{
				return samplesXMLDoc;
			}
		}
		public XmlNode GetSamplesByID(String IDVal)
		{
			return FindNodeByAttribute(samplesXMLDoc, "ID", IDVal );
		}

		public string GetSampleSequenceID(string sampleID)
		{
			XmlNode xmlNode = FindNodeByAttribute(this.TocSequenceXMLDoc, "SampleID", sampleID);
			if(xmlNode == null)
			{
				return xmlNode.Attributes["SequenceID"].Value;
			}
			return "1";
		}

		public string GetSampleIDFromSequenceID(string sequenseID, ref string newSequenceID)
		{
			// Find sample sequence node
			XmlNode xmlNode = FindNodeByAttribute(this.TocSequenceXMLDoc, "SequenceID", sequenseID);
			if(xmlNode == null)
			{
				if(sequenseID.StartsWith("-") || sequenseID == "0")
				{
					xmlNode = this.TocSequenceXMLDoc["SampleList"].LastChild;
				}
				else
				{
					xmlNode = this.TocSequenceXMLDoc["SampleList"].FirstChild;
				}
			}

			// Get sample ID
			newSequenceID = xmlNode.Attributes["SequenceID"].Value;
			return xmlNode.Attributes["SampleID"].Value;
		}

		/// <summary>
		/// This function must be called to init this class. This function collects and prepares 
		/// the user interface and samples
		/// </summary>
		/// <param name="rootDirectory">root directory of where the samples can be found</param>
		public void Init(String rootDirectory)
		{
			//prepare and save the apps root directory
			rootDirectory.TrimEnd('/','\\');
			rootAppDir = rootDirectory;

			//search the directories and load in the XML files
			LoadInXMLData(rootDirectory);

			//create the TOC page
			CreateTOC(rootDirectory);

			// create content index
			CreateContentIndex(rootDirectory);

			// save the master XML documents
			string fileName = rootDirectory + "\\DynTOCNodesSequence.xml";
			if( !File.Exists(fileName) )
			{
				try
				{
					TocSequenceXMLDoc.Save(fileName);
				}
				catch
				{
					// Ignore errors
				}
			}
		}
		

		/// <summary>
		/// Searches all the sub directories within the given root directory for 'sampleConfig.xml' files
		/// Then adds the XML data to the master XML document under the 'Samples' root node
		/// </summary>
		/// <param name="rootDirectory"></param>
		private void LoadInXMLData(String rootDirectory)
		{

			//check to see if the master XML documents exist
			try
			{					
				StreamReader	fileIn;
				String			path;

				path = rootDirectory + "\\DynSampleConfig.xml";
				fileIn = new StreamReader(path);
				samplesXMLDoc = new XmlDocument();
				samplesXMLDoc.Load(fileIn);
				fileIn.Close();

				path = rootDirectory + "\\DynTOCNodes.xml";
				fileIn = new StreamReader(path);
				TocXMLDoc = new XmlDocument();
				TocXMLDoc.Load(fileIn);
				fileIn.Close();

				path = rootDirectory + "\\DynTOCNodesSequence.xml";
				fileIn = new StreamReader(path);
				TocSequenceXMLDoc = new XmlDocument();
				TocSequenceXMLDoc.Load(fileIn);
				fileIn.Close();
			}

			catch(FileNotFoundException )
			{
				//prepare the master XML documents
				samplesXMLDoc = new XmlDocument();
				samplesXMLDoc.AppendChild(samplesXMLDoc.CreateElement("SampleList"));
				TocXMLDoc = new XmlDocument();
				TocXMLDoc.AppendChild(TocXMLDoc.CreateElement("TOC"));
				XmlAttribute newAttr = TocXMLDoc.CreateAttribute("ID");
				newAttr.Value = "Root";
				TocXMLDoc["TOC"].Attributes.Append(newAttr);
				TocSequenceXMLDoc = new XmlDocument();
				TocSequenceXMLDoc.AppendChild(TocSequenceXMLDoc.CreateElement("SampleList"));


				//prepare the unique ID counter
				int uniqueID = 1;

				//start searching for all of the XML data files			
				SearchDirectories(rootDirectory, ref uniqueID);

				//save the master XML documents
				samplesXMLDoc.Save(rootDirectory + "\\DynSampleConfig.xml");
				TocXMLDoc.Save(rootDirectory + "\\DynTOCNodes.xml");
			}
		}
		
		private void SearchDirectories(String rootDirectory, ref int uniqueID)
		{
		
			StreamReader	fileIn;
			String[]		dirs;
			XmlDocument		doc = null;
			String			path = string.Empty;
			XmlAttribute	newAttr;
			
			dirs = Directory.GetDirectories(rootDirectory);

			for(int loop = 0; loop < dirs.Length; loop++)
			{
				// check and see if this directory has a "SampleConfig.xml" file
				// if so, then retrieve it, prepare it, and add it to the master 
				// samples XML document
				try
				{					
					//load in the XML data into an XmlDocument
					try
					{
						path = dirs[loop] + "\\sampleConfig.xml";
						fileIn = new StreamReader(path);
						doc = new XmlDocument();
						doc.Load(fileIn);
						fileIn.Close();
					}
					catch(System.Xml.XmlException ex)
					{
						throw(new InvalidOperationException("Error reading XML file '" + path + "'" + ex.Message));
					}
					
					XmlNode sampleNode = doc["SampleConfigs"];
					if(sampleNode != null)
						sampleNode = sampleNode["SampleConfig"];
					else
						sampleNode = doc["SampleConfig"];
					while(sampleNode != null)
					{
						if(sampleNode.Name == "SampleConfig")
						{
							//add the samples path to the node as an attribute
							newAttr = doc.CreateAttribute("Path");
							newAttr.Value = dirs[loop].Remove(0,rootAppDir.Length+1);
							sampleNode.Attributes.Append(newAttr);
							//add the samples unique ID as an attribute
							newAttr = doc.CreateAttribute("ID");
							newAttr.Value = "Sample" + uniqueID.ToString();
							sampleNode.Attributes.Append(newAttr);
							uniqueID++;

							samplesXMLDoc.FirstChild.AppendChild(samplesXMLDoc.ImportNode(sampleNode,true));
						}

						//get the next sample node
						sampleNode = sampleNode.NextSibling;
					}					
				}
				catch(FileNotFoundException )
				{
					//just ignore if the file is not found
				}

				// check and see if this directory has a "TOCNodes.xml" file
				// if so, then retrieve it, prepare it, and add it to the master 
				// TOC XML document
				try
				{					
					//load in the XML data into an XmlDocument
					path = dirs[loop] + "\\TOCNodes.xml";
					fileIn = new StreamReader(path);
					doc = new XmlDocument();
					doc.Load(fileIn);
					fileIn.Close();

					InsertIntoTocXMLDoc(doc,dirs[loop].Remove(0,rootAppDir.Length+1));
				}
				catch(FileNotFoundException )
				{
					//just ignore if the file is not found
				}
				catch(System.Xml.XmlException ex)
				{
					throw(new InvalidOperationException("Error reading XML file '" + path + "'" + ex.Message));
				}

				//check for sub directories
				SearchDirectories(dirs[loop], ref uniqueID);
			}
		}

		private void InsertIntoTocXMLDoc(XmlDocument nodes, String XmlFilePath)
		{

			XmlNodeList nodeList = nodes.GetElementsByTagName("TOCNode");
			for(int listLoop = 0; listLoop < nodeList.Count; listLoop++)
			{

				//add the path to each TOCNode as an attribute
				XmlAttribute newAttr = nodes.CreateAttribute("Path");
				newAttr.Value = XmlFilePath;
				nodeList[listLoop].Attributes.Append(newAttr);

				//get the priority
				int priority = 0;
				if(nodeList[listLoop].Attributes["Priority"] != null)
					priority = int.Parse(nodeList[listLoop].Attributes["Priority"].Value);

				//find the items parent node
				XmlNode parentNode = TocXMLDoc["TOC"];
				if(nodeList[listLoop].Attributes["ParentNodeID"] != null)
				{
					parentNode = FindNodeByAttribute(TocXMLDoc,"ID",
						nodeList[listLoop].Attributes["ParentNodeID"].Value);
				}
				if(parentNode == null)
					continue;

				//find where to insert the node (by priority)
				XmlNode XmlSiblingNode = parentNode.FirstChild;
				//if there are no child nodes already then at it as the first child
				if(XmlSiblingNode == null)
				{
					parentNode.AppendChild(TocXMLDoc.ImportNode(nodeList[listLoop],true));
				}
				//otherwise search through the list of child nodes and add it in order of priority
				while(XmlSiblingNode != null)
				{
					if(XmlSiblingNode.Name == "TOCNode")
					{
						int sibPriority = int.Parse(XmlSiblingNode.Attributes["Priority"].Value);
						if(priority < sibPriority)
						{
							XmlSiblingNode.ParentNode.InsertBefore(TocXMLDoc.ImportNode(nodeList[listLoop],true),
								XmlSiblingNode);
							break;
						}
					}
					if(XmlSiblingNode.NextSibling == null)
					{
						XmlSiblingNode.ParentNode.InsertAfter(TocXMLDoc.ImportNode(nodeList[listLoop],true),
							XmlSiblingNode);
						break;
					}
					XmlSiblingNode = XmlSiblingNode.NextSibling;
				}
			}					
		}

		public XmlNode FindNodeByAttribute(XmlNode nodes, String attrib, String val)
		{
			bool bPrevFound = true;
			return FindNextNodeByAttributeIntern(null,nodes, attrib, val, ref bPrevFound);			
		}
		public XmlNode FindNextNodeByAttribute(XmlNode prevNode,XmlNode nodes, String attrib, String val)
		{
			bool bPrevFound = false;
			return FindNextNodeByAttributeIntern(prevNode,nodes, attrib, val, ref bPrevFound);
		}
		private XmlNode FindNextNodeByAttributeIntern(XmlNode prevNode,XmlNode nodes, String attrib, String val, ref bool bPrevFound)
		{
			XmlNode node;

			if(nodes.HasChildNodes == false)
				return null;
			
			node = nodes.FirstChild;

			while(node != null)
			{
				if(node.Attributes != null &&
					node.Attributes[attrib] != null &&
					node.Attributes[attrib].Value == val)
				{
					if(bPrevFound)
						return node;
					else if(node == prevNode)
						bPrevFound = true;
				}

				if(node.HasChildNodes)
				{
					XmlNode returnNode = FindNextNodeByAttributeIntern(prevNode,node,attrib,val,ref bPrevFound);
					if(returnNode != null)
					{
						return returnNode;
					}					  
				}
				node = node.NextSibling;
			}
			return null;
		}

		/// <summary>
		/// Creates a TOC based off of a TOC template and the data in the master XML document
		/// </summary>
		private void CreateTOC(String rootDirectory)
		{
			//check to see if the TOC.HTM file exists
			if(	File.Exists(rootDirectory + "\\DynTOC.htm") )
			{
				return;
			}

			// Create TOC "Content" tab page HTML file
			CreateContentNavigationTab(
				rootDirectory + "\\DynTOCTab.htm",
				false,
				"DynIndexTab.htm");

			// Create TOC "Index" tab page HTML file
			CreateContentNavigationTab(
				rootDirectory + "\\DynIndexTab.htm",
				true,
				"DynTOCTab.htm");

			//add the headers and script to the top of the TOC page
			string TOCHtml = "<html><head><title>TOC</title></head>";
			TOCHtml += "<script id=\"ContentExpanding\">" +

				"function expandIt(whichEl){" +
				"if(document.getElementById(whichEl) != null)"+
				"{"+
				"var ImgID = whichEl + \"Img\";" +
				"var ImgID2 = whichEl + \"Img2\";" +
				"if( document.getElementById(whichEl).style.display == \"none\"){" +
				"document.getElementById(whichEl).style.display = \"\";" +
				"document.getElementById(ImgID).src = \"images/minus.gif\";" +
				"document.getElementById(ImgID2).src = \"images/Folder-Open.bmp\";" +
				"}" +
				"else{" + 
				"document.getElementById(whichEl).style.display = \"none\";" +
				"document.getElementById(ImgID).src = \"images/plus.gif\";" +
				"document.getElementById(ImgID2).src = \"images/Folder.bmp\";" +
				"}" +
				"}" +
				"}" +

				// NOTE: Underline text decoration is used instead of background color changing
//				"function SetMouseOverColor(element){" +
//				"element.style.backgroundColor=\"#FDEACE\";" +		// 6699FF  
//				"element.style.color=\"#000000\";}" +		
//
//				"function SetMouseLeaveColor(element){" +
//				"element.style.backgroundColor=\"#FFFFFF\";" +
//				"element.style.color=\"#000000\";}" +

				"function SetMouseOverColor(element){" +
				"element.style.textDecoration=\"underline\";" +
				"}" +		

				"function SetMouseLeaveColor(element){" +
				"element.style.textDecoration=\"none\";" +
				"}" +

				"var selectedElement;"+
				"function onMouseDown(element){" +
				"parent.onMouseDown(element);" +
				"}" +

				"</script>";


			TOCHtml += "<link type=\"text/css\" rel=\"stylesheet\" href=\"anseStyles.css\">"+
				"<body leftmargin=\"10px\" topMargin=\"5px\">";


			XmlNode rootNode = TocXMLDoc["TOC"];
			
			CreateTOCIntern(rootNode, ref TOCHtml, 0, 0);

			TOCHtml += "<SCRIPT id=\"ContentExpanding2\">" +
				"parent.onMouseDown(document.getElementById(parent.selectedElementID));"+
				"</SCRIPT>";


			//add the footers
			TOCHtml += "</body></html>";

			//save the toc string
			StreamWriter sw = File.CreateText(rootDirectory + "\\DynTOC.htm");
			sw.Write(TOCHtml);
			sw.Close();
		}

		private void CreateTOCIntern(XmlNode TOCnode, ref String TOCHtml, int level, int numLevelsOpen)
		{
			//for each level of the TOC tree create a table, and put each element in a row
			//headers
			try
			{
				string parentNodeID = " ParentFolderID=\"\"";
				if(TOCnode.Attributes["ParentNodeID"] != null)
				{
					parentNodeID = " ParentFolderID=\"" + TOCnode.Attributes["ParentNodeID"].Value + "\"";
				}
				if(this.expandLevels || level < numLevelsOpen + 1)				
					TOCHtml += "<table cellspacing=\"0\" cellpadding=\"1\" border=\"0\" " + parentNodeID + " ID=\"" + TOCnode.Attributes["ID"].Value + "\">\r\n";
				else
					TOCHtml += "<table cellspacing=\"0\" cellpadding=\"1\" border=\"0\" " + parentNodeID + " ID=\"" + TOCnode.Attributes["ID"].Value + "\" style=\"display:none;\">\r\n";
			}
			catch(NullReferenceException)
			{
				TOCHtml += "<table border=\"0\">\r\n";
			}

			// Create list of sample and TOC nodes
			ArrayList nodeList = new ArrayList();

			// Add all samples into the list
			XmlNode sampleNode = FindNodeByAttribute(
				samplesXMLDoc, 
				"ParentNodeID",
				TOCnode.Attributes["ID"].Value);
			while(sampleNode != null)
			{	
				// Add sample node into the list
				nodeList.Add(sampleNode);

				// Get next node
				sampleNode = FindNextNodeByAttribute(
					sampleNode,
					samplesXMLDoc, 
					"ParentNodeID",
					TOCnode.Attributes["ID"].Value);
			}

			// Add TOC nodes into the list
			XmlNode nodeTOC = TOCnode.FirstChild;			
			while(nodeTOC != null)
			{
				if(nodeTOC.Name == "TOCNode")
				{
					// Add sample node into the list
					nodeList.Add(nodeTOC);
				}

				nodeTOC = nodeTOC.NextSibling;
			}

			// Sort TOC nodes using priority.
			nodeList.Sort(new NodesComparer());

			//add child Sample nodes			
			foreach(XmlNode xmlNode in nodeList)
			{	
				if(xmlNode.Name == "SampleConfig")
				{
					// Write tags
					sampleNode = xmlNode;
					TOCHtml += "<tr>";
					TOCHtml += "<td width=\"11px\">";
					TOCHtml += "<img align=\"center\" src=\"images/Spacer.bmp\">";
					TOCHtml += "</td>";
					TOCHtml += "<td width=\"16px\">";

					// Check for the overviews
					bool	isOverview = false;
					if(sampleNode["Title"].InnerText != "Gallery")
					{
						isOverview = true;
						if(sampleNode["Title"].InnerText != "Overview")
						{
							if(sampleNode["InfoPages"] != null)
							{
								if(sampleNode["InfoPages"].ChildNodes.Count == 1)
								{
									XmlNode firstNode = sampleNode["InfoPages"].ChildNodes[0];
									if(firstNode.Attributes["Title"].Value != "Overview")
									{
										if(firstNode.InnerText != sampleNode["Content"].InnerText)
										{
											isOverview = false;
										}
									}
								}
								else if(sampleNode["InfoPages"].ChildNodes.Count > 1)
								{
									isOverview = false;
								}
							}
						}
					}

					if(isOverview)
					{
						TOCHtml += "<img align=\"center\" src=\"images/Overview.bmp\">";
					}
					else if(sampleNode["Title"].InnerText == "Gallery")
					{
						TOCHtml += "<img align=\"center\" src=\"images/Gallery.bmp\">";
					}
					else
					{
						TOCHtml += "<img align=\"center\" src=\"images/Sample.bmp\">";
					}

					TOCHtml += "</td>";
					TOCHtml += "<td width=\"100%\" nowrap Class = \"ContentItem\" >";
					TOCHtml += "<span class=\"ContentItem\" onmouseover=\"SetMouseOverColor(this)\" onmouseout=\"SetMouseLeaveColor(this)\">";
					TOCHtml += "<a id=\"Link" + sequenceID.ToString() + "\" style=\"color:#000000;text-decoration:none;\" onmouseover=\"SetMouseOverColor(this)\" onmouseout=\"SetMouseLeaveColor(this)\" onmousedown=\"onMouseDown(this)\" Class = \"ContentItem\" TARGET=\"Content\" HREF=\"content.aspx?Sample=" + sampleNode.Attributes["ID"].InnerText + "&SampleSequenceID=" + sequenceID.ToString() + "\">";
					TOCHtml += sampleNode["Title"].InnerText;
					TOCHtml += "</span></a>";
					TOCHtml += "</td></tr>";
				
					// Remember sample sequence ID and then increase it
					XmlNode newSequenceNode = TocSequenceXMLDoc.CreateElement("SampleSequence");
					XmlAttribute attr = TocSequenceXMLDoc.CreateAttribute("SequenceID");
					attr.Value = sequenceID.ToString(); 
					newSequenceNode.Attributes.Append(attr);
					attr = TocSequenceXMLDoc.CreateAttribute("SampleID");
					attr.Value = sampleNode.Attributes["ID"].InnerText;
					newSequenceNode.Attributes.Append(attr);
					TocSequenceXMLDoc["SampleList"].AppendChild(newSequenceNode);
					++sequenceID;

					// Expand levels up to the first sample
					this.expandLevels = false;
				}
				else if(xmlNode.Name == "TOCNode")
				{
					XmlNode node = xmlNode;
					sampleNode = FindNodeByAttribute(samplesXMLDoc, "ParentNodeID",node.Attributes["ID"].Value);

					//headers 
					if(node["TOCNode"] != null || sampleNode != null)
					{
						TOCHtml += "<tr>";
						
						// Add plus/minus image
						TOCHtml += "<td width=\"11px\" nowrap onclick=\"javascript:expandIt('" + node.Attributes["ID"].Value + "')\">";
						if(this.expandLevels || level < numLevelsOpen)
							TOCHtml += "<img align=\"center\" src=\"images/minus.gif\" ID=\"" + node.Attributes["ID"].Value + "Img\">";
						else
							TOCHtml += "<img align=\"center\" src=\"images/plus.gif\" ID=\"" + node.Attributes["ID"].Value + "Img\">";
						TOCHtml += "</td>";

						// Add opened/closed folder image
						TOCHtml += "<td width=\"16px\" nowrap onclick=\"javascript:expandIt('" + node.Attributes["ID"].Value + "')\">";
						if(this.expandLevels || level < numLevelsOpen)
							TOCHtml += "<img align=\"center\" src=\"images/Folder-Open.bmp\" ID=\"" + node.Attributes["ID"].Value + "Img2\">";
						else
							TOCHtml += "<img align=\"center\" src=\"images/Folder.bmp\" ID=\"" + node.Attributes["ID"].Value + "Img2\">";
						TOCHtml += "</td>";
						TOCHtml += "<td width=\"100%\" nowrap onclick=\"javascript:expandIt('" + node.Attributes["ID"].Value + "')\">";
					}
					else
					{
						TOCHtml += "<tr>";
						TOCHtml += "<td>";
						TOCHtml += "<img align=\"center\" src=\"images/Sample.bmp\">";
						TOCHtml += "</td>";
						TOCHtml += "<td nowrap>";
					}

					if(node["Content"] != null)
					{
						TOCHtml += "<span class=\"ContentItem\" onmouseover=\"SetMouseOverColor(this)\" onmouseout=\"SetMouseLeaveColor(this)\"><A style=\"color:#000000\" class=\"ContentItem\" target=\"Content\" href=\"content.aspx?Content=" + 
							node.Attributes["Path"].Value + "\\" + node["Content"].InnerText + "\">";
						TOCHtml += node["Title"].InnerText;
						TOCHtml += "</span></a>";
					}
					else
					{
						//don't make item into hyperlink if there is no content tag specified
						TOCHtml += "<span class=\"ContentItem\" onmouseover=\"SetMouseOverColor(this)\" onmouseout=\"SetMouseLeaveColor(this)\">";
						TOCHtml += node["Title"].InnerText;
						TOCHtml += "</span>";
					}

					//add child TOC nodes
					String AttrVal = node.Attributes["ID"].Value;
					if(node["TOCNode"] != null || sampleNode != null)
					{
						TOCHtml += "<tr><td></td><td colspan=\"2\" nowrap>";
						CreateTOCIntern(node, ref TOCHtml, level + 1, numLevelsOpen);
						TOCHtml += "</td></tr>";
					}

					//footers
					TOCHtml += "</td></tr>";
				}
			}

			TOCnode = TOCnode.NextSibling;

			//footers
			TOCHtml += "</table>";
		}

		internal class NodesComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				if(x is XmlNode && y is XmlNode)
				{
					XmlNode	node1 = (XmlNode)x;
					XmlNode	node2 = (XmlNode)y;
					int		priortiy1 = 10000;
					int		priortiy2 = 10000;

					if(node1.Attributes != null &&
						node1.Attributes["Priority"] != null)
					{
						priortiy1 = int.Parse(node1.Attributes["Priority"].Value);
					}
					else if(node1.Name == "TOCNode")
					{
						priortiy1 = 20000;
					}

					if(node2.Attributes != null &&
						node2.Attributes["Priority"] != null)
					{
						priortiy2 = int.Parse(node2.Attributes["Priority"].Value);
					}
					else if(node2.Name == "TOCNode")
					{
						priortiy2 = 20000;
					}

					return priortiy1.CompareTo(priortiy2);
				}

				return 0;
			}
		}

		/// <summary>
		/// Creates a Content index based off of a TOC template and the data in the 
		/// DynSampleConfig XML document
		/// </summary>
		private void CreateContentIndex(String rootDirectory)
		{
			// check to see if the DynIndex.HTM file exists
			if(	File.Exists(rootDirectory + "\\DynIndex.htm") )
			{
				return;
			}

			// load index keywords from "DynSampleConfig.xml" file
			XmlNode rootNode = samplesXMLDoc["SampleList"];
			XmlNode node = rootNode.FirstChild;
			while(node != null)
			{
				// Process sample config nodes with non-empty content
				if(node.Name == "SampleConfig" &&
					node["Content"] != null)
				{
					// get sample content URL
					/*
					string	sampleHref = "content.aspx?Content=" + 
						node.Attributes["Path"].Value + "\\" + 
						node["Content"].InnerText;
						*/
					String sampleHref = "content.aspx?Sample=" +
						node.Attributes["ID"].Value ;


					// get keywords node
					if(node["Keywords"] != null)
					{
						XmlNode nodeKeyword = node["Keywords"].FirstChild;
						while(nodeKeyword != null)
						{
							// create new index info object
							IndexInfo indexInfo = new IndexInfo();
							indexInfo.Href = sampleHref;
							indexInfo.Path = RemoveUpDir(node.Attributes["Path"].Value + "\\" + node["Content"].InnerText);
							indexInfo.Key = nodeKeyword.InnerText.Trim();

							// Check if string has a sub index separated with comma
							int commaIndex = indexInfo.Key.IndexOf(',');
							if(commaIndex > 0)
							{
								indexInfo.SubKey = indexInfo.Key.Substring(commaIndex + 1).Trim();
								indexInfo.Key = indexInfo.Key.Substring(0, commaIndex).Trim();
							}

							// insert index information into the list
							this.contentIndexList.Add(indexInfo);

							// get next node
							nodeKeyword = nodeKeyword.NextSibling;
						}
					}
				}
				node = node.NextSibling;
			}

			// sort and remove duplicate index items
			PrepareIndexInfoList();

			// create ContentIndex.HTM file 
			
			// TODO: Here is the htm file must be generated based on the infomation
			// in the contentIndexList. List contains IndexInfo objects in the same
			// order they should appear in the index. Use ToString() method of the 
			// IndexInfo class to get the name of the index item.

			//save the toc string
			StreamWriter sw = File.CreateText(rootDirectory + "\\DynIndex.htm");
			String output = 
				"<html><head><title>TOC</title></head>" +
				"<link type=\"text/css\" rel=\"stylesheet\" href=\"anseStyles.css\">"+
				"<body leftmargin=\"10px\" topMargin=\"5px\">" +
				"<table class=\"IndexItem\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
			sw.WriteLine(output);

			for(int index = 0; index < this.contentIndexList.Count; index++)
			{
				IndexInfo indexInfo = (IndexInfo)this.contentIndexList[index];

				String display = indexInfo.Key;
				if(indexInfo.Name != null && indexInfo.Name.Length > 0)
					display = indexInfo.Name;
				bool indent = false;
				if(display[0] == ' ')
					indent = true;
				display = display.Trim();

				output = "<tr><td class=\"IndexItem\">&nbsp;";
				if(indent)
					output += "&nbsp;&nbsp;&nbsp;&nbsp;";
				if(indexInfo.Href != null && indexInfo.Href.Length > 0 )
				{
					output += "<a style=\"color:#000000\" class=\"IndexItem\" target=\"Content\" href=\"" + indexInfo.Href + "\">" +
						display +
						"</a><br>";
				}
				else
				{
					output += display +
						"<br>";
				}

				output += "</td></tr></body></html>";
				sw.WriteLine(output);
			}

			output = "</table>";
			sw.WriteLine(output);

			sw.Close();

		}

		/// <summary>
		/// Finds "\..\" substring and removes one directory name infront.
		/// </summary>
		/// <param name="source">Source string.</param>
		/// <returns>Result string.</returns>
		private string RemoveUpDir(string source)
		{
			string result = source;
			int upDirIndex = result.IndexOf("..\\");
			while(upDirIndex > 0)
			{
				// Replace the up dir and the sub directory to the left
				string tempValue = result.Substring(0, upDirIndex - 1);
				int rightSlash = tempValue.LastIndexOf("\\");
				if(rightSlash > 0)
				{
					tempValue = tempValue.Substring(0, rightSlash);
				}
				tempValue += result.Substring(upDirIndex + 2);
				result = tempValue;

				// Find new up dir
				upDirIndex = result.IndexOf("..\\");
			}

			return result;
		}

		/// <summary>
		/// Prepare index info array list.
		/// </summary>
		private void PrepareIndexInfoList()
		{
			// Define item names
			for(int index = 0; index < this.contentIndexList.Count; index++)
			{
				IndexInfo indexInfo = (IndexInfo)this.contentIndexList[index];

				// Only for items with sub-key
				if(indexInfo.SubKey.Length > 0)
				{
					indexInfo.Name = "   " + indexInfo.SubKey;

					IndexInfo mainKeyInfo = new IndexInfo();
					mainKeyInfo.Key = indexInfo.Key;
					this.contentIndexList.Insert(index, mainKeyInfo);
					++index;
				}
			}

			// Remove duplicated items
			for(int index1 = 0; index1 < this.contentIndexList.Count; index1++)
			{
				IndexInfo indexInfo1 = (IndexInfo)this.contentIndexList[index1];
				for(int index2 = index1 + 1; index2 < this.contentIndexList.Count; index2++)
				{
					IndexInfo indexInfo2 = (IndexInfo)this.contentIndexList[index2];

					// Remove completly identical items
					if(indexInfo1.Key == indexInfo2.Key &&
						indexInfo1.SubKey == indexInfo2.SubKey)
					{
						if(indexInfo1.Path == indexInfo2.Path ||
							indexInfo2.Path.Length == 0)
						{
							this.contentIndexList.RemoveAt(index2);
							--index2;
						}
						else if(indexInfo1.Path.Length == 0)
						{
							this.contentIndexList.RemoveAt(index1);
							--index1;
							--index2;
						}
						
					}
				}

			}
			
			// Sort items in the list using Key + SubKey
			this.contentIndexList.Sort();
		}
	
		/// <summary>
		/// Creates content navigation tab HTML pages for content and index trees.
		/// </summary>
		private void CreateContentNavigationTab(
			string fileName,
			bool isContent, 
			string href)
		{
			string outputHTML = "<html><head><title>TOC</title></head>";
			outputHTML += "<body scroll=\"no\" unselectable=\"on\" leftMargin=\"0px\" topMargin=\"0\" rightMargin=\"0px\" bottomMargin=\"0\">";

			if(isContent)
			{
				outputHTML += "<script>" +
					"parent.document.getElementById(\"contentTreeFrame\").src=\"" + "DynIndex.htm" + "\";"+
					"</script>";
			}
			else
			{
				outputHTML += "<script>" +
					"parent.document.getElementById(\"contentTreeFrame\").src=\"" + "DynTOC.htm" + "\";"+
					"</script>";
			}

			outputHTML += "<style>" + 
				"td { color:#1A3B69; font-family: Verdana; font-size: 8pt; font-weight: bold; }" +
				"</style>";
			outputHTML += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";

			outputHTML += "<td><img src=\"images/tabs/Tab-Background.gif\"></TD>";

			if(isContent)
			{
				// drawing the non-active Content tab
				String title = "Content";
				String aTag = "<a style=\"color:#757575; text-decoration:none;\" HREF=\"" + href + "\">Content</a>";
				outputHTML += "<td><img src=\"images/tabs/Tab-Body-EndLeftInactive.gif\"></td><td background=\"images/tabs/Tab-Body-BGInactive.gif\">";
				outputHTML += aTag;

				// drawing the active Index tab
				title = "Index";
				
				outputHTML += "<td><img src=\"images/tabs/Tab-Body-RightisActive.gif\"></td><td background=\"images/tabs/Tab-Body-BGActive.gif\">";
				outputHTML += title;
				outputHTML += "</td><td><img src=\"images/tabs/Tab-Body-EndRightActive.gif\">";
			}
			else
			{
				// drawing the active Content tab
				String title = "Content";
				outputHTML += "<td><img src=\"images/tabs/Tab-Body-EndLeftActive.gif\"></td><td background=\"images/tabs/Tab-Body-BGActive.gif\">";
				outputHTML += title;

				// drawing the non-active Index tab
				title = "Index";
				String aTag = "<a style=\"color:#757575; text-decoration:none;\" HREF=\"" + href + "\">" + title + "</a>";
				outputHTML += "<td><img src=\"images/tabs/Tab-Body-LeftisActive.gif\"></td><td background=\"images/tabs/Tab-Body-BGInactive.gif\">";
				outputHTML += aTag;

				outputHTML += "</td><td><img src=\"images/tabs/Tab-Body-EndRightInactive.gif\">";
			}

			outputHTML += "<td width=\"100%\" background=\"images/tabs/Tab-Background.gif\">&nbsp;</td></tr></table>";

			// Add HTML footers
			outputHTML += "</body></html>";

			// Save the TOC tab HTML page
			StreamWriter sw = File.CreateText(fileName);
			sw.Write(outputHTML);
			sw.Close();
		}
	}

	/// <summary>
	/// Index item data structure.
	/// </summary>
	public class IndexInfo : IComparable
	{
		public	string		Href = "";
		public	string		Path = "";
		public	string		Key = "";
		public	string		SubKey = "";
		public	string		Name = "";

		/// <summary>
		/// Converts index item to string.
		/// </summary>
		/// <returns>Name of index.</returns>
		public override string ToString()
		{
			if(this.Name.Length > 0)
			{
				return this.Name;
			}

			if(this.SubKey.Length == 0)
			{
				return this.Key;
			}

			return this.Key + " - " + this.SubKey;
		}

		/// <summary>
		/// Compares two index items. Used in sorting
		/// </summary>
		/// <param name="obj">Second class.</param>
		/// <returns>Comparing result.</returns>
		public int CompareTo(object obj)
		{
			if(obj is IndexInfo)
			{
				IndexInfo info2 = (IndexInfo)obj;
				if(this.Key != info2.Key)
				{
					return this.Key.CompareTo(info2.Key);
				}
				return this.SubKey.CompareTo(info2.SubKey);
			}
			return 0;
		}

	}

}
