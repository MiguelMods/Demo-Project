using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class ProjectTypeResponse : BaseResponse
{
    public long ProjectTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public static explicit operator ProjectTypeResponse(ProjectTypeEntity projectTypeEntity)
    => new()
    {
        ProjectTypeId = projectTypeEntity.ProjectTypeId,
        Name = projectTypeEntity.Name,
        Description = projectTypeEntity.Description,
        IsActive = projectTypeEntity.IsActive,
        CreatedBy = projectTypeEntity.CreatedBy,
        CreatedAt = projectTypeEntity.CreatedAt,
        UpdatedBy = projectTypeEntity.UpdatedBy,
        UpdatedAt = projectTypeEntity.UpdatedAt,
        RowGuid = projectTypeEntity.RowGuid
    };
}
