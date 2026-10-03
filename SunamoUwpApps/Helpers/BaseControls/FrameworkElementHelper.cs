namespace apps.Helpers.BaseControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

    public static class FrameworkElementHelper 
    {
        public static void DebugAllSizes(FrameworkElement fw)
        {
            DebugLogger.Instance.WriteLine("***");
            DebugLogger.Instance.WriteLine( fw.Name + " of type " + fw.GetType().Name);
            DebugLogger.Instance.WriteLine("ActualSize", fw.ActualSize);
            DebugLogger.Instance.WriteLine("DesiredSize", fw.DesiredSize);
            DebugLogger.Instance.WriteLine("RenderSize", fw.RenderSize);
            DebugLogger.Instance.WriteLine("Width/Height", fw.Width + "x" + fw.Height);
            DebugLogger.Instance.WriteLine("Actual", fw.ActualWidth + "x" + fw.ActualHeight);
            DebugLogger.Instance.WriteLine("Min", fw.MinWidth + "x" + fw.MinHeight);
            DebugLogger.Instance.WriteLine("Max", fw.MaxWidth + "x" + fw.MaxHeight);
            DebugLogger.Instance.WriteLine("***");
        }

        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        public static void SetMinMaxWidth(FrameworkElement e, double v)
        {
            e.MinWidth = e.MaxWidth = v;
        }

        public static void SetMinMaxHeight(FrameworkElement e, double v)
        {
            e.MinHeight = e.MaxHeight = v;
        }

        /// <summary>
        /// Vrátí new Size(fe.ActualWidth, fe.ActualHeight);
        /// </summary>
        /// <param name="fe"></param>
        public static Size GetMaxContentSize(FrameworkElement fe)
        {
            return new Size(fe.ActualWidth, fe.ActualHeight);
        }

        public static void SetMaxContentSize(FrameworkElement fe, Size s)
        {
            fe.MaxWidth = s.Width;
            fe.MaxHeight = s.Height;

            var r1 = fe.RenderSize;

            fe.Measure(s);

            var r2 = fe.RenderSize;
            
            //fe.InvalidateArrange();
            
            //fe.UpdateLayout();
        }

        

        public static RenderTargetBitmap CaptureToStreamAsync(FrameworkElement uielement, IRandomAccessStream stream, Guid encoderId)
        {
            try
            {
                var renderTargetBitmap = new RenderTargetBitmap();
                AsyncHelperApps.ci.GetResult( renderTargetBitmap.RenderAsync(uielement));

                var pixels = GetResult<IBuffer>( renderTargetBitmap.GetPixelsAsync().AsTask());

                var logicalDpi = DisplayInformation.GetForCurrentView().LogicalDpi;
                var encoder = GetResult<BitmapEncoder>( BitmapEncoder.CreateAsync(encoderId, stream).AsTask());
                encoder.SetPixelData(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Ignore,
                    (uint)renderTargetBitmap.PixelWidth,
                    (uint)renderTargetBitmap.PixelHeight,
                    logicalDpi,
                    logicalDpi,
                    pixels.ToArray());

                AsyncHelperApps.ci.GetResult( encoder.FlushAsync());

                return renderTargetBitmap;
            }
            catch (Exception ex)
            {
                //DisplayMessage(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// ControlHelper.GetMinimumSize - call only measure
        /// FrameworkElementHelper.SizeToContent - call measure and arrange
        /// </summary>
        /// <param name="window"></param>
        public static void SizeToContent(FrameworkElement window)
        {
            window.Measure(ControlHelper.SizePositiveInfinity);
            window.Arrange(new Rect(0, 0, window.DesiredSize.Width, window.DesiredSize.Height));
        }

        public static T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
