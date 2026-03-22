using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IPriorityTypeEntityRepostory
{
    Task<List<PriorityTypeResponse>> GetAllAsync();
    Task<PriorityTypeResponse?> GetByIdAsync(long id);
    Task<PriorityTypeResponse?> GetByRowGuidAsync(string rowGuid);
    Task<PriorityTypeResponse> AddAsync(PriorityTypeCreate priorityTypeEntity);
    Task<PriorityTypeResponse> UpdateAsync(PriorityTypeEntity priorityTypeEntity);
    Task<bool> ActiveInactiveAsync(long id);
    Task<bool> ActiveInactiveAsync(string rowGuid);
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteAsync(string rowGuid);
}