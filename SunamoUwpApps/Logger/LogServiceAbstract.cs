using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if WINDOWS_UWP
using Microsoft.UI.Xaml.Controls;
#elif !WINDOWS_UWP
using Microsoft.UI.Xaml.Controls;
#endif


public abstract class LogServiceAbstract<Color, StorageFile> : LogServiceAbstract<Color, StorageFile, TextBlock>
    {
    }