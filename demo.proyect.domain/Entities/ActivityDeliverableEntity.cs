namespace demo.proyect.domain.Entities;

public class ActivityDeliverableEntity : BaseEntity
{
    public ActivityEntity Activity { get; set; }
    public long ActivityId { get; set; }
    public DeliverableEntity Deliverable { get; set; }
    public long DeliverableId { get; set; }
    public string Comment { get; set; }
}