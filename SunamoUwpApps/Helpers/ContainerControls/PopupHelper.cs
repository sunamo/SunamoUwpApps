using apps.Essential;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;

namespace apps
{
    public static class PopupHelper
    {
        public static void AssignNewSizePopupCenter(Size windowSize, Popup popup)
        {
            //Size s = new Size(p.RenderSize.Width, p.RenderSize.Height);
            Point center = ControlHelper.GetOnCenter(windowSize, new Size(popup.Width, popup.Height));
            popup.HorizontalOffset = center.X;
            popup.VerticalOffset = center.Y;
        }

        /// <summary>
        /// A3  IUN
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="child"></param>
        /// <param name="controlSize"></param>
        /// <param name="show"></param>
        /// <param name="borderBrush"></param>
        public static Popup GetPopupWholeScreen(Control child, bool show, Brush borderBrush)
        {
            Size w = PageHelper.WindowSize(false);
            //ip.xName = ControlNameGenerator.GetSeries(child.GetType());
            Popup p = new Popup();
            p.Width = w.Width;
            p.Height = w.Height;
            p.Margin = new Thickness(0);
            p.MinHeight = p.Height;
            p.MinWidth = p.Width;
            p.Name = ControlNameGenerator.GetSeries(p.GetType());
            //child.Name = ControlNameGenerator.GetSeries(child.GetType());
            if (child != null)
            {
                IPopupWholeScreen ip = (IPopupWholeScreen)child;
                ip.PopupBorderBrush = borderBrush;

                Size s = new Size(w.Width - 4, w.Height - 4);
                child.MinWidth = s.Width;
                child.MinHeight = s.Height;

                child.Width = s.Width;
                child.Height = s.Height;
                p.Child = child;
            }
            if (show)
            {
                p.IsOpen = true;
            }
            return p;
        }

        static void d(object o)
        {
            //DebugLogger.Instance.WriteLine(o);
        }

        /// <summary>
        /// Border thickness se nikdy a nikde nenastavuje tady, dává se pro každý element zvlášť. 
        /// umístí dokonale na střed okna, ověřoval jsem to v Šenově :-)
        /// </summary>
        /// <param name="w"></param>
        /// <param name="child"></param>
        /// <param name="controlSize"></param>
        /// <param name="show"></param>
        /// <param name="borderBrush"></param>
        public static Popup GetPopupResponsive(Control child, bool show, Brush borderBrush)
        {
            Popup p = new Popup();
            p.IsLightDismissEnabled = false;
            p.Margin = new Thickness(0);
            p.Name = ControlNameGenerator.GetSeries(p.GetType());

            Size windowSize = Size.Empty;
            windowSize = PageHelper.WindowSize(true);
            Size sizeMin = ControlHelper.GetMinimumHeightMinimumWidth(child, windowSize);

            if (child != null)
            {
                child.Name = ControlNameGenerator.GetSeries(child.GetType());
                p.Child = child;

                IPopupResponsive ips = (IPopupResponsive)child;
                ips.MaxContentSize = sizeMin;
                ips.PopupBorderBrush = borderBrush;

                

                var scaleFactor = DisplayHelper.GetScaleFactor();
                Size sizeMinRecalculatedWithScaleFactor = sizeMin.RecalculateSizeWithScaleFactor();
                Point center = ControlHelper.GetOnCenter(windowSize, sizeMinRecalculatedWithScaleFactor);
                p.VerticalOffset = ((center.Y));
                p.HorizontalOffset = ((center.X));
            }

            if (show)
            {
                p.IsOpen = true;
            }
            return p;
        }

       public static void ClosePopup()
        {
            var mp = WpfApp.mp;
            
            mp.popup.IsOpen = false;
            VisualTreeHelper.DisconnectChildrenRecursive(mp.popup);
        }


    }
}