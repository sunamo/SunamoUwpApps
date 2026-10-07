namespace apps.Helpers.Resources;

using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

public static class BitmapImageHelper
    {
        public static BitmapImage MsAppx(string relPath)
        {
            
            BitmapImage bitmapImage = new BitmapImage(new Uri(ImageHelper.protocol + relPath, UriKind.Absolute));
            return bitmapImage;
        }

        /// <summary>
        /// Do A1 se vkládá člen výčtu AppPics2.TS()
        /// Přípona se doplní automaticky na .png
        /// Používá se tehdy, když je obrázek v nějaké specifické složce(ne e nebo d) nebo když je přímo v rootu
        /// </summary>
        /// <param name="appPic2"></param>
        public static BitmapImage MsAppxI(string appPic2)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri(ImageHelper.protocol + "i/" + appPic2 + ".png"));
            return bitmapImage;
        }

        public static BitmapImage MsAppx(bool disabled, AppPics appPic)
        {
            string cesta = "";
            if (disabled)
            {
                cesta = "i/d/";
            }
            else
            {
                cesta = "i/e/";
            }
            cesta += appPic.ToString() + ".png";
            return MsAppx(cesta);
        }

    public static BitmapImage PathToBitmapImage(string path)
    {
        return UriToBitmapImage(new Uri(path, UriKind.Absolute));
    }

    public static BitmapImage UriToBitmapImage(Uri uri)
    {
        BitmapImage bitmapImage = new BitmapImage(uri);
        return bitmapImage;
    }

    public static ImageSource Path(string path)
        {
            return Uri(new Uri(path, UriKind.Absolute));
        }

        public static ImageSource Uri(Uri uri)
        {
            BitmapImage bitmapImage = new BitmapImage(uri);
            return bitmapImage;
        }

        public static BitmapImage MsAppxRoot(string path)
        {
            return new BitmapImage(new Uri( ImageHelper.protocol+ path, UriKind.Absolute));
        }

    public static BitmapImage Resize(BitmapImage source, int rate)
    {
        
        
        source.DecodePixelHeight = rate;
        source.DecodePixelWidth = rate;
        
        return source;
    }

    
}
