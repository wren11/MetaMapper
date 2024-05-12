namespace MetaMapper.Extensions;

/// <summary>
/// Extensions for working with service responses.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Converts a service metaResponseWrap to an API metaResponseWrap.
    /// </summary>
    /// <typeparam name="T">The type of data in the service metaResponseWrap.</typeparam>
    /// <param name="metaResponseWrap">The service metaResponseWrap to convert.</param>
    /// <returns>An API metaResponseWrap.</returns>
    public static ApiResponse ToApiResponse<T>(this MetaResponse<T> metaResponseWrap)
    {
        var apiResponse = new ApiResponse(metaResponseWrap);
        return apiResponse;
    }
}