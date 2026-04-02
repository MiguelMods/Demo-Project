using demo.proyect.application;
using demo.proyect.application.Repository;
using demo.proyect.domain.Entities;
using demo.proyect_persistance.Context;

namespace demo.proyect_persistance.Repository;

public class PeriodRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IPeriodRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;

    public Task<Result<List<PeriodEntity>>> GetAllAsync() 
        => Task.FromResult(Result<List<PeriodEntity>>.Success(demoProjectApplicationContext.PeriodEntities.ToList()));
}

public class PerspectiveRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IPerspectiveRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    public Task<Result<List<PerspectiveEntity>>> GetAllAsync() 
        => Task.FromResult(Result<List<PerspectiveEntity>>.Success(demoProjectApplicationContext.PerspectiveEntities.ToList()));
}

public class GoalTypeRepository(DemoProjectApplicationContext demoProjectApplicationContext) : IGoalTypeRepository
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    public Task<Result<List<GoalTypeEntity>>> GetAllAsync() 
        => Task.FromResult(Result<List<GoalTypeEntity>>.Success(demoProjectApplicationContext.GoalTypesEntities.ToList()));
}
