namespace apps.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IColorTheme
    {
        /// <summary>
        /// As body method write just ColorThemeHelper.ApplyColorTheme(border, ct);
        /// </summary>
        /// <param name="colorTheme"></param>
        void ApplyColorTheme(ColorTheme colorTheme);
    }
