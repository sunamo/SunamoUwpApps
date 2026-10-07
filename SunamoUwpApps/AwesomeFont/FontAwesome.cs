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
        public static FontAwesomeIcon GetSymbol(DependencyObject dependencyObject)
        {
            return (FontAwesomeIcon)dependencyObject.GetValue(SymbolProperty);
        }

        public static FontFamily FontFamily { get; set; }

        static FontAwesome()
        {
            FontFamily = new FontFamily(AwesomeFontControls.awesomeFontPath);
        }

        public static void SetSymbol(DependencyObject dependencyObject, FontAwesomeIcon value)
        {
            string hex = ((int)value).ToString("X").ToLower();
            dependencyObject.SetValue(SymbolProperty, hex);

            if (dependencyObject is Button)
            {
                dependencyObject.SetValue(Button.FontFamilyProperty, new FontFamily( "ms-appx:///Fonts/FontAwesome.otf#FontAwesome"));
                dependencyObject.SetValue(Button.ContentProperty, "" + hex);
            }
            else if (dependencyObject is TextBlock)
            {
                TextBlock dpb = (TextBlock)dependencyObject;
                
                dependencyObject.SetValue(TextBlock.FontFamilyProperty, new FontFamily("/fontawesome-webfont.ttf#FontAwesome"));
                dependencyObject.SetValue(TextBlock.TextProperty, "&#x" + hex + AllStrings.sc);
            }
        }

        public static readonly DependencyProperty SymbolProperty = DependencyProperty.RegisterAttached("Symbol", typeof(FontAwesomeIcon), typeof(TextBlock), new PropertyMetadata(FontAwesomeIcon.None));
    }
