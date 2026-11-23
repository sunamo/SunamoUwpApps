namespace apps.Helpers.BaseControls;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the dependency object helper type.
    /// </summary>
    public static class DependencyObjectHelper
    {
        /// <summary>
        /// Find visual child t.
        /// </summary>
        /// <typeparam name="T">The type T.</typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns>The find visual child t result.</returns>
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
