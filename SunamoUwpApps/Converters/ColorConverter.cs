namespace apps.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

    /// <summary>
    /// Represents the color converter type.
    /// </summary>
    public static class ColorConverter //: ISimpleConverter<Color, string>
    {

        /// <summary>
        /// Convert to.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>The convert to result.</returns>
        public static Color ConvertTo(string url)
        {
            var elements = SF.GetAllElementsLine(url);
            var numbers = CA.ToInt(elements);
            return Color.FromArgb((byte)numbers[0], (byte)numbers[1], (byte)numbers[2], (byte)numbers[3]);
        }

        /// <summary>
        /// Convert from.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The convert from result.</returns>
        public static string ConvertFrom(Color color)
        {
            return SF.PrepareToSerialization(CA.ToListString(color.A, color.R, color.G, color.B));
        }
    }
