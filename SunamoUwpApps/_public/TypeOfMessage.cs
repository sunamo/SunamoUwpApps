namespace apps._public;

/// <summary>
/// Represents the type of message type.
/// </summary>
public enum TypeOfMessage
{
    /// <summary>
    ///     tbLastErrorOrWarning
    /// </summary>
    Error,

    /// <summary>
    ///     tbLastErrorOrWarning
    /// </summary>
    Warning,
    /// <summary>
    /// The information value.
    /// </summary>
    Information,

    /// <summary>
    ///     Returned if from text cant determine value
    /// </summary>
    Ordinal,
    /// <summary>
    /// The appeal value.
    /// </summary>
    Appeal,
    /// <summary>
    /// The success value.
    /// </summary>
    Success
}
