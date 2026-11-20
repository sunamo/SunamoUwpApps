namespace apps.Helpers.Resources;

using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

/// <summary>
/// Represents the image helper type.
/// </summary>
public static partial class ImageHelper
{
    /// <summary>
    /// Return image.
    /// </summary>
    /// <param name="imageSource">The image source.</param>
    /// <returns>The return image result.</returns>
    public static Image ReturnImage(ImageSource imageSource)
    {
        Image image = new Image();
        image.Stretch = Stretch.Uniform;
        image.Source = imageSource;
        return image;
    }

    /// <summary>
    /// Return image.
    /// </summary>
    /// <param name="imageSource">The image source.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>The return image result.</returns>
    public static Image ReturnImage(ImageSource imageSource, double width, double height)
    {
        Image image = new Image();
        image.Stretch = Stretch.Uniform;
        image.Source = imageSource;
        image.Width = width;
        image.Height = height;
        return image;
    }

    /// <summary>
    /// Toto je jediné místo kde je tato proměnná a to proto že je na něho navázaná metoda SetAssemblyNameForWpfApps, která se musí volat ve WPF(ale ne Windows Store apps) aplikacích
    /// </summary>
    public static string protocol = "ms-appx:///";
    
    /// <summary>
    /// Do A1 se vkládá člen výčtu AppPics2.TS()
    /// Přípona se doplní automaticky na .png
    /// </summary>
    /// <param name="appPic2"></param>
    public static Image MsAppxI(string appPic2)
    {
        BitmapSource bitmapSource = new BitmapImage(new Uri(protocol + "i/" + appPic2 + ".png"));
        return ReturnImage(bitmapSource);
    }

    /// <summary>
    /// Pokud chceš získat jen URI, dej new Uri(ImageHelper.protocol + relPath)
    /// </summary>
    /// <param name="relPath"></param>
    public static Image MsAppx(string relPath)
    {
        BitmapSource bitmapSource = new BitmapImage(new Uri(protocol + relPath));
        return ReturnImage(bitmapSource);
    }

    /// <summary>
    /// Ms appx.
    /// </summary>
    /// <param name="disabled">The disabled.</param>
    /// <param name="appPic">The app pic.</param>
    /// <returns>The ms appx result.</returns>
    public static Image MsAppx(bool disabled, AppPics appPic)
    {
        ///Subfolder/ResourceFile.xaml
        return ReturnImage(BitmapImageHelper.MsAppx(disabled, appPic));
    }
}
