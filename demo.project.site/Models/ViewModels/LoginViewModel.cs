using System.ComponentModel.DataAnnotations;

namespace demo.project.site.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "Este Campo *Nombre de Usuario* es Requirido*")]
        public string UserName { get; set; }
        
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este Campo *Contraseña* es Requirido*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}
