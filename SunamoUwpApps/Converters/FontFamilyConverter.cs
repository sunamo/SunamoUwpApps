namespace apps.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the font family converter type.
    /// </summary>
    public class FontFamilyConverter : IValueConverter
    {
        /// <summary>
        /// Convert.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns>The convert result.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType == typeof( FontFamily))
            {
                return new FontFamily(value.ToString());
            }
            return null;
        }

        /// <summary>
        /// Convert back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns>The convert back result.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
