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

                for (int first2 = 0; first2 < writeableBitmap.PixelWidth; first2++)
                {
                    for (int second = 0; second < writeableBitmap.PixelHeight; second++)
                    {
                        pxs[first2, second] = writeableBitmap.GetPixel(first2, second);
                    }
                }

                var first = pxs[0, 0];
                
                for (int index = 0; index < pxs.GetLength(0); index++)
                {
                    for (int second2 = 0; second2 < pxs.GetLength(1); second2++)
                    {
                        
                        var pxsi = pxs[index, second2];
#if DEBUG
                        //ColorH.DebugWrite(pxsi);
#endif

                        bool first3 = false;
                        ColorH.IsColorSame(first, pxsi);

                        //bool b2 = pxsi.A < 254;
                        bool second3 = pxsi.A != 0;
                        if (first3)
                        {
                            nt3++;
                            pxs[index, second2] = trans;
                            writeableBitmap.SetPixel(index, second2, trans);
                        }
                        else
                        {
                            ////DebugLogger.Instance.Write(pxsi.Alpha + AllStrings.dash + pxsi.Red + AllStrings.dash + pxsi.Green + AllStrings.dash + pxsi.Blue);
                            if (second3)
                            {
                                number++;
                                pxs[index, second2] = white2;
                                writeableBitmap.SetPixel(index, second2, white2);
                            }
                            else
                            {
                                nt2++;
                                pxs[index, second2] = trans;
                                writeableBitmap.SetPixel(index, second2, trans);
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
