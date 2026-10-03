namespace apps.AwesomeFont;

using apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

    public static class FontAwesome
    {
        public static FontAwesomeIcon GetSymbol(DependencyObject dp)
        {
            return (FontAwesomeIcon)dp.GetValue(SymbolProperty);
        }

        public static FontFamily FontFamily { get; set; }

        static FontAwesome()
        {
            FontFamily = new FontFamily(AwesomeFontControls.awesomeFontPath);
        }

        public static void SetSymbol(DependencyObject dp, FontAwesomeIcon value)
        {
            string hex = ((int)value).ToString("X").ToLower();
            dp.SetValue(SymbolProperty, hex);

            if (dp is Button)
            {
                dp.SetValue(Button.FontFamilyProperty, new FontFamily( "ms-appx:///Fonts/FontAwesome.otf#FontAwesome"));
                dp.SetValue(Button.ContentProperty, "" + hex);
            }
            else if (dp is TextBlock)
            {
                TextBlock dpb = (TextBlock)dp;
                
                dp.SetValue(TextBlock.FontFamilyProperty, new FontFamily("/fontawesome-webfont.ttf#FontAwesome"));
                dp.SetValue(TextBlock.TextProperty, "&#x" + hex + AllStrings.sc);
            }
        }

        public static readonly DependencyProperty SymbolProperty = DependencyProperty.RegisterAttached("Symbol", typeof(FontAwesomeIcon), typeof(TextBlock), new PropertyMetadata(FontAwesomeIcon.None));
    }
