namespace demo.proyect.domain.Entities;

public class ActivityEmployeeEntity : BaseEntity
{
    public ActivityEntity Activity { get; set; }
    public long ActivityId { get; set; }
    public EmployeeEntity Employee { get; set; }
    public long EmployeeId { get; set; }
    public string Comment { get; set; }
}