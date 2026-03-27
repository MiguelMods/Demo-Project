using demo.project.site.Models.ViewModels;
using demo.proyect.application.Repository;
using demo.proyect.application.Services.Contract;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers
{
    [Authorize]
    [RequireAntiforgeryToken]
    public class ProjectController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var allProject = await unitOfWork.ProjectRepository.GetAllAsync();
            return View(allProject.Data);
        }

        public async Task<IActionResult> Register()
        {
            await Load();
            return View(new ProjectViewModel());
        }

        public async Task<IActionResult> Detail(string rowGuid)
        {
            var result = await unitOfWork.ProjectRepository.GetByRowGuidAsync(rowGuid);

            if (!result.IsSuccess)
                return RedirectToAction("index");

            await Load();
            return View((ProjectViewModel)result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProjectViewModel projectViewModel, [FromServices] IProjectInitativeService projectInitativeService)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("register", projectViewModel);

            if (projectViewModel.ProjectId > 0)
            {
                var model = ProjectViewModel.Map(projectViewModel, "updated-by-me", projectViewModel.RowGuid);
                var result = await unitOfWork.ProjectRepository.UpdateAsync(model);

                if (!result.IsSuccess)
                    ModelState.AddModelError("saveError", result.Message);

                await Load();

                return View("Detail", projectViewModel);
            }
            else
            {
                var model = ProjectViewModel.Map(projectViewModel, "create-by-me");
                var result = await projectInitativeService.CreateAsync(model);

                if (!result.IsSuccess)
                    ModelState.AddModelError("saveError", result.Message);

                return RedirectToAction("register");
            }
        }

        private async Task Load()
        {
            var area = await unitOfWork.AreaEntityRepository.GetAllAsync();
            var priority = await unitOfWork.PriorityTypeEntityRepostory.GetAllAsync();
            var projectType = await unitOfWork.ProjectTypeRepository.GetAllAsync();
            var projectDevelopmentType = await unitOfWork.ProjectDevelopmentTypeRepository.GetAllAsync();

            var areaSelectOption = area.Data.Select(x => new SelectOption(x.AreaId, x.Name)).ToList();
            ViewBag.Area = areaSelectOption;
            ViewBag.SubArea = areaSelectOption;
            ViewBag.Priority = priority.Data.Select(x => new SelectOption(x.PriorityTypeId, x.Name)).ToList();
            ViewBag.ProjectType = projectType.Data.Select(x => new SelectOption(x.ProjectTypeId, x.Name)).ToList();
            ViewBag.ProjectDevelopmentType = projectDevelopmentType.Data.Select(x => new SelectOption(x.ProjectDevelopmentTypeId, x.Name)).ToList();
        }
    }
}
