using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Filtering
{
    public partial class DrawGraphForm : Form
    {
        private double zMin;
        private double zMax;
        private double[] z;
        private int n;
        private Brush brush;
        private Font font;
        private Pen pen1, pen2;

        private void FindMinMax()
        {
            zMin = double.MaxValue;
            zMax = double.MinValue;

            for (int i = 0; i < n; i++)
            {
                if (z[i] < zMin)
                    zMin = z[i];
                if (z[i] > zMax)
                    zMax = z[i];
            }
        }

        public DrawGraphForm(int n, double[] z)
        {
            InitializeComponent();
            this.n = n;
            this.z = z;
            FindMinMax();
            brush = new SolidBrush(Color.Black);
            pen1 = new Pen(Color.Black);
            pen2 = new Pen(Color.Blue);
            font = new Font("Courier New", 12f, FontStyle.Bold);
            panel1.Paint += new PaintEventHandler(PanelPaintHandler);
        }

        private void DrawGraph(float u0, float v0,
            float u1, float v1,
            Graphics g)
        {
            try
            {
                float xMin = u0;
                float yMin = v0;
                float xMax = u1;
                float yMax = v1;

                float xSpan = xMax - xMin;
                float ySpan = yMax - yMin;

                float deltaX = xSpan / 8.0f;
                float deltaY = ySpan / 8.0f;
                float height = panel1.Height;
                float width = panel1.Width;

                float sx0 = 2f * width / 16f;
                float sx1 = 14f * width / 16f;
                float sy0 = 2f * height / 16f;
                float sy1 = 14f * height / 16f;

                float xSlope = (sx1 - sx0) / xSpan;
                float xInter = sx0 - xSlope * xMin;
                float ySlope = (sy0 - sy1) / ySpan;
                float yInter = sy0 - ySlope * yMax;

                float x = xMin;
                float y = yMin;

                string fTitle = "Graph of Signal";

                float w = g.MeasureString(fTitle, font).Width;
                float h = g.MeasureString(fTitle, font).Height;

                g.DrawString(fTitle, font, brush,
                    (width - w) / 2f, h);

                string xTitle = "log(t + 1)";
                w = g.MeasureString(xTitle, font).Width;
                g.DrawString(xTitle, font, brush,
                    sx0 + (sx1 - sx0 - w) / 2f, sy1 + h + h);

                string yTitle = "S";
                w = g.MeasureString(yTitle, font).Width;
                g.DrawString(yTitle, font, brush,
                    sx1 + w / 5f, sy0 + (sy1 - sy0) / 2f - h / 2f);

                while (x <= xMax)
                {
                    float sx = xSlope * x + xInter;
                    string s = string.Format("{0,5:0.00}", Math.Log10(1 + x));

                    g.DrawLine(pen1, sx, sy0, sx, sy1);

                    w = g.MeasureString(s, font).Width;
                    g.DrawString(s, font, brush,
                        sx - w / 2, sy1 + h / 2f);
                    x += deltaX;
                }

                while (y <= yMax)
                {
                    float sy = ySlope * y + yInter;
                    string s = string.Format("{0,5:0.00}", y);

                    w = g.MeasureString(s, font).Width;
                    g.DrawLine(pen1, sx0, sy, sx1, sy);
                    g.DrawString(s, font, brush,
                        sx0 - w - w / 5f, sy - h / 2f);
                    y += deltaY;
                }

                g.Clip = new Region(new RectangleF(
                    sx0, sy0, (sx1 - sx0), (sy1 - sy0)));

                if (z == null)
                    return;

                deltaX = (xMax - xMin) / (n - 1);

                x = xMin;
                y = (float)z[0];

                int tx0 = (int)(xSlope * x + xInter);
                int ty0 = (int)(ySlope * y + yInter);
                int i = 0;

                while (x < xMax)
                {
                    i++;

                    if (i == n)
                        break;

                    x += deltaX;
                    y = (float)z[i];

                    int tx1 = (int)(xSlope * x + xInter);
                    int ty1 = (int)(ySlope * y + yInter);

                    g.DrawLine(pen2, tx0, ty0, tx1, ty1);

                    tx0 = tx1;
                    ty0 = ty1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LayOutTheForm()
        {
            // layout the panel

            int w = ClientSize.Width;
            int h = ClientSize.Height;

            panel1.Width = w;
            panel1.Height = 11 * h / 12;
            panel1.Location = new Point(0, 0);
            panel1.Invalidate();
        }

        protected void PanelPaintHandler(object sender, PaintEventArgs pa)
        {
            DrawGraph(0.0f, (float)zMin, 2000.0f, (float)zMax, pa.Graphics);
        }

        protected override void OnResize(EventArgs ea)
        {
            LayOutTheForm();
        }
    }
}
