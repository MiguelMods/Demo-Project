namespace demo.proyect.domain.Entities;

public class GoalEntity : BaseEntity
{
    public long GoalId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Formula { get; set; }
    public bool IsReal { get; set; }
    public AreaEntity Area { get; set; }
    public long AreaId { get; set; }
    public PeriodEntity Period { get; set; }
    public long PeriodId { get; set; }
    public PerspectiveEntity Perspective { get; set; }
    public long PerspectiveId { get; set; }
    public GoalTypeEntity GoalType { get; set; }
    public long GoalTypeId { get; set; }
    public ProjectEntity Project { get; set; }
    public long ProjectId { get; set; }
    public ICollection<InitiativeEntity> InitiativeEntities { get; set; }
}