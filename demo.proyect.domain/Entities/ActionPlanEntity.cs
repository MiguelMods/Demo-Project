namespace demo.proyect.domain.Entities;

public class ActionPlanEntity : BaseEntity 
{
    public string ActionPlanId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Decimal? Budget { get; set; }
    public bool IsExectuable { get; set; }
    public bool Converted { get; set; }
    public AreaEntity? AreaEntity { get; set; }
    public long? AreaId { get; set; }
    public int Order { get; set;  }
    public InitiativeEntity Initiative { get; set; }
    public long InitiativeId { get; set;  }
}