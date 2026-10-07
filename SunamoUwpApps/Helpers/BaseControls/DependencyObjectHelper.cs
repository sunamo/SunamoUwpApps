namespace apps.Helpers.BaseControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

    public static class DependencyObjectHelper
    {
        public static T FindVisualChild<T>(DependencyObject obj)
    where T : DependencyObject
        {
            for (int index = 0; index < VisualTreeHelper.GetChildrenCount(obj); index++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, index);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
