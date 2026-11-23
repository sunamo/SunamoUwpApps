namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the check box helper type.
    /// </summary>
    public static class CheckBoxHelper
    {
        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="noWrap">The no wrap.</param>
        /// <param name="value">The value.</param>
        /// <returns>The get result.</returns>
        public static CheckBox Get(TextWrapping noWrap, string value)
        {
            return Get(noWrap, value, null);
        }

        /// <summary>
        /// Get.
        /// </summary>
        /// <param name="noWrap">The no wrap.</param>
        /// <param name="value">The value.</param>
        /// <param name="tag">The tag.</param>
        /// <returns>The get result.</returns>
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
