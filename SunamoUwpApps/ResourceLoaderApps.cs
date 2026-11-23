namespace apps;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

    /// <summary>
    /// Represents the resource loader apps type.
    /// </summary>
    public class ResourceLoaderApps : IResourceHelper
    {
        static ResourceLoader loader = ResourceLoader.GetForCurrentView("apps/Resources");

        /// <summary>
        /// Get stream.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The get stream result.</returns>
        public Stream GetStream(string name)
        {
            return null;
        }

        /// <summary>
        /// Get string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The get string result.</returns>
        public string GetString(string name)
        {
            return sess.i18n(name);
        }
    }
