using demo.project.site.Models.ViewModels;
using demo.proyect.application.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class GoalController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("")]
        public async Task<IActionResult> Assign(string rowguid)
        {
            var project = await unitOfWork.ProjectRepository.GetByRowGuidAsync(rowguid);
            await Load();
            return View(new ProjectGoalViewModel()
            {
                Project = new ProjectViewModel()
                {
                    ProjectId = project.Data.ProjectId,
                    Name = project.Data.Name,
                    CodeOne = project.Data.CodeOne,
                    RowGuid = project.Data.RowGuid
                }
            });
        }


        [HttpPost("")]
        public async Task<IActionResult> Post(ProjectGoalViewModel projectGoalViewModel) 
        {
            return View("Assign", projectGoalViewModel);
        }

        private async Task Load()
        {
            var area = await unitOfWork.AreaEntityRepository.GetAllAsync();

            if (area.IsSuccess)
                ViewBag.Area = area.Data.Select(x => new SelectOption(x.AreaId, x.Name)).ToList();

            var period = await unitOfWork.PeriodRepository.GetAllAsync();
            
            if (period.IsSuccess)
                ViewBag.Period = period.Data.Select(x => new SelectOption(x.PeriodId, x.Name)).ToList();

            var perspective = await unitOfWork.PerspectiveRepository.GetAllAsync();

            if (perspective.IsSuccess)
                ViewBag.Perspective = perspective.Data.Select(x => new SelectOption(x.PerspectiveId, x.Name)).ToList();

            var goalType = await unitOfWork.GoalTypeRepository.GetAllAsync();

            if (goalType.IsSuccess)
                ViewBag.GoalType = goalType.Data.Select(x => new SelectOption(x.GoalTypeId, x.Name)).ToList();
        }
    }
}
