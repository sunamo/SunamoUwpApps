namespace apps.Helpers.UI;

using System;
using Microsoft.UI.Xaml;
using Windows.Foundation;
using Windows.Graphics.Display;
using Microsoft.UI.Xaml.Controls;

/// <summary>
/// Represents the size h type.
/// </summary>
public static class SizeH
{
    /// <summary>
    /// Divide.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="div">The div.</param>
    /// <returns>The divide result.</returns>
    public static Size Divide(Size size, double div)
    {
        return new Size(size.Width / div, size.Height / div);
    }

    /// <summary>
    /// Multiply.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="mul">The mul.</param>
    /// <returns>The multiply result.</returns>
    public static Size Multiply(Size size, double mul)
    {
        return new Size(size.Width * mul, size.Height * mul);
    }

    /// <summary>
    /// Multiply.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="dpiXPrinter">The dpi x printer.</param>
    /// <param name="dpiYPrinter">The dpi y printer.</param>
    /// <returns>The multiply result.</returns>
    public static Size Multiply(Size size, int dpiXPrinter, int dpiYPrinter)
    {
        return new Size(size.Width * dpiXPrinter, size.Height * dpiYPrinter);
    }
    /// <summary>
    /// Plus.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="value">The value.</param>
    /// <returns>The plus result.</returns>
    public static Size Plus(Size size, int value)
    {
        return new Size(size.Width + value, size.Height + value);
    }
    /// <summary>
    /// Minus.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="value">The value.</param>
    /// <returns>The minus result.</returns>
    public static Size Minus(Size size, int value)
    {
        return new Size(size.Width - value, size.Height - value);
    }
    /// <summary>
    /// Overall width.
    /// </summary>
    /// <param name="tbKeywords">The tb keywords.</param>
    /// <returns>The overall width result.</returns>
    public static double OverallWidth(TextBlock tbKeywords)
    {
        return tbKeywords.Margin.Left + tbKeywords.Padding.Left + tbKeywords.ActualWidth + tbKeywords.Padding.Right + tbKeywords.Margin.Right;
    }

    /// <summary>
    /// Overall width.
    /// </summary>
    /// <param name="tbKeywords">The tb keywords.</param>
    /// <returns>The overall width result.</returns>
    public static double OverallWidth(Button tbKeywords)
    {
        return tbKeywords.Margin.Left + tbKeywords.Padding.Left + tbKeywords.ActualWidth + tbKeywords.Padding.Right + tbKeywords.Margin.Right;
    }

    /// <summary>
    /// Margin LR.
    /// </summary>
    /// <param name="tbKeywords">The tb keywords.</param>
    /// <returns>The margin LR result.</returns>
    public static double MarginLR(StackPanel tbKeywords)
    {
        return tbKeywords.Margin.Left + tbKeywords.Margin.Right;
    }

    /// <summary>
    /// Overall TB.
    /// </summary>
    /// <param name="pbTop">The pb top.</param>
    /// <returns>The overall TB result.</returns>
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

    /// <summary>
    /// Overall TB.
    /// </summary>
    /// <param name="spKeywords">The sp keywords.</param>
    /// <returns>The overall TB result.</returns>
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

    /// <summary>
    /// Padding TB.
    /// </summary>
    /// <param name="lvApps">The lv apps.</param>
    /// <returns>The padding TB result.</returns>
    public static double PaddingTB(ListView lvApps)
    {
        return lvApps.Padding.Top + lvApps.Padding.Bottom;
    }

    /// <summary>
    /// Margin TB.
    /// </summary>
    /// <param name="lvApps">The lv apps.</param>
    /// <returns>The margin TB result.</returns>
    public static double MarginTB(ListView lvApps)
    {
        return lvApps.Margin.Top + lvApps.Margin.Bottom;
    }

    /// <summary>
    /// Recalculate size with scale factor.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The recalculate size with scale factor result.</returns>
    public static double RecalculateSizeWithScaleFactor(double value)
    {
        var scaleFactor = DisplayHelper.GetScaleFactor();
        return value * scaleFactor;
    }
}
