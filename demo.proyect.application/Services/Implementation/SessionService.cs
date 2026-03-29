using demo.proyect.application.DTO_s;
using demo.proyect.application.Services.Contract;
using System.Security.Claims;

namespace demo.proyect.application.Services.Implementation;

public class SessionService() : ISessionService
{
    public async Task<Result<ClaimsPrincipal>> CreateSessionAsync(UserResponse userResponse)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.SerialNumber, userResponse.RowGuid),
            new(ClaimTypes.Name, userResponse.UserName),
            new(ClaimTypes.Role, "default")
        };
        
        var claimsIdentity = new ClaimsIdentity(claims, "cookie");
        var principal = new ClaimsPrincipal(claimsIdentity);

        return principal.Success();
    }
}
