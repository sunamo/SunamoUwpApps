namespace SunamoUwpApps._sunamo;

/// <summary>
/// Interface for building text output with append and undo capabilities.
/// </summary>
public interface ITextBuilder
{
    /// <summary>
    /// Gets or sets a value indicating whether undo operation is enabled.
    /// </summary>
    bool CanUndo { get; set; }

    /// <summary>
    /// Gets or sets the list of lines when list mode is used.
    /// </summary>
    List<string>? List { get; set; }

    /// <summary>
    /// Gets or sets text to prepend before every non-whitespace append.
    /// </summary>
    string PrependEveryNoWhite { get; set; }

    /// <summary>
    /// Appends the string representation of an object.
    /// </summary>
    /// <param name="value">The object to append.</param>
    void Append(object value);

    /// <summary>
    /// Appends text.
    /// </summary>
    /// <param name="text">The text to append.</param>
    void Append(string text);

    /// <summary>
    /// Appends a new line.
    /// </summary>
    void AppendLine();

    /// <summary>
    /// Appends text followed by a new line.
    /// </summary>
    /// <param name="text">The text to append.</param>
    void AppendLine(string text);

    /// <summary>
    /// Clears all content.
    /// </summary>
    void Clear();

    /// <summary>
    /// Returns the built text as a string.
    /// </summary>
    /// <returns>The built text.</returns>
    string ToString();

    /// <summary>
    /// Undoes the last append operation.
    /// </summary>
    void Undo();
}
