namespace apps.Extensions;

using apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Microsoft.UI.Xaml.Media;

public static class ColorH
    {
    #region For easy copy
    static Type type = typeof(ColorH);
    public static PixelColor PixelColorFromColor(Color color, byte? alpha)
    {
        if (alpha == null)
        {
            alpha = color.A;
        }
        PixelColor white2 = new PixelColor() { Alpha = alpha.Value, Red = color.R, Green = color.G, Blue = color.B };
        return white2;
    }
    public static Color GetOpaqueColor(byte red, byte green, byte byteValue)
    {
        Color color = new Color();
        color.A = 255;
        color.R = red;
        color.G = green;
        color.B = byteValue;
        return color;
    }
    public static Color RandomColor(bool light)
    {
        return GetOpaqueColor(RandomHelper.RandomColorPart(light), RandomHelper.RandomColorPart(light), RandomHelper.RandomColorPart(light));
    }
    public static SolidColorBrush RandomLightBrush(ColorComponent shade)
    {
        byte red = 0;
        byte green = 0;
        byte byteValue = 0;
        switch (shade)
        {
            case ColorComponent.Red:
                red = 255;
                green = byteValue = RandomHelper.RandomByte(200, 250);
                break;
            case ColorComponent.Green:
                green = 255;
                green = red = RandomHelper.RandomByte(200, 250);
                break;
            case ColorComponent.Blue:
                byteValue = 255;
                green = red = RandomHelper.RandomByte(200, 250);
                break;
            case ColorComponent.None:
            default:
                red = green = byteValue = 255;
                break;
        }
        return new SolidColorBrush(GetColorWithAlpha(red, green, byteValue, 150));
    }
    public static SolidColorBrush RandomBrush(bool light, ColorComponent into)
    {
        byte red = RandomHelper.RandomColorPart(light, 0);
        byte green = RandomHelper.RandomColorPart(light, 0);
        byte byteValue = RandomHelper.RandomColorPart(light, 0);
        switch (into)
        {
            case ColorComponent.Red:
                red += 127;
                break;
            case ColorComponent.Green:
                green += 127;
                break;
            case ColorComponent.Blue:
                byteValue += 127;
                break;
            case ColorComponent.None:
                red += 127;
                green += 127;
                byteValue += 127;
                break;
            default:
                ThrowEx.Custom("Not implemented case in ColorHelperApps.RandomBrush");
                return Brushes.Black;
        }
        return new SolidColorBrush(GetOpaqueColor(red, green, byteValue));
    }
    public static Color GetColorWithAlpha(byte red, byte green, byte byteValue, byte byteValue2)
    {
        Color white2 = new Color { A = byteValue2, R = red, G = green, B = byteValue };
        return white2;
    }
    public static Color GetColorWithAlpha(Color color, byte? alpha)
    {
        if (alpha == null)
        {
            alpha = color.A;
        }
        Color white2 = new Color { A = alpha.Value, R = color.R, G = color.G, B = color.B };
        return white2;
    }
    public static bool IsColorSame(Color first, Color pxsi)
    {
        return first.R == pxsi.R && first.G == pxsi.G && first.B == pxsi.B;
    }
    public static bool IsColorSame(PixelColor first, PixelColor pxsi)
    {
        return first.Red == pxsi.Red && first.Green == pxsi.Green && first.Blue == pxsi.Blue;
    }
#if DEBUG
    public static void DebugWrite(Color c)
    {
        //DebugLoggerApps.Instance.Write("A: " + c.A + " R: " + c.R + " G: " + c.G + " : " + c.B);
    }
#endif 
    #endregion
}
