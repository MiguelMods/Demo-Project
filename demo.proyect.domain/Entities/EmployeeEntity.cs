namespace demo.proyect.domain.Entities;

public class EmployeeEntity : BaseEntity
{
    public long EmployeeId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Code { get; set; }
    public long AreaId { get; set; }
    public AreaEntity Area { get; set; }
    public long PositionId { get; set; }
    public PositionEntity Position { get; set; }
}
