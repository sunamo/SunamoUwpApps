namespace apps.Collections;

using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml;

public class SunamoDictionaryWithKeysDependencyObject<T, U> : SunamoDictionary<T, U> where T : DependencyObject
{
    public List<U> GetValuesByValuesOfKeysProperty<X>(DependencyProperty dependencyProperty, X searchedValue)
    {
        var matching = this.Where(pair => EqualityComparer<X>.Default.Equals((X)pair.Key.GetValue(dependencyProperty), searchedValue));
        return matching.Select(pair2 => pair2.Value).ToList();
        //return vr.SelectMany(d => d.Value);
    }
}
