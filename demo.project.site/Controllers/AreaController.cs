using demo.project.site.Models.ViewModels;
using demo.proyect.application.Repository;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace demo.project.site.Controllers;

[RequireAntiforgeryToken]
public class AreaController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<IActionResult> Index()
    {
        var areas = await unitOfWork.AreaEntityRepository.GetAllAsync();
        return View(areas.Data);
    }

    public async Task<IActionResult> Register()
    {
        await Load();
        return View(new AreaViewModel());
    }

    public async Task<IActionResult> Detail(string rowguid)
    {
        var area = await unitOfWork.AreaEntityRepository.GetByRowGuidAsync(rowguid);

        if (!area.IsSuccess)
            return await Index();

        await Load();
        return View((AreaViewModel)area.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Save(AreaViewModel areaViewModel) 
    {
        if(!ModelState.IsValid)
            return View("register", areaViewModel);

        if(areaViewModel.AreaId > 0) 
        {
            areaViewModel.UpdatedBy = "me";
            var result = await unitOfWork.AreaEntityRepository.UpdateAsync(AreaViewModel.MapUpdate(areaViewModel));

            await Load();
            if (result.IsSuccess)
                return View("detail", (AreaViewModel)result.Data);
        }
        else 
        {
            areaViewModel.CreatedBy = "me";
            var result = await unitOfWork.AreaEntityRepository.AddAsync(AreaViewModel.MapCreate(areaViewModel));
            await Load();
            if (result.IsSuccess)
                return View("detail", (AreaViewModel)result.Data);
        }

        return await Index();
    }

    public async Task Load() 
    {
        var listOfAreas = await unitOfWork.AreaEntityRepository.GetAllAsync();
        
        if(listOfAreas.IsSuccess)
            ViewBag.listOfAreas = listOfAreas.Data.Select(x => new SelectOption(x.AreaId, x.Name)).ToList();
    }
}
