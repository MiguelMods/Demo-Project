namespace demo.proyect.domain.Entities;

public class IndicatorEmployeeDataColectorEntity : BaseEntity 
{
    public IndicatorEntity IndicatorEntity { get; set; }
    public long IndicatorId { get; set; }
    public EmployeeEntity EmployeeEntity { get; set; }
    public long EmployeeId { get; set; }
    public string Comment { get; set; }
}