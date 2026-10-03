namespace SunamoUwpApps._sunamo;

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
        bool w = Width <= 0;
        bool h = Height <= 0;
        return w || h;
    }
    public void Parse(string input)
    {
        var d = input.Split(',');
        //ParserTwoValues.ParseDouble(",", SHParts.RemoveAfterFirstFunc(input, char.IsLetter, new char[] { ',' }));
        Width = double.Parse(d[0]);
        Height = double.Parse(d[1]);
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