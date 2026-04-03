using demo.proyect.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace demo.project.site.Models.ViewModels;

public class EmployeCreateViewModel
{
    public long EmployeeId { get; set; }
    
    [Display(Name = "Codigo de Empleado")]
    public string Code { get; set; }
    
    [Display(Name = "Primer Nombre")]
    public string FirtName { get; set; }

    [Display(Name = "Primer Nombre")]
    public string? MiddleName { get; set; }

    [Display(Name = "Primer Nombre")]
    public string Surname { get; set; }

    [Display(Name = "Foto del Empleado")]
    public IFormFile? Photo { get; set; }

    [Display(Name = "Asignar un Area")]
    public long AreaId { get; set; }

    [Display(Name = "Asignar una Posicion")]
    public long PositionId { get; set; }

    [Display(Name = "Asignar un Supervisor")]
    public long? SuperiorEmployeeId { get; set; }

    [Display(Name = "Genero")]
    public GenderEnum? Gender { get; set; }

    [Display(Name = "Crear Usuario Automaticamente")]
    public bool CreateUserSystem { get; set; } = false;
}
