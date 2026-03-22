using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IProjectTypeRepository 
{
    Task<List<ProjectTypeResponse>> GetAllAsync();
    Task<ProjectTypeResponse?> GetByIdAsync(long id);
    Task<ProjectTypeResponse?> GetByRowGuidAsync(string rowGuid);
    Task<ProjectTypeResponse> AddAsync(ProjectTypeCreate projectTypeCreate);
    Task<ProjectTypeResponse> UpdateAsync(ProjectTypeEntity projectTypeEntity);
    Task<bool> ActiveInactiveAsync(long id);
    Task<bool> ActiveInactiveAsync(string rowGuid);
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteAsync(string rowGuid);
}
