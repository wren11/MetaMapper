namespace MetaMapper.Tests.TestModels;

public class UserEntity : BaseEntity
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required ICollection<TodoListEntity> TodoLists { get; set; }
}