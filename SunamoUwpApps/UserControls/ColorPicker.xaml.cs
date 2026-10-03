namespace apps.UserControls;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

    public sealed partial class ColorPicker : UserControl
    {
static Type type = typeof(ColorPicker);
        Color result = new Color();
        public Color Result
        {
            get
            {
                return result;
            }
            set
            {
                RSlider.Value = value.R;
                GSlider.Value = value.G;
                BSlider.Value = value.B;
                ASlider.Value = value.A;
                result = value;
                SetColor(value);
            }
        }
        private void SetColor(Color value)
        {
            SolidColorBrush scb = new SolidColorBrush(value);
            htmlColor.Text = StringHexColorConverter.ConvertTo(value);
            rectColor.Fill = scb;
            ColorChanged(result);
            RSlider.BorderBrush = GSlider.BorderBrush = BSlider.BorderBrush = ASlider.BorderBrush = scb;
            //return value;
        }
        public event VoidColor ColorChanged;
        public ColorPicker()
        {
            this.InitializeComponent();
                ATextBlock.Text = sess.i18n( "TransparencyColon");
                RTextBlock.Text = sess.i18n( "RedColorComponentColon");
                GTextBlock.Text = sess.i18n("GreenColorComponentColon");
                BTextBlock.Text = sess.i18n("BlueColorComponentColon");
            
            //ASlider.Value = 255;            
        }
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (rectColor != null)
            {
                Slider s = (sender as Slider);
                string name = s.Name;
                byte value = (byte)s.Value;
                switch (name)
                {
                    case "RSlider":
                        result.R = value;
                        break;
                    case "GSlider":
                        result.G = value;
                        break;
                    case "BSlider":
                        result.B = value;
                        break;
                    case "ASlider":
                        result.A = value;
                        break;
                    default:
                        ThrowEx.Custom("Bad property value Name of Slider A1");
                        break;
                }
                rectColor.Fill = new SolidColorBrush(result);
                SetColor(result);
                //ColorChanged(result);
            }
        }

        
        private void htmlColor_KeyUp_1(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                e.Handled = true;
                Result = StringHexColorConverter.ConvertFrom(htmlColor.Text);
            }
            
        }
        private void htmlColor_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            
            
        }
    }
