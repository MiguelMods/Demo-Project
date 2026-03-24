using demo.proyect.domain.Entities;

namespace demo.proyect.application.DTO_s;

public class InitiativeResponse : BaseResponse
{
    public long InitiativeId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string ActionPlanEntity { get; set; }
    public long? ActionPlanOriginId { get; set; }
    public bool IsReal { get; set; }
    public bool IsExecutable { get; set; }
    public string Goal { get; set; }
    public long GoalId { get; set; }
    public string Area { get; set; }
    public long AreaId { get; set; }                

    public static explicit operator InitiativeResponse(InitiativeEntity initiativeEntity) => new()
    {
        InitiativeId = initiativeEntity.InitiativeId,
        Name = initiativeEntity.Name,
        Description = initiativeEntity.Description,
        ActionPlanEntity = initiativeEntity.ActionPlanEntity?.Name,
        ActionPlanOriginId = initiativeEntity.ActionPlanOriginId,
        IsReal = initiativeEntity.IsReal,
        IsExecutable = initiativeEntity.IsExecutable,
        Goal = initiativeEntity.Goal?.Name,
        GoalId = initiativeEntity.GoalId,
        Area = initiativeEntity.Area?.Name,
        AreaId = initiativeEntity.AreaId,
        IsActive = initiativeEntity.IsActive,
        CreatedBy = initiativeEntity.CreatedBy,
        CreatedAt = initiativeEntity.CreatedAt,
        UpdatedBy = initiativeEntity.UpdatedBy,
        UpdatedAt = initiativeEntity.UpdatedAt,
        RowGuid = initiativeEntity.RowGuid
    };
}