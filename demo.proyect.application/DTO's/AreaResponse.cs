using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class AreaResponse : BaseResponse 
{
    public long AreaId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static explicit operator AreaResponse(AreaEntity areaEntity)
    => new()
    {
        AreaId = areaEntity.AreaId,
        Code = areaEntity.Code,
        Name = areaEntity.Name,
        Description = areaEntity.Description,
        IsActive = areaEntity.IsActive,
        CreatedBy = areaEntity.CreatedBy,
        CreatedAt = areaEntity.CreatedAt,
        UpdatedBy = areaEntity.UpdatedBy,
        UpdatedAt = areaEntity.UpdatedAt,
        RowGuid = areaEntity.RowGuid
    };
}
