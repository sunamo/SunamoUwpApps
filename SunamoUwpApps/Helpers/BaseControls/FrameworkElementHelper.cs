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

    /// <summary>
    /// Represents the framework element helper type.
    /// </summary>
    public static class FrameworkElementHelper 
    {
        /// <summary>
        /// Debug all sizes.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        public static void DebugAllSizes(FrameworkElement frameworkElement)
        {
            DebugLogger.Instance.WriteLine("***");
            DebugLogger.Instance.WriteLine( frameworkElement.Name + " of type " + frameworkElement.GetType().Name);
            DebugLogger.Instance.WriteLine("ActualSize", frameworkElement.ActualSize);
            DebugLogger.Instance.WriteLine("DesiredSize", frameworkElement.DesiredSize);
            DebugLogger.Instance.WriteLine("RenderSize", frameworkElement.RenderSize);
            DebugLogger.Instance.WriteLine("Width/Height", frameworkElement.Width + "x" + frameworkElement.Height);
            DebugLogger.Instance.WriteLine("Actual", frameworkElement.ActualWidth + "x" + frameworkElement.ActualHeight);
            DebugLogger.Instance.WriteLine("Min", frameworkElement.MinWidth + "x" + frameworkElement.MinHeight);
            DebugLogger.Instance.WriteLine("Max", frameworkElement.MaxWidth + "x" + frameworkElement.MaxHeight);
            DebugLogger.Instance.WriteLine("***");
        }

        /// <summary>
        /// Get element rect.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>The get element rect result.</returns>
        public static Rect GetElementRect(FrameworkElement element)
        {
            GeneralTransform buttonTransform = element.TransformToVisual(null);
            Point point = buttonTransform.TransformPoint(new Point());
            return new Rect(point, new Size(element.ActualWidth, element.ActualHeight));
        }

        /// <summary>
        /// Set min max width.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <param name="value">The value.</param>
        public static void SetMinMaxWidth(FrameworkElement frameworkElement, double value)
        {
            frameworkElement.MinWidth = frameworkElement.MaxWidth = value;
        }

        /// <summary>
        /// Set min max height.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <param name="value">The value.</param>
        public static void SetMinMaxHeight(FrameworkElement frameworkElement, double value)
        {
            frameworkElement.MinHeight = frameworkElement.MaxHeight = value;
        }

        /// <summary>
        /// Vrátí new Size(fe.ActualWidth, fe.ActualHeight);
        /// </summary>
        /// <param name="frameworkElement"></param>
        public static Size GetMaxContentSize(FrameworkElement frameworkElement)
        {
            return new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
        }

        /// <summary>
        /// Set max content size.
        /// </summary>
        /// <param name="frameworkElement">The framework element.</param>
        /// <param name="size">The size.</param>
        public static void SetMaxContentSize(FrameworkElement frameworkElement, Size size)
        {
            frameworkElement.MaxWidth = size.Width;
            frameworkElement.MaxHeight = size.Height;

            var firstRenderSize = frameworkElement.RenderSize;

            frameworkElement.Measure(size);

            var secondRenderSize = frameworkElement.RenderSize;
            
            //fe.InvalidateArrange();
            
            //fe.UpdateLayout();
        }

        

        /// <summary>
        /// Capture to stream async.
        /// </summary>
        /// <param name="uielement">The uielement.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="encoderId">The encoder id.</param>
        /// <returns>The capture to stream async result.</returns>
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
            catch (Exception exception)
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

        /// <summary>
        /// Get result t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="task">The task.</param>
        /// <returns>The get result t result.</returns>
        public static T GetResult<T>(Task<T> task)
        {
            return AsyncHelper.ci.GetResult<T>(task);
        }
    }
