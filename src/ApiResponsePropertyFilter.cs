namespace MetaMapper;

/// <summary>
/// Represents a property filter for API responses.
/// </summary>
public class ApiResponsePropertyFilter
{
    /// <summary>
    /// Gets the predicate function to determine whether to exclude the property.
    /// </summary>
    public Func<string, bool> FilterPredicate { get; }

    /// <summary>
    /// Initializes a new instance of the ApiResponsePropertyFilter class with the specified predicate function.
    /// </summary>
    /// <param name="filterPredicate">The predicate function to determine whether to exclude the property.</param>
    public ApiResponsePropertyFilter(Func<string, bool> filterPredicate)
    {
        FilterPredicate = filterPredicate;
    }
}