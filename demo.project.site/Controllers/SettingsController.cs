using demo.proyect.application;
using demo.proyect.application.Repository;
using demo.proyect.application.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers
{
    [Area("Fill")]
    public class SettingsController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private List<SelectOptions> DefaultNotFound(string name) => [new(0, $"No se encontraron opciones para {name}")];

        [HttpGet("/fill/options/areas")]
        public async Task<IActionResult> Areas()
        {
            var areas = await unitOfWork.AreaEntityRepository.GetAllAsync();

            if (!areas.IsSuccess)
                return Json(DefaultNotFound("Areas").Failure());

            var data = areas.Data.Select(a => new SelectOptions(a.AreaId, a.Name)).ToList();

            return Json(data.Success());
        }

        [HttpGet("/fill/options/subareas")]
        public async Task<IActionResult> Subareas(long areaid)
        {
            var areas = await unitOfWork.AreaEntityRepository.GetAllSubAreasFromAreaId(areaid);

            if (!areas.IsSuccess)
                return Json(DefaultNotFound("SubArea").Failure());

            var data = areas.Data.Select(a => new SelectOptions(a.AreaId, a.Name)).ToList();

            return Json(data.Success());
        }

        [HttpGet("/fill/options/genders")]
        public async Task<IActionResult> Genders()
        {
            return Json(new List<SelectOptions>
            {
                new(1, "Masculino"),
                new(2, "Femenino"),
                new(3, "Otro")
            }.Success());
        }

        [HttpGet("/fill/options/positions")]
        public async Task<IActionResult> Positions([FromServices] IPositionService positionService)
        {
            var employees = await positionService.GetAllAsync();

            if (!employees.IsSuccess)
                return Json(DefaultNotFound("posicion").Failure());

            var data = employees.Data.Select(e => new SelectOptions(e.PositionId, e.Name)).ToList();

            return Json(data.Success());
        }

        [HttpGet("/fill/options/employees")]
        public async Task<IActionResult> Employees([FromServices] IEmployeeService employeeService)
        {
            var employees = await employeeService.GetAllAsync();

            if (!employees.IsSuccess)
                return Json(DefaultNotFound("Empleados").Failure());

            var data = employees.Data.Select(e => new SelectOptions(e.EmployeeId, e.CompleteName)).ToList();

            return Json(data.Success());
        }

        public record SelectOptions(long value, string text);
    }
}