using Microsoft.Web.WebView2.Core;

namespace SunamoUwpApps._sunamo;

/// <summary>Delegate taking a string and returning a string.</summary>
public delegate string StringString(string s);
/// <summary>Delegate taking a generic value and returning void.</summary>
public delegate void VoidT<T>(T t);
/// <summary>Delegate taking an int and returning void.</summary>
public delegate void VoidInt(int i);
/// <summary>Delegate taking a string and returning void.</summary>
public delegate void VoidString(string s);
/// <summary>Delegate taking a nullable bool and returning void.</summary>
public delegate void VoidBoolNullable(bool? b);
/// <summary>Async delegate taking a nullable bool.</summary>
public delegate Task TaskBoolNullable(bool? b);
/// <summary>Delegate taking a Uri and returning void.</summary>
public delegate void VoidUri(Uri uri);
/// <summary>Delegate taking an object and returning void.</summary>
public delegate void VoidObject(object o);
/// <summary>Delegate without parameters returning void.</summary>
public delegate void VoidVoid();
/// <summary>Delegate taking an object and a bool and returning void.</summary>
public delegate void VoidObjectBool(object o, bool b);
/// <summary>Handler raised when the browser finished navigation.</summary>
public delegate void LoadCompletedEventHandler(object sender, CoreWebView2NavigationCompletedEventArgs e);
/// <summary>Handler for events that carry a Uri.</summary>
public delegate void UriEventHandler(object sender, UriEventArgs e);

/// <summary>Event data carrying a Uri.</summary>
public class UriEventArgs : EventArgs
{
    /// <summary>The carried address.</summary>
    public Uri Uri { get; }

    /// <summary>Creates event data for the given address.</summary>
    public UriEventArgs(Uri uri)
    {
        Uri = uri;
    }
}
