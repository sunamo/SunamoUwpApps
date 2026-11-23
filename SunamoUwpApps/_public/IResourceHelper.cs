namespace apps._public;

/// <summary>
/// Represents the i resource helper type.
/// </summary>
public interface IResourceHelper
{
    /// <summary>
    /// Get string.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get string result.</returns>
    string GetString(string name);

    /// <summary>
    /// Get stream.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get stream result.</returns>
    Stream GetStream(string name);
}
