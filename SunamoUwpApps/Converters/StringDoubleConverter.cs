namespace apps.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;

    /// <summary>
    /// Represents the string double converter type.
    /// </summary>
    public  class StringDoubleConverter : IValueConverter
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
            if (value is String)
            {
                return double.Parse(value.ToString());
            }
            return value.ToString();
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
            return true;
        }
    }
