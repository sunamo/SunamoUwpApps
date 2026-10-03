using System.Reflection;

namespace SunamoUwpApps._sunamo;

/// <summary>Font weights accepted by the text block helpers (values are OpenType weights).</summary>
public enum FontWeight2 : ushort
{
    /// <summary>Thin.</summary>
    Thin = 100,
    /// <summary>Normal.</summary>
    Normal = 400,
    /// <summary>Bold.</summary>
    Bold = 700
}

/// <summary>Where the login dialog stores the remembered password.</summary>
public enum StorageApplicationData
{
    /// <summary>Nowhere.</summary>
    NoWhere,
    /// <summary>In a text file.</summary>
    TextFile
}

/// <summary>Encrypt and decrypt delegates used by the login dialog.</summary>
public class CryptDelegates
{
    /// <summary>Decrypts the string, first argument is salt.</summary>
    public Func<string, string, string> decryptString;
    /// <summary>Encrypts the string, first argument is salt.</summary>
    public Func<string, string, string> encryptString;
}

/// <summary>Color with separate channels.</summary>
public struct PixelColor
{
    /// <summary>Blue channel.</summary>
    public byte Blue;
    /// <summary>Green channel.</summary>
    public byte Green;
    /// <summary>Red channel.</summary>
    public byte Red;
    /// <summary>Alpha channel.</summary>
    public byte Alpha;
}

/// <summary>Dictionary base used by the apps collections.</summary>
public class SunamoDictionary<T, U> : Dictionary<T, U>
{
}

/// <summary>Contract of the clipboard helper.</summary>
public interface IClipboardHelperApps
{
    /// <summary>Puts the text to the clipboard.</summary>
    void SetText(string v);
    /// <summary>Puts the lines to the clipboard.</summary>
    void SetLines(List<string> lines);
    /// <summary>Returns true when the clipboard contains text.</summary>
    bool ContainsText();
    /// <summary>Returns the clipboard text.</summary>
    string GetText();
    /// <summary>Returns the clipboard text split to lines.</summary>
    List<string> GetLines();
}

/// <summary>Keys handler for key events.</summary>
public interface IKeysHandler<KeyArg>
{
    /// <summary>Handles the key and returns true when handled.</summary>
    bool HandleKey(KeyArg e);
}

/// <summary>Generic browser interface with type parameter for browser control type.</summary>
public interface ISunamoBrowser<T> : ISunamoBrowser
{
}

/// <summary>Process-wide identity of the application and a hook for status messages.</summary>
public class ThisApp
{
    /// <summary>Name of the application.</summary>
    public static string Name;
    /// <summary>Root namespace of the application.</summary>
    public static string Namespace;
    /// <summary>Raised when a status message should be shown.</summary>
    public static event Action<TypeOfMessage, string> StatusSetted;

    /// <summary>Raises <see cref="StatusSetted"/>.</summary>
    protected static void RaiseStatusSetted(TypeOfMessage t, string message)
    {
        StatusSetted?.Invoke(t, message);
    }
}

/// <summary>Shared language and resource loader of the application.</summary>
public static class RL
{
    /// <summary>Current language.</summary>
    public static Langs l = Langs.en;
    /// <summary>Loader of localized resources.</summary>
    public static IResourceHelper loader;
}
