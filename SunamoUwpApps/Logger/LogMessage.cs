
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
//NETFX_CORE; WINDOWS_UWP
using Windows.Storage;
#if WINDOWS_UWP
using apps.Essential;

using Windows.UI;
using Microsoft.UI.Xaml.Media;
#elif !WINDOWS_UWP
using System.Drawing;
using Microsoft.UI.Xaml.Media;
#endif

namespace apps
{
    public class LogMessage : LogMessageAbstract<Color, StorageFile>//, ILogMessage
    {
        public LogMessage()
        {

        }

        #if WINDOWS_UWP
        protected override void SetBg(Color c)
        {
            AsyncHelperApps.ci.GetResult(WpfApp.cd.RunAsync(WpfApp.cdp, () => {
                    Bg = c;
                }));
        }
        #endif

    }

}