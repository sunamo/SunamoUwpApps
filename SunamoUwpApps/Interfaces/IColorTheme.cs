using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apps.Interfaces
{
    public interface IColorTheme
    {
        /// <summary>
        /// As body method write just ColorThemeHelper.ApplyColorTheme(border, ct);
        /// </summary>
        /// <param name="ct"></param>
        void ApplyColorTheme(ColorTheme ct);
    }
}