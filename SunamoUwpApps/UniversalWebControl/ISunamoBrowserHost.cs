namespace apps.UniversalWebControl;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

    public interface ISunamoBrowserHost
    {
        WebView2 SelectedWebView();
        SunamoBrowser lastOpenedSunamoBrowserAlsoInBackground { get;  }
        //SunamoBrowser lastOpenedSunamoBrowserOnlyInBackground { get; }
        /// <summary>
        /// Zda byl otevřen nový tab v poslední operaci
        /// </summary>
        bool wasOpenedNewTab { get; set; }
    }
