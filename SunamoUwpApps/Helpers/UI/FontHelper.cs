namespace apps.Helpers.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Windows.UI.Text;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the font helper type.
    /// </summary>
    public static class FontHelper
    {
        /// <summary>
        /// Divide string to rows.
        /// </summary>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="fontStretch">The font stretch.</param>
        /// <param name="fontWeight">The font weight.</param>
        /// <param name="text">The text.</param>
        /// <param name="maxSize">The max size.</param>
        /// <returns>The divide string to rows result.</returns>
        public static List<string> DivideStringToRows(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight, string text, Size maxSize)
        {
            FontArgs fontArgs = new FontArgs(fontFamily, fontSize, fontStyle, fontStretch, fontWeight);
            List<string> items = SHWithControls.DivideStringToRowsList(fontFamily, fontSize, fontStyle, fontStretch, fontWeight, text, maxSize);
            return items;
        }
    }
