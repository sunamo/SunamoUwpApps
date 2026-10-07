namespace apps.AwesomeFont;

using apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    class AwesomeFontButtonWithAction : ButtonWithAction
    {
        public void InitAwesomeFontButtonWithAction(bool visible, double width, double height, VoidObject action, string otf, Brush brush, object idObject)
        {
            if (visible)
            {
                InitButtonWithAction(visible, width, height, action, null, idObject);

                TextBlock textBlock = new TextBlock();

                 AwesomeFontControls.SetAwesomeFontSymbol(textBlock, otf, brush, AwesomeFontControls.CalculateFontSize(width), "");

                base.SetButtonContent(textBlock);
            }
        }
    }
