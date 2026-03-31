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
}

public class GoalInitativeViewModel
{
    public long InitiativeId { get; set; }
    
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    
    [Display(Name = "Descripcion")]
    public string? Descripcion { get; set; }

    [Display(Name = "Es Ejecutable")]
    public bool IsExecutable { get; set; }

    public bool IsReal { get; set; } = true;
}
