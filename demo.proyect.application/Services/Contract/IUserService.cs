using demo.proyect.application.DTO_s;
using System.Security.Claims;

namespace demo.proyect.application.Services.Contract;

public interface IUserService
{
    Task<Result<ClaimsPrincipal>> SiginAsync(string username, string password);
}
