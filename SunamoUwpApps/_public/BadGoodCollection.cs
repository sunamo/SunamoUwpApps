namespace apps._public;

/// <summary>
/// Represents the bad good collection t type.
/// </summary>
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
