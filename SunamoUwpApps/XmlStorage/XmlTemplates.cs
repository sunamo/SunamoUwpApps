namespace apps.XmlStorage;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Represents the xml templates type.
    /// </summary>
    public class XmlTemplates
    {
        /// <summary>
        /// Get xml 2.
        /// </summary>
        /// <param name="prvni">The prvni.</param>
        /// <param name="druhy">The druhy.</param>
        /// <returns>The get xml 2 result.</returns>
        public static string GetXml2(string prvni, string druhy)
        {
            return "<sunamo><prvni><![CDATA[" + prvni + "]]></prvni><druhy><![CDATA[" + druhy + "]]></druhy></sunamo>";
        }
    }
