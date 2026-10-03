using apps.Essential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace apps.AwesomeFont
{
    /// <summary>
    /// Obsahuje metody pro přiřazení awesome font ikon různým controlům
    /// </summary>
    public static class AwesomeFontControls
    {
        public const string awesomeFontPath = "/Fonts/FontAwesome.otf#FontAwesome";
        public static FontFamily fontFamily = null;
        
        /// <summary>
        /// A1 = Math.Min(WidthOfParent, HeightOfParent)
        /// </summary>
        public static double CalculateFontSize(double woh)
        {
            return (woh / 2) - 6;
        }

        public async static Task SetAwesomeFontSymbol(TextBlock txtSearchIcon, string otf)
        {
             WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            {
                if (fontFamily != null)
                {
                    txtSearchIcon.FontFamily = fontFamily;
                }
                else
                {
                    txtSearchIcon.FontFamily = new FontFamily(awesomeFontPath);
                }
                
                txtSearchIcon.Text = otf;
                
            }).AsTask().Conf();
        }

        public static void SetAwesomeFontSymbol(TextBlock txtSearchIcon, string otf, Brush fg, double fontSize, string tooltip)
        {
            AsyncHelperApps.ci.GetResult( WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            {
                txtSearchIcon.FontFamily = new FontFamily(awesomeFontPath);
                txtSearchIcon.Text = otf;
                txtSearchIcon.Foreground = fg;
                txtSearchIcon.FontSize = fontSize;
                
            }));
        }

        public static double CalculateFontSize(double widthOfIconControl, double heightOfIconControl)
        {
            return CalculateFontSize(Math.Min(widthOfIconControl, heightOfIconControl));
        }

        public async static Task SetAwesomeFontSymbol(ContentControl txtSearchIcon, string otf)
        {
            AsyncHelperApps.ci.GetResult( WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            {
                txtSearchIcon.FontFamily = new FontFamily(awesomeFontPath);
                txtSearchIcon.Content = otf;
            }));
        }

        public async static Task SetAwesomeFontSymbolAsContent(ContentControl txtSearchIcon, string otf, double fontSize)
        {
            AsyncHelperApps.ci.GetResult( WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            {
                //FontIcon fi = new FontIcon();
                //fi.FontFamily = new FontFamily(awesomeFontPath);
                //fi.FontSize = fontSize;
                //fi.Glyph = otf;

                txtSearchIcon.FontFamily = new FontFamily(awesomeFontPath);
                txtSearchIcon.FontSize = fontSize;

                txtSearchIcon.VerticalContentAlignment = Microsoft.UI.Xaml.VerticalAlignment.Center;
                txtSearchIcon.HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center;
                txtSearchIcon.Content = otf;
            }));
        }
    }
}