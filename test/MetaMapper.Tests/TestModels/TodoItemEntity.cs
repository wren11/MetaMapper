namespace MetaMapper.Tests.TestModels;

public class TodoItemEntity : BaseEntity
{
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int TodoListId { get; set; }
    public required TodoListEntity TodoList { get; set; }
    public required ICollection<CommentEntity> Comments { get; set; }
}