namespace apps.Helpers.ContainerControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    public static class PanelHelper
    {
        /// <summary>
        /// A1 může být cokoliv - panel nebo jeho odvozeniny
        /// </summary>
        /// <param name="value"></param>
        public static UIElement GetFirstChildren(object value)
        {
            Panel panel = (Panel)value;
            if (panel != null)
            {
                UIElementCollection children = panel.Children;
                return children[0];
            }
            return null;
        }
    }
