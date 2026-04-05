namespace demo.proyect.domain.Entities;

public partial class MetricEntity : CommonNameDescription
{
    public long MetricId { get; set; }
    public string Code { get; set; }
    public UpdateFormEnumEntity UpdateFormEnum { get; set; }
    public CalculationTypeEnumEntity CalculationTypeEnum { get; set; }
    public ValueTypeEnumEntity ValueTypeEnum { get; set; }
    public string FormulaText { get; set; }
    public string? FormulaPicUrl { get; set; }
    public byte[]? FormulaPicData { get; set; }
    public decimal Minimun { get; set;  }
    public decimal Maximun { get; set; }
    public decimal ActualValue { get; set; }
    public MetricTypeEntity MetricType { get; set; }
    public long MetricTypeId { get; set; }
    public UnitMeasurementEntity UnitMeasurement { get; set; }
    public long UnitMeasurementId { get; set; }
    public PeriodicityEntity Periodicity { get; set; }
    public long PeriodicityId { get; set; }
}