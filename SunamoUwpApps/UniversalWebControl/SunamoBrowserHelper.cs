using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalWebControl;

public static class SunamoBrowserHelper
{
    /// <summary>
    /// Create instance of SunamoBrowser, add as Child into MainPage, set handlers for sbc commands and render engine
    /// </summary>
    public static SunamoBrowser CreateInstanceWebViewHost(ISunamoBrowserHost sbHost)
    {
        var sunamoBrowser = new SunamoBrowser();
        sunamoBrowser.sbHost = sbHost;
        

        

        

        return sunamoBrowser;
    }
}