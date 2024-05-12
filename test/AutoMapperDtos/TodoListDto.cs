namespace MetaMapper.Tests.AutoMapperDtos;
// DTO models for mapping

public class TodoListDto
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
    public required UserDto User { get; set; }
    public required List<TagDto> Tags { get; set; }
    public required List<CommentDto> Comments { get; set; }
    public required List<TodoItemDto> Items { get; set; }
}