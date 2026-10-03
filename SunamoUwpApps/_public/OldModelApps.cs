using System.Reflection;

namespace SunamoUwpApps._sunamo;

/// <summary>Part of a simple XPath expression, for example tag[@name="value"].</summary>
public class XPathPart
{
    /// <summary>Name of the tag.</summary>
    public string tag;
    /// <summary>Name of the attribute, empty when not used.</summary>
    public string attName = string.Empty;
    /// <summary>Value of the attribute, empty when not used.</summary>
    public string attValue = string.Empty;

    /// <summary>Parses the part of an XPath expression.</summary>
    public XPathPart(string part)
    {
        var open = part.IndexOf('[');
        var close = part.IndexOf(']');
        if (open != -1 && close != -1)
        {
            tag = part.Substring(0, open);
            var attribute = part.Substring(open + 1, close - open - 1);
            if (attribute.StartsWith("@"))
            {
                var pair = attribute.Substring(1).Split('=');
                attName = pair[0];
                attValue = pair.Length > 1 ? pair[1].Trim('"', '\'') : string.Empty;
            }
        }
        else
        {
            tag = part;
        }
    }
}

/// <summary>Marks a class mapped to an outer storage.</summary>
public class OuterObjectAttribute : Attribute
{
}

/// <summary>Marks a property that is not stored.</summary>
public class IgnoreAttribute : Attribute
{
}

/// <summary>Marks a primary key property.</summary>
public class PrimaryKeyAttribute : Attribute
{
}

/// <summary>Tag stored in the Tag of the web view.</summary>
public class WebViewTag
{
    /// <summary>Text representation of the page.</summary>
    public string toString;
    /// <summary>Html content of the page.</summary>
    public string content;
}

/// <summary>Static facade over the clipboard helper.</summary>
public static class ClipboardHelper
{
    /// <summary>Clipboard helper of the Windows apps.</summary>
    public static IClipboardHelperApps InstanceApps;

    /// <summary>Puts the text to the clipboard.</summary>
    public static void SetText(string text)
    {
        (InstanceApps ?? ClipboardHelperApps.Instance).SetText(text);
    }
}
