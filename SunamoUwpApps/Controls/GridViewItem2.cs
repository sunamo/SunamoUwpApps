namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Represents the grid view item 2 type.
/// </summary>
public class GridViewItem2 : GridViewItem
{
    /// <summary>
    /// Length items.
    /// </summary>
    /// <returns>The length items result.</returns>
    public int LengthItems()
    {
        return ((StackPanel)this.Content).Children.Count;
    }

    /// <summary>
    /// Width of item.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The width of item result.</returns>
    public double WidthOfItem(int number)
    {
        StackPanel stackPanel = (StackPanel)this.Content;
        var element = (FrameworkElement)stackPanel.Children[number];
        return element.Width;
    }

    /// <summary>
    /// Width of item.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <param name="width">The width.</param>
    public void WidthOfItem(int number, double width)
    {
        StackPanel stackPanel = (StackPanel)this.Content;
        var element = (FrameworkElement)stackPanel.Children[number];
        element.Width = width;
    }

    /// <summary>
    /// Children.
    /// </summary>
    /// <returns>The children result.</returns>
    public UIElementCollection Children()
    {
        StackPanel stackPanel = (StackPanel)this.Content;
        var children = stackPanel.Children;
        return children;
    }
}
