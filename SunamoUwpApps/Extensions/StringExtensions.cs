namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class StringExtensions
    {
        public static string Copy(this string text)
        {
            return new string(text.ToCharArray());
        }
    }
