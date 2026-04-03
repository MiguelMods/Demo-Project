namespace demo.proyect.domain.Entities;

public class EmployeeEntity : BaseEntity
{
    public long EmployeeId { get; set; }
    public string Code { get; set; }
    public string FirtName { get; set; }
    public string? MiddleName { get; set; }
    public string Surname { get; set; }
    public string? PhotoUrl { get; set; }
    public long AreaId { get; set; }
    public AreaEntity Area { get; set; }
    public long PositionId { get; set; }
    public PositionEntity Position { get; set; }
    public long? SuperiorEmployeeId { get; set; }
    public EmployeeEntity? SuperiorEmployee { get; set; }
    public GenderEnum Gender { get; set; }
    public ICollection<GoalEntity> GoalEntities { get; set; }
}
