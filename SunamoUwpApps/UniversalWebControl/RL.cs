namespace apps.UniversalWebControl;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

    /// <summary>
    /// Represents the RL type.
    /// </summary>
    public static class RL
    {
        static ResourceLoader rl = ResourceLoader.GetForCurrentView("UniversalWebControl/Resources");

        /// <summary>
        /// Get string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The get string result.</returns>
        public static string GetString(string key)
        {
            return rl.GetString(key);
        }
    }
