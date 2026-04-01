using demo.project.site.Extensions;
using demo.project.site.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo.project.site.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Toasts
            TempData.ToastSuccess("Bienvenido al sistema", "Bienvenido");
            //TempData.ToastError("Ocurrió un error al guardar.", "Error inesperado");
            //TempData.ToastWarning("El proyecto ya existe en el sistema.");

            // Banners (más prominentes, para avisos de página)
            TempData.BannerInfo($"Hola, {HttpContext.User.Identity.Name}");
            //TempData.BannerError("No tienes permisos para modificar este registro.");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
