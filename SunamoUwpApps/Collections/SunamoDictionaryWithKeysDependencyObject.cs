namespace apps.Collections;

using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;

/// <summary>
/// Represents the sunamo dictionary with keys dependency object t u type.
/// </summary>
public class SunamoDictionaryWithKeysDependencyObject<T, U> : SunamoDictionary<T, U> where T : DependencyObject
{
    /// <summary>
    /// Get values by values of keys property x.
    /// </summary>
    /// <typeparam name="X">The type X.</typeparam>
    /// <param name="dependencyProperty">The dependency property.</param>
    /// <param name="searchedValue">The searched value.</param>
    /// <returns>The get values by values of keys property x result.</returns>
    public List<U> GetValuesByValuesOfKeysProperty<X>(DependencyProperty dependencyProperty, X searchedValue)
    {
        var matching = this.Where(pair => EqualityComparer<X>.Default.Equals((X)pair.Key.GetValue(dependencyProperty), searchedValue));
        return matching.Select(matchingPair => matchingPair.Value).ToList();
        //return vr.SelectMany(d => d.Value);
    }
}
