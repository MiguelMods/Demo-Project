using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class ProjectDevelopmentTypeResponse : BaseResponse
{
    public long ProjectDevelopmentTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static explicit operator ProjectDevelopmentTypeResponse(ProjectDevelopmentTypeEntity projectDevelopmentTypeEntity)
    => new()
    {
        ProjectDevelopmentTypeId = projectDevelopmentTypeEntity.ProjectDevelopmentTypeId,
        Name = projectDevelopmentTypeEntity.Name,
        Description = projectDevelopmentTypeEntity.Description,
        IsActive = projectDevelopmentTypeEntity.IsActive,
        CreatedBy = projectDevelopmentTypeEntity.CreatedBy,
        CreatedAt = projectDevelopmentTypeEntity.CreatedAt,
        UpdatedBy = projectDevelopmentTypeEntity.UpdatedBy,
        UpdatedAt = projectDevelopmentTypeEntity.UpdatedAt,
        RowGuid = projectDevelopmentTypeEntity.RowGuid
    };
}
