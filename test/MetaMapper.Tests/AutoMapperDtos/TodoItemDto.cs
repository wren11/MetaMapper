namespace MetaMapper.Tests.AutoMapperDtos;

public class TodoItemDto
{
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public required List<CommentDto> Comments { get; set; }
}