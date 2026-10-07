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

    public static class FontHelper
    {
        public static List<string> DivideStringToRows(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight, string text, Size maxSize)
        {
            FontArgs fontArgs = new FontArgs(fontFamily, fontSize, fontStyle, fontStretch, fontWeight);
            List<string> items = SHWithControls.DivideStringToRowsList(fontFamily, fontSize, fontStyle, fontStretch, fontWeight, text, maxSize);
            return items;
        }
    }
