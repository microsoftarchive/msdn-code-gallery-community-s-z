using System;
using Android.Graphics.Drawables;
using Android.Text;
using SQLiteSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
namespace SQLiteSample.Droid {
    public class MyEntryRenderer : EntryRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Entry element = Element as Entry;
            if (e.NewElement != null)
            {
                element = Element as Entry;
            }
            else
            {
                element = e.OldElement as Entry;
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


