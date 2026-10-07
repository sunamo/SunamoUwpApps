namespace apps.UniversalWriteableBitmap;

using apps;
using apps.Helpers;
using apps.Helpers.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

    public static class SunamoWriteableBitmap
    {
        public static Grid gridCreateWithImage = null;
        public static Grid grid = null;

        /// <summary>
        /// Funguje naprosto správně, už nic neměnit
        /// </summary>
        /// <param name="bi"></param>
        /// <param name="trans"></param>
        /// <param name="white2"></param>
        public async static Task<WriteableBitmap> MakeWriteableBitmapTransparentAllOther(WriteableBitmap writeableBitmap, Color trans, Color white2, int pixelWidth, int pixelHeight)
        {
            white2.A = 255;

            gridCreateWithImage.Background = new SolidColorBrush(trans);
            int number = 0;
            int nt2 = 0;
            int nt3 = 0;
            using (BitmapContext ctx = writeableBitmap.GetBitmapContext(ReadWriteMode.ReadWrite))
            {
                writeableBitmap = ctx.WriteableBitmap;
                int toIndex = writeableBitmap.PixelWidth * writeableBitmap.PixelHeight + 1;
                Color[,] pxs = new Color[writeableBitmap.PixelWidth, writeableBitmap.PixelHeight];

                for (int columnIndex = 0; columnIndex < writeableBitmap.PixelWidth; columnIndex++)
                {
                    for (int second = 0; second < writeableBitmap.PixelHeight; second++)
                    {
                        pxs[columnIndex, second] = writeableBitmap.GetPixel(columnIndex, second);
                    }
                }

                var first = pxs[0, 0];
                
                for (int index = 0; index < pxs.GetLength(0); index++)
                {
                    for (int rowIndex = 0; rowIndex < pxs.GetLength(1); rowIndex++)
                    {
                        
                        var pxsi = pxs[index, rowIndex];
#if DEBUG
                        //ColorH.DebugWrite(pxsi);
#endif

                        bool isBackgroundColor = false;
                        ColorH.IsColorSame(first, pxsi);

                        //bool b2 = pxsi.A < 254;
                        bool isVisible = pxsi.A != 0;
                        if (isBackgroundColor)
                        {
                            nt3++;
                            pxs[index, rowIndex] = trans;
                            writeableBitmap.SetPixel(index, rowIndex, trans);
                        }
                        else
                        {
                            ////DebugLogger.Instance.Write(pxsi.Alpha + AllStrings.dash + pxsi.Red + AllStrings.dash + pxsi.Green + AllStrings.dash + pxsi.Blue);
                            if (isVisible)
                            {
                                number++;
                                pxs[index, rowIndex] = white2;
                                writeableBitmap.SetPixel(index, rowIndex, white2);
                            }
                            else
                            {
                                nt2++;
                                pxs[index, rowIndex] = trans;
                                writeableBitmap.SetPixel(index, rowIndex, trans);
                            }


                        }
                    }

                }


            }
            return writeableBitmap;
            
                
            
        }

        public async static Task<WriteableBitmap> BufferToWriteableBitmap(IBuffer buffer, int width, int height)
        {
            WriteableBitmap bmp = BitmapFactory.New(width, height);
            bmp = await bmp.FromPixelBuffer(buffer, width, height);

            return bmp;
        }

        public async static Task<WriteableBitmap> CreateFromVisual(FrameworkElement text)
        {
            FrameworkElementHelper.SizeToContent(text);
                var renderTargetBitmap = new RenderTargetBitmap();
                //, (int)text.ActualWidth, (int)text.ActualHeight
                await renderTargetBitmap.RenderAsync(text);
                var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();

                var stream = new InMemoryRandomAccessStream();

                var bpf = BitmapPixelFormat.Bgra8;
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetPixelData(
                    bpf,
                    BitmapAlphaMode.Straight,
                    (uint)renderTargetBitmap.PixelWidth,
                    (uint)renderTargetBitmap.PixelHeight, 96d, 96d,
                    pixelBuffer.ToArray());

                await encoder.FlushAsync();

                WriteableBitmap writeableBitmap = BitmapFactory.New(renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight);
            
                return await writeableBitmap.FromStream(stream, bpf);
            
        }

    }
