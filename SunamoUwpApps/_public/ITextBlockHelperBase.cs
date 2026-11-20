namespace apps._public;

/// <summary>
/// Represents the i text block helper base font weight italic inline bold run inline UI container font args type.
/// </summary>
public interface ITextBlockHelperBase<FontWeight, Italic, Inline, Bold, Run, InlineUIContainer, FontArgs>
{
    /// <summary>
    /// Get font weight.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The get font weight result.</returns>
    FontWeight GetFontWeight(FontWeight2 fontWeight);
    /// <summary>
    /// Get italic.
    /// </summary>
    /// <param name="run">The run.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get italic result.</returns>
    Italic GetItalic(string run, FontArgs fontArgs);
    /// <summary>
    /// Get bullet.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get bullet result.</returns>
    Inline GetBullet(string path, FontArgs fontArgs);
    /// <summary>
    /// Get error.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get error result.</returns>
    Bold GetError(string path, FontArgs fontArgs);
    /// <summary>
    /// Get bold.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get bold result.</returns>
    Bold GetBold(string path, FontArgs fontArgs);
    /// <summary>
    /// Get run.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get run result.</returns>
    Run GetRun(string text, FontArgs fontArgs);
    /// <summary>
    /// Get hyperlink.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="uri">The uri.</param>
    /// <param name="fontArgs">The font args.</param>
    /// <returns>The get hyperlink result.</returns>
    InlineUIContainer GetHyperlink(string text, string uri, FontArgs fontArgs);
}
