using demo.proyect.application.Create;
using demo.proyect.application.DTO_s;
using demo.proyect.application.Update;

namespace demo.proyect.application.Repository;

public interface IProjectRepository
{
    Task<Result<List<ProjectResponse>>> GetAllAsync();
    Task<Result<ProjectResponse>> GetByRowGuidAsync(string rowGuid);
    Task<Result<ProjectResponse>> GetByIdAsync(long longId);
    Task<Result<ProjectResponse>> AddAsync(ProjectCreate projectCreate);
    Task<Result<ProjectResponse>> UpdateAsync(ProjectUpdate projectUpdate);
}