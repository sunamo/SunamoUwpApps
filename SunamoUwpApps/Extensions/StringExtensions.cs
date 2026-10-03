namespace apps.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class StringExtensions
    {
        public static string Copy(this string s)
        {
            return new string(s.ToCharArray());
        }
    }
