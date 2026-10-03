using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace apps;
    public class ResourceLoaderApps : IResourceHelper
    {
        static ResourceLoader loader = ResourceLoader.GetForCurrentView("apps/Resources");

        public Stream GetStream(string name)
        {
            return null;
        }

        public string GetString(string name)
        {
            return sess.i18n(name);
        }
    }
