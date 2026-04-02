using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class ProjectResponse() : BaseResponse
{
    public long ProjectId { get; set; }
    public string CodeOne { get; set; }
    public string CodeTwo { get; set; }
    public string Name { get; set; }
    public string? Objetive { get; set; }
    public string? Scope { get; set; }
    public string? Description { get; set; }
    public string Area { get; set; }
    public long AreaId { get; set; }
    public string SubArea { get; set; }
    public long SubAreaId { get; set; }
    public bool PoaRoadmap { get; set; }
    public DateTime? EnterDate { get; set; }
    public DateTime? WishDate { get; set; }
    public bool IsCritical { get; set; }
    public bool UseNormalFlow { get; set; }
    public string Priority { get; set; }
    public long PriorityTypeId { get; set; }
    public string ProjectType { get; set; }
    public long ProjectTypeId { get; set; }
    public string ProjectDevelopmentType { get; set; }
    public long ProjectDevelopmentTypeId { get; set; }

    public static explicit operator ProjectResponse(ProjectEntity projectEntity)
    => new()
    {
        ProjectId = projectEntity.ProjectId,
        CodeOne = projectEntity.CodeOne,
        CodeTwo = projectEntity.CodeTwo,
        Name = projectEntity.Name,
        Objetive = projectEntity.Objetive,
        Scope = projectEntity.Scope,
        Description = projectEntity.Description,
        Area = projectEntity.Area?.Name ?? "",
        AreaId = projectEntity.AreaId,
        SubArea = projectEntity.SubArea?.Name ?? "",
        SubAreaId = projectEntity.SubAreaId,
        PoaRoadmap = projectEntity.PoaRoadmap,
        EnterDate = projectEntity.EnterDate,
        WishDate = projectEntity.WishDate,
        IsCritical = projectEntity.IsCritical,
        UseNormalFlow = projectEntity.UseNormalFlow,
        Priority = projectEntity.Priority?.Name ?? "",
        PriorityTypeId = projectEntity.PriorityTypeId,
        ProjectType = projectEntity.ProjectType?.Name ?? "",
        ProjectTypeId = projectEntity.ProjectTypeId,
        ProjectDevelopmentType = projectEntity.ProjectDevelopmentType?.Name ?? "",
        ProjectDevelopmentTypeId = projectEntity.ProjectDevelopmentTypeId,
        IsActive = projectEntity.IsActive,
        CreatedBy = projectEntity.CreatedBy,
        CreatedAt = projectEntity.CreatedAt,
        UpdatedBy = projectEntity.UpdatedBy,
        UpdatedAt = projectEntity.UpdatedAt,
        RowGuid = projectEntity.RowGuid
    };
}
