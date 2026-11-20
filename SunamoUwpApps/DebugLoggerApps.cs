namespace apps;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

    /// <summary>
    /// Represents the debug logger apps type.
    /// </summary>
    public class DebugLoggerApps
    {
        /// <summary>
        /// The instance.
        /// </summary>
        public static DebugLoggerApps Instance = new DebugLoggerApps();

        private DebugLoggerApps()
        {

        }


        /// <summary>
        /// Write.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Write(string message)
        {
            //DateTime.Now.ToLongTimeString() + AllStrings.space + message);
            Debug.Write(message + Environment.NewLine);
        }

        /// <summary>
        /// Write actual position of canvas element.
        /// </summary>
        /// <param name="svMenu">The sv menu.</param>
        public  void WriteActualPositionOfCanvasElement(UIElement svMenu)
        {
            DebugLoggerApps.Instance.Write(Canvas.GetLeft(svMenu) + AllStrings.space + Canvas.GetTop(svMenu));
        }
    }
