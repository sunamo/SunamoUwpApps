namespace apps.Logger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using apps.Essential;
using Windows.UI;
using Microsoft.UI.Xaml.Media;

    public class LogMessage : LogMessageAbstract<Color, StorageFile>//, ILogMessage
    {
        public LogMessage()
        {

        }

        protected override void SetBg(Color color)
        {
            AsyncHelperApps.ci.GetResult(WpfApp.cd.RunAsync(WpfApp.cdp, () => {
                    Bg = color;
                }));
        }

    }
