using demo.project.site.Models.ViewModels;
using demo.proyect.application.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class InitiativeController(IUnitOfWork unitOfWork) : Controller
    {
        public IUnitOfWork UnitOfWork { get; } = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var response = await UnitOfWork.InitiativeRepository.GetAllIncludeAsyn();
            return View(response.Data);
        }

        public IActionResult Register() => View(new GoalInitativeViewModel { });

        public async Task<IActionResult> Detail(string rowguid = "")
        {
            if (string.IsNullOrEmpty(rowguid))
            {
                TempData["Error"] = "No se puede abrir la Iniciativa seleccionada";
                return RedirectToAction(nameof(Index));
            }
            var response = await UnitOfWork.InitiativeRepository.GetByRowGuidAsync();
            if (!response.IsSuccess)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
