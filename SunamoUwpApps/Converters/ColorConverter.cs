namespace apps.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

    public static class ColorConverter //: ISimpleConverter<Color, string>
    {

        public static Color ConvertTo(string url)
        {
            var elements = SF.GetAllElementsLine(url);
            var numbers = CA.ToInt(elements);
            return Color.FromArgb((byte)numbers[0], (byte)numbers[1], (byte)numbers[2], (byte)numbers[3]);
        }

        public static string ConvertFrom(Color color)
        {
            return SF.PrepareToSerialization(CA.ToListString(color.A, color.R, color.G, color.B));
        }
    }
