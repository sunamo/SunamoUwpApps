namespace SunamoUwpApps._sunamo;

/// <summary>
/// Collection that categorizes items into Bad and Good lists
/// </summary>
/// <typeparam name="T">The type of elements in the collection</typeparam>
public class BadGoodCollection<T>
{
    /// <summary>
    /// Gets or sets the list of bad items
    /// </summary>
    public List<T> Bad { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of good items
    /// </summary>
    public List<T> Good { get; set; } = new();
}