using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls;

public interface ISunamoAppsBrowser<T> : ISunamoBrowser<T>
{
    WebView2 WebView { get; set; }
    bool IsNavigating { get; set; }
    
}