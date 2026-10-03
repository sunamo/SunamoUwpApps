using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;

namespace apps.Helpers
{
    public static class XamlHelper //: IAsync
    {
        public static BitmapImage CreateBitmapImageFromVisual(FrameworkElement text)
        {
            if (text.ActualHeight != 0 && text.ActualWidth != 0 && false)
            {
                var renderTargetBitmap = new RenderTargetBitmap();
                //, (int)text.ActualWidth, (int)text.ActualHeight
                AsyncHelperApps.ci.GetResult( renderTargetBitmap.RenderAsync(text));
                var pixelBuffer = GetResult<IBuffer>( renderTargetBitmap.GetPixelsAsync().AsTask());

                var stream = new InMemoryRandomAccessStream();


                var encoder = GetResult<BitmapEncoder>( BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream).AsTask());
                encoder.SetPixelData(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Straight,
                    (uint)renderTargetBitmap.PixelWidth,
                    (uint)renderTargetBitmap.PixelHeight, 96d, 96d,
                    pixelBuffer.ToArray());

                AsyncHelperApps.ci.GetResult(encoder.FlushAsync());

                BitmapImage vr = new BitmapImage();
                vr.SetSource(stream);
                return vr;
            }
            return null;
        }

        public static void SaveImage(FrameworkElement text, StorageFile sf)
        {
            var renderTargetBitmap = new RenderTargetBitmap();
            AsyncHelperApps.ci.GetResult(renderTargetBitmap.RenderAsync(text));
            var pixelBuffer = GetResult<IBuffer>( renderTargetBitmap.GetPixelsAsync().AsTask());

            IRandomAccessStream stream = GetResult<IRandomAccessStream>( sf.OpenAsync(FileAccessMode.ReadWrite).AsTask());


            var encoder = GetResult<BitmapEncoder>( BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream).AsTask());
            encoder.SetPixelData(
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Straight,
                (uint)renderTargetBitmap.PixelWidth,
                (uint)renderTargetBitmap.PixelHeight, 96d, 96d,
                pixelBuffer.ToArray());

            AsyncHelperApps.ci.GetResult(encoder.FlushAsync());
        }

        public static T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
}