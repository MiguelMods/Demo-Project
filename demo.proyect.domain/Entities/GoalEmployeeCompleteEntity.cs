namespace demo.proyect.domain.Entities;

public class GoalEmployeeCompleteEntity : BaseEntity
{
    public GoalEntity GoalEntity { get; set; }
    public long GoalId { get; set; }
    public EmployeeEntity EmployeeEntity { get; set; }
    public long EmployeeId { get; set; }
    public string Comment { get; set; }
}