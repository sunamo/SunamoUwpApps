namespace apps.Helpers.UI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    public static class MarginSetter
    {
        /// <summary>
        /// Pro A2 je nejlepší asi orange
        /// Výchozí pro A3 je 3, levý je 4násobek a spodní dvojnásobek, pravý vždy 0
        /// </summary>
        /// <param name="textBlock"></param>
        /// <param name="topMargin"></param>
        public static void UppercaseTextBlock(TextBlock textBlock, Brush color, double topMargin)
        {
            textBlock.Text = textBlock.Text.ToUpper();
            textBlock.Margin = new Microsoft.UI.Xaml.Thickness(topMargin *4, topMargin, 0, topMargin * 2);
            if (color != null)
            {
                textBlock.Foreground = color;
            }
        }
    }
