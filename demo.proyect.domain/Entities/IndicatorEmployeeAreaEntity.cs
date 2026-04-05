namespace demo.proyect.domain.Entities;

public class IndicatorEmployeeAreaEntity : BaseEntity
{
    public IndicatorEntity IndicatorEntity { get; set; }
    public long IndicatorId { get; set; }
    public EmployeeEntity EmployeeEntity { get; set; }
    public long EmployeeId { get; set; }
    public AreaEntity AreaEntity { get; set; }
    public long AreaId { get; set; }
    public string Comment { get; set; }
}