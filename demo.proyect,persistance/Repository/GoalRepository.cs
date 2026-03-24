using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;

namespace demo.proyect_persistance.Repository;

public class GoalRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IGoalRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;

    public async Task<Result<GoalResponse>> AddAsync(GoalCreate goalCreate)
    {
        try
        {
            var entity = MapCreate(goalCreate);
            var entityResult = await demoProjectApplicationContext.GoalEntities.AddAsync(entity);
            var saveResult = await demoProjectApplicationContext.SaveChangesAsync();

            if (saveResult > 0)
                return Result<GoalResponse>.Success((GoalResponse)entityResult.Entity);

            return Result<GoalResponse>.Failure("Entidad no registrada");
        }
        catch (Exception ex)
        {
            return Result<GoalResponse>.Failure(ex.Message);
        }
    }

    private static GoalEntity MapCreate(GoalCreate goalCreate) => new()
    {
        Code = goalCreate.Code,
        Name = goalCreate.Name,
        Description = goalCreate.Description,
        Formula = goalCreate.Formula,
        IsReal = goalCreate.IsReal,
        AreaId = goalCreate.AreaId,
        PeriodId = goalCreate.PeriodId,
        PerspectiveId = goalCreate.PerspectiveId,
        GoalTypeId = goalCreate.GoalTypeId,
        ProjectId = goalCreate.ProjectId,
        CreatedBy = goalCreate.CreatedBy
    };
}
