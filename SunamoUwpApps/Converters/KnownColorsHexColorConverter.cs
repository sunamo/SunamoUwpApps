namespace apps.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using System.Reflection;
using System.Diagnostics;

    public static class KnownColorsHexColorConverter //: ISimpleConverter<ColorConverter, string>
    {
        static Dictionary<string, Color> hexKnownColors = new Dictionary<string, Color>();
        static Dictionary<string, Color> stringKnownColors = new Dictionary<string, Color>();

        static KnownColorsHexColorConverter()
        {
            IEnumerable<PropertyInfo> properties = typeof(Colors).GetRuntimeProperties();
            foreach (var item in properties)
            {
                Color color = (Color)item.GetValue(null);
                string value = item.Name;
                if (!stringKnownColors.ContainsKey(value))
                {
                stringKnownColors.Add(value, color);    
                }
                char[] chars = color.ToString().ToCharArray();
                chars[1] = 'F';
                chars[2] = 'F';
                String text = new string(chars);
                if (!hexKnownColors.ContainsKey(text))
                {
                    hexKnownColors.Add(text, color);
                }
                
            }
        }

        public  static Color ConvertTo(string url)
        {
            Color color = Colors.AliceBlue;
            if (url.StartsWith("#"))
            {
                if (url.Length == 7)
                {
                    //
                    url = "#FF" + url.Substring(1);
                }
                else if(url.Length == 9)
                {
                    url = "#FF" + url.Substring(3);
                }
                else if (url.Length == 4)
                {
                    //
                    url = "#FF" + url[1] + url[1] + url[2] + url[2] + url[3] + url[3];
                }
                if (url == "#FFFFFFFF")
                {
                    return Colors.LightBlue;
                }
                if (hexKnownColors.ContainsKey(url))
                {
                    return hexKnownColors[url];
                }
                else
                { 
                    color = StringHexColorConverter.ConvertFrom(url);
                    return Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                return stringKnownColors["Blue"];    
            }
            if (stringKnownColors.ContainsKey(url))
            {
                return stringKnownColors[url];
            }
#if DEBUG
            Debug.WriteLine("Blue");
#endif
            return stringKnownColors["LightBlue"];
            //return (Color)typeof(Colors).GetRuntimeProperty(u).GetValue(null);
        }

        public static string ConvertFrom(Color color)
        {
            return StringHexColorConverter.ConvertTo(color);
        }
    }
