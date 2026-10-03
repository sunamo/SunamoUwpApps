using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace apps.Helpers
{
    public static class CheckBoxHelper
    {
        public static CheckBox Get(TextWrapping noWrap, string v)
        {
            return Get(noWrap, v, null);
        }

        public static CheckBox Get(TextWrapping noWrap, string v, object tag)
        {
            CheckBox chb = new CheckBox();
            TextBlock tb = new TextBlock();
            tb.Text = v;
            chb.Tag = tag;
            tb.TextWrapping = noWrap;
            chb.Content = tb;
            return chb;
        }
    }
}