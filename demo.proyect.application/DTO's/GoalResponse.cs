using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class GoalResponse : BaseResponse
{
    public long GoalId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Formula { get; set; }
    public bool IsReal { get; set; }
    public long AreaId { get; set; }
    public long PeriodId { get; set; }
    public long PerspectiveId { get; set; }
    public long GoalTypeId { get; set; }
    public long ProjectId { get; set; }

    public static explicit operator GoalResponse(GoalEntity goalEntity) => new() {
        GoalId = goalEntity.GoalId,
        Code = goalEntity.Code,
        Name = goalEntity.Name,
        Description = goalEntity.Description,
        Formula = goalEntity.Formula,
        IsReal = goalEntity.IsReal,
        AreaId = goalEntity.AreaId,
        PeriodId = goalEntity.PeriodId,
        PerspectiveId = goalEntity.PerspectiveId,
        GoalTypeId = goalEntity.GoalTypeId,
        ProjectId = goalEntity.ProjectId,
        IsActive = goalEntity.IsActive,
        CreatedBy = goalEntity.CreatedBy,
        CreatedAt = goalEntity.CreatedAt,
        UpdatedBy = goalEntity.UpdatedBy,
        UpdatedAt = goalEntity.UpdatedAt,
        RowGuid = goalEntity.RowGuid
    };
}