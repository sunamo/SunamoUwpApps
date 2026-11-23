namespace apps.AwesomeFont;

using apps.Essential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    /// <summary>
    /// Represents the awesome font controls type.
    /// </summary>
    public static class AwesomeFontControls
    {
        /// <summary>
        /// The awesome font path constant.
        /// </summary>
        public const string awesomeFontPath = "/Fonts/FontAwesome.otf#FontAwesome";
        /// <summary>
        /// The font family.
        /// </summary>
        public static FontFamily fontFamily = null;
        
        /// <summary>
        /// A1 = Math.Min(WidthOfParent, HeightOfParent)
        /// </summary>
        public static double CalculateFontSize(double woh)
        {
            return (woh / 2) - 6;
        }

        /// <summary>
        /// Set awesome font symbol.
        /// </summary>
        /// <param name="txtSearchIcon">The txt search icon.</param>
        /// <param name="otf">The otf.</param>
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

        /// <summary>
        /// Set awesome font symbol.
        /// </summary>
        /// <param name="txtSearchIcon">The txt search icon.</param>
        /// <param name="otf">The otf.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="fontSize">The font size.</param>
        /// <param name="tooltip">The tooltip.</param>
        public static void SetAwesomeFontSymbol(TextBlock txtSearchIcon, string otf, Brush brush, double fontSize, string tooltip)
        {
            AsyncHelperApps.ci.GetResult( WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            {
                txtSearchIcon.FontFamily = new FontFamily(awesomeFontPath);
                txtSearchIcon.Text = otf;
                txtSearchIcon.Foreground = brush;
                txtSearchIcon.FontSize = fontSize;
                
            }));
        }

        /// <summary>
        /// Calculate font size.
        /// </summary>
        /// <param name="widthOfIconControl">The width of icon control.</param>
        /// <param name="heightOfIconControl">The height of icon control.</param>
        /// <returns>The calculate font size result.</returns>
        public static double CalculateFontSize(double widthOfIconControl, double heightOfIconControl)
        {
            return CalculateFontSize(Math.Min(widthOfIconControl, heightOfIconControl));
        }

        /// <summary>
        /// Set awesome font symbol.
        /// </summary>
        /// <param name="txtSearchIcon">The txt search icon.</param>
        /// <param name="otf">The otf.</param>
        public async static Task SetAwesomeFontSymbol(ContentControl txtSearchIcon, string otf)
        {
            AsyncHelperApps.ci.GetResult( WpfApp.cd.RunAsync(WpfApp.cdp, () =>
            {
                txtSearchIcon.FontFamily = new FontFamily(awesomeFontPath);
                txtSearchIcon.Content = otf;
            }));
        }

        /// <summary>
        /// Set awesome font symbol as content.
        /// </summary>
        /// <param name="txtSearchIcon">The txt search icon.</param>
        /// <param name="otf">The otf.</param>
        /// <param name="fontSize">The font size.</param>
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
