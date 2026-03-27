using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IPriorityTypeEntityRepostory
{
    Task<Result<List<PriorityTypeResponse>>> GetAllAsync();
    Task<Result<PriorityTypeResponse?>> GetByIdAsync(long id);
    Task<Result<PriorityTypeResponse?>> GetByRowGuidAsync(string rowGuid);
    Task<Result<PriorityTypeResponse>> AddAsync(PriorityTypeCreate priorityTypeEntity);
    Task<Result<PriorityTypeResponse>> UpdateAsync(PriorityTypeEntity priorityTypeEntity);
    Task<Result<bool>> ActiveInactiveAsync(long id);
    Task<Result<bool>> ActiveInactiveAsync(string rowGuid);
    Task<Result<bool>> DeleteAsync(long id);
    Task<Result<bool>> DeleteAsync(string rowGuid);
}