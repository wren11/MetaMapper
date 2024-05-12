namespace MetaMapper;

/// <summary>
/// Extensions for configuring API response filters.
/// </summary>
public static class ApiResponseConfigurationExtensions
{
    /// <summary>
    /// Configures property filters for API responses.
    /// </summary>
    /// <param name="configuration">The API response configuration instance.</param>
    /// <param name="configureFilters">The action to configure property filters.</param>
    public static void ConfigureFilters(this ApiResponseConfiguration configuration,
        Action<HashSet<ApiResponsePropertyFilter>> configureFilters)
    {
        configuration.Configure(configureFilters);
    }

    /// <summary>
    /// Adds a property filter for API responses based on the provided predicate function.
    /// </summary>
    /// <param name="filters">The set of property filters.</param>
    /// <param name="filterPredicate">The predicate function to determine whether to exclude the property.</param>
    public static void AddFilter(this HashSet<ApiResponsePropertyFilter> filters, Func<string, bool> filterPredicate)
    {
        filters.Add(new ApiResponsePropertyFilter(filterPredicate));
    }
}