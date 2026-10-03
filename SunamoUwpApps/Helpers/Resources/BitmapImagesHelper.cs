namespace apps.Helpers.Resources;

using System;
using Microsoft.UI.Xaml.Media.Imaging;

public static class BitmapImagesHelper
{
    public static BitmapImage MsAppx(bool enabled, AppPics appPic)
    {
        string cesta = "";
        if (enabled)
        {
            cesta = "i/d/";
        }
        else
        {
            cesta = "i/e/";
        }
        cesta += appPic.ToString() + ".png";
        return BitmapImageHelper.MsAppx(cesta);
    }

    
}
