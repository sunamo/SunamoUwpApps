namespace apps._public;

using System.Reflection;

/// <summary>
/// Represents the outer object mapping type.
/// </summary>
public class OuterObjectMapping
{
    /// <summary>
    /// The primary key.
    /// </summary>
    public PropertyInfo primaryKey = null;

    /// <summary>
    /// The property infos.
    /// </summary>
    public List<PropertyInfo> propertyInfos = new List<PropertyInfo>();
}
