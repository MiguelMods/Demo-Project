using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Create;

public class GoalCreate : BaseResponse
{
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
}