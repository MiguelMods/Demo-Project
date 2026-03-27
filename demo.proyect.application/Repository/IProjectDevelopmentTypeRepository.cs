using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IProjectDevelopmentTypeRepository
{
    Task<Result<List<ProjectDevelopmentTypeResponse>>> GetAllAsync();
    Task<Result<ProjectDevelopmentTypeResponse?>> GetByIdAsync(long id);
    Task<Result<ProjectDevelopmentTypeResponse?>> GetByRowGuidAsync(string rowGuid);
    Task<Result<ProjectDevelopmentTypeResponse>> AddAsync(ProjectDevelopmentTypeCreate projectDevelopmentTypeCreate);
    Task<Result<ProjectDevelopmentTypeResponse>> UpdateAsync(ProjectDevelopmentTypeEntity projectDevelopmentTypeEntity);
    Task<Result<bool>> ActiveInactiveAsync(long id);
    Task<Result<bool>> ActiveInactiveAsync(string rowGuid);
    Task<Result<bool>> DeleteAsync(long id);
    Task<Result<bool>> DeleteAsync(string rowGuid);
}