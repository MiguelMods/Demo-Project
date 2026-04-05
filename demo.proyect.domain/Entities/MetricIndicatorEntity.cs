namespace demo.proyect.domain.Entities;

public class MetricIndicatorEntity : BaseEntity
{
    public MetricEntity Metric { get; set; }
    public long MetricId { get; set; }
    public IndicatorEntity Indicator { get; set; }
    public long IndicatorId { get; set; }
    public  string Comment { get; set; }
}