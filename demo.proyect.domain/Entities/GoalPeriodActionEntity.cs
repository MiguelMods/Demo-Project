namespace demo.proyect.domain.Entities;

public class GoalPeriodActionEntity : BaseEntity
{
    public GoalEntity GoalEntity { get; set; }
    public long GoalId { get; set; }
    public PeriodEntity PeriodEntity { get; set; }
    public long PeriodId { get; set; }
    public StateEntity StateEntity { get; set; }
    public long StateId { get; set; }
    public ActionEntity ActionEntity { get; set; }
    public long ActionId { get; set; }
    public int Sequence { get; set; }
}