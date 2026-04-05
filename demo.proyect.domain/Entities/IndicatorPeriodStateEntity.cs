namespace demo.proyect.domain.Entities;

public class IndicatorPeriodStateEntity : BaseEntity 
{
    public IndicatorEntity IndicatorEntity { get; set; }
    public long IndicatorId { get; set; }
    public PeriodEntity PeriodEntity { get; set; }
    public long PeriodId { get; set; }
    public StateEntity StateEntity { get; set; }
    public string Comment { get; set; }
}