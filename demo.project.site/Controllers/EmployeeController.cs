using demo.proyect.application.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers;

public class EmployeeController(IEmployeeService employeeService) : Controller
{
    private readonly IEmployeeService employeeService = employeeService;

    public async Task<IActionResult> Index()
    {
        var result = await employeeService.GetAllAsync();
        return View(result.Data);
    }

    public IActionResult Register()
    {
        return View();
    }

    public Task<IActionResult> Details(int id)
    {
        throw new NotImplementedException();
    }
}
