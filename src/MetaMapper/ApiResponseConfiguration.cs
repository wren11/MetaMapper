namespace MetaMapper;

/// <summary>
/// Represents configuration settings for API responses.
/// </summary>
public class ApiResponseConfiguration
{
    private static ApiResponseConfiguration? _instance;

    /// <summary>
    /// Gets the singleton instance of ApiResponseConfiguration.
    /// </summary>
    public static ApiResponseConfiguration Instance => _instance ??= new ApiResponseConfiguration();

    /// <summary>
    /// Gets the set of property filters for API responses.
    /// </summary>
    public HashSet<ApiResponsePropertyFilter> Filters { get; } = [];

    /// <summary>
    /// Configures property filters for API responses.
    /// </summary>
    /// <param name="configureFilters">The action to configure property filters.</param>
    public void Configure(Action<HashSet<ApiResponsePropertyFilter>>? configureFilters)
    {
        configureFilters?.Invoke(Filters);
    }
}