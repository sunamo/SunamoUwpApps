namespace apps._public;

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
    Information,

    /// <summary>
    ///     Returned if from text cant determine value
    /// </summary>
    Ordinal,
    Appeal,
    Success
}
