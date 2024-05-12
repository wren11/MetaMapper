namespace MetaMapper.Tests.TestModels;

public class BaseEntity
{
    public int Id { get; set; }
    public Guid GlobalId { get; set; }
    public DateTime ModifiedAt { get; set; }
    public required string ModifiedBy { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}