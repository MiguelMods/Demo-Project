using demo.proyect.application.Create;
using demo.proyect.application.Repository;
using demo.proyect.application.Services.Contract;
using demo.proyect.common.Helpers.Results;

namespace demo.proyect.application.Services.Implementation;

public class ProjectInitativeService(IUnitOfWork unitOfWork) : IProjectInitativeService
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<Result<bool>> CreateAsync(ProjectCreate projectCreate)
    {
        var projectResult = await unitOfWork.ProjectRepository.AddAsync(projectCreate);

        if (!projectResult.IsSuccess)
            return Result<bool>.Failure("");

        var goalResult = await unitOfWork.GoalRepository.AddAsync(new() 
        {
            Code = projectCreate.CodeOne,
            Name = projectCreate.Name,
            Description = projectCreate.Description,
            Formula = "N/A",
            IsReal = true,
            AreaId = projectCreate.AreaId,
            PeriodId = 1,
            PerspectiveId = 1,
            GoalTypeId = 1,
            ProjectId = projectResult.Data.ProjectId,
            CreatedBy = "me"
        });

        if(!goalResult.IsSuccess)
            return Result<bool>.Failure("");

        var initiativeResult = await unitOfWork.InitiativeRepository.AddAsync(new ()
        { 
            Name = projectCreate.Name,
            Description = projectCreate.Description,
            IsReal= true,
            IsExecutable = true,
            GoalId = goalResult.Data.GoalId,
            AreaId = goalResult.Data.AreaId,
            CreateBy = "me"
        });

        if(!initiativeResult.IsSuccess)
            return Result<bool>.Failure("");

        return Result<bool>.Success(Messages.SuccessEntityCreation("Proyecto"));
    }
}
