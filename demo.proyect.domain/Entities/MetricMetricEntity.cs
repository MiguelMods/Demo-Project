namespace demo.proyect.domain.Entities;

public class MetricMetricEntity : BaseEntity
{
    public MetricEntity MetricOne { get; set; }
    public long MetricOneId { get; set; }
    public MetricEntity MetricTwo { get; set; }
    public long MetricTwoId { get; set; }
    public string Comment { get; set; }
}