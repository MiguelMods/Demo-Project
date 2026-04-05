namespace demo.proyect.domain.Entities;

public class MetricPeriodValueEntity : BaseEntity
{
    public MetricEntity Metric { get; set; }
    public long MetricId { get; set; }
    public PeriodEntity Period { get; set; }
    public long PeriodId { get; set; }
    public decimal Value { get; set; }
    public string Comment { get; set; }
}