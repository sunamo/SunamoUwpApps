namespace apps.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Text;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the measure string args type.
    /// </summary>
    public class MeasureStringArgs : FontArgs
    {
        /// <summary>
        /// Initializes a new instance of the measure string args class.
        /// </summary>
        /// <param name="fontFamily">The font family.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <param name="fontStretch">The font stretch.</param>
        /// <param name="fontWeight">The font weight.</param>
        /// <param name="text">The text.</param>
        public MeasureStringArgs(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight, string text)
        {
            this.fontFamily = fontFamily;
            this.fontSize = fontSize;
            this.fontStretch = fontStretch;
            this.fontStyle = fontStyle;
            this.fontWeight = fontWeight;
            this.text = text;
        }

        
        /// <summary>
        /// The text.
        /// </summary>
        public string text = "";
        //Size maxSize = Constants.maxSize;
    }
