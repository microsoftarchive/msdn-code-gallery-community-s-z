using System;
using Android.Graphics.Drawables;
using Android.Text;
using SQLiteSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePicker), typeof(CustomDatePickerRenderer))]
namespace SQLiteSample.Droid
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            DatePicker element = Element as DatePicker;
            if (e.NewElement != null)
            {
                element = Element as DatePicker;
            }
            else
            {
                element = e.OldElement as DatePicker;
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


