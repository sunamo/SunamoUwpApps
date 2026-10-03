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
        /// <param name="lb"></param>
        /// <param name="sm"></param>
        public SelectorHelper(Selector lb, ObservableCollection<SelectorHelperItem> boc)
            : base(lb, boc)
        {

            lb.SelectionChanged += Lb_SelectionChanged;
        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selector.SelectedItem is T)
            {
                T t = (T)selector.SelectedItem;
                SelectedO = t;
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
                    var id = (SelectedO as IIdentificator);
                    return (U)id.Id;
                }

                return default(U);
            }
        }

        public static List<T> GetItemsListT(ItemCollection oc)
        {
            List<T> vr = new List<T>();
            foreach (object var in oc)
            {
                if (var is T)
                {
                    vr.Add((T)var);
                }
            }
            return vr;
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

        public SelectorHelper(Selector lb, ObservableCollection<SelectorHelperItem> boc)
        {
            selector = lb;
            oc = boc;

            lb.SelectionChanged += Lb_SelectionChanged;
        }

        public void UpdateItemsSource()
        {
            selector.ItemsSource = null;
            selector.ItemsSource = oc;
        }

        public void RunOne(object o)
        {
            if (o != null)
            {
                StorageFile sf = GetResult<StorageFile>( StorageFile.GetFileFromPathAsync(o.ToString()).AsTask());
                if (FSApps.ExistsFile(sf))
                {
                    AsyncHelperApps.ci.GetResult( Launcher.LaunchFileAsync(sf));
                }
            }
        }

        public void SaveToClipboard(object o)
        {
            if (o != null)
            {
                ClipboardHelper.SetText(o.ToString());
            }
        }

        public void RemoveOne(object o)
        {
            if (o != null)
            {
                if (ItemRemovedObject != null)
                {
                    ItemRemovedObject(o);
                }

                RemoveFromSelector(o);
            }
        }

        protected abstract void RemoveFromSelector(object o);

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selector.SelectedItem != null)
            {
                object t = selector.SelectedItem;
                SelectedO = t;
                if (this.SelectionChangedObject != null)
                {
                    this.SelectionChangedObject(t);
                }
            }
        }

        public event VoidObject SelectionChangedObject;
        /// <summary>
        /// Zkopiruje do schranky vsechny polozky v lb
        /// </summary>
        public void CopyToClipboard()
        {
            StringBuilder sb = new StringBuilder();
            foreach (object var in selector.Items)
            {
                sb.AppendLine(var.ToString());
            }
            ClipboardHelper.SetText(sb.ToString());
        }

        AwesomeFontButtonWithAction CreateAwesomeFontButtonWithAction(bool visible, double wh, VoidObject runOne, string otf, SolidColorBrush brush, object idObject)
        {
            var vr = new AwesomeFontButtonWithAction();
            vr.InitAwesomeFontButtonWithAction(visible, wh, wh, runOne, otf, brush, idObject);
            return vr;

        }

        ButtonWithAction CreateButtonWithAction(bool visible, double wh, VoidObject runOne, object content, object idObject)
        {
            var vr = new ButtonWithAction();
            vr.InitButtonWithAction(visible, wh, wh, runOne, content, idObject);
            return vr;
        }


        public List<string> GetItemsListString()
        {
            List<string> vr = new List<string>();
            foreach (object item in selector.Items)
            {
                vr.Add(item.ToString());
            }
            return vr;
        }

        public static List<string> GetSelectedListString(IList selectedObjectCollection)
        {
            List<string> vr = new List<string>();
            foreach (object var in selectedObjectCollection)
            {
                vr.Add(var.ToString());
            }
            return vr;
        }

        public static List<T1> GetItemsListT<T1>(ItemCollection objectCollection)
        {
            List<T1> t1 = new List<T1>();
            foreach (T1 var in objectCollection)
            {
                t1.Add(var);
            }
            return t1;
        }

        public static List<string> GetItemsListString(ItemCollection objectCollection)
        {
            List<string> t1 = new List<string>();
            foreach (object var in objectCollection)
            {
                t1.Add(var.ToString());
            }
            return t1;
        }

        public static bool IsSelectedStatic(ListView lv)
        {
            return lv.SelectedItem != null;
        }

        public T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
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
            /// <param name="lb"></param>
            /// <param name="sm"></param>
            public SelectorHelper(Selector lb, ObservableCollection<SelectorHelperItem> boc)
                : base(lb, boc)
            {

                lb.SelectionChanged += Lb_SelectionChanged;
            }

            private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (selector.SelectedItem is T)
                {
                    T t = (T)selector.SelectedItem;
                SelectedO = t;
                    if (this.SelectionChanged != null)
                    {
                        this.SelectionChanged(t);
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

            public static List<T> GetItemsListT(ItemCollection oc)
            {
                List<T> vr = new List<T>();
                foreach (object var in oc)
                {
                    if (var is T)
                    {
                        vr.Add((T)var);
                    }
                }
                return vr;
            }
        }
