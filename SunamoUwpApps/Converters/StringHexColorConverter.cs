namespace apps.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

    public static class StringHexColorConverter //: ISimpleConverter<string, Color>
    {

        public static string ConvertTo(Color color)
        {
            return SH.Format2("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
        }

        public static Color ConvertFrom(string task)
        {
            Color color = new Color();
            task = task.TrimStart('#');
            if (task.Length == 8)
            {
                color.A = GetGroup(0,task);
                color.R = GetGroup(1, task);
                color.G = GetGroup(2, task);
                color.B = GetGroup(3, task);
            }
            else if (task.Length == 6)
            {
                color.R = GetGroup(0, task);
                color.G = GetGroup(1, task);
                color.B = GetGroup(2, task);
            }
            else
            {
                return Colors.Black;
            }
            return color;
        }

        private static byte GetGroup(int value, string task)
        {
            string text = "";
            if (value == 0)
            {
                text = task[0].ToString() + task[1].ToString();
            }
            else if (value == 1)
            {
                text = task[2].ToString() + task[3].ToString();
            }
            else if (value == 2)
            {
                text = task[4].ToString() + task[5].ToString();
            }
            else 
            {
                text = task[6].ToString() + task[7].ToString();
            }
            return Convert.ToByte(text, 16);
        }
    }
