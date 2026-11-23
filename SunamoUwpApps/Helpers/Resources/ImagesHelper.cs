namespace apps.Helpers.Resources;

using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Represents the images helper type.
/// </summary>
public static class ImagesHelper
{
    //-Tato třída je zde, abych když budu konvertovat nějaký kód z WPF do WF, tak přidám pouze s do ImageHelper(vznikne ImagesHelper) a na levé straně upravím, aby se to načítalo přímo do Image místo do Content. Snad si tímto ušetřím trochu práce
    /// <summary>
    /// Ms appx.
    /// </summary>
    /// <param name="enabled">The enabled.</param>
    /// <param name="appPic">The app pic.</param>
    /// <returns>The ms appx result.</returns>
    public static Image MsAppx(bool enabled, AppPics appPic)
    {
        ///Subfolder/ResourceFile.xaml
        return ImageHelper.ReturnImage( BitmapImagesHelper.MsAppx(enabled, appPic));
    }
}
