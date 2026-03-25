using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;
using demo.proyect.common.Helpers.Validations;
using System.ComponentModel.DataAnnotations;

namespace demo.project.site.Models.ViewModels;

public class AreaViewModel : BaseViewModel
{
    [Display(Name = "Numero De Area")]
    public long AreaId { get; set; }
    
    [Display(Name = "Codigo"), Required(ErrorMessage = Messages.IsRequired)]
    [MinLength(1, ErrorMessage = "Este Campo Requiere un Minimo de 1 un Caracter*")]
    [MaxLength(6, ErrorMessage = "Este Campo Requiere un Minimo de 6 un Caracteres*")]
    public string Code { get; set; }
    
    [Display(Name = "Nombre"), Required(ErrorMessage = Messages.IsRequired)]
    public string Name { get; set; }

    [Display(Name = "Descripcion")]
    public string? Description { get; set; }

    [Display(Name = "Area Superior")]
    public long? SuperiorAreaId { get; set; } = null;

    public static explicit operator AreaViewModel(AreaResponse areaResponse) => new() {
        AreaId = areaResponse.AreaId,
        Code = areaResponse.Code,
        Name = areaResponse.Name,
        Description = areaResponse.Description,
        SuperiorAreaId = areaResponse.SuperiorAreaId,
        IsActive = areaResponse.IsActive,
        CreatedAt = areaResponse.CreatedAt,
        CreatedBy = areaResponse.CreatedBy,
        UpdatedBy = areaResponse.UpdatedBy,
        UpdatedAt = areaResponse.UpdatedAt,
        RowGuid = areaResponse.RowGuid
    };

    public static AreaCreate MapCreate(AreaViewModel model) => new() { 
        Code = model.Code,
        Name = model.Name,
        Description = model.Description,
        SuperiorAreaId = model.SuperiorAreaId,
        IsActive = model.IsActive,
        CreateBy = model.CreatedBy
    };

    public static AreaUpdate MapUpdate(AreaViewModel model) => new()
    {
        AreaId = model.AreaId,
        Code = model.Code,
        Name = model.Name,
        Description = model.Description,
        SuperiorAreaId = model.SuperiorAreaId,
        IsActive = model.IsActive,
        UpdateBy = model.UpdatedBy,
        RowGuid = model.RowGuid
    };
}
