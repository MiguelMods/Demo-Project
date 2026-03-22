using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IProjectDevelopmentTypeRepository
{
    Task<List<ProjectDevelopmentTypeResponse>> GetAllAsync();
    Task<ProjectDevelopmentTypeResponse?> GetByIdAsync(long id);
    Task<ProjectDevelopmentTypeResponse?> GetByRowGuidAsync(string rowGuid);
    Task<ProjectDevelopmentTypeResponse> AddAsync(ProjectDevelopmentTypeCreate projectDevelopmentTypeCreate);
    Task<ProjectDevelopmentTypeResponse> UpdateAsync(ProjectDevelopmentTypeEntity projectDevelopmentTypeEntity);
    Task<bool> ActiveInactiveAsync(long id);
    Task<bool> ActiveInactiveAsync(string rowGuid);
    Task<bool> DeleteAsync(long id);
    Task<bool> DeleteAsync(string rowGuid);
}