namespace demo.proyect.domain.Entities;

public class ActionPlanActivityEntity : BaseEntity
{
    public ActionPlanEntity ActionPlan { get; set; }
    public long ActionPlanId { get; set; }
    public ActivityEntity Activity { get; set; }
    public long ActivityId { get; set; }
    public decimal Contribution { get; set; }
    public bool ContributionIsValid { get; set; }
    public string Comment { get; set; }
}