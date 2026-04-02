namespace demo.proyect.domain.Entities;

public class LevelEntity
{
    public long LevelId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool Superior { get; set; }
    public bool Infection { get; set; }
    public long? SuperiorLevelId { get; set; }
    public LevelEntity? SuperiorLevel { get; set; }
}
