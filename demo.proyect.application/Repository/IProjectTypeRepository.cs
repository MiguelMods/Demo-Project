using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.domain.Entities;

namespace demo.proyect.application.Repository;

public interface IProjectTypeRepository 
{
    Task<Result<List<ProjectTypeResponse>>> GetAllAsync();
    Task<Result<ProjectTypeResponse?>> GetByIdAsync(long id);
    Task<Result<ProjectTypeResponse?>> GetByRowGuidAsync(string rowGuid);
    Task<Result<ProjectTypeResponse>> AddAsync(ProjectTypeCreate projectTypeCreate);
    Task<Result<ProjectTypeResponse>> UpdateAsync(ProjectTypeEntity projectTypeEntity);
    Task<Result<bool>> ActiveInactiveAsync(long id);
    Task<Result<bool>> ActiveInactiveAsync(string rowGuid);
    Task<Result<bool>> DeleteAsync(long id);
    Task<Result<bool>> DeleteAsync(string rowGuid);
}
