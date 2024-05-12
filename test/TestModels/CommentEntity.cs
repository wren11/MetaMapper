namespace MetaMapper.Tests.TestModels;

public class CommentEntity : BaseEntity
{
    public required string Content { get; set; }
    public int TodoListId { get; set; }
    public int? TodoItemId { get; set; }
    public required TodoListEntity TodoList { get; set; }
    public required TodoItemEntity TodoItem { get; set; }
    public DateTime CreatedAt { get; set; }
}