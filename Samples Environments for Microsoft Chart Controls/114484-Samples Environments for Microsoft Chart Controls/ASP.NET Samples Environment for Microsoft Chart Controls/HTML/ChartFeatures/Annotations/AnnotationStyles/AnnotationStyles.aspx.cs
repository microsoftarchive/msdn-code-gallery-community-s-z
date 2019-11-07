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
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for LegendCustomPosition.
	/// </summary>
	public partial class AnnotationStyles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			SetAnnotationType();

			if(!this.IsPostBack || this.Request.Form["UpdateButton"] == null)
			{
				SetAnnotation();
			}
			
			SetAnnotationStyle();
			SetAnnotationStyle1();
			SetAnnotationStyle2();
			

		}

		private void SetAnnotationType()
		{
			Chart1.Annotations.Clear();
			
			if(Annotation.SelectedItem.Value == "Line")
			{
				LineAnnotation annotation = new LineAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Height = -25;
				annotation.Width = -25;
				annotation.LineWidth = 2;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Vertical Line")
			{
				VerticalLineAnnotation annotation = new VerticalLineAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Height = -25;
				annotation.LineWidth = 2;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Horizontal Line")
			{
				HorizontalLineAnnotation annotation = new HorizontalLineAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Width = -25;
				annotation.LineWidth = 2;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Polyline")
			{
				PolylineAnnotation annotation = new PolylineAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];

				// explicitly set the relative height and width
				annotation.Height = 50;
				annotation.Width = 30;

				PointF [] points = new PointF[5];
				points[0].X = 0;
				points[0].Y = 0;				
				
				points[1].X = 100;
				points[1].Y = 0;
				
				points[2].X = 0;
				points[2].Y = 100;
				
				points[3].X = 100;
				points[3].Y = 100;
				
				points[4].X = 0;
				points[4].Y = 50;

				annotation.GraphicsPath.AddPolygon(points);
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Text")
			{
				TextAnnotation annotation = new TextAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Text = "I am a TextAnnotation";
				annotation.ForeColor = Color.Black;
				annotation.Font = new Font("Arial", 12);;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Rectangle")
			{
				RectangleAnnotation annotation = new RectangleAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Text = "I am a\nRectangleAnnotation";
				annotation.ForeColor = Color.Black;
				annotation.Font = new Font("Arial", 12);;
				annotation.LineWidth = 2;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Ellipse")
			{
				EllipseAnnotation annotation = new EllipseAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Text = "I am an EllipseAnnotation";
				annotation.ForeColor = Color.Black;
				annotation.Font = new Font("Arial", 12);;
				annotation.LineWidth = 2;
				annotation.Height = 35;
				annotation.Width = 60;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Arrow")
			{
				ArrowAnnotation annotation = new ArrowAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Height = -25;
				annotation.Width = -25;
				annotation.LineWidth = 2;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Border3D")
			{
				Border3DAnnotation annotation = new Border3DAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Text = "I am a Border3DAnnotation";
				annotation.ForeColor = Color.Black;
				annotation.Font = new Font("Arial", 12);;
				annotation.Height = 40;
				annotation.Width = 50;
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Callout")
			{
				CalloutAnnotation annotation = new CalloutAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[1];
				annotation.Text = "I am a\nCalloutAnnotation";
				annotation.ForeColor = Color.Black;
				annotation.Font = new Font("Arial", 10);;
				annotation.Height = 35;
				annotation.Width = 50;

				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Polygon")
			{
				PolygonAnnotation annotation = new PolygonAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				
				// explicitly set the relative height and width
				annotation.Height = 50;
				annotation.Width = 30;

				annotation.BackColor = Color.FromArgb(128, Color.Orange);

				// define relative value points for a polygon
				PointF [] points = new PointF[5];
				points[0].X = 0;
				points[0].Y = 0;				
				
				points[1].X = 100;
				points[1].Y = 0;
				
				points[2].X = 100;
				points[2].Y = 100;
				
				points[3].X = 0;
				points[3].Y = 100;
				
				points[4].X = 50;
				points[4].Y = 50;

				annotation.GraphicsPath.AddPolygon(points);
				
				Chart1.Annotations.Add(annotation);
			}
			else if(Annotation.SelectedItem.Value == "Image")
			{
                if (Chart1.Images.IndexOf("MyBmp") < 0)
				{
					Bitmap Bmp = new Bitmap(200, 75);
					Graphics g = Graphics.FromImage(Bmp);
					g.FillRectangle(new SolidBrush(Color.Transparent), 0, 0, Bmp.Width, Bmp.Height);
					g.FillRectangle(new SolidBrush(Color.PaleGoldenrod), Bmp.Width/2, 0, Bmp.Width/2, Bmp.Height);
					g.FillRectangle(new SolidBrush(Color.PaleVioletRed), 0, 0, Bmp.Width/2, Bmp.Height);
					g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.DarkOrange)), 0, Bmp.Height/2, Bmp.Width, Bmp.Height/2);
					g.DrawString("I am an ImageAnnotation", new Font("Arial", 12), 
						new SolidBrush(Color.Black), 
						new Rectangle( 0, 0, Bmp.Width, Bmp.Height));
				
					g.Dispose();

					Chart1.Images.Add(new NamedImage("MyBmp", Bmp));
				}

				ImageAnnotation annotation = new ImageAnnotation();
				annotation.AnchorDataPoint = Chart1.Series[0].Points[2];
				annotation.Image = "MyBmp";
				
				Chart1.Annotations.Add(annotation);
			}
		}

		private void SetCalloutControls()
		{
			foreach(string style in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.CalloutStyle)))
			{
				AnnotationStyle.Items.Add(style);
			}
			AnnotationStyle.SelectedIndex = 2;
			AnnotationStyle.Enabled = true;
			AnnotationStyle.Visible = true;


			foreach(String colorName in KnownColor.GetNames(typeof(KnownColor)))
			{
				AnnotationStyle1.Items.Add(colorName);
			}

			StyleLabel1.Text = "Back Color";
			AnnotationStyle1.SelectedIndex = 54;
			AnnotationStyle1.Enabled = true;
			AnnotationStyle1.Visible = true;


			StyleLabel2.Text = "";
			AnnotationStyle2.Enabled = false;
			AnnotationStyle2.Visible = false;

		}

		private void SetBorder3DControls()
		{
			foreach(string skinStyle in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.BorderSkinStyle)))
			{
				AnnotationStyle.Items.Add(skinStyle);
			}
			AnnotationStyle.SelectedIndex = 1;
			AnnotationStyle.Enabled = true;
			AnnotationStyle.Visible = true;


			foreach(String colorName in KnownColor.GetNames(typeof(KnownColor)))
			{
				AnnotationStyle1.Items.Add(colorName);
			}

			StyleLabel1.Text = "Border Color";
			AnnotationStyle1.SelectedIndex = 54;
			AnnotationStyle1.Enabled = true;
			AnnotationStyle1.Visible = true;


			StyleLabel2.Text = "";
			AnnotationStyle2.Enabled = false;
			AnnotationStyle2.Visible = false;

		}


		private void SetArrowControls()
		{

			foreach(string arrow in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.ArrowStyle)))
			{
				AnnotationStyle.Items.Add(arrow);
			}
			AnnotationStyle.SelectedIndex = 0;
			AnnotationStyle.Enabled = true;
			AnnotationStyle.Visible = true;


			for(int i = 1; i <= 10; i++)
				AnnotationStyle1.Items.Add(i.ToString());

			StyleLabel1.Text = "Arrow Size";
			AnnotationStyle1.SelectedIndex = 3;
			AnnotationStyle1.Enabled = true;
			AnnotationStyle1.Visible = true;

			StyleLabel2.Text = "";
			AnnotationStyle2.Enabled = false;
			AnnotationStyle2.Visible = false;


		}

		private void SetColorLineControls()
		{
			foreach(String colorName in KnownColor.GetNames(typeof(KnownColor)))
			{
				AnnotationStyle1.Items.Add(colorName);
			}

			StyleLabel1.Text = "Back Color";
			AnnotationStyle1.SelectedIndex = 34;
			AnnotationStyle1.Enabled = true;
			AnnotationStyle1.Visible = true;


			foreach(string lineName in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.ChartDashStyle)))
			{
				AnnotationStyle2.Items.Add(lineName);
			}

			StyleLabel2.Text = "Line Style";
			AnnotationStyle2.SelectedIndex = 5;
			AnnotationStyle2.Enabled = true;
			AnnotationStyle2.Visible = true;

		}

		private void SetTextControls()
		{
            //FIXFIX Take this out
            
			foreach(string style in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.TextStyle)))
			{
				AnnotationStyle.Items.Add(style);
			}

			AnnotationStyle.SelectedIndex = 3;
			AnnotationStyle.Enabled = true;
			AnnotationStyle.Visible = true;

			
			StyleLabel1.Text = "";
			StyleLabel2.Text = "";
			AnnotationStyle1.Visible = false;
			AnnotationStyle2.Visible = false;

		}

		private void SetColorControl()
		{
			foreach(String colorName in KnownColor.GetNames(typeof(KnownColor)))
			{
				AnnotationStyle.Items.Add(colorName);
			}

			AnnotationStyle.SelectedIndex = 54;
			AnnotationStyle.Enabled = true;
			AnnotationStyle.Visible = true;


		}


		private void SetLineControls(bool showAnchors)
		{
			foreach(string lineName in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.ChartDashStyle)))
			{
				AnnotationStyle.Items.Add(lineName);
			}

			AnnotationStyle.SelectedIndex = 5;
			AnnotationStyle.Enabled = true;
			AnnotationStyle.Visible = true;


			if(showAnchors)
			{
				foreach(string arrowStyle in Enum.GetNames(typeof(System.Web.UI.DataVisualization.Charting.LineAnchorCapStyle)))
				{
					AnnotationStyle1.Items.Add(arrowStyle);
					AnnotationStyle2.Items.Add(arrowStyle);
				}

				AnnotationStyle1.SelectedIndex = 1;
				AnnotationStyle1.Enabled = true;
				AnnotationStyle2.SelectedIndex = 1;
				AnnotationStyle2.Enabled = true;

				AnnotationStyle1.Visible = true;
				AnnotationStyle2.Visible = true;

				StyleLabel1.Text = "Start Cap:";
				StyleLabel2.Text = "End Cap:";
			}
			else
			{
				AnnotationStyle1.Visible = false;
				AnnotationStyle2.Visible = false;

				StyleLabel1.Text = "";
				StyleLabel2.Text = "";
			}

		}


		private void SetAnnotationStyle()
		{
			if(AnnotationStyle == null || AnnotationStyle.SelectedIndex == -1)
				return;

			if(Annotation.SelectedItem.Value.ToLower().IndexOf("line") >= 0)
			{
				Chart1.Annotations[0].LineDashStyle = 
					(ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), AnnotationStyle.SelectedItem.Value);

			}
            
			else if(Annotation.SelectedItem.Value == "Text" ||
				Annotation.SelectedItem.Value == "Rectangle" ||
				Annotation.SelectedItem.Value == "Ellipse"        )
			{
				Chart1.Annotations[0].TextStyle = 
					(TextStyle)TextStyle.Parse(typeof(TextStyle), AnnotationStyle.SelectedItem.Value);

			}
			else if(Annotation.SelectedItem.Value == "Arrow")
			{
				((ArrowAnnotation)Chart1.Annotations[0]).ArrowStyle = 
					(ArrowStyle)ArrowStyle.Parse(typeof(ArrowStyle), AnnotationStyle.SelectedItem.Value);

			}
			else if(Annotation.SelectedItem.Value == "Border3D")
			{
				((Border3DAnnotation)Chart1.Annotations[0]).BorderSkin.SkinStyle = 
					(BorderSkinStyle)BorderSkinStyle.Parse(typeof(BorderSkinStyle), AnnotationStyle.SelectedItem.Value);

			}
			else if(Annotation.SelectedItem.Value == "Callout")
			{
				((CalloutAnnotation)Chart1.Annotations[0]).CalloutStyle = 
					(CalloutStyle)CalloutStyle.Parse(typeof(CalloutStyle), AnnotationStyle.SelectedItem.Value);

			}
			else if(Annotation.SelectedItem.Value == "Polygon")
			{
				PolygonAnnotation annotation = (PolygonAnnotation) Chart1.Annotations[0];

				annotation.BackColor = Color.FromArgb(128, Color.FromName(AnnotationStyle.SelectedItem.Value));
			}
		}

		private void SetAnnotationStyle1()
		{
			if(AnnotationStyle1 == null || AnnotationStyle1.SelectedIndex == -1)
				return;

			if(Annotation.SelectedItem.Value == "Line")
			{
				LineAnnotation annotation = (LineAnnotation) Chart1.Annotations[0];

				annotation.StartCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle1.SelectedItem.Value);

			}
			else if(Annotation.SelectedItem.Value == "Vertical Line")
			{
				VerticalLineAnnotation annotation = (VerticalLineAnnotation) Chart1.Annotations[0];

				annotation.StartCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle1.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Horizontal Line")
			{
				HorizontalLineAnnotation annotation = (HorizontalLineAnnotation) Chart1.Annotations[0];

				annotation.StartCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle1.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Polyline")
			{
				PolylineAnnotation annotation = (PolylineAnnotation) Chart1.Annotations[0];

				annotation.StartCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle1.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Rectangle")
			{
				RectangleAnnotation annotation = (RectangleAnnotation) Chart1.Annotations[0];

				annotation.BackColor = Color.FromArgb(128, Color.FromName(AnnotationStyle1.SelectedItem.Value));
			}
			else if(Annotation.SelectedItem.Value == "Ellipse")
			{
				EllipseAnnotation annotation = (EllipseAnnotation) Chart1.Annotations[0];

				annotation.BackColor = Color.FromArgb(128, Color.FromName(AnnotationStyle1.SelectedItem.Value));
			}
			else if(Annotation.SelectedItem.Value == "Arrow")
			{
				ArrowAnnotation annotation = (ArrowAnnotation) Chart1.Annotations[0];

				if(AnnotationStyle1.SelectedItem.Value != "")
					annotation.ArrowSize = int.Parse(AnnotationStyle1.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Border3D")
			{
				Border3DAnnotation annotation = (Border3DAnnotation) Chart1.Annotations[0];

				annotation.BorderSkin.BackColor = Color.FromArgb(128, Color.FromName(AnnotationStyle1.SelectedItem.Value));
			}
			else if(Annotation.SelectedItem.Value == "Callout")
			{
				CalloutAnnotation annotation = (CalloutAnnotation) Chart1.Annotations[0];

				annotation.BackColor = Color.FromArgb(128, Color.FromName(AnnotationStyle1.SelectedItem.Value));
			}
			else if(Annotation.SelectedItem.Value == "Polygon")
			{
				PolygonAnnotation annotation = (PolygonAnnotation) Chart1.Annotations[0];

				annotation.LineColor = Color.FromName(AnnotationStyle1.SelectedItem.Value);
			}
		
		}

		private void SetAnnotationStyle2()
		{
			if(AnnotationStyle2 == null || AnnotationStyle2.SelectedIndex == -1)
				return;

			if(Annotation.SelectedItem.Value == "Line")
			{
				LineAnnotation annotation = (LineAnnotation) Chart1.Annotations[0];

				annotation.EndCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle2.SelectedItem.Value);

			}
			else if(Annotation.SelectedItem.Value == "Vertical Line")
			{
				VerticalLineAnnotation annotation = (VerticalLineAnnotation) Chart1.Annotations[0];

				annotation.EndCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle2.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Horizontal Line")
			{
				HorizontalLineAnnotation annotation = (HorizontalLineAnnotation) Chart1.Annotations[0];

				annotation.EndCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle2.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Polyline")
			{
				PolylineAnnotation annotation = (PolylineAnnotation) Chart1.Annotations[0];

				annotation.EndCap = 
					(LineAnchorCapStyle)LineAnchorCapStyle.Parse(typeof(LineAnchorCapStyle), AnnotationStyle2.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Rectangle")
			{
				RectangleAnnotation annotation = (RectangleAnnotation) Chart1.Annotations[0];

				annotation.LineDashStyle = 
					(ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), AnnotationStyle2.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Ellipse")
			{
				EllipseAnnotation annotation = (EllipseAnnotation) Chart1.Annotations[0];

				annotation.LineDashStyle = 
					(ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), AnnotationStyle2.SelectedItem.Value);
			}
			else if(Annotation.SelectedItem.Value == "Polygon")
			{
				PolygonAnnotation annotation = (PolygonAnnotation) Chart1.Annotations[0];

				annotation.LineDashStyle = 
					(ChartDashStyle)ChartDashStyle.Parse(typeof(ChartDashStyle), AnnotationStyle2.SelectedItem.Value);
			}


		
		}

		private void SetAnnotation()
		{
			AnnotationStyle.Items.Clear();
			AnnotationStyle1.Items.Clear();
			AnnotationStyle2.Items.Clear();

			StyleLabel.Text = "Style";

			AnnotationStyle.Visible = false;
			AnnotationStyle1.Visible = false;
			AnnotationStyle2.Visible = false;


			if(Annotation.SelectedItem.Value == "Line")
			{
				SetLineControls(true);
			}
			else if(Annotation.SelectedItem.Value == "Vertical Line")
			{
				SetLineControls(true);
			}
			else if(Annotation.SelectedItem.Value == "Horizontal Line")
			{
				SetLineControls(true);
			}
			else if(Annotation.SelectedItem.Value == "Polyline")
			{
				SetLineControls(false);
			}
			else if(Annotation.SelectedItem.Value == "Text")
			{
				SetTextControls();
			}
			else if(Annotation.SelectedItem.Value == "Rectangle")
			{
				SetTextControls();
				SetColorLineControls();
				AnnotationStyle1.SelectedIndex = 54;
			}
			else if(Annotation.SelectedItem.Value == "Ellipse")
			{
				SetTextControls();
				SetColorLineControls();
				AnnotationStyle1.SelectedIndex = 54;
			}
			else if(Annotation.SelectedItem.Value == "Arrow")
			{
				SetArrowControls();
			}
			else if(Annotation.SelectedItem.Value == "Border3D")
			{
				SetBorder3DControls();
			}
			else if(Annotation.SelectedItem.Value == "Callout")
			{
				SetCalloutControls();
			}
			else if(Annotation.SelectedItem.Value == "Polygon")
			{
				SetColorControl();
				SetColorLineControls();
			}
			else if(Annotation.SelectedItem.Value == "Image")
			{
				StyleLabel.Text = "";
				StyleLabel1.Text = "";
				StyleLabel2.Text = "";
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

		}
		#endregion


	}
}
