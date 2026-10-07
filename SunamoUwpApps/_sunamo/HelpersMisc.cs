using System.Globalization;
using System.Xml.Linq;

namespace SunamoUwpApps._sunamo;

/// <summary>Serialization of lists to one line.</summary>
internal static class SF
{
    /// <summary>Joins the values to one line.</summary>
    internal static string PrepareToSerialization(List<string> values)
    {
        return string.Join(";", values);
    }

    /// <summary>Splits the serialized line to values.</summary>
    internal static List<string> GetAllElementsLine(string line)
    {
        return line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}

/// <summary>Uri helpers.</summary>
internal static class UH
{
    /// <summary>Creates the Uri, adds http scheme when missing.</summary>
    internal static Uri CreateUri(string text)
    {
        if (!text.Contains("://"))
        {
            text = "http://" + text;
        }
        return new Uri(text);
    }
}

/// <summary>Current culture of the application.</summary>
internal static class AppLangHelper
{
    /// <summary>Current UI culture.</summary>
    internal static CultureInfo currentUICulture => CultureInfo.CurrentUICulture;
}

/// <summary>Special folders.</summary>
internal static class SpecialFoldersHelper
{
    /// <summary>Returns the roaming AppData folder.</summary>
    internal static string AppDataRoaming()
    {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    }
}

/// <summary>Constants of SQL Server.</summary>
internal static class SqlServerHelper
{
    /// <summary>Minimal date of the datetime type.</summary>
    internal static readonly DateTime DateTimeMinVal = new DateTime(1753, 1, 1);
}

/// <summary>Generates unique names of controls.</summary>
internal static class ControlNameGenerator
{
    private static Dictionary<Type, uint> s_actual = new Dictionary<Type, uint>();

    /// <summary>Returns next name in the series of the type.</summary>
    internal static string GetSeries(Type type)
    {
        if (s_actual.ContainsKey(type))
        {
            return type.Name + (++s_actual[type]).ToString();
        }

        s_actual.Add(type, 0);
        return type.Name + "0";
    }
}

/// <summary>HtmlAgilityPack helpers.</summary>
internal static class HtmlAgilityHelper
{
    /// <summary>Creates an empty document.</summary>
    internal static HtmlDocument CreateHtmlDocument()
    {
        return new HtmlDocument();
    }
}

/// <summary>Xml helpers.</summary>
internal static class XHelper
{
    /// <summary>Returns the first child element of the name.</summary>
    internal static XElement GetElementOfName(XElement parent, string name)
    {
        return parent.Elements().FirstOrDefault(element => element.Name.LocalName == name);
    }

    /// <summary>Returns the first child element of the name with the attribute value.</summary>
    internal static XElement GetElementOfNameWithAttr(XElement parent, string name, string attributeName, string attributeValue)
    {
        return parent.Elements().FirstOrDefault(element => element.Name.LocalName == name && (string)element.Attribute(attributeName) == attributeValue);
    }
}

/// <summary>Writes diagnostic messages to the debug output.</summary>
internal class DebugLogger
{
    /// <summary>Shared instance.</summary>
    internal static DebugLogger Instance = new DebugLogger();

    /// <summary>Writes the line to the debug output.</summary>
    internal void WriteLine(string text)
    {
        System.Diagnostics.Debug.WriteLine(text);
    }

    /// <summary>Writes the labeled value to the debug output.</summary>
    internal void WriteLine(string label, object value)
    {
        System.Diagnostics.Debug.WriteLine(label + ": " + value);
    }
}

/// <summary>Localization of keys.</summary>
internal static class sess
{
    /// <summary>Returns translation of the key, the key itself when translation is not available.</summary>
    internal static string i18n(string key)
    {
        return key;
    }
}

/// <summary>Date and time formatting.</summary>
internal static class DTHelper
{
    /// <summary>Returns the time as H:mm:ss.</summary>
    internal static string TimeToStringAngularTime(DateTime dateTime)
    {
        return dateTime.ToString("H:mm:ss");
    }

    /// <summary>Returns the date in the format of the language.</summary>
    internal static string DateToString(DateTime dateTime, Langs language)
    {
        return language == Langs.cs ? dateTime.ToString("d. M. yyyy") : dateTime.ToString("M/d/yyyy");
    }

    /// <summary>Returns the date and time, empty for the minimal value.</summary>
    internal static string DateTimeToString(DateTime dateTime, Langs language, DateTime minValue)
    {
        if (dateTime == minValue)
        {
            return string.Empty;
        }
        return DateToString(dateTime, language) + " " + dateTime.ToString("H:mm:ss");
    }

    /// <summary>Returns the date and time usable in a file name.</summary>
    internal static string DateTimeToFileName(DateTime dateTime, bool withMiliseconds)
    {
        return dateTime.ToString(withMiliseconds ? "yyyy-MM-dd_HH-mm-ss-fff" : "yyyy-MM-dd_HH-mm-ss");
    }

    /// <summary>Returns the duration as text.</summary>
    internal static string OperationLastedInLocalizateString(TimeSpan timeSpan, Langs language)
    {
        return timeSpan.TotalSeconds.ToString("0.###") + " s";
    }
}
