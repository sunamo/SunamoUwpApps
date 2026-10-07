namespace apps._public;

public interface ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, InlineUIContainer, FontArgs>
{
    FontWeight GetFontWeight(FontWeight2 fontWeight);
    Italic GetItalic(string run, FontArgs fontArgs);
    Inline GetBullet(string path, FontArgs fontArgs);
    Bold GetError(string path, FontArgs fontArgs);
    Bold GetBold(string path, FontArgs fontArgs);
    Run GetRun(string text, FontArgs fontArgs);
    InlineUIContainer GetHyperlink(string text, string uri, FontArgs fontArgs);
}
