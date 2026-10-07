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

        public event VoidT<U> SelectionChanged;

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
        public object SelectedO = null;
        protected Selector selector = null;
        public event VoidObject ItemRemovedObject;

        //protected object Selected = null;
        public IList oc = null;
        public bool IsSelected { get {
                return SelectedO != null;
            } }

        public SelectorHelper(Selector selectorControl, ObservableCollection<SelectorHelperItem> boc)
        {
            selector = selectorControl;
            oc = boc;

            selectorControl.SelectionChanged += Lb_SelectionChanged;
        }

        public void UpdateItemsSource()
        {
            selector.ItemsSource = null;
            selector.ItemsSource = oc;
        }

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

        public void SaveToClipboard(object value)
        {
            if (value != null)
            {
                ClipboardHelper.SetText(value.ToString());
            }
        }

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


        public List<string> GetItemsListString()
        {
            List<string> result = new List<string>();
            foreach (object item in selector.Items)
            {
                result.Add(item.ToString());
            }
            return result;
        }

        public static List<string> GetSelectedListString(IList selectedObjectCollection)
        {
            List<string> result = new List<string>();
            foreach (object var in selectedObjectCollection)
            {
                result.Add(var.ToString());
            }
            return result;
        }

        public static List<T1> GetItemsListT<T1>(ItemCollection objectCollection)
        {
            List<T1> items = new List<T1>();
            foreach (T1 var in objectCollection)
            {
                items.Add(var);
            }
            return items;
        }

        public static List<string> GetItemsListString(ItemCollection objectCollection)
        {
            List<string> items = new List<string>();
            foreach (object var in objectCollection)
            {
                items.Add(var.ToString());
            }
            return items;
        }

        public static bool IsSelectedStatic(ListView listView)
        {
            return listView.SelectedItem != null;
        }

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

            public event VoidT<T> SelectionChanged;

            public T SelectedT
            {
                get
                {
                    return (T)SelectedO;
                }
            }

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
