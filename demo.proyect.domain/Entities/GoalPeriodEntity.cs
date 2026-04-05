namespace demo.proyect.domain.Entities;

public class GoalPeriodEntity : BaseEntity
{
    public GoalEntity GoalEntity { get; set; }
    public long GoalId { get; set; }
    public PeriodEntity PeriodEntity { get; set; }
    public long PeriodId { get; set; }
    public decimal Value { get; set; }
}