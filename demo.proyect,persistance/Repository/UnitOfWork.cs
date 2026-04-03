using demo.proyect.application.Repository;
using demo.proyect_persistance.Context;

namespace demo.proyect_persistance.Repository;

public class UnitOfWork(DemoProjectApplicationContext demoProjectApplicationContext) : IUnitOfWork
{
    private readonly DemoProjectApplicationContext demoProjectApplicationContext = demoProjectApplicationContext;
    public IPriorityTypeEntityRepostory PriorityTypeEntityRepostory => new PriorityTypeEntityRepostory(demoProjectApplicationContext);
    public IAreaEntityRepository AreaEntityRepository => new AreaEntityRepository(demoProjectApplicationContext);
    public IProjectDevelopmentTypeRepository ProjectDevelopmentTypeRepository => new ProjectDevelopmentTypeRepository(demoProjectApplicationContext);
    public IProjectTypeRepository ProjectTypeRepository => new ProjectTypeRepository(demoProjectApplicationContext);
    public IProjectRepository ProjectRepository => new ProjectRepository(demoProjectApplicationContext);
    public IGoalRepository GoalRepository => new GoalRepository(demoProjectApplicationContext);
    public IInitiativeRepository InitiativeRepository => new InitiativeRepository(demoProjectApplicationContext);
    public IUserRepository UserRepository => new UserRepository(demoProjectApplicationContext);
    public IPeriodRepository PeriodRepository => new PeriodRepository(demoProjectApplicationContext);
    public IPerspectiveRepository PerspectiveRepository => new PerspectiveRepository(demoProjectApplicationContext);
    public IGoalTypeRepository GoalTypeRepository => new GoalTypeRepository(demoProjectApplicationContext);
    public IEmployeeRepository EmployeeRepository => new EmployeeRepository(demoProjectApplicationContext);
    public IPositionEntityRepository PositionRepository => new PositionEntityRepository(demoProjectApplicationContext);
    public async Task<int> SaveChangesAsync()
    {
        demoProjectApplicationContext.ChangeTracker.DetectChanges();
        return await demoProjectApplicationContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            demoProjectApplicationContext.Dispose();
        }
    }
}
