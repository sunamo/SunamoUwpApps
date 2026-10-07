namespace apps.Controls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

public class GridViewItem2 : GridViewItem
{
    public int LengthItems()
    {
        return ((StackPanel)this.Content).Children.Count;
    }

    public double WidthOfItem(int number)
    {
        StackPanel stackPanel = (StackPanel)this.Content;
        var element = (FrameworkElement)stackPanel.Children[number];
        return element.Width;
    }

    public void WidthOfItem(int number, double width)
    {
        StackPanel stackPanel = (StackPanel)this.Content;
        var element = (FrameworkElement)stackPanel.Children[number];
        element.Width = width;
    }

    public UIElementCollection Children()
    {
        StackPanel stackPanel = (StackPanel)this.Content;
        var children = stackPanel.Children;
        return children;
    }
}
