namespace apps.Helpers.DataHolderControls;

using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Represents the items control helper type.
/// </summary>
public static class ItemsControlHelper
{
    /// <summary>
    /// Has index without exception.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="nahledy">The nahledy.</param>
    /// <returns>The has index without exception result.</returns>
    public static bool HasIndexWithoutException(int value, ItemCollection nahledy)
    {
        if (value < 0)
        {
            return false;
        }
        if (nahledy.Count > value)
        {
            return true;
        }
        return false;
    }
}
