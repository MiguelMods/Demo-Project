namespace demo.proyect.domain.Entities;

public class PosibleStateEntity : BaseEntity
{
    public ElementTypeEntity ElementType { get; set; }
    public long ElementTypeId { get; set; }
    public PeriodEntity PeriodEntity { get; set; }
    public long PeriodId { get; set; }
    public decimal MinimumValue { get; set; }
    public decimal MaximumValue { get; set; }
    public StateEntity StateEntity { get; set; }
    public long StateId { get; set; }
}