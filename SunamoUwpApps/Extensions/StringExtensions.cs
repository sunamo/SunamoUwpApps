namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Represents the string extensions type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Copy.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>The copy result.</returns>
        public static string Copy(this string text)
        {
            return new string(text.ToCharArray());
        }
    }
