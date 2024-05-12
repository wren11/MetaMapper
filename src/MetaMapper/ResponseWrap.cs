namespace MetaMapper;

/// <summary>
/// Represents a service response.
/// </summary>
/// <typeparam name="T">The type of data in the service response.</typeparam>
public record MetaResponse<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the service response was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the service response.
    /// </summary>
    public string Message { get; set; } = default!;

    /// <summary>
    /// Gets or sets the data contained in the service response.
    /// </summary>
    public T Data { get; set; } = default!;
}