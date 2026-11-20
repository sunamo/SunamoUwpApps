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

    /// <summary>
    /// Represents the log message type.
    /// </summary>
    public class LogMessage : LogMessageAbstract<Color, StorageFile>//, ILogMessage
    {
        /// <summary>
        /// Initializes a new instance of the log message class.
        /// </summary>
        public LogMessage()
        {

        }

        /// <summary>
        /// Set bg.
        /// </summary>
        /// <param name="color">The color.</param>
        protected override void SetBg(Color color)
        {
            AsyncHelperApps.ci.GetResult(WpfApp.cd.RunAsync(WpfApp.cdp, () => {
                    Bg = color;
                }));
        }

    }
