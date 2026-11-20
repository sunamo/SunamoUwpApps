namespace apps.Helpers.Controls;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using System.Collections;
using Windows.System;
using Windows.Storage;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.UI.Core;
using apps;
using System.Threading.Tasks;
using apps.AwesomeFont;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Controls.Primitives;
using apps.Helpers;
using System.Collections.ObjectModel;

    /// <summary>
    /// Represents the list box helper t type.
    /// </summary>
    public class ListBoxHelper<T> : SelectorHelper<T> where T : IIdentificator
    {
        static Type type = typeof(ListBoxHelper);

        /// <summary>
        /// EK, OOP.
        /// V¢chozy pro A2 bylo SelectionMode.Extended
        /// </summary>
        /// <param name="listBox"></param>
        public ListBoxHelper(ListBox listBox, SelectionMode selectionMode, ObservableCollection<SelectorHelperItem> boc) : base(listBox, boc)
        {
                listBox.SelectionMode = selectionMode;
        }

        /// <summary>
        /// Remove from selector.
        /// </summary>
        /// <param name="value">The value.</param>
        protected override void RemoveFromSelector(object value)
        {
            ThrowEx.NotImplementedMethod();
        }
    }

    /// <summary>
    /// Represents the list box helper type.
    /// </summary>
    public class ListBoxHelper : SelectorHelper
    {
        static Type type = typeof(SelectorHelper);

        /// <summary>
        /// EK, OOP.
        /// Vychozi pro A2 bylo SelectionMode.Extended
        /// </summary>
        /// <param name="listBox"></param>
        public ListBoxHelper(ListBox listBox, SelectionMode selectionMode, ObservableCollection<SelectorHelperItem> boc) : base(listBox, boc)
        {
            listBox.SelectionMode = selectionMode;
        }

        /// <summary>
        /// Remove from selector.
        /// </summary>
        /// <param name="value">The value.</param>
        protected override void RemoveFromSelector(object value)
        {
            ThrowEx.NotImplementedMethod();
        }
    }
