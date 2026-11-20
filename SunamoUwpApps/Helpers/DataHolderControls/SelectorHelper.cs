namespace apps.Helpers.DataHolderControls;

using apps.AwesomeFont;
using apps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the selector helper t u type.
    /// </summary>
    public abstract class SelectorHelper<T, U> : SelectorHelper where T : IIdentificator
    {
        /// <summary>
        /// Výchozí pro A2 bylo SelectionMode.Extended
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="sm"></param>
        public SelectorHelper(Selector selector, ObservableCollection<SelectorHelperItem> boc)
            : base(selector, boc)
        {

            selector.SelectionChanged += Lb_SelectionChanged;
        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (selector.SelectedItem is T)
            {
                T item = (T)selector.SelectedItem;
                SelectedO = item;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(SelectedU);
                }
            }
        }

        /// <summary>
        /// The selection changed.
        /// </summary>
        public event VoidT<U> SelectionChanged;

        /// <summary>
        /// The selected u.
        /// </summary>
        public U SelectedU
        {
            get
            {
                if (SelectedO != null)
                {
                    var identificator = (SelectedO as IIdentificator);
                    return (U)identificator.Id;
                }

                return default(U);
            }
        }

        /// <summary>
        /// Get items list t.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>The get items list t result.</returns>
        public static List<T> GetItemsListT(ItemCollection items)
        {
            List<T> result = new List<T>();
            foreach (object var in items)
            {
                if (var is T)
                {
                    result.Add((T)var);
                }
            }
            return result;
        }
    }

    /// <summary>
    /// Um. lepsi man. s LB.
    /// </summary>
    public abstract class SelectorHelper : IAsync
    {
        /// <summary>
        /// The selected o.
        /// </summary>
        public object SelectedO = null;
        /// <summary>
        /// The selector.
        /// </summary>
        protected Selector selector = null;
        /// <summary>
        /// The item removed object.
        /// </summary>
        public event VoidObject ItemRemovedObject;

        //protected object Selected = null;
        /// <summary>
        /// The oc.
        /// </summary>
        public IList oc = null;
        /// <summary>
        /// Gets the is selected.
        /// </summary>
        public bool IsSelected { get {
                return SelectedO != null;
            } }

        /// <summary>
        /// Initializes a new instance of the selector helper class.
        /// </summary>
        /// <param name="selectorControl">The selector control.</param>
        /// <param name="boc">The boc.</param>
        public SelectorHelper(Selector selectorControl, ObservableCollection<SelectorHelperItem> boc)
        {
            selector = selectorControl;
            oc = boc;

            selectorControl.SelectionChanged += Lb_SelectionChanged;
        }

        /// <summary>
        /// Update items source.
        /// </summary>
        public void UpdateItemsSource()
        {
            selector.ItemsSource = null;
            selector.ItemsSource = oc;
        }

        /// <summary>
        /// Run one.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RunOne(object value)
        {
            if (value != null)
            {
                StorageFile storageFile = GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(value.ToString()).AsTask());
                if (FSApps.ExistsFile(storageFile))
                {
                    AsyncHelperApps.ci.GetResult( Launcher.LaunchFileAsync(storageFile));
                }
            }
        }

        /// <summary>
        /// Save to clipboard.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SaveToClipboard(object value)
        {
            if (value != null)
            {
                ClipboardHelper.SetText(value.ToString());
            }
        }

        /// <summary>
        /// Remove one.
        /// </summary>
        /// <param name="value">The value.</param>
        public void RemoveOne(object value)
        {
            if (value != null)
            {
                if (ItemRemovedObject != null)
                {
                    ItemRemovedObject(value);
                }

                RemoveFromSelector(value);
            }
        }

        /// <summary>
        /// Remove from selector.
        /// </summary>
        /// <param name="value">The value.</param>
        protected abstract void RemoveFromSelector(object value);

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (selector.SelectedItem != null)
            {
                object value = selector.SelectedItem;
                SelectedO = value;
                if (this.SelectionChangedObject != null)
                {
                    this.SelectionChangedObject(value);
                }
            }
        }

        /// <summary>
        /// The selection changed object.
        /// </summary>
        public event VoidObject SelectionChangedObject;
        /// <summary>
        /// Zkopiruje do schranky vsechny polozky v lb
        /// </summary>
        public void CopyToClipboard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (object var in selector.Items)
            {
                stringBuilder.AppendLine(var.ToString());
            }
            ClipboardHelper.SetText(stringBuilder.ToString());
        }

        AwesomeFontButtonWithAction CreateAwesomeFontButtonWithAction(bool visible, double size, VoidObject runOne, string otf, SolidColorBrush brush, object idObject)
        {
            var button = new AwesomeFontButtonWithAction();
            button.InitAwesomeFontButtonWithAction(visible, size, size, runOne, otf, brush, idObject);
            return button;

        }

        ButtonWithAction CreateButtonWithAction(bool visible, double size, VoidObject runOne, object content, object idObject)
        {
            var button = new ButtonWithAction();
            button.InitButtonWithAction(visible, size, size, runOne, content, idObject);
            return button;
        }


        /// <summary>
        /// Get items list string.
        /// </summary>
        /// <returns>The get items list string result.</returns>
        public List<string> GetItemsListString()
        {
            List<string> result = new List<string>();
            foreach (object item in selector.Items)
            {
                result.Add(item.ToString());
            }
            return result;
        }

        /// <summary>
        /// Get selected list string.
        /// </summary>
        /// <param name="selectedObjectCollection">The selected object collection.</param>
        /// <returns>The get selected list string result.</returns>
        public static List<string> GetSelectedListString(IList selectedObjectCollection)
        {
            List<string> result = new List<string>();
            foreach (object var in selectedObjectCollection)
            {
                result.Add(var.ToString());
            }
            return result;
        }

        /// <summary>
        /// Get items list t t 1.
        /// </summary>
        /// <typeparam name="T1">The type T1.</typeparam>
        /// <param name="objectCollection">The object collection.</param>
        /// <returns>The get items list t t 1 result.</returns>
        public static List<T1> GetItemsListT<T1>(ItemCollection objectCollection)
        {
            List<T1> items = new List<T1>();
            foreach (T1 var in objectCollection)
            {
                items.Add(var);
            }
            return items;
        }

        /// <summary>
        /// Get items list string.
        /// </summary>
        /// <param name="objectCollection">The object collection.</param>
        /// <returns>The get items list string result.</returns>
        public static List<string> GetItemsListString(ItemCollection objectCollection)
        {
            List<string> items = new List<string>();
            foreach (object var in objectCollection)
            {
                items.Add(var.ToString());
            }
            return items;
        }

        /// <summary>
        /// Is selected static.
        /// </summary>
        /// <param name="listView">The list view.</param>
        /// <returns>The is selected static result.</returns>
        public static bool IsSelectedStatic(ListView listView)
        {
            return listView.SelectedItem != null;
        }

        /// <summary>
        /// Get result t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The get result t result.</returns>
        public T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }

    /// <summary>
    /// Add SelectedT property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SelectorHelper<T> : SelectorHelper
        {
            /// <summary>
            /// Výchozí pro A2 bylo SelectionMode.Extended
            /// </summary>
            /// <param name="selector"></param>
            /// <param name="sm"></param>
            public SelectorHelper(Selector selector, ObservableCollection<SelectorHelperItem> boc)
                : base(selector, boc)
            {

                selector.SelectionChanged += Lb_SelectionChanged;
            }

            private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
            {
                if (selector.SelectedItem is T)
                {
                    T item = (T)selector.SelectedItem;
                SelectedO = item;
                    if (this.SelectionChanged != null)
                    {
                        this.SelectionChanged(item);
                    }
                }
            }

            /// <summary>
            /// The selection changed.
            /// </summary>
            public event VoidT<T> SelectionChanged;

            /// <summary>
            /// The selected t.
            /// </summary>
            public T SelectedT
            {
                get
                {
                    return (T)SelectedO;
                }
            }

            /// <summary>
            /// Get items list t.
            /// </summary>
            /// <param name="items">The items.</param>
            /// <returns>The get items list t result.</returns>
            public static List<T> GetItemsListT(ItemCollection items)
            {
                List<T> result = new List<T>();
                foreach (object var in items)
                {
                    if (var is T)
                    {
                        result.Add((T)var);
                    }
                }
                return result;
            }
        }
