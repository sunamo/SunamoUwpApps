namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents the display helper type.
/// </summary>
public static class DisplayHelper
{
    /// <summary>
    /// Get scale factor.
    /// </summary>
    /// <returns>The get scale factor result.</returns>
    public static double GetScaleFactor()
    {
        //DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel
        return 1;
    }
}
