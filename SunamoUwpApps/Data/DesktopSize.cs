using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml;

/// <summary>
/// Must be new due to different NS of SizeChangedEventArgs
/// </summary>
public class DesktopSize : SunamoSize
{


    public DesktopSize()
    {

    }

    public DesktopSize(SizeChangedEventArgs e)
    {
        Width = e.NewSize.Width;
        Height = e.NewSize.Height;
    }

    public DesktopSize(double actualWidth, double actualHeight)
    {
        Width = actualWidth;
        Height = actualHeight;
    }


}