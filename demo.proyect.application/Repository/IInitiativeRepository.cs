using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;

namespace demo.proyect.application.Repository;

public interface IInitiativeRepository 
{
    Task<Result<List<InitiativeResponse>>> GetAllAsyn();
    Task<Result<List<InitiativeResponse>>> GetAllIncludeAsyn();
    Task<Result<InitiativeResponse>> GetByRowGuidAsync();
    Task<Result<InitiativeResponse>> AddAsync(InitativeCreate initativeCreate);
}