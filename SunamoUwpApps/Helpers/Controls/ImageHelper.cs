using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace apps
{
    /// <summary>
    /// ms-appx:/// - where the app is installed
    /// ms-appdata - application with
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Do A1 se vkládá člen výčtu AppPics2.TS()
        /// Přípona se doplní automaticky na .png
        /// </summary>
        /// <param name="appPic2"></param>
        public static Image MsAppxI(string appPic2)
        {
            BitmapSource bs = new BitmapImage(new Uri("ms-appx:///i/" + appPic2 + ".png"));
            return ReturnImage(bs);
        }

        public static Image MsAppx(string relPath)
        {
            BitmapSource bs = new BitmapImage(new Uri("ms-appx:///" + relPath));
            return ReturnImage(bs);
        }

        private static Image ReturnImage(BitmapSource bs)
        {
            Image image = new Image();
            image.Stretch = Stretch.Uniform;
            image.Source = bs;
            return image;
        }

        public static Image MsAppx(bool disabled, AppPics appPic)
        {
            return ReturnImage(BitmapImageHelper.MsAppx(disabled, appPic));
        }

        
    }
}