namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the TBH type.
    /// </summary>
    public class TBH : TextBlockHelperBase
    {
        /// <summary>
        /// The fa.
        /// </summary>
        public FontArgs fa = FontArgs.DefaultRun();
        TextBlock tb = null;
        /// <summary>
        /// Initializes a new instance of the TBH class.
        /// </summary>
        /// <param name="textBlock">The text block.</param>
        public TBH(TextBlock textBlock)
        {
            this.tb = textBlock;
        }

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
        public void DivideStringToRows(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight, string text, Size maxSize)
        {
            FontArgs fontArgs = new FontArgs(fontFamily, fontSize, fontStyle, fontStretch, fontWeight);
            List<string> items = SHWithControls.DivideStringToRowsList(fontFamily, fontSize, fontStyle, fontStretch, fontWeight, text, maxSize);
            foreach (var item in items)
            {
                tb.Inlines.Add(GetRun(item, fontArgs));
                tb.Inlines.Add(new LineBreak());
            }

        }



        

        /// <summary>
        /// H 1.
        /// </summary>
        /// <param name="text">The text.</param>
        public void H1(string text)
        {
            Bold bold = new Bold();
            FontArgs fontArgs = FontArgs.DefaultRun();
            fontArgs.fontSize = 50;
            //b.FontSize = 40;
            bold.Inlines.Add(new LineBreak());
            bold.Inlines.Add(GetRun(text, fontArgs));
            bold.Inlines.Add(new LineBreak());
            bold.Inlines.Add(new LineBreak());
            tb.Inlines.Add(bold);
        }

        /// <summary>
        /// Run.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Run(string value)
        {
            tb.Inlines.Add(GetRun(value, fa));
        }

        /// <summary>
        /// Bold.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Bold(string value)
        {
            tb.Inlines.Add(GetBold(value, fa));
        }

        /// <summary>
        /// H 3.
        /// </summary>
        /// <param name="text">The text.</param>
        public void H3(string text)
        {
            Italic italic = new Italic();
            FontArgs fontArgs = FontArgs.DefaultRun();
            fontArgs.fontSize = 30;
            //b.FontSize = 30;
            italic.Inlines.Add(new LineBreak());
            italic.Inlines.Add(GetRun(text, fontArgs));
            italic.Inlines.Add(new LineBreak());
            italic.Inlines.Add(new LineBreak());
            tb.Inlines.Add(italic);
        }

        /// <summary>
        /// Tato Metoda nefunguje, protože Paragraph je odvozený od Block a ne od Inline 
        /// </summary>
        /// <param name="italic"></param>
        public void AddParagraph(Inline italic)
        {
        }

        /// <summary>
        /// Line break.
        /// </summary>
        public void LineBreak()
        {
            tb.Inlines.Add(new LineBreak());
        }

        

        /// <summary>
        /// Key value.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        public void KeyValue(string first, string second)
        {
             second = second.Trim();
             first = first.Trim();
            if (second != "" && first != "")
            {
                Bold(first);
                Run(AllStrings.space + second);
                LineBreak();
            }
        }

        

        /// <summary>
        /// Error.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Error(string path)
        {
            tb.Inlines.Add(GetError(path, FontArgs.DefaultRun()));
            LineBreak();
        }

        /// <summary>
        /// Bullet.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Bullet(string path)
        {
            Inline inline = GetBullet(path, fa);
            //il.Foreground = new SolidColorBrush(Colors.Black);
            tb.Inlines.Add(inline);
            LineBreak();
        }

        /// <summary>
        /// Italic.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Italic(string path)
        {
            tb.Inlines.Add(GetItalic(path, fa));
        }
    }
