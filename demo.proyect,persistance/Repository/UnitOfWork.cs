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
}
