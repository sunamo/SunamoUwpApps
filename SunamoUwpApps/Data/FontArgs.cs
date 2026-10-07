namespace apps.Data;

using Microsoft.UI.Xaml;
using Windows.UI.Text;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;

public class FontArgs
{
    public FontArgs()
    {
        
    }

    public FontArgs(FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontStretch fontStretch, FontWeight fontWeight)
    {
        this.fontFamily = fontFamily;
        this.fontSize = fontSize;
        this.fontStretch = fontStretch;
        this.fontStyle = fontStyle;
        this.fontWeight = fontWeight;
    }

    public FontArgs(FontArgs fontArgs)
    {
        this.fontFamily = fontArgs.fontFamily;
        this.fontSize = fontArgs.fontSize;
        this.fontStretch = fontArgs.fontStretch;
        this.fontStyle = fontArgs.fontStyle;
        this.fontWeight = fontArgs.fontWeight;
    }

    public FontFamily fontFamily = null;
    public double fontSize = 0;
    public FontStyle fontStyle = FontStyle.Normal;
    /// <summary>
    /// Hodnota mezi 1-9, průměrná je 5
    /// </summary>
    public FontStretch fontStretch = FontStretch.Normal;
    public FontWeight fontWeight = new FontWeight();

    public static FontArgs DefaultRun()
    {
        Run run = new Run();
        return new FontArgs(run.FontFamily, run.FontSize, run.FontStyle, run.FontStretch, run.FontWeight);
    }
}
