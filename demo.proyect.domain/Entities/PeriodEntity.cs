namespace demo.proyect.domain.Entities;

public class PeriodEntity : BaseEntity 
{
    public long PeriodId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
