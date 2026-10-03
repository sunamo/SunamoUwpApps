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

namespace apps
{
    public class ListBoxHelper<T> : SelectorHelper<T> where T : IIdentificator
    {
        static Type type = typeof(ListBoxHelper);

        /// <summary>
        /// EK, OOP.
        /// V¢chozy pro A2 bylo SelectionMode.Extended
        /// </summary>
        /// <param name="lb"></param>
        public ListBoxHelper(ListBox lb, SelectionMode sm, ObservableCollection<SelectorHelperItem> boc) : base(lb, boc)
        {
                lb.SelectionMode = sm;
        }

        protected override void RemoveFromSelector(object o)
        {
            ThrowEx.NotImplementedMethod();
        }
    }

    public class ListBoxHelper : SelectorHelper
    {
        static Type type = typeof(SelectorHelper);

        /// <summary>
        /// EK, OOP.
        /// Vychozi pro A2 bylo SelectionMode.Extended
        /// </summary>
        /// <param name="lb"></param>
        public ListBoxHelper(ListBox lb, SelectionMode sm, ObservableCollection<SelectorHelperItem> boc) : base(lb, boc)
        {
            lb.SelectionMode = sm;
        }

        protected override void RemoveFromSelector(object o)
        {
            ThrowEx.NotImplementedMethod();
        }
    }
}