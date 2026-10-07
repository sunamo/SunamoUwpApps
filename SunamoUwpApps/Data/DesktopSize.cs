namespace apps.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

public class DesktopSize : SunamoSize
{


    public DesktopSize()
    {

    }

    public DesktopSize(SizeChangedEventArgs sizeChangedEventArgs)
    {
        Width = sizeChangedEventArgs.NewSize.Width;
        Height = sizeChangedEventArgs.NewSize.Height;
    }

    public DesktopSize(double actualWidth, double actualHeight)
    {
        Width = actualWidth;
        Height = actualHeight;
    }


}
