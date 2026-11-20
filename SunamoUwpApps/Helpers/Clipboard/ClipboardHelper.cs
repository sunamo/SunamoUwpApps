namespace apps.Helpers.Clipboard;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

    /// <summary>
    /// Represents the clipboard helper apps 2 type.
    /// </summary>
    public static class ClipboardHelperApps2
    {
        /// <summary>
        /// The content changed.
        /// </summary>
        public static event Action<object, object> ContentChanged;

        /// <summary>
        /// Get text.
        /// </summary>
        /// <returns>The get text result.</returns>
        public static string GetText()
        {
            string dataFormat = StandardDataFormats.Text;
            return SH.NullToStringOrEmpty( GetFormat(dataFormat));
        }

        /// <summary>
        /// Vrátí null v případě že data nebudou nalezeny ve schránce
        /// </summary>
        /// <param name="dataFormat"></param>
        private static object GetFormat(string dataFormat)
        {
            var dpv = Clipboard.GetContent();
            if (dpv.Contains(dataFormat))
            {
                //return ClipboardHelperApps.GetContent().GetTextAsync();
                return Clipboard.GetContent().GetDataAsync(dataFormat);
            }
            return null;
        }

        /// <summary>
        /// Set text.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void SetText(string value)
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.SetText(value);
            Clipboard.SetContent(dataPackage);
        }
    }
