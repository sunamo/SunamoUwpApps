namespace SunamoUwpApps._sunamo;

/// <summary>
/// A collection that automatically prevents duplicate items.
/// Supports both normal comparison and string-based comparison.
/// </summary>
/// <typeparam name="T">The type of items in the collection.</typeparam>
public class CollectionWithoutDuplicates<T> : CollectionWithoutDuplicatesBase<T>
{
    /// <summary>
    /// Initializes a new instance of the collection without duplicates.
    /// </summary>
    public CollectionWithoutDuplicates()
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates with a specified initial capacity.
    /// </summary>
    /// <param name="initialCapacity">The initial capacity of the collection.</param>
    public CollectionWithoutDuplicates(int initialCapacity) : base(initialCapacity)
    {
    }

    /// <summary>
    /// Initializes a new instance of the collection without duplicates from an existing list.
    /// </summary>
    /// <param name="list">The list to initialize from.</param>
    public CollectionWithoutDuplicates(IList<T> list) : base(list)
    {
    }

    /// <summary>
    /// Adds an item to the collection and returns its index.
    /// If the item already exists, returns the existing index.
    /// </summary>
    /// <param name="value">The item to add.</param>
    /// <returns>The index of the item in the collection.</returns>
    public override int AddWithIndex(T value)
    {
        if (IsComparingByString())
        {
            if (!Contains(value).GetValueOrDefault())
            {
                Add(value);
                return Collection.Count - 1;
            }
        }

        var index = Collection.IndexOf(value);
        if (index == -1)
        {
            Add(value);
            return Collection.Count - 1;
        }

        return index;
    }

    /// <summary>
    /// Determines whether the collection contains the specified item.
    /// </summary>
    /// <param name="value">The item to check.</param>
    /// <returns>True if the item exists, false if not, null if the item is null and nulls are allowed.</returns>
    public override bool? Contains(T value)
    {
        if (IsComparingByString())
        {
            StringValue = value?.ToString();
            return StringRepresentations.Contains(StringValue!);
        }

        if (!Collection.Contains(value))
        {
            if (EqualityComparer<T>.Default.Equals(value, default)) return null;
            return false;
        }

        return true;
    }

    /// <summary>
    /// Returns the index of the specified item in the collection.
    /// If the item does not exist, it is added and the new index is returned.
    /// </summary>
    /// <param name="value">The item to find.</param>
    /// <returns>The zero-based index of the item.</returns>
    public override int IndexOf(T value)
    {
        if (IsComparingByString()) return StringRepresentations.IndexOf(value?.ToString()!);
        var index = Collection.IndexOf(value);
        if (index == -1)
        {
            Collection.Add(value);
            return Collection.Count - 1;
        }

        return index;
    }

    /// <summary>
    /// Determines whether the collection compares items by their string representation.
    /// </summary>
    /// <returns>True if comparing by string, false otherwise.</returns>
    protected override bool IsComparingByString()
    {
        return AllowNull.HasValue && AllowNull.Value;
    }
}