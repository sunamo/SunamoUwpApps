namespace SunamoUwpApps._sunamo;

/// <summary>
/// Converts English words between singular and plural forms.
/// This class is not static (unlike other converters) to avoid wasting resources at application startup
/// when the class might not be used at all. Please try to create only one instance of this class.
/// </summary>
public sealed partial class PluralConverter : ISimpleConverter
{
    /// <summary>
    /// Call this method to get the singular 
    /// version of a plural English word.
    /// </summary>
    /// <param name = "word">The word to turn into a singular</param>
    /// <returns>The singular word</returns>
    public string ConvertFrom(string word)
    {
        word = word.ToLower();
        if (s_dictionary.ContainsValue(word))
        {
            foreach (KeyValuePair<string, string> kvp in s_dictionary)
            {
                if (kvp.Value.ToLower() == word)
                    return kvp.Key;
            }
        }

        if (word.Substring(word.Length - 1) != "s")
        {
            return word; // not a plural word if it doesn't end in S
        }

        if (word.Length <= 2)
        {
            return word; // not a word that can be made singular if only two letters!
        }

        if (word.Length >= 4)
        {
            switch (word.Substring(word.Length - 4))
            {
                case "bies":
                case "cies":
                case "dies":
                case "fies":
                case "gies":
                case "hies":
                case "jies":
                case "kies":
                case "lies":
                case "mies":
                case "nies":
                case "pies":
                case "ries":
                case "sies":
                case "ties":
                case "vies":
                case "wies":
                case "xies":
                case "zies":
                {
                    return word.Substring(0, word.Length - 3) + "y";
                }

                case "ches":
                case "shes":
                {
                    return word.Substring(0, word.Length - 2);
                }
            }
        }

        if (word.Length >= 3)
        {
            switch (word.Substring(word.Length - 3))
            {
                //box--boxes
                case "ses":
                case "zes":
                case "xes":
                {
                    return word.Substring(0, word.Length - 2);
                }
            }
        }

        if (word.Length >= 3)
        {
            switch (word.Substring(word.Length - 2))
            {
                case "es":
                {
                    return word.Substring(0, word.Length - 1) + "is";
                }

                //4. Assume add an -s to form the plural of most words.
                default:
                {
                    return word.Substring(0, word.Length - 1);
                }
            }
        }

        return word;
    }

    /// <summary>
    /// test if a word is plural
    /// </summary>
    /// <param name = "word">word to test</param>
    /// <returns>true if a word is plural</returns>
    private static bool TestIsPlural(string word)
    {
        word = word.ToLower();
        if (word.Length <= 2)
        {
            return false; // not a word that can be made singular if only two letters!
        }

        if (s_dictionary.ContainsValue(word.ToLower()))
        {
            return true; //it's definitely already a plural
        }

        if (word.Length >= 4)
        {
            switch (word.Substring(word.Length - 4))
            {
                case "bies":
                case "cies":
                case "dies":
                case "fies":
                case "gies":
                case "hies":
                case "jies":
                case "kies":
                case "lies":
                case "mies":
                case "nies":
                case "pies":
                case "ries":
                case "sies":
                case "ties":
                case "vies":
                case "wies":
                case "xies":
                case "zies":
                case "ches":
                case "shes":
                {
                    return true;
                }
            }
        }

        if (word.Length >= 3)
        {
            switch (word.Substring(word.Length - 3))
            {
                //box--boxes
                case "ses":
                case "zes":
                case "xes":
                {
                    return true;
                }
            }
        }

        if (word.Length >= 3)
        {
            switch (word.Substring(word.Length - 2))
            {
                case "es":
                {
                    return true;
                }
            }
        }

        if (word.Substring(word.Length - 1) != "s")
        {
            return false; // not a plural word if it doesn't end in S
        }

        return true;
    }
}