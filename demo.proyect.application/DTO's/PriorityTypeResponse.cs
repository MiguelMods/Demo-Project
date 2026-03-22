using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class PriorityTypeResponse : BaseResponse
{
    public long PriorityTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static explicit operator PriorityTypeResponse(PriorityTypeEntity priorityTypeEntity)
        => new() 
        { 
            PriorityTypeId = priorityTypeEntity.PriorityTypeId,
            Name = priorityTypeEntity.Name,
            Description = priorityTypeEntity.Description,
            IsActive = priorityTypeEntity.IsActive,
            CreatedBy = priorityTypeEntity.CreatedBy,
            CreatedAt = priorityTypeEntity.CreatedAt,
            UpdatedBy = priorityTypeEntity.UpdatedBy,
            UpdatedAt = priorityTypeEntity.UpdatedAt,
            RowGuid = priorityTypeEntity.RowGuid
        };
}