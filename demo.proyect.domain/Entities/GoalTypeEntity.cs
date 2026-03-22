namespace demo.proyect.domain.Entities;

public class GoalTypeEntity : BaseEntity 
{
    public long GoalTypeId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
