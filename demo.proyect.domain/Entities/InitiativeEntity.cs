namespace demo.proyect.domain.Entities;

public class InitiativeEntity : BaseEntity 
{
    public long InitiativeId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ActionPlanEntity? ActionPlan { get; set; }
    public long? ActionPlanId { get; set; }
    public bool IsReal { get; set; }
    public bool IsExecutable { get; set; }
    public GoalEntity Goal { get; set; }
    public long GoalId { get; set; }
    public AreaEntity Area { get; set; }
    public long AreaId { get; set; }
    public ICollection<ActionPlanEntity> ActionPlanEntities { get; set; }
}
