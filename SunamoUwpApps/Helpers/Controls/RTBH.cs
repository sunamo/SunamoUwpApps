namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Documents;

    public class RTBH : TextBlockHelperBase
    {
        public FontArgs fa = FontArgs.DefaultRun();
        RichTextBlock rtb = null;

        public RTBH(RichTextBlock rtb)
        {
            this.rtb = rtb;
        }

        public void Run(string path)
        {
            rtb.Blocks.Add(GetParagraph(GetRun(path, fa)));
        }

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
