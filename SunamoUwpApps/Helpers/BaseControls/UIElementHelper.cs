namespace apps.Helpers.BaseControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Windows.UI.Core;

    class UIElementHelper
    {
        public  static void Refresh( UIElement uiElement)
        {
            uiElement.UpdateLayout();
        }
    }
