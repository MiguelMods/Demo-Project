using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace demo.project.site.Models.ViewModels;

public class ProjectGoalViewModel
{
    public ProjectViewModel Project { get; set; }
    public long GoalId { get; set; }
    [Display(Name = "Codigo")]
    public string Code { get; set; }
    
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    
    [Display(Name = "Descripcion")]
    public string? Description { get; set; }
    public string? Formula { get; set; }
    public bool IsReal { get; set; }

    [Display(Name = "Asignar Empleado")]
    public long EmployeeId { get; set; }

    public AreaEntity Area { get; set; }

    [Display(Name = "Selección de Area")]
    public long AreaId { get; set; }

    [Display(Name = "Selección de Periodo")]
    public long PeriodId { get; set; }

    [Display(Name = "Selección de Perpectiva")]
    public long PerspectiveId { get; set; }

    [Display(Name = "Selección de Tipo Objetivo")]
    public long GoalTypeId { get; set; }

    [Display(Name = "Marcar Como Activo")]
    public bool IsActive { get; set; }
    public GoalInitativeViewModel GoalInitative { get; set; }
    public List<GoalInitativeViewModel> GoalInitatives { get; set; }

    public static explicit operator ProjectGoalViewModel(GoalResponse response) => new() {
        GoalId = response.GoalId,
        Code = response.Code,
        Name = response.Name,
        Description = response.Description,
        Formula = response.Formula,
        IsReal = response.IsReal,
        AreaId = response.AreaId,
        PeriodId = response.PeriodId,
        PerspectiveId = response.PerspectiveId,
        GoalTypeId = response.GoalTypeId,
        IsActive = response.IsActive,
        Project = new () { Name = response.Project.Name, Description = response.Project.Description, RowGuid = response.Project.RowGuid },
        GoalInitatives = [.. response?.InitiativeEntities?.Select(x => new GoalInitativeViewModel { 
         InitiativeId = x.InitiativeId,
         Name = x.Name,
         Description = x.Description,
         IsExecutable = x.IsExecutable,
        })]
    };
}

public class GoalInitativeViewModel
{
    public long InitiativeId { get; set; }
    
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    
    [Display(Name = "Descripcion")]
    public string? Description { get; set; }

    [Display(Name = "Es Ejecutable")]
    public bool IsExecutable { get; set; }

    public bool IsReal { get; set; } = true;

    public string RowGuid { get; set; }

    public List<ActionPlanViewModel> ActionPlans { get; set; }
}

public class ActionPlanViewModel
{
    public long ActionPlanId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string RowGuid { get; set; }
}
