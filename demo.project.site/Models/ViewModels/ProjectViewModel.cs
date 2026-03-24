using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;
using demo.proyect.common.Helpers.Validations;
using System.ComponentModel.DataAnnotations;

namespace demo.project.site.Models.ViewModels;

public class ProjectViewModel
{
    [Display(Name = "Numero de Proyecto")]
    public long ProjectId { get; set; }
    
    [Display(Name = "Codigo")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public string CodeOne { get; set; }
    
    [Display(Name = "Numero de TTK:")]
    public string CodeTwo { get; set; }
    
    [Display(Name = "Nombre")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public string Name { get; set; }
    
    [Display(Name = "Objetivo")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public string? Objetive { get; set; }
    
    [Display(Name = "Alcance")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public string? Scope { get; set; }
    
    [Display(Name = "Descripcion")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public string? Description { get; set; }
    
    [Display(Name = "Area Solicitante Principal")]
    public string? Area { get; set; }

    [Required(ErrorMessage = Messages.IsRequired)]
    public long AreaId { get; set; }

    [Display(Name = "Sub-area Solicitante Principal")]
    public string? SubArea { get; set; }

    [Required(ErrorMessage = Messages.IsRequired)]
    public long? SubAreaId { get; set; }

    [Display(Name = "Proyecto pertenece al POA/ROADMAP")]
    public bool PoaRoadMap { get; set; }

    [Display(Name = "Fecha Propuesta Entrada a Produccion")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public DateTime? WishDate { get; set; }

    [Display(Name = "Marcar este Proyecto Como Critico")]
    public bool IsCritical { get; set; }

    [Display(Name = "Marcar para usar el Flujo Normal")]
    public bool UseNormalFlow { get; set; }

    [Display(Name = "Tipo de Prioridad")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public long PriorityTypeId { get; set; }

    [Display(Name = "Tipo de Proyecto")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public long ProjectTypeId { get; set; }

    [Display(Name = "Tipo de Desarrollo")]
    [Required(ErrorMessage = Messages.IsRequired)]
    public long ProjectDevelopmentTypeId { get; set; }

    public string? RowGuid { get; set; }

    public static explicit operator ProjectViewModel(ProjectResponse response)
        => new() { 
            ProjectId = response.ProjectId,
            CodeOne = response.CodeOne,
            CodeTwo = response.CodeTwo,
            Name = response.Name,
            Objetive = response.Objetive,
            Scope = response.Scope,
            Description = response.Description,
            WishDate = response.WishDate,
            IsCritical = response.IsCritical,
            UseNormalFlow = response.UseNormalFlow,
            PriorityTypeId = response.PriorityTypeId,
            ProjectTypeId = response.ProjectTypeId,
            ProjectDevelopmentTypeId = response.ProjectDevelopmentTypeId,
            PoaRoadMap = response.PoaRoadmap,
            AreaId = response.AreaId,
            SubAreaId = response.SubAreaId,
            RowGuid = response.RowGuid,
        };
    public static ProjectCreate Map(ProjectViewModel model, string createdBy = "") => new() 
    {
        CodeOne = model.CodeOne,
        CodeTwo = model.CodeTwo,
        Name = model.Name,
        Objetive = model.Objetive,
        Scope = model.Scope,
        Description= model.Description,
        AreaId = model.AreaId,
        SubAreaId = model.SubAreaId ?? 0,
        PoaRoadMap = model.PoaRoadMap,
        WishDate = model.WishDate,
        IsCritical = model.IsCritical,
        UseNormalFlow = model.UseNormalFlow,
        PriorityTypeId = model.PriorityTypeId,
        ProjectTypeId = model.ProjectTypeId,
        ProjectDevelopmentTypeId = model.ProjectDevelopmentTypeId,
        CreateBy = createdBy
    };
    public static ProjectUpdate Map(ProjectViewModel model, string updateBy = "", string rowGuid = "") => new()
    {
        ProjectId = model.ProjectId,
        CodeOne = model.CodeOne,
        CodeTwo = model.CodeTwo,
        Name = model.Name,
        Objetive = model.Objetive,
        Scope = model.Scope,
        Description = model.Description,
        AreaId = model.AreaId,
        SubAreaId = model.SubAreaId ?? 0,
        PoaRoadMap = model.PoaRoadMap,
        WishDate = model.WishDate,
        IsCritical = model.IsCritical,
        UseNormalFlow = model.UseNormalFlow,
        PriorityTypeId = model.PriorityTypeId,
        ProjectTypeId = model.ProjectTypeId,
        ProjectDevelopmentTypeId = model.ProjectDevelopmentTypeId,
        UpdateBy = updateBy,
        RowGuid = rowGuid
    };
}
