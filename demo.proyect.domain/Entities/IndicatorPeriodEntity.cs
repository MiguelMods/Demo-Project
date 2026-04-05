namespace demo.proyect.domain.Entities;

public class IndicatorPeriodEntity : BaseEntity
{
    public IndicatorEntity Indicator { get; set; }
    public long IndicatorId { get; set; }
    public PeriodEntity Period { get; set; }
    public long PeriodId { get; set; }
    public decimal Value { get; set; }
    public string Comment { get; set; }
}