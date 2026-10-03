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
        public void InitAwesomeFontButtonWithAction(bool visible, double width, double height, VoidObject action, string otf, Brush fg, object idObject)
        {
            if (visible)
            {
                InitButtonWithAction(visible, width, height, action, null, idObject);

                TextBlock tb = new TextBlock();

                 AwesomeFontControls.SetAwesomeFontSymbol(tb, otf, fg, AwesomeFontControls.CalculateFontSize(width), "");

                base.SetButtonContent(tb);
            }
        }
    }
