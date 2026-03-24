using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;

namespace demo.proyect.application.Repository;

public interface IGoalRepository 
{
    Task<Result<GoalResponse>> AddAsync(GoalCreate goalCreate);
}
