namespace demo.proyect.application.Repository;

public interface IUnitOfWork
{
    IPriorityTypeEntityRepostory PriorityTypeEntityRepostory { get; }
    IAreaEntityRepository AreaEntityRepository { get; }
    IProjectDevelopmentTypeRepository ProjectDevelopmentTypeRepository { get; }
    IProjectTypeRepository ProjectTypeRepository { get; }
    IProjectRepository ProjectRepository { get; }
    IGoalRepository GoalRepository { get; }
    IInitiativeRepository InitiativeRepository { get; }
    IUserRepository UserRepository { get; }
}
