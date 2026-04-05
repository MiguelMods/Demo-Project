namespace demo.proyect.domain.Entities;

public class MetricEmployeeResponsableEntity : BaseEntity
{
    public MetricEntity Metric { get; set; }
    public long MetricId { get; set; }
    public EmployeeEntity Employee { get; set; }
    public long EmployeeId { get; set; }
    public string Comment { get; set; }
}