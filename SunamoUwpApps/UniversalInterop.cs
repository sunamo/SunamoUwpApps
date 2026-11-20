namespace apps;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Metadata;

    /// <summary>
    /// Represents the universal interop type.
    /// </summary>
    public static class UniversalInterop
    {
        /// <summary>
        /// Vrátí zda zařízení nemá HW tlačítka
        /// </summary>
        public static bool IsLargeScreen()
        {
            bool isHardwareButtonsAPIPresent = ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");

            if (isHardwareButtonsAPIPresent)
            {
                return false;
                //return Platform.WindowsPhone;
            }
            else
            {
                return true;
                //return Platform.Windows;
            }
        }

        /// <summary>
        /// Is portrait.
        /// </summary>
        /// <param name="noScaleFactor">The no scale factor.</param>
        /// <returns>The is portrait result.</returns>
        public static bool IsPortrait(bool noScaleFactor)
        {
            Size size = PageHelper.WindowSize(noScaleFactor);
            return size.Height > size.Width;
        }

        
    }
