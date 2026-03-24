namespace demo.proyect.application.Create;

public class ProjectCreate : BaseCreate
{
    public string CodeOne { get; set; }
    public string CodeTwo { get; set; }
    public string Name { get; set; }
    public string? Objetive { get; set; }
    public string? Scope { get; set; }
    public string? Description { get; set; }
    public long AreaId { get; set; }
    public long SubAreaId { get; set; }
    public bool PoaRoadMap { get; set; }
    public DateTime? WishDate { get; set; }
    public bool IsCritical { get; set; }
    public bool UseNormalFlow { get; set; }
    public long PriorityTypeId { get; set; }
    public long ProjectTypeId { get; set; }
    public long ProjectDevelopmentTypeId { get; set; }
}