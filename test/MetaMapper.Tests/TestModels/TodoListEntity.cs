namespace MetaMapper.Tests.TestModels;

public class TodoListEntity : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int Priority { get; set; }
    public required string Category { get; set; }
    public required string AssignedTo { get; set; }
    public required string CreatedBy { get; set; }
    public int UserId { get; set; }
    public required ICollection<TodoItemEntity> Items { get; set; }
    public required ICollection<TagEntity> Tags { get; set; }
    public required ICollection<CommentEntity> Comments { get; set; }
    public required UserEntity User { get; set; }
}