namespace demo.proyect.domain.Entities;

public class PositionEntity : BaseEntity
{
    public long PositionId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Code { get; set; }
    public long LevelId { get; set; }
    public LevelEntity Level { get; set; }
}
