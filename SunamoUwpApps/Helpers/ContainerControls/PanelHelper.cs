using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace apps.Helpers
{
    public static class PanelHelper
    {
        /// <summary>
        /// A1 může být cokoliv - panel nebo jeho odvozeniny
        /// </summary>
        /// <param name="o"></param>
        public static UIElement GetFirstChildren(object o)
        {
            Panel p = (Panel)o;
            if (p != null)
            {
                UIElementCollection c = p.Children;
                return c[0];
            }
            return null;
        }
    }
}