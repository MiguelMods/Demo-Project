namespace demo.proyect.domain.Entities;

public class IndicatorOldToNewEntity : BaseEntity
{
    public IndicatorEntity IndicatorOld { get; set; }
    public long IndicatorOldId { get; set; }
    public IndicatorEntity IndicatorNew { get; set; }
    public long IndicatorNewId { get; set; }
    public string Comment { get; set; }
}