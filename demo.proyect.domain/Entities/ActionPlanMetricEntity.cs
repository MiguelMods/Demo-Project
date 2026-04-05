namespace demo.proyect.domain.Entities;

public class ActionPlanMetricEntity : BaseEntity
{
    public ActionPlanEntity ActionPlan { get; set; }
    public long ActionPlanId { get; set; }
    public MetricEntity Metric { get; set; }
    public long MetricId { get; set; }
    public string Comment { get; set; }
}