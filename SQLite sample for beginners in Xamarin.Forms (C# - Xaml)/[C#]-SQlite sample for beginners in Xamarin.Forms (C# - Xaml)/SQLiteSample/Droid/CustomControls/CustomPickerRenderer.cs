using System;
using Android.Graphics.Drawables;
using Android.Text;
using SQLiteSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]
namespace SQLiteSample.Droid{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            Picker element = Element as Picker;
            if (e.NewElement != null)
            {
                element = Element as Picker;
            }
            else
            {
                element = e.OldElement as Picker;
            }

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
            }
        }

    }
}


