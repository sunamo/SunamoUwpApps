namespace apps.UniversalWebControl;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the i sunamo browser host type.
    /// </summary>
    public interface ISunamoBrowserHost
    {
        /// <summary>
        /// Selected web view.
        /// </summary>
        /// <returns>The selected web view result.</returns>
        WebView2 SelectedWebView();
        /// <summary>
        /// Gets the last opened sunamo browser also in background.
        /// </summary>
        SunamoBrowser lastOpenedSunamoBrowserAlsoInBackground { get;  }
        //SunamoBrowser lastOpenedSunamoBrowserOnlyInBackground { get; }
        /// <summary>
        /// Zda byl otevřen nový tab v poslední operaci
        /// </summary>
        bool wasOpenedNewTab { get; set; }
    }
