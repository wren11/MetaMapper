namespace MetaMapper.Tests.TestModels;

public class TagEntity : BaseEntity
{
    public required string Name { get; set; }
    public required ICollection<TodoListEntity> TodoLists { get; set; }
}