namespace apps;

using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

    public static class Pictures 
    {


        

        public static  Stream TransformImage(StorageFile file, double newWidth, double newHeight, string newFullPath)
        {
            Stream result = null;

            // create a stream from the file and decode the image
            var fileStream = GetResult < IRandomAccessStream>(file.OpenAsync(FileAccessMode.Read).AsTask());
            BitmapSource bs = new BitmapImage(new Uri(file.Path));
            BitmapDecoder decoder = BitmapDecoder.CreateAsync(fileStream).AsTask().Result;

            // create a new stream and encoder for the new image
            using (InMemoryRandomAccessStream ras = new InMemoryRandomAccessStream())
            {
                BitmapEncoder enc = GetResult<BitmapEncoder>(BitmapEncoder.CreateForTranscodingAsync(ras, decoder).AsTask());

                // convert the entire bitmap to a 100px by 100px bitmap
                enc.BitmapTransform.ScaledHeight = (uint)newHeight;
                enc.BitmapTransform.ScaledWidth = (uint)newWidth;

                BitmapBounds bounds = new BitmapBounds();
                bounds.Height = (uint)bs.PixelHeight;
                bounds.Width = (uint)bs.PixelWidth;
                bounds.X = 0;
                bounds.Y = 0;
                enc.BitmapTransform.Bounds = bounds;

                // write out to the stream
                try
                {
                    AsyncHelperApps.ci.GetResult(enc.FlushAsync());
                }
                catch (Exception ex)
                {
                    //string s = ex.ToString();
                    return null;
                }

                result = ras.AsStream();
            }
            return result;
        }


        public static BitmapImage UIElementToImage(UIElement uie)
        {
            var renderTargetBitmap = new RenderTargetBitmap();
            AsyncHelperApps.ci.GetResult(renderTargetBitmap.RenderAsync(uie));
            var pixelBuffer = GetResult<IBuffer>(renderTargetBitmap.GetPixelsAsync().AsTask());

            
                using (var stream = new InMemoryRandomAccessStream())
                {
                    var encoder = GetResult<BitmapEncoder>( BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream).AsTask());
                    encoder.SetPixelData(
                        BitmapPixelFormat.Bgra8,
                        BitmapAlphaMode.Straight,
                        (uint)renderTargetBitmap.PixelWidth,
                        (uint)renderTargetBitmap.PixelHeight, 96d, 96d,
                        pixelBuffer.ToArray());

                AsyncHelperApps.ci.GetResult(encoder.FlushAsync());

                var bi = new BitmapImage();
                bi.SetSource(stream);
                return bi;
            }

            return null;
        }

        public static T GetResult<T>(Task<T> t)
        {
            return AsyncHelper.ci.GetResult<T>(t);
        }
    }
