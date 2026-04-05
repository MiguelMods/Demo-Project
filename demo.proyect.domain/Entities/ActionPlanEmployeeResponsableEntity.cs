namespace demo.proyect.domain.Entities;

public class ActionPlanEmployeeResponsableEntity : BaseEntity
{
    public ActionPlanEntity ActionPlan { get; set; }
    public long ActionPlanId { get; set; }
    public EmployeeEntity Employee { get; set; }
    public long EmployeeId { get; set; }
    public string Comment { get; set; }
}