using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;
#if WINDOWS_UWP

using Windows.UI;
#elif !WINDOWS_UWP
using Microsoft.UI.Xaml.Media;
using System.Drawing;
#endif

public class LogMessageAbstract : LogMessageAbstract<Color, StorageFile>
{
}