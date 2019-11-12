using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;
using System.Drawing.Design;

namespace CustomServerControlsLibrary
{
	[DefaultProperty("RichText")]
    [ToolboxData("<{0}:RichLabel runat=server><Format HighlightTag=b Type=Html /></{0}:RichLabel>")]    
	public class RichLabel : WebControl
	{
		public RichLabel() : base()
		{
			Text = "";
			Format = new RichLabelFormattingOptions(RichLabelTextType.Xml, "b");
		}

		[Editor(typeof(ColorTypeEditor), typeof(UITypeEditor))]
		public override Color BackColor
		{
			get	{return base.BackColor;}
			set	{base.BackColor = value;}
		}


		protected override void RenderContents(HtmlTextWriter output)
		{	
			string convertedText = "";
			switch (Format.Type)
			{
				case RichLabelTextType.Xml:
					convertedText = RichLabel.ConvertXmlTextToHtmlText(Text, Format.HighlightTag);
					break;
				case RichLabelTextType.Html:
					convertedText = Text;
					break;
			}
			output.Write(convertedText);
		}

		[Category("Appearance")]
		[Description("The content that will be displayed.")]
		public string Text
		{
			get	{return (string)ViewState["Text"];}
			set	{ViewState["Text"] = value;}
		}

		[Category("Appearance")]
		[Description("Options for configuring how text is rendered.")]
		[TypeConverter(typeof(RichLabelFormattingOptionsConverter))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public RichLabelFormattingOptions Format
		{
			get {return (RichLabelFormattingOptions)ViewState["Format"];}
			set {ViewState["Format"] = value;}
		}

		// This is a static method, just in case you want to use it
		// idependent of any control object.
		public static string ConvertXmlTextToHtmlText(string inputText, string highlightTag)
		{
			if (inputText == "")
			{
				return "";
			}
			else
			{
				// Replace all start and end tags.
				string startPattern = @"<([^>]+)>";
				Regex regEx = new Regex(startPattern);
				string outputText = regEx.Replace(inputText, 
					@"&lt;<" + highlightTag + @">$1&gt;</" + highlightTag + ">");

				outputText = outputText.Replace(" ", "&nbsp;");
				outputText = outputText.Replace("\r\n", "<br />");

				return outputText;
			}
		}
	}

	public class RichLabelFormattingOptionsConverter : ExpandableObjectConverter
	{
		private string ToString(object value)
		{
			RichLabelFormattingOptions format = (RichLabelFormattingOptions)value;
			return String.Format("{0}, <{1}>", format.Type, format.HighlightTag);
		}

		private RichLabelFormattingOptions FromString(object value)
		{
			string[] values = ((string)value).Split(',');
			if (values.Length != 2)
				throw new ArgumentException("Could not convert the value");

			try
			{
				RichLabelTextType type = (RichLabelTextType)Enum.Parse(typeof(RichLabelTextType), values[0], true);
				string tag = values[1].Trim(new char[]{' ','<','>'});
				return new RichLabelFormattingOptions(type, tag);
			}
			catch
			{
				throw new ArgumentException("Could not convert the value");
			}
		}

		public override bool CanConvertFrom(
			ITypeDescriptorContext context, 
			Type sourceType) 
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			else
			{
				return base.CanConvertFrom(context, sourceType);
			}
		}

		public override object ConvertFrom(
			ITypeDescriptorContext context, 
			CultureInfo culture, object value) 
		{
			if (value is string)
			{
				return FromString(value);
			}
			else
			{
				return base.ConvertFrom(context, culture, value);
			}
		}

		public override bool CanConvertTo(
			ITypeDescriptorContext context,
			Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return true;
			}
			else
			{
				return base.CanConvertTo(context, destinationType);
			}
		}

		public override object ConvertTo(
			ITypeDescriptorContext context, 
			CultureInfo culture, object value, 
			Type destinationType) 
		{  
			if (destinationType == typeof(string))
			{
				return ToString(value);
			}
			else
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}

	}

	
	public enum RichLabelTextType
	{
		Xml, Html
	}

	[Serializable()]    
	public class RichLabelFormattingOptions
	{
		private RichLabelTextType type;

		[RefreshProperties(RefreshProperties.Repaint)]
		[NotifyParentProperty(true)]
		[Description("Type of content supplied in the text property")]
		public RichLabelTextType Type
		{
			get {return type;}
			set {type = value;}
		}

		private string highlightTag;

		[RefreshProperties(RefreshProperties.Repaint)]
		[NotifyParentProperty(true)]
		[Description("The HTML tag you want to use to mark up highlighted portions.")]
		public string HighlightTag
		{
			get {return highlightTag;}
			set {highlightTag = value;}
		}

		public RichLabelFormattingOptions(RichLabelTextType type, string highlightTag)
		{
			this.highlightTag = highlightTag;
			this.type = type;
		}

		public RichLabelFormattingOptions(){}
	}
}

