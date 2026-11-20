namespace apps._public;

/// <summary>
/// Represents the i simple converter t t output t input type.
/// </summary>
public interface ISimpleConverterT<TOutput, TInput>
{
    /// <summary>
    /// Convert to.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The convert to result.</returns>
    TOutput ConvertTo(TInput value);
    /// <summary>
    /// Convert from.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The convert from result.</returns>
    TInput? ConvertFrom(TOutput value);
}
