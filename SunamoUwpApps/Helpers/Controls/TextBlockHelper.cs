namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the text block helper type.
    /// </summary>
    public static class TextBlockHelper
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        /// <param name="text">The text.</param>
        /// <returns>The get result.</returns>
        public static TextBlock Get(Orientation orientation, string text)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            if (orientation == Orientation.Horizontal)
            {
                textBlock.VerticalAlignment = VerticalAlignment.Center;
            }
            else
            {
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            }

            return textBlock;
        }

        /// <summary>
        /// Split to words and newline after every.
        /// </summary>
        /// <param name="txt">The txt.</param>
        /// <param name="every">The every.</param>
        public static void SplitToWordsAndNewlineAfterEvery(TextBlock txt, int every)
        {
            every--;
            StringBuilder stringBuilder = new StringBuilder();
            var text = SH.Split(txt.Text, AllStrings.space);
            for (int index = 0; index < text.Count(); index++)
            {
                if (index % every == 0 && index != 0)
                {
                    stringBuilder.AppendLine(text[index]);
                }
                else
                {
                    stringBuilder.Append(text[index] + AllStrings.space);
                }
            }
            txt.Text = stringBuilder.ToString();
        }
    }
