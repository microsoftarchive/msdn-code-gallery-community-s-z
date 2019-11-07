using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace Tasks.Show.Controls
{
    /// <summary>
    /// A ToggleButton that manages its relationship with a Popup to avoid the strange behavior
    /// that one often gets when pinding the Popup.IsOpen to ToggleButton.IsChecked where
    /// the Popup automatically reopens if the user clicks on the ToggleButton to close it.
    /// To use: [c:PopupToggle Popup="{Binding ElementName=MyPopup}" /]
    /// </summary>

    public class PopupToggle : ToggleButton
    {
		#region Event Handlers 

        void Popup_Closed(object sender, EventArgs e)
        {
            this.IsChecked = false;
            this.IsHitTestVisible = true;
            if (this.Popup != null) this.Popup.Closed -= new EventHandler(Popup_Closed);
        }

		#endregion Event Handlers 

		#region Protected Methods 

        protected override void OnChecked(System.Windows.RoutedEventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup.Closed += new EventHandler(Popup_Closed);
                this.Popup.IsOpen = true;
                this.Popup.StaysOpen = false;

                this.IsHitTestVisible = false;
            }
            base.OnChecked(e);
        }

        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup.StaysOpen = true;
            }
            base.OnMouseEnter(e);

        }

        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {

            if (this.Popup != null)
            {
                this.Popup.StaysOpen = false;
            }
            base.OnMouseLeave(e);
        }

		#endregion Protected Methods 

        #region Popup

        public static readonly DependencyProperty PopupProperty =
            DependencyProperty.Register("Popup", typeof(Popup), typeof(PopupToggle),
                new FrameworkPropertyMetadata((Popup)null));

        public Popup Popup
        {
            get { return (Popup)GetValue(PopupProperty); }
            set { SetValue(PopupProperty, value); }
        }

        #endregion
    }
}