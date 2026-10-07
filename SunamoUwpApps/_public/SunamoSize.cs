namespace apps._public;

public class SunamoSize //: IParser
{
    public double Width { get; set; }
    public double Height { get; set; }
    public SunamoSize()
    {
    }
    public SunamoSize(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public bool IsNegativeOrZero()
    {
        bool flag = Width <= 0;
        bool handled = Height <= 0;
        return flag || handled;
    }
    public void Parse(string input)
    {
        var parts = input.Split(',');
        //ParserTwoValues.ParseDouble(",", SHParts.RemoveAfterFirstFunc(input, char.IsLetter, new char[] { ',' }));
        Width = double.Parse(parts[0]);
        Height = double.Parse(parts[1]);
    }
    public override string ToString()
    {
        //return ParserTwoValues.ToString(",", Width.ToString(), Height.ToString());
        return Width + "," + Height;
    }

    public object ToSystemWindows()
    {
        throw new NotImplementedException();
    }
}
