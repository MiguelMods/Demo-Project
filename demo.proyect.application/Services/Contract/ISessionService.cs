using demo.proyect.application.DTO_s;
using System.Security.Claims;

namespace demo.proyect.application.Services.Contract;

public interface ISessionService
{
    Task<Result<ClaimsPrincipal>> CreateSessionAsync(UserResponse userResponse);
}
