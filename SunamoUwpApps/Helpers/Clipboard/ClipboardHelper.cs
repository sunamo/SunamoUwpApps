using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace apps
{
    public static class ClipboardHelperApps2
    {
        public static event Action<object, object> ContentChanged;

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

        public static void SetText(string v)
        {
            DataPackage dp = new DataPackage();
            dp.SetText(v);
            Clipboard.SetContent(dp);
        }
    }
}