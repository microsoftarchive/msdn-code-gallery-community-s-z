using System;
using PixelLab.Common;

namespace Tasks.Show.Helpers
{
    public class BoolToNullableDateTimeConverter : SimpleValueConverter<DateTime?, bool>
    {
        protected override bool ConvertBase(DateTime? input)
        {
            return input.HasValue;
        }

        protected override DateTime? ConvertBackBase(bool input)
        {
            return input ? DateTime.Now : (DateTime?)null;
        }

        public static BoolToNullableDateTimeConverter Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new BoolToNullableDateTimeConverter();
                }
                return s_instance;
            }
        }

        private static BoolToNullableDateTimeConverter s_instance;
    }
}
