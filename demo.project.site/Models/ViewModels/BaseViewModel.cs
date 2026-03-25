using System.ComponentModel.DataAnnotations;

namespace demo.project.site.Models.ViewModels;

public abstract class BaseViewModel
{
    [Display(Name = "Activo")]
    public bool IsActive { get; set; } = true;
    
    [Display(Name = "Creado Por")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Fecha Creacion")]
    public DateTime? CreatedAt { get; set; }

    [Display(Name = "Modificado Ultima Vez Por")]
    public string? UpdatedBy { get; set; }

    [Display(Name = "Fecha Ultima Modicacion")]
    public DateTime? UpdatedAt { get; set; }
    
    public string? RowGuid { get; set; }
}
