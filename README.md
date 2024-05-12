# MetaMapper: The Superior Mapping Solution

Welcome to the GitHub repository for MetaMapper, a cutting-edge mapping library designed to simplify and accelerate the process of mapping data models in .NET applications. Unlike traditional mapping tools like AutoMapper and Mapster, MetaMapper eliminates the need for creating Data Transfer Objects (DTOs), offering a seamless and efficient mapping experience.

## Why MetaMapper?

MetaMapper stands out by not requiring explicit DTOs, reducing boilerplate code and streamlining the development process. This feature makes it uniquely advantageous for projects where maintaining numerous DTOs becomes cumbersome.

## How MetaMapper Works and Its Underlying Mechanics

MetaMapper leverages advanced .NET features to provide a highly efficient mapping solution that eliminates the need for explicit Data Transfer Objects (DTOs). Here's an overview of how it works and why it's fast:

### Underlying Mechanics

1. **Reflection and Expression Trees**: MetaMapper uses reflection to inspect the properties of the source and target types at runtime. It then constructs expression trees to represent the mapping operations. These expression trees are compiled into executable code, which is much faster than using reflection at runtime for each mapping operation.

2. **Caching Mechanism**: Once the expression trees are compiled, the resulting delegates are cached. This means that the first mapping operation might take slightly longer (due to the overhead of reflection and compilation), but subsequent mappings are extremely fast as they utilize the cached compiled code.

3. **No Intermediate DTOs**: Unlike traditional mappers that require defining DTOs, MetaMapper maps directly between the source and target types. This direct mapping reduces overhead and improves performance because there's no need to instantiate and populate intermediate objects.


### Why It's Fast

- **Precompiled Expressions**: The use of precompiled expression trees significantly reduces the runtime overhead compared to using reflection for each mapping operation.
- **Caching**: Storing the compiled mapping functions in a cache eliminates the need to recompile them for each mapping operation, providing a significant performance boost.
- **Direct Mapping**: By avoiding the creation of intermediate DTOs, MetaMapper reduces the number of operations required to map data from the source to the target.


## How to Use MetaMapper

MetaMapper is designed for ease of use. Here's a simple example to get you started:


```csharp
var response = new MetaTodoListResponse()
{
    Success = true,
    Message = "Data Mapped!",
    Data = todoListEntity
};
var apiResponse = response.ToApiResponse();
```


In this example, `MetaTodoListResponse` automatically maps the `todoListEntity` to the appropriate response format without needing a separate DTO.

## Performance Comparison

MetaMapper not only simplifies development but also excels in performance. Here's a comparison of mapping performance between MetaMapper, AutoMapper, and Mapster:

| Mapper     | Elapsed Time (ms) |
|------------|-------------------|
| AutoMapper | 115               |
| MetaMapper | 20                |
| Mapster    | 107               |

As shown, MetaMapper is significantly faster, making it ideal for high-performance applications.

```markdown
| Attribute             | AutoMapper                          | MetaMapper                              | Mapster                             |
|-----------------------|-------------------------------------|-----------------------------------------|-------------------------------------|
| **Title**             | black white 24/7                   | black white 24/7                       | black white 24/7                   |
| **Description**       | Sequi quia et qui qui tempore...    | Sequi quia et qui qui tempore...        | Sequi quia et qui qui tempore...    |
| **CreatedAt**         | 2024-05-12T18:31:55.8124613+10:00   | 2024-05-12T18:31:55.9341349+10:00       | 2024-05-12T18:31:55.9840437+10:00   |
| **DueDate**           | 2024-07-31T18:31:55.8124964+10:00   | 2024-07-31T18:31:55.9341353+10:00       | 2024-07-31T18:31:55.9840441+10:00   |
| **IsCompleted**       | true                                | true                                    | true                                |
| **Priority**          | 10                                  | 10                                      | 10                                  |
| **Category**          | Colombian Peso                      | Colombian Peso                          | Colombian Peso                      |
| **AssignedTo**        | Melba Buckridge                     | Melba Buckridge                         | Melba Buckridge                     |
| **CreatedBy**         | Melba Buckridge                     | Melba Buckridge                         | Melba Buckridge                     |
| **User**              | Annetta59, Mina.Hayes@yahoo.com     | Rudy84, Darryl.Mitchell49@gmail.com     | Marlin_Hansen97, Cali79@gmail.com   |
| **Tags**              | transmitting, hack, Unions          | synthesize, channels, Open-source       | cross-platform, firmware, Synergistic |
| **Number of Comments**| 2                                   | 2                                       | 2                                   |
| **Number of Items**   | 5                                   | 5                                       | 5                                   |
| **Elapsed Time (ms)** | 115                                 | 20                                      | 107                                 |
```


## Test Suite

For those interested in verifying these results, our test suite is included in the repository. You can run these tests to see firsthand how MetaMapper compares with other mappers.

## Conclusion

MetaMapper provides a superior mapping solution by eliminating the need for DTOs and offering unmatched performance. Whether you are working on a large-scale enterprise application or a small project, MetaMapper can enhance your development workflow and application efficiency.

Consider adopting MetaMapper for your next project to leverage its benefits and streamline your data handling processes.