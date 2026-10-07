namespace apps.UniversalWebControl;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

    public static class RL
    {
        static ResourceLoader rl = ResourceLoader.GetForCurrentView("UniversalWebControl/Resources");

        public static string GetString(string key)
        {
            return rl.GetString(key);
        }
    }
