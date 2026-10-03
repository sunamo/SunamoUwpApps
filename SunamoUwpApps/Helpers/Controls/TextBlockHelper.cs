namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    public static class TextBlockHelper
    {
        public static TextBlock Get(Orientation orientation, string text)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            if (orientation == Orientation.Horizontal)
            {
                tb.VerticalAlignment = VerticalAlignment.Center;
            }
            else
            {
                tb.HorizontalAlignment = HorizontalAlignment.Center;
            }

            return tb;
        }

        public static void SplitToWordsAndNewlineAfterEvery(TextBlock txt, int every)
        {
            every--;
            StringBuilder sb = new StringBuilder();
            var text = SH.Split(txt.Text, AllStrings.space);
            for (int i = 0; i < text.Count(); i++)
            {
                if (i % every == 0 && i != 0)
                {
                    sb.AppendLine(text[i]);
                }
                else
                {
                    sb.Append(text[i] + AllStrings.space);
                }
            }
            txt.Text = sb.ToString();
        }
    }
