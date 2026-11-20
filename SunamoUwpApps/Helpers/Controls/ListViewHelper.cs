namespace apps.Helpers.Controls;

using apps;
using apps.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the list view helper t u type.
    /// </summary>
    public class ListViewHelper<T, U> : SelectorHelper<T, U> where T :IIdentificator
    {
        /// <summary>
        /// EK, OOP.
        /// Výchozí pro A2 bylo SelectionMode.Extended
        /// </summary>
        /// <param name="listView"></param>
        public ListViewHelper(ListView listView, ListViewSelectionMode selectionMode, ObservableCollection<SelectorHelperItem> boc) : base(listView, boc)
        {
            listView.SelectionMode = selectionMode;
        }

        /// <summary>
        /// Remove from selector.
        /// </summary>
        /// <param name="value">The value.</param>
        protected override void RemoveFromSelector(object value)
        {
            if (oc != null)
            {
                for (int index = 0; index < oc.Count; index++)
                {
                    if (EqualityComparer<U>.Default.Equals( SelectedU, (U)value))
                    {
                        oc.RemoveAt(index);
                    }
                }
            }
            else
            {
                selector.Items.Remove(value);
            }
            UpdateItemsSource();
        }
    }

    /// <summary>
    /// Represents the list view helper t type.
    /// </summary>
    public class ListViewHelper<T> : SelectorHelper<T>
        {
            /// <summary>
            /// EK, OOP.
            /// Výchozí pro A2 bylo SelectionMode.Extended
            /// </summary>
            /// <param name="listView"></param>
            public ListViewHelper(ListView listView, ListViewSelectionMode selectionMode, ObservableCollection<SelectorHelperItem> boc) : base(listView, boc)
            {
                listView.SelectionMode = selectionMode;
            }

        /// <summary>
        /// Remove from selector.
        /// </summary>
        /// <param name="value">The value.</param>
        protected override void RemoveFromSelector(object value)
        {
            if (oc != null)
            {
                for (int index = 0; index < oc.Count; index++)
                {
                    if ((oc[index] as SelectorHelperItem).Id == value)
                    {
                        oc.RemoveAt(index);
                    }
                }
            }
            else
            {
                selector.Items.Remove(value);
            }
            UpdateItemsSource();
        }
    }

        /// <summary>
        /// Represents the list view helper type.
        /// </summary>
        public class ListViewHelper : SelectorHelper
        {
            /// <summary>
            /// EK, OOP.
            /// Výchozí pro A2 bylo SelectionMode.Extended
            /// </summary>
            /// <param name="listView"></param>
            public ListViewHelper(ListView listView, ListViewSelectionMode selectionMode, ObservableCollection<SelectorHelperItem> boc) : base(listView, boc)
            {
                listView.SelectionMode = selectionMode;
            }

        /// <summary>
        /// Remove from selector.
        /// </summary>
        /// <param name="value">The value.</param>
        protected override void RemoveFromSelector(object value)
        {
            if (oc != null)
            {
                oc.Remove((SelectorHelperItem)value);

            }
            else
            {
                selector.Items.Remove(value);
            }
            UpdateItemsSource();
        }
    }
