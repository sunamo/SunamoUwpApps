namespace apps.Helpers.UI;

using System;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Windows.Graphics.Display;
using Microsoft.UI.Xaml.Controls;

public static class SizeH
{
    public static Size Divide(Size size, double div)
    {
        return new Size(size.Width / div, size.Height / div);
    }

    public static Size Multiply(Size size, double mul)
    {
        return new Size(size.Width * mul, size.Height * mul);
    }

    public static Size Multiply(Size size, int dpiXPrinter, int dpiYPrinter)
    {
        return new Size(size.Width * dpiXPrinter, size.Height * dpiYPrinter);
    }
    public static Size Plus(Size size, int value)
    {
        return new Size(size.Width + value, size.Height + value);
    }
    public static Size Minus(Size size, int value)
    {
        return new Size(size.Width - value, size.Height - value);
    }
    public static double OverallWidth(TextBlock tbKeywords)
    {
        return tbKeywords.Margin.Left + tbKeywords.Padding.Left + tbKeywords.ActualWidth + tbKeywords.Padding.Right + tbKeywords.Margin.Right;
    }

    public static double OverallWidth(Button tbKeywords)
    {
        return tbKeywords.Margin.Left + tbKeywords.Padding.Left + tbKeywords.ActualWidth + tbKeywords.Padding.Right + tbKeywords.Margin.Right;
    }

    public static double MarginLR(StackPanel tbKeywords)
    {
        return tbKeywords.Margin.Left + tbKeywords.Margin.Right;
    }

    public static double OverallTB(ProgressBar pbTop)
    {
        return MarginTB(pbTop) + PaddingTB(pbTop) + pbTop.Height;
    }

    

    private static double PaddingTB(ProgressBar pbTop)
    {
        return pbTop.Padding.Top + pbTop.Padding.Bottom;
    }

    private static double MarginTB(ProgressBar pbTop)
    {
        return pbTop.Margin.Top + pbTop.Margin.Bottom;
    }

    public static double OverallTB(StackPanel spKeywords)
    {
        return MarginTB(spKeywords) + PaddingTB(spKeywords) + spKeywords.Height;
    }

    /// <summary>
    /// 0
    /// </summary>
    /// <param name="spKeywords"></param>
    private static double PaddingTB(StackPanel spKeywords)
    {
        return spKeywords.Padding.Top + spKeywords.Padding.Bottom;
    }

    private static double MarginTB(StackPanel spKeywords)
    {
        return spKeywords.Margin.Top + spKeywords.Margin.Bottom;
    }

    public static double PaddingTB(ListView lvApps)
    {
        return lvApps.Padding.Top + lvApps.Padding.Bottom;
    }

    public static double MarginTB(ListView lvApps)
    {
        return lvApps.Margin.Top + lvApps.Margin.Bottom;
    }

    public static double RecalculateSizeWithScaleFactor(double value)
    {
        var scaleFactor = DisplayHelper.GetScaleFactor();
        return value * scaleFactor;
    }
}
