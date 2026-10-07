using System.Text.RegularExpressions;

namespace SunamoUwpApps._sunamo;

/// <summary>String constants used by the apps helpers.</summary>
internal static class AllStrings
{
    internal const string space = " ";
    internal const string doubleSpace = "  ";
    internal const string dash = "-";
    internal const string swda = " - ";
    internal const string colon = ":";
    internal const string sc = ";";
    internal const string rb = ")";
    internal const string bs = @"\";
    internal const string slash = "/";
    internal const string lowbar = "_";
    internal const string asterisk = "*";
}

/// <summary>Char constants used by the apps helpers.</summary>
internal static class AllChars
{
    internal const char space = ' ';
    internal const char bs = '\\';
}

/// <summary>Throws exceptions with consistent messages.</summary>
internal static class ThrowEx
{
    /// <summary>Throws an exception with the custom message.</summary>
    internal static void Custom(string message)
    {
        throw new Exception(message);
    }

    /// <summary>Throws because the calling method is not implemented.</summary>
    internal static void NotImplementedMethod()
    {
        throw new NotImplementedException("Method is not implemented.");
    }

    /// <summary>Throws because the value was not handled by a switch.</summary>
    internal static void NotImplementedCase(object value)
    {
        throw new NotImplementedException("Case is not implemented: " + value);
    }

    /// <summary>Throws because the user control does not have a keys handler.</summary>
    internal static void WasNotKeysHandler(string title, object keysHandler)
    {
        throw new Exception("Control " + title + " was not keys handler: " + keysHandler);
    }

    /// <summary>Throws because the operation is not allowed.</summary>
    internal static void IsNotAllowed(string operationName)
    {
        throw new Exception("Operation is not allowed: " + operationName);
    }

    /// <summary>Throws because the first letter of the value is not upper case.</summary>
    internal static void FirstLetterIsNotUpper(string value)
    {
        throw new Exception("First letter is not upper: " + value);
    }
}

/// <summary>Helpers for blocking on tasks.</summary>
internal class AsyncHelperCore
{
    /// <summary>Blocks until the task completes.</summary>
    internal void GetResult(Task task)
    {
        task.GetAwaiter().GetResult();
    }

    /// <summary>Blocks until the task completes and returns its result.</summary>
    internal T GetResult<T>(Task<T> task)
    {
        return task.GetAwaiter().GetResult();
    }
}

/// <summary>Accessor of the shared instance of <see cref="AsyncHelperCore"/>.</summary>
internal static class AsyncHelper
{
    /// <summary>Shared instance.</summary>
    internal static AsyncHelperCore ci = new AsyncHelperCore();
}

/// <summary>Extension methods the old shared library exposed.</summary>
internal static class ExtensionsSunamo
{
    /// <summary>Returns count of elements.</summary>
    internal static int Length<T>(this IEnumerable<T> source)
    {
        return source.Count();
    }

    /// <summary>Awaits without capturing the context.</summary>
    internal static System.Runtime.CompilerServices.ConfiguredTaskAwaitable Conf(this Task task)
    {
        return task.ConfigureAwait(false);
    }

    /// <summary>Awaits without capturing the context.</summary>
    internal static System.Runtime.CompilerServices.ConfiguredTaskAwaitable<T> Conf<T>(this Task<T> task)
    {
        return task.ConfigureAwait(false);
    }
}

/// <summary>String helpers.</summary>
internal static class SH
{
    /// <summary>Splits the text by the delimiter and keeps empty parts.</summary>
    internal static List<string> SplitNone(string text, string delimiter)
    {
        return text.Split(new[] { delimiter }, StringSplitOptions.None).ToList();
    }

    /// <summary>Splits the text by the delimiter and removes empty parts.</summary>
    internal static List<string> Split(string text, string delimiter)
    {
        return text.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>Returns true when the text matches the wildcard mask (* and ?).</summary>
    internal static bool MatchWildcard(string text, string mask)
    {
        var pattern = "^" + Regex.Escape(mask).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        return Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
    }

    /// <summary>Makes the first char upper case.</summary>
    internal static string FirstCharUpper(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }
        return char.ToUpper(text[0]) + text.Substring(1);
    }

    /// <summary>Replaces every occurrence of the search values by the replacement.</summary>
    internal static string ReplaceAll(string text, string replacement, params string[] searchValues)
    {
        foreach (var item in searchValues)
        {
            if (item.Length > 0)
            {
                text = text.Replace(item, replacement);
            }
        }
        return text;
    }

    /// <summary>Removes the suffix when the text ends with it.</summary>
    internal static string RemoveLastCharIfIs(string text, string suffix)
    {
        if (text.EndsWith(suffix))
        {
            return text.Substring(0, text.Length - suffix.Length);
        }
        return text;
    }

