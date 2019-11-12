using PixelLab.Common;
namespace Tasks.Show.Utils
{
    public class NullBoolConverter : SimpleValueConverter<object, bool>
    {
        protected override bool ConvertBase(object input)
        {
            return input != null;
        }
    }
}
