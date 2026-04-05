namespace demo.proyect.domain.Entities;

public class IndicatorEntity : CommonNameDescription
{
    public long IndicatorId { get; set; }
    public string Code { get; set; }
    public CalculationTypeEnumEntity CalculationType { get; set; }
    public ValueTypeEnumEntity ValueType { get; set; }
    public DataOriginTypeEnumEntity DataOriginType { get; set; }
    public string FormulaText { get; set; }
    public byte[]? FormulaPicture { get; set; }
    public string? FormulaPictureUrl { get; set; }
    public decimal? WeightedWeight { get; set; }
    public GoalEntity GoalEntity { get; set; }
    public long GoalId { get; set; }
    public UnitMeasurementEntity UnitMeasurement { get; set; }
    public long UnitMeasurementId { get; set; }
    public OriginElementEntity OriginElement { get; set; }
    public long OriginElementId { get; set; }
    public PeriodicityEntity PeriodicityCalc { get; set; }
    public long PeriodicityCalcId { get; set; }
    public PeriodicityEntity PeriodicityPresentation { get; set; }
    public long PeriodicityPresentationId { get; set; }
}