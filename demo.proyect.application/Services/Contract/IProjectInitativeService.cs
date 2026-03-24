using demo.proyect.application.Create;

namespace demo.proyect.application.Services.Contract;

public interface IProjectInitativeService
{
    Task<Result<bool>> CreateAsync(ProjectCreate projectCreate); 
}
