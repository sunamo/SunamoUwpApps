namespace apps.Helpers.Resources;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Microsoft.UI.Xaml.Media.Imaging;

    /// <summary>
    /// Represents the writeable bitmap helper type.
    /// </summary>
    public static class WriteableBitmapHelper 
    {
        /// <summary>
        /// Encode writeable bitmap.
        /// </summary>
        /// <param name="bmp">The bmp.</param>
        /// <param name="writeStream">The write stream.</param>
        /// <param name="encoderId">The encoder id.</param>
        /// <returns>The encode writeable bitmap result.</returns>
        public static IRandomAccessStream EncodeWriteableBitmap(WriteableBitmap bmp, IRandomAccessStream writeStream, Guid encoderId)
        {
            // Copy buffer to pixels
            byte[] pixels;
            using (var stream = bmp.PixelBuffer.AsStream())
            {
                pixels = new byte[(uint)stream.Length];
                stream.ReadAsync(pixels, 0, pixels.Length);
            }

            // Encode pixels into stream
            var encoder = GetResult<BitmapEncoder>( BitmapEncoder.CreateAsync(encoderId, writeStream).AsTask());
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied,
               (uint)bmp.PixelWidth, (uint)bmp.PixelHeight,
               96, 96, pixels);
            AsyncHelperApps.ci.GetResult( encoder.FlushAsync());

            return writeStream;
        }

        /// <summary>
        /// To bitmap image.
        /// </summary>
        /// <param name="writeableBitmap">The writeable bitmap.</param>
        /// <returns>The to bitmap image result.</returns>
        public static  BitmapImage ToBitmapImage(WriteableBitmap writeableBitmap)
        {
            var stream = new InMemoryRandomAccessStream();
            WriteableBitmapHelper.EncodeWriteableBitmap(writeableBitmap, stream, BitmapEncoder.PngEncoderId);

            stream.Seek(0);

            var bitmapImage = new BitmapImage();

            //bm.CreateOptions = BitmapCreateOptions.None;
            bitmapImage.SetSource(stream);

            return bitmapImage;
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
