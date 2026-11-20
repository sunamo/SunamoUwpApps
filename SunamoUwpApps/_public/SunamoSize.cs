namespace apps._public;

/// <summary>
/// Represents the sunamo size type.
/// </summary>
public class SunamoSize //: IParser
{
    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    public double Width { get; set; }
    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public double Height { get; set; }
    /// <summary>
    /// Initializes a new instance of the sunamo size class.
    /// </summary>
    public SunamoSize()
    {
    }
    /// <summary>
    /// Initializes a new instance of the sunamo size class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public SunamoSize(double width, double height)
    {
        Width = width;
        Height = height;
    }
    /// <summary>
    /// Is negative or zero.
    /// </summary>
    /// <returns>The is negative or zero result.</returns>
    public bool IsNegativeOrZero()
    {
        bool flag = Width <= 0;
        bool handled = Height <= 0;
        return flag || handled;
    }
    /// <summary>
    /// Parse.
    /// </summary>
    /// <param name="input">The input.</param>
    public void Parse(string input)
    {
        var parts = input.Split(',');
        //ParserTwoValues.ParseDouble(",", SHParts.RemoveAfterFirstFunc(input, char.IsLetter, new char[] { ',' }));
        Width = double.Parse(parts[0]);
        Height = double.Parse(parts[1]);
    }
    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        //return ParserTwoValues.ToString(",", Width.ToString(), Height.ToString());
        return Width + "," + Height;
    }

    /// <summary>
    /// To system windows.
    /// </summary>
    /// <returns>The to system windows result.</returns>
    public object ToSystemWindows()
    {
        throw new NotImplementedException();
    }
}
