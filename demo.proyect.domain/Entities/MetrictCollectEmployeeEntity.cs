namespace demo.proyect.domain.Entities;

public class MetrictCollectEmployeeEntity : BaseEntity
{
    public MetricEntity MetricEntity { get; set; }
    public long MetricId { get; set; }
    public EmployeeEntity EmployeeEntity { get; set; }
    public long EmployeeId { get; set; }
    public string Comment { get; set; }
}