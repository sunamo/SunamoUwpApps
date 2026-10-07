namespace apps.Helpers.DataHolderControls;

using Microsoft.UI.Xaml.Controls;

public static class ItemsControlHelper
{
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
