namespace apps.Helpers.Resources;

using System;
using Microsoft.UI.Xaml.Media.Imaging;

/// <summary>
/// Represents the bitmap images helper type.
/// </summary>
public static class BitmapImagesHelper
{
    /// <summary>
    /// Ms appx.
    /// </summary>
    /// <param name="enabled">The enabled.</param>
    /// <param name="appPic">The app pic.</param>
    /// <returns>The ms appx result.</returns>
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
