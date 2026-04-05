namespace demo.proyect.domain.Entities;

public class GoalPeriodStateEntity : BaseEntity
{
    public GoalEntity GoalEntity { get; set; }
    public long GoalId { get; set; }
    public PeriodEntity PeriodEntity { get; set; }
    public long PeriodId { get; set; }
    public StateEntity StateEntity { get; set; }
    public long StateId { get; set; }
    public string Comment { get; set; }
}