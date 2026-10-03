namespace SunamoUwpApps._sunamo;

/// <summary>
/// Text builder that supports both StringBuilder and List modes with undo capability.
/// </summary>
public class TextBuilder : ITextBuilder
{
    private bool canUndo;
    private int lastIndex = -1;
    private string lastText = "";
    private readonly bool isUsingList;

    /// <summary>
    /// Gets or sets the internal StringBuilder used when not in list mode.
    /// </summary>
    public StringBuilder Builder { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="TextBuilder"/> class.
    /// </summary>
    /// <param name="isUsingList">When true, uses a list of strings instead of StringBuilder.
    /// Setting this to true requires justification because it changes the internal storage mode.</param>
    public TextBuilder(bool isUsingList = false)
    {
        this.isUsingList = isUsingList;
        if (isUsingList)
            List = new List<string>();
    }

    /// <summary>
    /// Gets or sets text to prepend before every non-whitespace append.
    /// </summary>
    public string PrependEveryNoWhite { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of lines used in list mode (e.g. for PowershellRunner).
    /// </summary>
    public List<string>? List { get; set; }

    /// <summary>
    /// Clears all content.
    /// </summary>
    public void Clear()
    {
        if (isUsingList)
            List!.Clear();
        else
            Builder.Clear();
    }

    /// <summary>
    /// Gets or sets a value indicating whether undo operation is enabled.
    /// </summary>
    public bool CanUndo
    {
        get
        {
            if (isUsingList) return false;
            return canUndo;
        }
        set
        {
            canUndo = value;
            if (!value)
            {
                lastIndex = -1;
                lastText = "";
            }
        }
    }

    /// <summary>
    /// Undoes the last append operation.
    /// </summary>
    public void Undo()
    {
        if (isUsingList) UndoIsNotAllowed("Undo");
        if (lastIndex != -1) Builder.Remove(lastIndex, lastText.Length);
    }

    /// <summary>
    /// Appends text.
    /// </summary>
    /// <param name="text">The text to append.</param>
    public void Append(string text)
    {
        if (isUsingList)
        {
            if (List!.Count > 0)
                List[List.Count - 1] += text;
            else
                List.Add(text);
        }
        else
        {
            SetUndo(text);
            Builder.Append(PrependEveryNoWhite);
            Builder.Append(text);
        }
    }

    /// <summary>
    /// Appends the string representation of an object.
    /// </summary>
    /// <param name="value">The object to append.</param>
    public void Append(object value)
    {
        var text = value.ToString() ?? string.Empty;
        SetUndo(text);
        Append(text);
    }

    /// <summary>
    /// Appends a new line.
    /// </summary>
    public void AppendLine()
    {
        Append(Environment.NewLine);
    }

    /// <summary>
    /// Appends text followed by a new line.
    /// </summary>
    /// <param name="text">The text to append.</param>
    public void AppendLine(string text)
    {
        if (isUsingList)
        {
            List!.Add(PrependEveryNoWhite + text);
        }
        else
        {
            SetUndo(text);
            Builder.Append(PrependEveryNoWhite + text + Environment.NewLine);
        }
    }

    /// <summary>
    /// Returns the built text. If using list mode, joins lines with newlines.
    /// </summary>
    /// <returns>The built text as a string.</returns>
    public override string ToString()
    {
        if (isUsingList)
            return string.Join(Environment.NewLine, List!);
        return Builder.ToString();
    }

    /// <summary>
    /// Creates a new ITextBuilder instance.
    /// </summary>
    /// <param name="isUsingList">Whether to use list mode.</param>
    /// <returns>A new ITextBuilder instance.</returns>
    public static ITextBuilder Create(bool isUsingList = false)
    {
        return new TextBuilder(isUsingList);
    }

    private void UndoIsNotAllowed(string operationName)
    {
        ThrowEx.IsNotAllowed(operationName);
    }

    private void SetUndo(string text)
    {
        if (isUsingList) UndoIsNotAllowed("SetUndo");
        if (CanUndo)
        {
            lastIndex = Builder.Length;
            lastText = text;
        }
    }
}
