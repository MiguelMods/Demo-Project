using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class EmployeeResponse : BaseResponse
{
    public long EmployeeId { get; set; }
    public string Code { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } 
    public string Surname { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
    public long AreaId { get; set; }
    public string AreaName { get; set; } = string.Empty;
    public long PositionId { get; set; }
    public string PositionName { get; set; } = string.Empty;
    public long? SuperiorEmployeeId { get; set; }
    public string? SuperiorEmployeeCompleteName { get; set; }
    public GenderEnum GenderEnum { get; set; }
    public string CompleteName => $"{FirstName} {MiddleName} {Surname}";

    public static explicit operator EmployeeResponse(EmployeeEntity entity)
        => new() { 
            EmployeeId = entity.EmployeeId,
            FirstName= entity.FirtName,
            MiddleName = entity.MiddleName,
            Surname = entity.Surname,
            PhotoUrl = entity.PhotoUrl,
            AreaId = entity.AreaId,
            PositionId = entity.PositionId,
            SuperiorEmployeeId = entity.SuperiorEmployeeId,
            GenderEnum = entity.Gender,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
            IsActive = entity.IsActive,
            RowGuid = entity.RowGuid,
            Code = entity.Code,
        };
}
