namespace apps.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

/// <summary>
/// Represents the desktop size type.
/// </summary>
public class DesktopSize : SunamoSize
{


    /// <summary>
    /// Initializes a new instance of the desktop size class.
    /// </summary>
    public DesktopSize()
    {

    }

    /// <summary>
    /// Initializes a new instance of the desktop size class.
    /// </summary>
    /// <param name="sizeChangedEventArgs">The size changed event args.</param>
    public DesktopSize(SizeChangedEventArgs sizeChangedEventArgs)
    {
        Width = sizeChangedEventArgs.NewSize.Width;
        Height = sizeChangedEventArgs.NewSize.Height;
    }

    /// <summary>
    /// Initializes a new instance of the desktop size class.
    /// </summary>
    /// <param name="actualWidth">The actual width.</param>
    /// <param name="actualHeight">The actual height.</param>
    public DesktopSize(double actualWidth, double actualHeight)
    {
        Width = actualWidth;
        Height = actualHeight;
    }


}
