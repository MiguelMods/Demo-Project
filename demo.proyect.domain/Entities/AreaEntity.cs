namespace demo.proyect.domain.Entities;

public class AreaEntity : BaseEntity
{
    public long AreaId { get; set; }
    public string Code {get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long? SuperiorAreaId { get; set; }
    public AreaEntity? SuperiorAreaEntity { get; set; }
    public ICollection<AreaEntity> SubAreasEntities { get; set; }
}