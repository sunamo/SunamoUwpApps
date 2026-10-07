namespace apps.Helpers.ContainerControls;

using apps.Essential;
using Windows.Foundation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;

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
            Size size = PageHelper.WindowSize(false);
            //ip.xName = ControlNameGenerator.GetSeries(child.GetType());
            Popup popup = new Popup();
            popup.Width = size.Width;
            popup.Height = size.Height;
            popup.Margin = new Thickness(0);
            popup.MinHeight = popup.Height;
            popup.MinWidth = popup.Width;
            popup.Name = ControlNameGenerator.GetSeries(popup.GetType());
            //child.Name = ControlNameGenerator.GetSeries(child.GetType());
            if (child != null)
            {
                IPopupWholeScreen popupWholeScreen = (IPopupWholeScreen)child;
                popupWholeScreen.PopupBorderBrush = borderBrush;

                Size size2 = new Size(size.Width - 4, size.Height - 4);
                child.MinWidth = size2.Width;
                child.MinHeight = size2.Height;

                child.Width = size2.Width;
                child.Height = size2.Height;
                popup.Child = child;
            }
            if (show)
            {
                popup.IsOpen = true;
            }
            return popup;
        }

        static void d(object value)
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
            Popup popup = new Popup();
            popup.IsLightDismissEnabled = false;
            popup.Margin = new Thickness(0);
            popup.Name = ControlNameGenerator.GetSeries(popup.GetType());

            Size windowSize = Size.Empty;
            windowSize = PageHelper.WindowSize(true);
            Size sizeMin = ControlHelper.GetMinimumHeightMinimumWidth(child, windowSize);

            if (child != null)
            {
                child.Name = ControlNameGenerator.GetSeries(child.GetType());
                popup.Child = child;

                IPopupResponsive ips = (IPopupResponsive)child;
                ips.MaxContentSize = sizeMin;
                ips.PopupBorderBrush = borderBrush;

                

                var scaleFactor = DisplayHelper.GetScaleFactor();
                Size sizeMinRecalculatedWithScaleFactor = sizeMin.RecalculateSizeWithScaleFactor();
                Point center = ControlHelper.GetOnCenter(windowSize, sizeMinRecalculatedWithScaleFactor);
                popup.VerticalOffset = ((center.Y));
                popup.HorizontalOffset = ((center.X));
            }

            if (show)
            {
                popup.IsOpen = true;
            }
            return popup;
        }

       public static void ClosePopup()
        {
            var popup2 = WpfApp.mp;
            
            popup2.popup.IsOpen = false;
            VisualTreeHelper.DisconnectChildrenRecursive(popup2.popup);
        }


    }
