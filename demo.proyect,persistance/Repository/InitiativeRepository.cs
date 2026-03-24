using demo.proyect.application;
using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;

namespace demo.proyect_persistance.Repository;

public class InitiativeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IInitiativeRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;

    public async Task<Result<InitiativeResponse>> AddAsync(InitativeCreate initativeCreate)
    {
        try
        {
            var entity = MapCreate(initativeCreate);
            var entityResult = await demoProjectApplicationContext.InitiativeEntities.AddAsync(entity);
            var saveResult = await demoProjectApplicationContext.SaveChangesAsync();

            if (saveResult > 0)
                return Result<InitiativeResponse>.Success((InitiativeResponse)entityResult.Entity);

            return Result<InitiativeResponse>.Failure("");
        }
        catch (Exception ex)
        {
            return Result<InitiativeResponse>.Failure(ex.Message);
        }
    }

    public static InitiativeEntity MapCreate(InitativeCreate initativeCreate) => new()
    {
        Name = initativeCreate.Name,
        Description = initativeCreate.Description,
        IsReal = initativeCreate.IsReal,
        IsExecutable = initativeCreate.IsExecutable,
        GoalId = initativeCreate.GoalId,
        AreaId = initativeCreate.AreaId,
        CreatedBy = "me"
    };
}