    /// <summary>Removes the char when the text ends with it.</summary>
    internal static string RemoveLastCharIfIs(string text, char suffix)
    {
        return RemoveLastCharIfIs(text, suffix.ToString());
    }

    /// <summary>Returns empty string for null.</summary>
    internal static string NullToStringOrEmpty(object value)
    {
        return value == null ? string.Empty : value.ToString();
    }

    /// <summary>Joins lines by new line.</summary>
    internal static string JoinNL(IEnumerable<string> lines)
    {
        return string.Join(Environment.NewLine, lines);
    }

    /// <summary>Splits the text to lines.</summary>
    internal static List<string> GetLines(string text)
    {
        return text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None).ToList();
    }

    /// <summary>Splits the text to lines.</summary>
    internal static List<string> GetLinesList(string text)
    {
        return GetLines(text);
    }

    /// <summary>Returns the first word of the text.</summary>
    internal static string GetFirstWord(string text)
    {
        var index = text.IndexOf(' ');
        return index == -1 ? text : text.Substring(0, index);
    }

    /// <summary>Formats the text, string.Format with a stable name.</summary>
    internal static string Format2(string template, params object[] args)
    {
        return string.Format(template, args);
    }
}

/// <summary>Conversions of basic types.</summary>
internal static class BTS
{
    /// <summary>Parses the int or returns the default.</summary>
    internal static int TryParseInt(string text, int defaultValue)
    {
        return int.TryParse(text, out var result) ? result : defaultValue;
    }

    /// <summary>Parses the bool or returns the default.</summary>
    internal static bool TryParseBool(string text, bool defaultValue)
    {
        return bool.TryParse(text, out var result) ? result : defaultValue;
    }

    /// <summary>Returns value of the nullable bool, false for null.</summary>
    internal static bool GetValueOfNullable(bool? value)
    {
        return value.HasValue && value.Value;
    }

    /// <summary>Compares two values as objects or as their text.</summary>
    internal static bool CompareAsObjectAndString(object first, object second)
    {
        return Equals(first, second) || string.Equals(first?.ToString(), second?.ToString());
    }
}

/// <summary>File system helpers.</summary>
internal static class FS
{
    /// <summary>Returns the directory of the path with trailing backslash.</summary>
    internal static string GetDirectoryName(string path)
    {
        var index = path.LastIndexOf('\\');
        return index == -1 ? string.Empty : path.Substring(0, index + 1);
    }

    /// <summary>Combines paths.</summary>
    internal static string Combine(params string[] parts)
    {
        return Path.Combine(parts);
    }

    /// <summary>Removes chars not allowed in a file name.</summary>
    internal static string DeleteWrongCharsInFileName(string fileName, bool isPath)
    {
        var invalid = Path.GetInvalidFileNameChars().Where(character => !isPath || (character != '\\' && character != '/' && character != ':')).ToArray();
        return new string(fileName.Where(fileNameCharacter => !invalid.Contains(fileNameCharacter)).ToArray());
    }

    /// <summary>Creates all the folders of the path when they do not exist.</summary>
    internal static void CreateUpfoldersPsysicallyUnlessThere(string path)
    {
        Directory.CreateDirectory(path);
    }
}

/// <summary>Collection helpers.</summary>
internal static class CA
{
    /// <summary>Converts the values to list of strings.</summary>
    internal static List<string> ToListString(IEnumerable<string> values)
    {
        return values.ToList();
    }

    /// <summary>Converts the values to list of strings.</summary>
    internal static List<string> ToListString(params object[] values)
    {
        return values.Select(item => item?.ToString()).ToList();
    }

    /// <summary>Converts the strings to list of ints.</summary>
    internal static List<int> ToInt(IEnumerable<string> values)
    {
        return values.Select(int.Parse).ToList();
    }

    /// <summary>Counts occurrences of the value.</summary>
    internal static int CountOfValue<T>(T value, IEnumerable<T> values)
    {
        return values.Count(item => EqualityComparer<T>.Default.Equals(item, value));
    }
}

/// <summary>Number helpers.</summary>
internal static class NH
{
    /// <summary>Divides the total by the count.</summary>
    internal static double Average(double total, double count)
    {
        return total / count;
    }
}

/// <summary>Random values.</summary>
internal static class RandomHelper
{
    private static readonly Random random = new Random();

    /// <summary>Returns random byte in the range.</summary>
    internal static byte RandomByte(int min, int max)
    {
        return (byte)random.Next(min, max + 1);
    }

    /// <summary>Returns random color channel, light colors are in the upper half.</summary>
    internal static byte RandomColorPart(bool light, int minDark = 0)
    {
        return light ? RandomByte(128, 255) : RandomByte(minDark, 127);
    }

    /// <summary>Returns random element of the collection.</summary>
    internal static T RandomElementOfCollectionT<T>(IEnumerable<T> collection)
    {
        var values = collection.ToList();
        return values[random.Next(0, values.Count)];
    }
}
