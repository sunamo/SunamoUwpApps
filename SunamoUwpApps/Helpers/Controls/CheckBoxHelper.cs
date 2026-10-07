namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    public static class CheckBoxHelper
    {
        public static CheckBox Get(TextWrapping noWrap, string value)
        {
            return Get(noWrap, value, null);
        }

        public static CheckBox Get(TextWrapping noWrap, string value, object tag)
        {
            CheckBox chb = new CheckBox();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = value;
            chb.Tag = tag;
            textBlock.TextWrapping = noWrap;
            chb.Content = textBlock;
            return chb;
        }
    }
