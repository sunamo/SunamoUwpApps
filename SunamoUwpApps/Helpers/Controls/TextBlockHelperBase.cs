namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the text block helper base type.
    /// </summary>
    public class TextBlockHelperBase : ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, InlineUIContainer, FontArgs>
    {
        /// <summary>
        /// The texts.
        /// </summary>
        protected List<MeasureStringArgs> texts = new List<MeasureStringArgs>();

        /// <summary>
        /// Get font weight.
        /// </summary>
        /// <param name="fontWeight">The font weight.</param>
        /// <returns>The get font weight result.</returns>
        protected FontWeight GetFontWeight(FontWeight2 fontWeight)
        {
            FontWeight convertedFontWeight = new FontWeight();
            convertedFontWeight.Weight = (ushort)fontWeight;
            return convertedFontWeight;
        }

        /// <summary>
        /// Get italic.
        /// </summary>
        /// <param name="run">The run.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get italic result.</returns>
        public Italic GetItalic(string run, FontArgs fontArgs)
        {
            Italic italic = new Italic();
            FontArgs fa2 = new FontArgs(fontArgs);
            fontArgs.fontStyle = Windows.UI.Text.FontStyle.Italic;
            italic.Inlines.Add(GetRun(run, fontArgs));

            return italic;
        }
        /// <summary>
        /// Get bullet.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get bullet result.</returns>
        public Inline GetBullet(string path, FontArgs fontArgs)
        {
            return GetRun("• " + path, fontArgs);
        }

        /// <summary>
        /// Get error.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get error result.</returns>
        public Bold GetError(string path, FontArgs fontArgs)
        {
            Bold bold = GetBold(path, fontArgs);
            bold.Foreground = new SolidColorBrush(Colors.Red);
            bold.FontSize += 5;
            return bold;
        }

        /// <summary>
        /// Get bold.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get bold result.</returns>
        public Bold GetBold(string path, FontArgs fontArgs)
        {
            Bold bold = new Bold();
            FontArgs fa2 = new FontArgs(fontArgs);
            Windows.UI.Text.FontWeight boldFontWeight = new Windows.UI.Text.FontWeight();
            boldFontWeight.Weight = 700;
            fa2.fontWeight = boldFontWeight;
            bold.Inlines.Add(GetRun(path, fa2));
            return bold;
        }

        /// <summary>
        /// Get run.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get run result.</returns>
        public Run GetRun(string text, FontArgs fontArgs)
        {
            Run run = new Run();
            run.FontFamily = fontArgs.fontFamily;
            run.FontSize = fontArgs.fontSize;
            run.FontStretch = fontArgs.fontStretch;
            run.FontStyle = fontArgs.fontStyle;
            run.FontWeight = fontArgs.fontWeight;
            run.Text = text;
            
            texts.Add(new MeasureStringArgs(run.FontFamily, run.FontSize, run.FontStyle, run.FontStretch, run.FontWeight, run.Text));
            return run;
        }

        /// <summary>
        /// Get hyperlink.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="margin">The margin.</param>
        /// <param name="padding">The padding.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get hyperlink result.</returns>
        public InlineUIContainer GetHyperlink(string text, string uri, Thickness margin, Thickness padding, FontArgs fontArgs)
        {
            HyperlinkButton link = new HyperlinkButton();
            link.FontFamily = fontArgs.fontFamily;
            link.FontSize = fontArgs.fontSize;
            link.FontStretch = fontArgs.fontStretch;
            link.FontStyle = fontArgs.fontStyle;
            link.FontWeight = fontArgs.fontWeight;
            link.NavigateUri = new Uri(uri);
            link.Padding = padding;
            link.Margin = margin;
            //link.Name = ControlNameGenetator.GetSeries(link.GetType());
            InlineUIContainer inlines = new InlineUIContainer();
            
            //inlines.Name = ControlNameGenetator.GetSeries(inlines.GetType());
            link.Content = text;
            texts.Add(new MeasureStringArgs(link.FontFamily, link.FontSize, link.FontStyle, link.FontStretch, link.FontWeight, link.Content.ToString()));
            inlines.Child = link;
            
            return inlines;
        }

        FontWeight ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, InlineUIContainer, FontArgs>.GetFontWeight(FontWeight2 fontWeight)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get hyperlink.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="fontArgs">The font args.</param>
        /// <returns>The get hyperlink result.</returns>
        public InlineUIContainer GetHyperlink(string text, string uri, FontArgs fontArgs)
        {
            throw new NotImplementedException();
        }
    }
