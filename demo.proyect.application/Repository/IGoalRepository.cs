using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;

namespace demo.proyect.application.Repository;

public interface IGoalRepository 
{
    Task<Result<List<GoalResponse>>> GetAllAsync();
    Task<Result<List<GoalResponse>>> GetAllIncludeAsync();
    Task<Result<GoalResponse>> GetByRowGuid(string rowguid);
    Task<Result<GoalResponse>> AddAsync(GoalCreate goalCreate);
}
