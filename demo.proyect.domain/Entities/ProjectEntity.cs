namespace demo.proyect.domain.Entities;

public class ProjectEntity : BaseEntity
{
    public long ProjectId { get; set; }
    public string CodeOne { get; set; }
    public string CodeTwo { get; set; }
    public string Name { get; set; }
    public string? Objetive { get; set; }
    public string? Scope { get; set; }
    public string? Description { get; set; }
    public AreaEntity Area { get; set; }
    public long AreaId { get; set; }
    public AreaEntity SubArea { get; set; }
    public long SubAreaId { get; set; }
    public bool PoaRoadmap { get; set; }
    public DateTime? EnterDate { get; set; }
    public DateTime? WishDate { get; set; }
    public bool IsCritical { get; set; }
    public bool UseNormalFlow { get; set; }
    public PriorityTypeEntity Priority { get; set; }
    public long PriorityTypeId { get; set; }
    public ProjectTypeEntity ProjectType { get; set; }
    public long ProjectTypeId { get; set; }
    public ProjectDevelopmentTypeEntity ProjectDevelopmentType { get; set; }
    public long ProjectDevelopmentTypeId { get; set; }
}