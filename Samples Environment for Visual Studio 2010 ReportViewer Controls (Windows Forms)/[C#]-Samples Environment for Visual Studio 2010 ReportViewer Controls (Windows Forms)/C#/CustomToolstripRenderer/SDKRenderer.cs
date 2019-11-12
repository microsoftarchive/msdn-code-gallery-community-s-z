//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomToolStripRenderer
{
    /// <summary>
    /// This custom toolstrip renderer is provided as a sample use case for ReportViewer.ToolStripRenderer for demonstration purposes only. 
    /// The code snippet is taken from the Visual Studio SDK and is not supported by the ReportViewer team.
    /// </summary>
    public sealed class SdkRenderer : ToolStripRenderer, IDisposable
    {
        private ArrayList m_toolstrips;
        private ArrayList m_ToolStripPanels;
        private ArrayList m_toolstripitems;
        private Timer m_timer;
        private bool m_drawToolbarBorder;
        private Color m_color1;
        private Color m_color2;
        private Color m_currentc1;
        private Color m_currentc2;
        private Color m_itemBorderColor;
        private Color m_arrowColor;
        private short m_rinc;
        private short m_ginc;
        private short m_binc;
        private const short NumIncrements = 30;
        private int m_currentTick;
        private bool m_positiveDirection;
        private const int TimerSpeedMs = 1000;
    
        public SdkRenderer() : base()
        {
            this.m_color1 = Color.Aqua;
            this.m_color2 = Color.LightSalmon;
            OnColorChanged();
        
            this.m_drawToolbarBorder = true;
        
            this.m_toolstrips = new ArrayList();
            this.m_toolstripitems = new ArrayList();
            
            this.m_ToolStripPanels = new ArrayList();
        }

        public void Dispose()
        {
            this.m_timer.Stop();
            this.m_timer.Dispose();

            this.m_toolstrips.Clear();
            this.m_toolstripitems.Clear();
            this.m_ToolStripPanels.Clear();

            this.m_toolstrips = null;
            this.m_toolstripitems = null;

            this.m_ToolStripPanels = null;
        }

        public bool DrawToolBarBorder 
        {
            get 
            { 
                return this.m_drawToolbarBorder; 
            }
        
            set 
            { 
                this.m_drawToolbarBorder = value; 
            }
        }
    
        protected override void Initialize(ToolStrip toolStrip)
        {
            if (!this.m_toolstrips.Contains(toolStrip)) 
            {
                this.m_toolstrips.Add(toolStrip);
            }
            
            PostInitialize();
        }
    
        protected override void InitializePanel(System.Windows.Forms.ToolStripPanel toolStripPanel)
        {
            base.InitializePanel(toolStripPanel);
            if (!this.m_ToolStripPanels.Contains(toolStripPanel)) 
            {
                this.m_ToolStripPanels.Add(toolStripPanel);
            }
            PostInitialize();
        }
    
        protected override void InitializeItem(ToolStripItem item)
        {
            if (!this.m_toolstripitems.Contains(item)) 
            {
                this.m_toolstripitems.Add(item);
            }
            
            PostInitialize();
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            if ((this.m_drawToolbarBorder)) 
            {
                using (Pen p = new Pen(this.m_itemBorderColor)) 
                {
                    Rectangle r = default(Rectangle);
                    r = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            OnRenderItemBackground(e);
        }
    
        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            LinearGradientMode lgm = default(LinearGradientMode);
            Rectangle r = default(Rectangle);
        
            if (e.GripDisplayStyle == ToolStripGripDisplayStyle.Horizontal) 
            {
                lgm = LinearGradientMode.Vertical;
                r = new Rectangle(e.GripBounds.Left + 2, e.GripBounds.Top, e.GripBounds.Width - 6, e.GripBounds.Height - 3);
            }
            else 
            {
                lgm = LinearGradientMode.Horizontal;
                r = new Rectangle(e.GripBounds.Left, e.GripBounds.Top + 2, e.GripBounds.Width - 3, e.GripBounds.Height - 6);
            }
        
            using (LinearGradientBrush lgb = new LinearGradientBrush(r, ScaleColorPct(this.m_color1, 80), ScaleColorPct(this.m_color2, 80), lgm)) 
            {
                e.Graphics.FillRectangle(lgb, r);
            }
        
            using (Pen p = new Pen(this.m_itemBorderColor)) 
            {
                e.Graphics.DrawRectangle(p, r);
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            LinearGradientMode lgm = default(LinearGradientMode);
            Rectangle r = default(Rectangle);
        
            r = new Rectangle(Point.Empty, e.ToolStrip.Size);
        
            if (e.ToolStrip.Orientation == Orientation.Vertical) 
            {
                lgm = LinearGradientMode.Vertical;
            }
            else 
            {
                lgm = LinearGradientMode.Horizontal;
            }
        
            using (LinearGradientBrush lgb = new LinearGradientBrush(r, this.m_currentc1, this.m_currentc2, lgm)) 
            {
                e.Graphics.FillRectangle(lgb, r);
            }
        }

        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            OnRenderButtonBackground(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            DrawLittleArrow(e.Graphics, e.ArrowRectangle, e.Direction);
        }
    
        protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            OnRenderItemBackground(e);
        }

        protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            LinearGradientMode lgm = default(LinearGradientMode);
            Rectangle r = default(Rectangle);
        
            r = new Rectangle(Point.Empty, e.ToolStripPanel.Size);
        
            if (e.ToolStripPanel.Width == 0 || e.ToolStripPanel.Height == 0) 
            {
                return;
            }
        
            if (e.ToolStripPanel.Dock == DockStyle.Left || e.ToolStripPanel.Dock == DockStyle.Right) 
            {
                lgm = LinearGradientMode.Vertical;
            }
            else 
            {
                lgm = LinearGradientMode.Horizontal;
            }
        
            using (LinearGradientBrush lgb = new LinearGradientBrush(r, this.m_currentc1, this.m_currentc2, lgm)) 
            {
                e.Graphics.FillRectangle(lgb, r);
            }
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            LinearGradientMode lgm = default(LinearGradientMode);
            Color c1 = default(Color);
            Color c2 = default(Color);
            Rectangle r = default(Rectangle);
            ArrowDirection d = default(ArrowDirection);
        
            if (e.ToolStrip.Orientation == Orientation.Vertical) 
            {
                lgm = LinearGradientMode.Vertical;
                r = new Rectangle(0, 0, e.Item.Bounds.Width - 2, e.Item.Bounds.Height - 2);
            }
            else 
            {
                lgm = LinearGradientMode.Horizontal;
                r = new Rectangle(0, 0, e.Item.Bounds.Width - 2, e.Item.Bounds.Height - 2);
            }
        
            if ((e.Item.Pressed)) 
            {
                c1 = ScaleColorPct(this.m_color1, 70);
                c2 = ScaleColorPct(this.m_color2, 70);
            }
            else if ((e.Item.Selected)) 
            {
                c1 = ScaleColorPct(this.m_color1, 120);
                c2 = ScaleColorPct(this.m_color2, 120);
            }
            else 
            {
                c1 = ScaleColorPct(this.m_color1, 90);
                c2 = ScaleColorPct(this.m_color2, 90);
            }
        
            using (LinearGradientBrush lgb = new LinearGradientBrush(r, c1, c2, lgm)) 
            {
                e.Graphics.FillRectangle(lgb, r);
            }
        
            using (Pen p = new Pen(this.m_itemBorderColor)) 
            {
                e.Graphics.DrawRectangle(p, r);
            }
        
            r = new Rectangle(Point.Empty, e.Item.Size);
            if (e.ToolStrip.Orientation == Orientation.Horizontal) 
            {
                d = ArrowDirection.Down;
            }
            else 
            {
                d = ArrowDirection.Right;
            }
            
            DrawLittleArrow(e.Graphics, r, d);
        }

        private void m_timer_Tick(object sender, System.EventArgs e)
        {
            byte c1r = 0;
            byte c1g = 0;
            byte c1b = 0;
            byte c2r = 0;
            byte c2g = 0;
            byte c2b = 0;
        
            if ((this.m_positiveDirection == true && this.m_currentTick == NumIncrements)) 
            {
                this.m_positiveDirection = false;
            
                this.m_rinc = (short)(-(this.m_rinc));
                this.m_ginc = (short)(-(this.m_ginc));
                
                this.m_binc = (short)(-(this.m_binc));
            }
            else if ((this.m_positiveDirection == false && this.m_currentTick == 0)) 
            {
                this.m_positiveDirection = true;
            
                this.m_rinc = (short)(-(this.m_rinc));
                this.m_ginc = (short)(-(this.m_ginc));
                
                this.m_binc = (short)(-(this.m_binc));
            }
        
            if ((this.m_positiveDirection)) 
            {
                this.m_currentTick += 1;
            }
            else 
            {
                this.m_currentTick -= 1;
            }
        
            c1r = ValueInLimitsByte(this.m_currentc1.R - this.m_rinc, 0, 255);
            c1g = ValueInLimitsByte(this.m_currentc1.G - this.m_ginc, 0, 255);
            c1b = ValueInLimitsByte(this.m_currentc1.B - this.m_binc, 0, 255);
            c2r = ValueInLimitsByte(this.m_currentc2.R + this.m_rinc, 0, 255);
            c2g = ValueInLimitsByte(this.m_currentc2.G + this.m_ginc, 0, 255);
            c2b = ValueInLimitsByte(this.m_currentc2.B + this.m_binc, 0, 255);
        
            this.m_currentc1 = Color.FromArgb(255, c1r, c1g, c1b);
            this.m_currentc2 = Color.FromArgb(255, c2r, c2g, c2b);
        
            foreach (ToolStrip ts in this.m_toolstrips) 
            {
                ts.Invalidate(true);
            }
            foreach (ToolStripPanel rc in this.m_ToolStripPanels) 
            {
                rc.Invalidate(true);
            }
            foreach (ToolStripItem tsi in this.m_toolstripitems) 
            {
                tsi.Invalidate();
            }
        }

        private void ComputeIncrements()
        {
            this.m_rinc = (short)(((short)this.m_color1.R - (short)this.m_color2.R) / NumIncrements);
            this.m_ginc = (short)(((short)this.m_color1.G - (short)this.m_color2.G) / NumIncrements);
            
            this.m_binc = (short)(((short)this.m_color1.B - (short)this.m_color2.B) / NumIncrements);
        }

        private static byte ValueInLimitsByte(int val, byte lower, byte upper)
        {
            if ((val < lower))
            {
                val = lower;
            }
            else if ((val > upper))
            {
                val = upper;
            }

            return (byte)val;
        }

        private static Color ScaleColorPct(Color c, int pct)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;
            double p = 0;
        
            p = (double)pct / 100;
        
            r = ValueInLimitsByte((int)((double)c.R * p), 0, 255);
            g = ValueInLimitsByte((int)((double)c.G * p), 0, 255);
            b = ValueInLimitsByte((int)((double)c.B * p), 0, 255);
        
            return Color.FromArgb(c.A, r, g, b);
        }

        private void PostInitialize()
        {
            if ((this.m_timer == null)) 
            {
                this.m_timer = new Timer();
                this.m_timer.Tick += new System.EventHandler(m_timer_Tick);
                this.m_currentTick = 1;
                this.m_positiveDirection = true;
                this.m_timer.Interval = TimerSpeedMs;
                
                this.m_timer.Start();
            }
        }

        private void OnColorChanged()
        {
            ComputeIncrements();
            this.m_currentc1 = this.m_color1;
            this.m_currentc2 = this.m_color2;
        
            this.m_itemBorderColor = ScaleColorPct(this.m_color1, 20);
            
            this.m_arrowColor = ScaleColorPct(this.m_color1, 10);
        }

        private void DrawLittleArrow(Graphics g, Rectangle bounds, ArrowDirection dir)
        {
            int left = 0;
            int aleft = 0;
            int top = 0;
            int atop = 0;
        
            aleft = (int)((bounds.Width + 5) / 2) - 5;
            atop = (int)((bounds.Height + 5) / 2) - 5;
            left = bounds.Left;
            top = bounds.Top;

            switch (dir)
            {
                case ArrowDirection.Down:
                    using (Pen p = new Pen(this.m_arrowColor))
                    {
                        for (int x = 0; x <= 2; x++)
                        {
                            g.DrawLine(p, left + aleft + x, top + atop + x, left + aleft + (5 - x), top + atop + x);
                        }
                    }

                    break;
                case ArrowDirection.Right:
                    using (Pen p = new Pen(this.m_arrowColor))
                    {
                        for (int x = 0; x <= 2; x++)
                        {
                            g.DrawLine(p, left + aleft + x, top + atop + x, left + aleft + x, top + atop + (5 - x));
                        }
                    }

                    break;
            }
        }
    }
}
