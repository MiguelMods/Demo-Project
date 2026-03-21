namespace demo.proyect.domain.Entities;

public abstract class BaseEntity
{
    public bool IsActive { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string RowGuid { get; set; }
    public bool IsDeleted { get; set; }
}