namespace demo.proyect.domain.Entities;

public abstract class BaseEntity
{
    public bool Active { get; set; }
    public string AddedName { get; set; }
    public DateTime AddedDate { get; set; }
    public string ? ModifiedName { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string RowGuid { get; set; }
    public bool Delete { get; set; }
}