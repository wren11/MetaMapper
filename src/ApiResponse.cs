using System.Reflection;

namespace MetaMapper;

/// <summary>
/// Represents an API response with success status and data.
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// Gets or sets a value indicating whether the API response was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets the dictionary containing response data.
    /// </summary>
    public Dictionary<string, object> Data { get; } = [];

    // Cached property info
    private static readonly Dictionary<Type, (PropertyInfo SuccessProp, PropertyInfo MessageProp)> TypePropertyCache = [];

    /// <summary>
    /// Initializes a new instance of the ApiResponse class with the given responses.
    /// </summary>
    /// <param name="responses">Objects representing API responses.</param>
    public ApiResponse(params object[] responses)
    {
        Success = true;
        var visited = new HashSet<object>();

        foreach (var response in responses)
        {
            var responseType = response.GetType();

            if (!TypePropertyCache.TryGetValue(responseType, out var props))
            {
                var successProp = responseType.GetProperty("Success");
                var messageProp = responseType.GetProperty("Message");
                props = (successProp, messageProp)!;
                TypePropertyCache[responseType] = props;
            }

            if (props.SuccessProp == null || props.MessageProp == null)
                continue;

            var respSuccess = (bool)props.SuccessProp.GetValue(response)!;
            var message = (string)props.MessageProp.GetValue(response)!;

            Success &= respSuccess;

            if (!respSuccess)
            {
                Data[$"{responseType.Name}Error"] = message;
            }
            else
            {
                var dto = ConvertToDynamicDto(response, visited);
                if (dto != null!)
                {
                    Data[responseType.Name] = dto;
                }
            }
        }
    }

    private static object ConvertToDynamicDto(object entity, HashSet<object> visited)
    {
        if (!visited.Add(entity))
            return null!;

        var dto = new Dictionary<string, object>();
        var properties = entity.GetType().GetProperties();

        foreach (var prop in properties)
        {
            if (ShouldExcludeProperty(prop.Name))
                continue;

            var propValue = prop.GetValue(entity);
            if (propValue == null) continue;

            var isCollection = typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string);
            var isComplexType = prop.PropertyType.IsClass && !IsScalarType(prop.PropertyType);

            if (isCollection)
            {
                var listDto = new List<object>();
                foreach (var item in (System.Collections.IEnumerable)propValue)
                {
                    if (visited.Contains(item))
                        continue;

                    var itemDto = ConvertToDynamicDto(item, visited);
                    if (itemDto != null!)
                    {
                        listDto.Add(itemDto);
                    }
                }
                if (listDto.Count > 0)
                {
                    dto[prop.Name] = listDto;
                }
            }
            else if (isComplexType)
            {
                var complexDto = ConvertToDynamicDto(propValue, visited);
                if (complexDto != null!)
                {
                    dto[prop.Name] = complexDto;
                }
            }
            else if (IsScalarType(prop.PropertyType))
            {
                dto[prop.Name] = propValue;
            }
        }

        visited.Remove(entity);
        return dto.Count > 0 ? dto : null!;
    }

    private static bool ShouldExcludeProperty(string propertyName)
    {
        return ApiResponseConfiguration.Instance.Filters.Any(filter => filter.FilterPredicate(propertyName));
    }

    private static bool IsScalarType(Type type)
    {
        return Type.GetTypeCode(type) != TypeCode.Object || type.IsValueType || type == typeof(Guid) || type == typeof(DateTime) || type == typeof(DateTimeOffset);
    }
}
