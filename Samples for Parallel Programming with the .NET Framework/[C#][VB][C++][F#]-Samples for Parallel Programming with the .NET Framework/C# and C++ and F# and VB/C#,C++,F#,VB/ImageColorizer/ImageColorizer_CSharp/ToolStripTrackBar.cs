//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: ToolStripTrackBar.cs
//
//--------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Microsoft.ParallelComputingPlatform.ParallelExtensions.Samples
{
    /// <summary>A TrackBar that can live in a ToolStrip.</summary>
    [System.ComponentModel.DesignerCategory("code")]
    [ToolStripItemDesignerAvailability(
        ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
    internal partial class ToolStripTrackBar : ToolStripControlHost
    {
        /// <summary>Initializes the ToolStripTrackBar.</summary>
        public ToolStripTrackBar() : base(CreateControlInstance()) { }

        /// <summary>Gets the actual TrackBar instance.</summary>
        public TrackBar TrackBar { get { return Control as TrackBar; } }

        /// <summary>Create the actual TrackBar control.</summary>
        private static Control CreateControlInstance()
        {
            TrackBar t = new TrackBar();
            t.AutoSize = false;
            t.Height = 16;
            t.TickStyle = TickStyle.None;
            t.Minimum = 0;
            t.Maximum = 100;
            t.Value = 0;
            return t;
        }

        /// <summary>Gets the current TrackBar value.</summary>
        [DefaultValue(0)]
        public int Value { get { return TrackBar.Value; } set { TrackBar.Value = value; } }

        /// <summary>Gets the minimum TrackBar value.</summary>
        [DefaultValue(0)]
        public int Minimum { get { return TrackBar.Minimum; } set { TrackBar.Minimum = value; } }

        /// <summary>Gets the maximum TrackBar value.</summary>
        [DefaultValue(100)]
        public int Maximum { get { return TrackBar.Maximum; } set { TrackBar.Maximum = value; } }

        /// <summary>Attach to events that need to be wrapped.</summary>
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
            ((TrackBar)control).ValueChanged += trackBar_ValueChanged;
        }

        /// <summary>Detach from events that were wrapped.</summary>
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
            ((TrackBar)control).ValueChanged -= trackBar_ValueChanged;
        }

        /// <summary>Raise the ValueChanged event.</summary>
        void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) ValueChanged(sender, e);
        }

        /// <summary>Event used to notify when the TrackBar's value changes.</summary>
        public event EventHandler ValueChanged;

        /// <summary>Gets the default size for the control.</summary>
        protected override Size DefaultSize { get { return new Size(200, 16); } }
    }
}