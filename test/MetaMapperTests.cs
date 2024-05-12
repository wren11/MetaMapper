using AutoMapper;
using Mapster;
using MetaMapper.Extensions;
using MetaMapper.Tests.AutoMapperDtos;
using MetaMapper.Tests.Infrastructure;
using MetaMapper.Tests.TestModels;
using Newtonsoft.Json;
using System.Diagnostics;
// ReSharper disable Xunit.XunitTestWithConsoleOutput
// ReSharper disable UnusedVariable

namespace MetaMapper.Tests;

public record MetaTodoListResponse : MetaResponse<TodoListEntity>;

public class MetaMapperTests : IClassFixture<MetaMapperTests>
{
    public MetaMapperTests()
    {
        ApiResponseConfiguration.Instance.ConfigureFilters(filters =>
        {
            filters.AddFilter(propertyName =>
                    (propertyName.StartsWith("Id") || propertyName.EndsWith("Id")) && propertyName != "GlobalId");

            filters.AddFilter(propertyName =>
                    propertyName is "IsDeleted" or "IsActive");
        });
    }

    [Fact]
    public void RunAllPerformanceTests()
    {
        // AutoMapper Test
        var (autoMapperDto, autoMapperTime) = AutoMapperPerformanceTest();
        string autoMapperJson = JsonConvert.SerializeObject(autoMapperDto, Formatting.Indented);

        // MetaMapper Test
        var (metaMapperDto, metaMapperTime) = MetaMapperPerformanceTest();
        string metaMapperJson = JsonConvert.SerializeObject(metaMapperDto, Formatting.Indented);

        // Mapster Test
        var (mapsterDto, mapsterTime) = MapsterPerformanceTest();
        string mapsterJson = JsonConvert.SerializeObject(mapsterDto, Formatting.Indented);

        Console.WriteLine("AutoMapper Result JSON:");
        Console.WriteLine(autoMapperJson);
        Console.WriteLine($"Elapsed Time: {autoMapperTime} ms\n");

        Console.WriteLine("MetaMapper Result JSON:");
        Console.WriteLine(metaMapperJson);
        Console.WriteLine($"Elapsed Time: {metaMapperTime} ms\n");

        Console.WriteLine("Mapster Result JSON:");
        Console.WriteLine(mapsterJson);
        Console.WriteLine($"Elapsed Time: {mapsterTime} ms\n");
    }

    private (TodoListDto, long) AutoMapperPerformanceTest()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TodoListEntity, TodoListDto>();
            cfg.CreateMap<UserEntity, UserDto>();
            cfg.CreateMap<TagEntity, TagDto>();
            cfg.CreateMap<CommentEntity, CommentDto>();
            cfg.CreateMap<TodoItemEntity, TodoItemDto>();
        });

        var mapper = mapperConfig.CreateMapper();
        var stopwatch = Stopwatch.StartNew();
        var todoListEntity = DataGenerator.GenerateTodoList();
        var dto = mapper.Map<TodoListDto>(todoListEntity);
        stopwatch.Stop();
        return (dto, stopwatch.ElapsedMilliseconds);
    }

    private (ApiResponse, long) MetaMapperPerformanceTest()
    {
        var stopwatch = Stopwatch.StartNew();
        var todoListEntity = DataGenerator.GenerateTodoList();
        var response = new MetaTodoListResponse()
        {
            Success = true,
            Message = "Meta Mapped!",
            Data = todoListEntity
        };
        var apiResponse = response.ToApiResponse();
        stopwatch.Stop();
        return (apiResponse, stopwatch.ElapsedMilliseconds);
    }

    private (TodoListDto, long) MapsterPerformanceTest()
    {
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        var stopwatch = Stopwatch.StartNew();
        var todoListEntity = DataGenerator.GenerateTodoList();
        var dto = todoListEntity.Adapt<TodoListDto>();
        stopwatch.Stop();
        return (dto, stopwatch.ElapsedMilliseconds);
    }
}
    
