using System.Windows.Media;
using System;
using PixelLab.Common;

namespace Tasks.Show.Helpers
{
    public static class BOT
    {
        public static Color ParseHexColor(string colorString)
        {
            Util.RequireNotNullOrEmpty(colorString, "colorString");
            Util.RequireArgument(((colorString.Length == 4) || (colorString.Length == 5) || (colorString.Length == 7) || (colorString.Length == 9)) && (colorString[0] == '#'), "colorString");

            int num;
            int num2;
            int num3;
            int num4 = 255;
            if (colorString.Length > 7)
            {
                num4 = (ParseHexChar(colorString[1]) * 16) + ParseHexChar(colorString[2]);
                num3 = (ParseHexChar(colorString[3]) * 16) + ParseHexChar(colorString[4]);
                num2 = (ParseHexChar(colorString[5]) * 16) + ParseHexChar(colorString[6]);
                num = (ParseHexChar(colorString[7]) * 16) + ParseHexChar(colorString[8]);
            }
            else if (colorString.Length > 5)
            {
                num3 = (ParseHexChar(colorString[1]) * 16) + ParseHexChar(colorString[2]);
                num2 = (ParseHexChar(colorString[3]) * 16) + ParseHexChar(colorString[4]);
                num = (ParseHexChar(colorString[5]) * 16) + ParseHexChar(colorString[6]);
            }
            else if (colorString.Length > 4)
            {
                num4 = ParseHexChar(colorString[1]);
                num4 += num4 * 16;
                num3 = ParseHexChar(colorString[2]);
                num3 += num3 * 16;
                num2 = ParseHexChar(colorString[3]);
                num2 += num2 * 16;
                num = ParseHexChar(colorString[4]);
                num += num * 16;
            }
            else
            {
                num3 = ParseHexChar(colorString[1]);
                num3 += num3 * 16;
                num2 = ParseHexChar(colorString[2]);
                num2 += num2 * 16;
                num = ParseHexChar(colorString[3]);
                num += num * 16;
            }
            return Color.FromArgb((byte)num4, (byte)num3, (byte)num2, (byte)num);
        }

        private static int ParseHexChar(char c)
        {
            int num = c;
            if ((num >= 48) && (num <= 57))
            {
                return (num - 48);
            }
            if ((num >= 97) && (num <= 102))
            {
                return ((num - 97) + 10);
            }
            if ((num < 65) || (num > 70))
            {
                throw new FormatException();
            }
            return ((num - 65) + 10);
        }
    }
}
