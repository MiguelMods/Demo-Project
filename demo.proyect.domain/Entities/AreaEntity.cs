namespace demo.proyect.domain.Entities;

public class AreaEntity : BaseEntity
{
    public long AreaId { get; set; }
    public string Code {get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AreaEntity SuperiorArea { get; set; }
    public long? SuperiorAreaId { get; set; }
    public ICollection<AreaEntity> SubAreas { get; set; }
}