namespace demo.proyect.domain.Entities;

public class IndicatorActionPeriodEntity : BaseEntity
{
    public IndicatorEntity IndicatorEntity { get; set; }
    public long IndicatorId { get; set; }
    public PeriodEntity PeriodEntity { get; set; }
    public long PeriodId { get; set; }
    public StateEntity StateEntity { get; set; }
    public long StateId { get; set; }
    public ActionEntity ActionEntity { get; set; }
    public long ActionId { get; set; }
    public string Comment { get; set; } 
}