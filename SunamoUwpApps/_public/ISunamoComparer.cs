namespace apps._public;


/// <summary>
/// Represents the i sunamo comparer t type.
/// </summary>
public interface ISunamoComparer<T>
{
    /// <summary>
    /// Desc.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The desc result.</returns>
    int Desc(T first, T second);
    /// <summary>
    /// Asc.
    /// </summary>
    /// <param name="first">The first.</param>
    /// <param name="second">The second.</param>
    /// <returns>The asc result.</returns>
    int Asc(T first, T second);
}
