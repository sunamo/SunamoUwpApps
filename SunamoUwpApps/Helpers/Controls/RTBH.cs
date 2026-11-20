namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;

    /// <summary>
    /// Represents the RTBH type.
    /// </summary>
    public class RTBH : TextBlockHelperBase
    {
        /// <summary>
        /// The fa.
        /// </summary>
        public FontArgs fa = FontArgs.DefaultRun();
        RichTextBlock rtb = null;

        /// <summary>
        /// Initializes a new instance of the RTBH class.
        /// </summary>
        /// <param name="rtb">The rtb.</param>
        public RTBH(RichTextBlock rtb)
        {
            this.rtb = rtb;
        }

        /// <summary>
        /// Run.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Run(string path)
        {
            rtb.Blocks.Add(GetParagraph(GetRun(path, fa)));
        }

        /// <summary>
        /// Bold.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Bold(string path)
        {
            rtb.Blocks.Add(GetParagraph( GetBold(path, fa)));
        }

        private Paragraph GetParagraph(Inline bold)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(bold);
            return paragraph;
        }
    }
