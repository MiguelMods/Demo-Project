using demo.proyect.application.DTO_s;

namespace demo.proyect.application.Services.Contract;

public interface IPositionService
{
    Task<Result<List<PositionResponse>>> GetAllAsync();
}
