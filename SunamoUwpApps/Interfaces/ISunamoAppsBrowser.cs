namespace apps.Interfaces;

using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Represents the i sunamo apps browser t type.
/// </summary>
public interface ISunamoAppsBrowser<T> : ISunamoBrowser<T>
{
    /// <summary>
    /// Gets or sets the web view.
    /// </summary>
    WebView2 WebView { get; set; }
    /// <summary>
    /// Gets or sets the is navigating.
    /// </summary>
    bool IsNavigating { get; set; }
    
}
