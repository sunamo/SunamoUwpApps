namespace apps._public;

using Microsoft.Web.WebView2.Core;

public delegate string StringString(string text);
/// <summary>Delegate taking a generic value and returning void.</summary>
public delegate void VoidT<T>(T item);
/// <summary>Delegate taking an int and returning void.</summary>
public delegate void VoidInt(int index);
/// <summary>Delegate taking a string and returning void.</summary>
public delegate void VoidString(string text);
/// <summary>Delegate taking a nullable bool and returning void.</summary>
public delegate void VoidBoolNullable(bool? flag);
/// <summary>Async delegate taking a nullable bool.</summary>
public delegate Task TaskBoolNullable(bool? flag);
/// <summary>Delegate taking a Uri and returning void.</summary>
public delegate void VoidUri(Uri uri);
/// <summary>Delegate taking an object and returning void.</summary>
public delegate void VoidObject(object value);
/// <summary>Delegate without parameters returning void.</summary>
public delegate void VoidVoid();
/// <summary>Delegate taking an object and a bool and returning void.</summary>
public delegate void VoidObjectBool(object value, bool flag);
/// <summary>Handler raised when the browser finished navigation.</summary>
public delegate void LoadCompletedEventHandler(object sender, CoreWebView2NavigationCompletedEventArgs navigationCompletedEventArgs);
/// <summary>Handler for events that carry a Uri.</summary>
public delegate void UriEventHandler(object sender, UriEventArgs uriEventArgs);

/// <summary>Event data carrying a Uri.</summary>
public class UriEventArgs : System.EventArgs
{
    /// <summary>The carried address.</summary>
    public Uri Uri { get; }

    /// <summary>Creates event data for the given address.</summary>
    public UriEventArgs(Uri uri)
    {
        Uri = uri;
    }
}
