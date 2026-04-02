using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IGetListOnlyRepository<Tentity> where Tentity : BaseEntity
{
    public Task<Result<List<Tentity>>> GetAllAsync();
}

public interface IPeriodRepository : IGetListOnlyRepository<PeriodEntity> 
{
    
}

public interface IPerspectiveRepository : IGetListOnlyRepository<PerspectiveEntity>
{
    
}

public interface IGoalTypeRepository : IGetListOnlyRepository<GoalTypeEntity>
{
    
}