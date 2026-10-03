namespace apps._public;

using System.Diagnostics;

public abstract class CollectionWithoutDuplicatesBase<T>
{
    /// <summary>
    /// When true, breaks into debugger on construction. Used for debugging purposes.
    /// </summary>
    public static bool ShouldBreakOnConstruction { get; set; }

    private bool? allowNull = false;

    /// <summary>
    /// Gets or sets the underlying collection of items.
    /// </summary>
    public List<T> Collection { get; set; }

    private readonly int initialCapacity = 10000;

    /// <summary>
    /// Gets or sets the string representations of items when comparing by string.
    /// </summary>
    /// <summary>
    /// The string value of the current item being processed.
    /// </summary>
    protected string? StringValue { get; set; }

    private readonly List<T> duplicateItems = new();

    /// <summary>
    /// Initializes a new instance of the collection without duplicates.
    /// </summary>
    public List<string> StringRepresentations { get; set; }

    public CollectionWithoutDuplicatesBase()
    {
        if (ShouldBreakOnConstruction) Debugger.Break();
        Collection = new List<T>();
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates with a specified initial capacity.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity of the collection.</param>
    public CollectionWithoutDuplicatesBase(int initialCapacity)
    {
        this.initialCapacity = initialCapacity;
        Collection = new List<T>(initialCapacity);
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates from an existing list.
    /// </summary>
    /// <param name="list">The list to initialize from.</param>
    public CollectionWithoutDuplicatesBase(IList<T> list)
    {
        Collection = new List<T>(list.ToList());
        StringRepresentations = new List<string>();
    }

    /// <summary>
    /// Gets or sets whether to allow null values and how to compare items.
    /// True = compare items by their string representation.
    /// False = compare items normally (not by string).
    /// Null = allow null values (cannot compare by string).
    /// </summary>
    public bool? AllowNull
    {
        get => allowNull;
        set
        {
            allowNull = value;
            if (value.HasValue && value.Value) StringRepresentations = new List<string>(initialCapacity);
        }
    }

    /// <summary>
    /// Adds an item to the collection if it is not already present.
    /// </summary>
    /// <param name="value">The item to add.</param>
    /// <returns>True if the item was added, false if it was a duplicate.</returns>
    public bool Add(T value)
    {
        var result = false;
        var containsResult = Contains(value);
        if (containsResult.HasValue)
        {
            if (!containsResult.Value)
            {
                Collection.Add(value);
                result = true;
            }
        }
        else
        {
            if (!AllowNull.HasValue)
            {
                Collection.Add(value);
                result = true;
            }
        }

        if (result)
            if (IsComparingByString())
                StringRepresentations.Add(StringValue!);
        return result;
    }

    /// <summary>
    /// Determines whether the collection compares items by their string representation.
    /// </summary>
    /// <returns>True if comparing by string, false otherwise.</returns>
    protected abstract bool IsComparingByString();

    /// <summary>
    /// Determines whether the collection contains the specified item.
    /// </summary>
    /// <param name="value">The item to check.</param>
    /// <returns>True if the item exists, false if not, null if the item is null and nulls are allowed.</returns>
    public abstract bool? Contains(T value);

    /// <summary>
    /// Adds an item to the collection and returns its index.
    /// </summary>
    /// <param name="value">The item to add.</param>
    /// <returns>The index of the item in the collection.</returns>
    public abstract int AddWithIndex(T value);

    /// <summary>
    /// Returns the index of the specified item in the collection.
    /// </summary>
    /// <param name="value">The item to find.</param>
    /// <returns>The zero-based index of the item.</returns>
    public abstract int IndexOf(T value);

    /// <summary>
    /// Adds multiple items to the collection, skipping duplicates.
    /// </summary>
    /// <param name="list">The list of items to add.</param>
    /// <returns>A list of items that were not added because they were duplicates.</returns>
    public List<T> AddRange(IList<T> list)
    {
        duplicateItems.Clear();
        foreach (var item in list)
            if (!Add(item))
                duplicateItems.Add(item);
        return duplicateItems;
    }

    /// <summary>
    /// This method is not supported and will throw an exception.
    /// </summary>
    /// <param name="operation">The operation name.</param>
    /// <param name="dumpAsStringHeaderArgs">The dump arguments.</param>
    /// <returns>Never returns, always throws.</returns>
    /// <exception cref="Exception">Always thrown as this functionality has been moved to sunamo.</exception>
    public string DumpAsString(string operation, object dumpAsStringHeaderArgs)
    {
        throw new Exception("Cannot be here because DumpListAsStringOneLine was moved to sunamo and will stay there");
    }
}
